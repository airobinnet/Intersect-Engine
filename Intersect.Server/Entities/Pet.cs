using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.Logging;
using Intersect.Network.Packets.Server;
using Intersect.Server.Database;
using Intersect.Server.Database.PlayerData.Players;
using Intersect.Server.Entities.Combat;
using Intersect.Server.Entities.Events;
using Intersect.Server.Entities.Pathfinding;
using Intersect.Server.General;
using Intersect.Server.Maps;
using Intersect.Server.Networking;
using Intersect.Utilities;

using JetBrains.Annotations;

namespace Intersect.Server.Entities
{

    public class Pet : Entity
    {
        public bool Despawnable;

        public Entity Owner;

        public long FindTargetWaitTime;

        //Moving
        public long LastRandomMove;

        //Pathfinding
        private Pathfinder mPathFinder;

        private Task mPathfindingTask;
        
        public int FindTargetDelay = 500;

        public byte Range;

        public Pet([NotNull] PetBase myBase, Entity owner, bool despawnable = false) : base()
        {
            Name = myBase.Name;
            Sprite = myBase.Sprite;
            Level = myBase.Level;
            Base = myBase;
            Despawnable = despawnable;
            Owner = owner;

            Range = (byte)myBase.SightRange;
            mPathFinder = new Pathfinder(this);
        }

        [NotNull]
        public PetBase Base { get; private set; }

        public override EntityTypes GetEntityType()
        {
            return EntityTypes.Pet;
        }

        public override void Die(int dropitems = 100, Entity killer = null)
        {
            MapInstance.Get(MapId).RemoveEntity(this);
            PacketSender.SendEntityDie(this);
            PacketSender.SendEntityLeave(this);
        }

        public void RemoveTarget()
        {
            Target = null;
        }

        public void AssignTarget(Entity en)
        {
            Target = Owner;
        }

        public override void Update(long timeMs)
        {
            var curMapLink = MapId;
            base.Update(timeMs);

            if (MoveTimer < Globals.Timing.TimeMs)
            {
                var targetMap = Guid.Empty;
                var targetX = 0;
                var targetY = 0;
                var targetZ = 0;

                //Check if there is a target, if so, run their ass down.
                if (Target != null)
                {
                    if (!Target.IsDead())
                    {
                        targetMap = Target.MapId;
                        targetX = Target.X;
                        targetY = Target.Y;
                        targetZ = Target.Z;
                        var targetStatuses = Target.Statuses.Values.ToArray();
                        foreach (var targetStatus in targetStatuses)
                        {
                            if (targetStatus.Type == StatusTypes.Stealth)
                            {
                                targetMap = Guid.Empty;
                                targetX = 0;
                                targetY = 0;
                                targetZ = 0;
                            }
                        }
                    }
                    else
                    {
                        RemoveTarget();
                    }
                }
                else //Find a target if able
                {
                    TryFindNewTarget(timeMs);
                }

                if (targetMap != Guid.Empty)
                {
                    //Check if target map is on one of the surrounding maps, if not then we are not even going to look.
                    if (targetMap != MapId)
                    {
                        if (MapInstance.Get(MapId).SurroundingMaps.Count > 0)
                        {
                            for (var x = 0; x < MapInstance.Get(MapId).SurroundingMaps.Count; x++)
                            {
                                if (MapInstance.Get(MapId).SurroundingMaps[x] == targetMap)
                                {
                                    break;
                                }

                                if (x == MapInstance.Get(MapId).SurroundingMaps.Count - 1)
                                {
                                    targetMap = Guid.Empty;
                                }
                            }
                        }
                        else
                        {
                            targetMap = Guid.Empty;
                        }
                    }
                }

                if (targetMap != Guid.Empty)
                {
                    if (mPathFinder.GetTarget() != null)
                    {
                        if (targetMap != mPathFinder.GetTarget().TargetMapId ||
                            targetX != mPathFinder.GetTarget().TargetX ||
                            targetY != mPathFinder.GetTarget().TargetY)
                        {
                            mPathFinder.SetTarget(null);
                        }
                    }

                    if (mPathFinder.GetTarget() == null)
                    {
                        mPathFinder.SetTarget(new PathfinderTarget(targetMap, targetX, targetY, targetZ));
                    }

                    if (mPathFinder.GetTarget() != null)
                    {
                        if (!IsOneBlockAway(
                            mPathFinder.GetTarget().TargetMapId, mPathFinder.GetTarget().TargetX,
                            mPathFinder.GetTarget().TargetY, mPathFinder.GetTarget().TargetZ
                        ))
                        {
                            switch (mPathFinder.Update(timeMs))
                            {
                                case PathfinderResult.Success:
                                    var dir = mPathFinder.GetMove();
                                    if (dir > -1)
                                    {

                                        if (CanMove(dir) == -1 || CanMove(dir) == -4)
                                        {

                                            Move((byte)dir, null);
                                        }
                                        else
                                        {
                                            mPathFinder.PathFailed(timeMs);
                                        }

                                    }
                                    // Npc move when here

                                    break;
                                case PathfinderResult.OutOfRange:
                                    RemoveTarget();
                                    targetMap = Guid.Empty;

                                    break;
                                case PathfinderResult.NoPathToTarget:
                                    TryFindNewTarget(timeMs, Target?.Id ?? Guid.Empty);
                                    targetMap = Guid.Empty;

                                    break;
                                case PathfinderResult.Failure:
                                    targetMap = Guid.Empty;
                                    RemoveTarget();

                                    break;
                                case PathfinderResult.Wait:
                                    targetMap = Guid.Empty;

                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            if (Dir != DirToEnemy(Target) && DirToEnemy(Target) != -1)
                            {
                                ChangeDir(DirToEnemy(Target));
                            }
                            else
                            {
                                if (Target.IsDisposed)
                                {
                                    Target = null;
                                }
                            }
                        }
                    }
                }
                
            }
            LastRandomMove = Globals.Timing.TimeMs + (long) GetMovementTime();


            //If we switched maps, lets update the maps
            if (curMapLink != MapId)
            {
                if (curMapLink == Guid.Empty)
                {
                    MapInstance.Get(curMapLink).RemoveEntity(this);
                }

                if (MapId != Guid.Empty)
                {
                    MapInstance.Get(MapId).AddEntity(this);
                }
            }
            base.Update(timeMs);
            // End of the Npc Movement
        }

        private void TryFindNewTarget(long timeMs, Guid avoidId = new Guid())
        {
            if (FindTargetWaitTime > timeMs)
            {
                return;
            }

            var maps = MapInstance.Get(MapId).GetSurroundingMaps(true);
            var possibleTargets = new List<Entity>();
            var closestRange = Range + 1; //If the range is out of range we didn't find anything.
            var closestIndex = -1;
            foreach (var map in maps)
            {
                foreach (var en in map.GetEntitiesDictionary())
                {
                    var entity = en.Value;
                    if (entity != null && entity.IsDead() == false && entity == Owner)
                    {
                        //TODO Check if NPC is allowed to attack player with new conditions
                        if (entity.GetType() == typeof(Player))
                        {
                                var dist = GetDistanceTo(entity);
                                if (dist <= Range && dist < closestRange)
                                {
                                    possibleTargets.Add(entity);
                                    closestIndex = possibleTargets.Count - 1;
                                    closestRange = dist;
                                }
                        }
                    }
                }
            }

            if (closestIndex != -1)
            {
                AssignTarget(possibleTargets[closestIndex]);
            }

            FindTargetWaitTime = timeMs + FindTargetDelay;
        }

        public override EntityPacket EntityPacket(EntityPacket packet = null, Player forPlayer = null)
        {
            if (packet == null)
            {
                packet = new PetEntityPacket();
            }

            packet = base.EntityPacket(packet, forPlayer);

            var pkt = (PetEntityPacket)packet;

            return pkt;
        }
    }

}
