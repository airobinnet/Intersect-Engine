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
            Passable = true;

            Range = (byte)myBase.SightRange;
            mPathFinder = new Pathfinder(this);

            for (var i = 0; i < (int)Stats.StatCount; i++)
            {
                BaseStats[i] = myBase.Stats[i];
                Stat[i] = new Stat((Stats)i, this);
            }
            Stat[(int)Stats.MovementSpeed].BaseStat = owner.Stat[(int)Stats.MovementSpeed].Value();
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
            PacketSender.SendPetAggressionToProximity(this);
        }

        public void AssignTarget(Entity en)
        {
            Target = Owner;
            PacketSender.SendPetAggressionToProximity(this);
        }

        public override int CalculateAttackTime()
        {
            return 1;
        }


        public override void Update(long timeMs)
        {
            var curMapLink = MapId;
            base.Update(timeMs);
            var fleeing = false;
            
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
                                        if (fleeing)
                                        {
                                            switch (dir)
                                            {
                                                case 0:
                                                    dir = 1;

                                                    break;
                                                case 1:
                                                    dir = 0;

                                                    break;
                                                case 2:
                                                    dir = 3;

                                                    break;
                                                case 3:
                                                    dir = 2;

                                                    break;
                                                case 4:
                                                    dir = 5;

                                                    break;
                                                case 5:
                                                    dir = 4;

                                                    break;
                                                case 6:
                                                    dir = 7;

                                                    break;
                                                case 7:
                                                    dir = 6;

                                                    break;
                                            }
                                        }

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
                        }
                        else
                        {
                            var fleed = false;
                            if (fleeing)
                            {
                                var dir = DirToEnemy(Target);
                                switch (dir)
                                {
                                    case 0:
                                        dir = 1;

                                        break;
                                    case 1:
                                        dir = 0;

                                        break;
                                    case 2:
                                        dir = 3;

                                        break;
                                    case 3:
                                        dir = 2;

                                        break;
                                    case 4:
                                        dir = 5;

                                        break;
                                    case 5:
                                        dir = 4;

                                        break;
                                    case 6:
                                        dir = 7;

                                        break;
                                    case 7:
                                        dir = 6;

                                        break;
                                }

                                if (CanMove(dir) == -1 || CanMove(dir) == -4)
                                {
                                    Move(dir, null);
                                    fleed = true;
                                }
                            }

                            if (!fleed)
                            {
                                if (Target != null && Dir != DirToEnemy(Target) && DirToEnemy(Target) != -1)
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
                //Move randomly
                if (targetMap != Guid.Empty)
                {
                    return;
                }

                if (LastRandomMove >= Globals.Timing.TimeMs || CastTime > 0)
                {
                    return;
                }

                var i = Randomization.Next(0, 1);
                if (i == 0)
                {
                    i = Randomization.Next(0, 8);
                    if (CanMove(i) == -1)
                    {
                        Move((byte)i, null);

                    }
                }

                LastRandomMove = Globals.Timing.TimeMs + Randomization.Next(1000, 3000);
                
                if (fleeing)
                {
                    LastRandomMove = Globals.Timing.TimeMs + (long) GetMovementTime();
                }
            }
            

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
            // End of the Pet Movement
            //PacketSender.SendEntityDataToProximity(this);
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
            //tp to player if too far away
            X = Owner.X;
            Y = Owner.Y;
            Dir = Owner.Dir;
            MapId = Owner.MapId;
            PacketSender.SendEntityDataToProximity(this);
        }

        public override void Warp(
            Guid newMapId,
            byte newX,
            byte newY,
            byte newDir,
            bool adminWarp = false,
            byte zOverride = 0,
            bool mapSave = false
        )
        {
            var map = MapInstance.Get(newMapId);
            if (map == null)
            {
                return;
            }

            X = newX;
            Y = newY;
            Z = zOverride;
            Dir = newDir;
            if (newMapId != MapId)
            {
                var oldMap = MapInstance.Get(MapId);
                if (oldMap != null)
                {
                    oldMap.RemoveEntity(this);
                }

                PacketSender.SendEntityLeave(this);
                MapId = newMapId;
                PacketSender.SendEntityDataToProximity(this);
                PacketSender.SendEntityPositionToAll(this);
            }
            else
            {
                PacketSender.SendEntityPositionToAll(this);
                PacketSender.SendEntityVitals(this);
                PacketSender.SendEntityStats(this);
            }
        }

        public int GetAggression(Player player)
        {
            return 1;
        }

        public override EntityPacket EntityPacket(EntityPacket packet = null, Player forPlayer = null)
        {
            if (packet == null)
            {
                packet = new PetEntityPacket();
            }

            packet = base.EntityPacket(packet, forPlayer);

            var pkt = (PetEntityPacket)packet;
            pkt.Aggression = GetAggression(forPlayer);
            pkt.Passable = true;
            pkt.Stats[(int)Stats.MovementSpeed] = forPlayer.Stat[(int)Stats.MovementSpeed].Value();

            return pkt;
        }
    }

}
