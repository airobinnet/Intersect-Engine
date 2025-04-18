﻿using System;
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

    public class Npc : Entity
    {

        //Spell casting
        public long CastFreq;

        /// <summary>
        /// Damage Map - Keep track of who is doing the most damage to this npc and focus accordingly
        /// </summary>
        public ConcurrentDictionary<Entity, long> DamageMap = new ConcurrentDictionary<Entity, long>();

        /// <summary>
        /// Returns the entity that ranks the highest on this NPC's damage map.
        /// </summary>
        public Entity DamageMapHighest { 
            get {
                long damage = 0;
                Entity top = null;
                foreach (var pair in DamageMap)
                {
                    if (pair.Value > damage)
                    {
                        top = pair.Key;
                        damage = pair.Value;
                    }
                }
                return top;
            } 
        }

        public bool Despawnable;

        //Moving
        public long LastRandomMove;

        //Pathfinding
        private Pathfinder mPathFinder;

        private Task mPathfindingTask;

        public byte Range;
        
        //BossBehavior
        public int KeepDistance = 1;

        public int SpellCounter;

        public int keepDistance = 1;

        public int MovementType = 0;

        public int newSpellIndex = 0;

        public int CustomTime = 0;

        public int errorCounter = 0;

        public long EnrageTimer;

        public bool EnrageTimerStarted = false;

        public bool EnrageReceived = false;

        public Entity tempCastTarget;

        //Respawn/Despawn
        public long RespawnTime;

        public long FindTargetWaitTime;
        public int FindTargetDelay = 500;

        /// <summary>
        /// The map on which this NPC was "aggro'd" and started chasing a target.
        /// </summary>
        public MapInstance AggroCenterMap;

        /// <summary>
        /// The X value on which this NPC was "aggro'd" and started chasing a target.
        /// </summary>
        public int AggroCenterX;

        /// <summary>
        /// The Y value on which this NPC was "aggro'd" and started chasing a target.
        /// </summary>
        public int AggroCenterY;

        /// <summary>
        /// The Z value on which this NPC was "aggro'd" and started chasing a target.
        /// </summary>
        public int AggroCenterZ;

        public Npc([NotNull] NpcBase myBase, bool despawnable = false) : base()
        {
            Name = myBase.Name;
            Sprite = myBase.Sprite;
            Level = myBase.Level;
            Base = myBase;
            Despawnable = despawnable;

            for (var i = 0; i < (int) Stats.StatCount; i++)
            {
                BaseStats[i] = myBase.Stats[i];
                Stat[i] = new Stat((Stats) i, this);
            }

            var spellSlot = 0;
            for (var I = 0; I < Base.Spells.Count; I++)
            {
                var slot = new SpellSlot(spellSlot);
                slot.Set(new Spell(Base.Spells[I]));
                Spells.Add(slot);
                spellSlot++;
            }

            //Give NPC Drops
            var itemSlot = 0;
            foreach (var drop in myBase.Drops)
            {
                //if (Globals.Rand.Next(1, 10001) <= drop.Chance * 100 && ItemBase.Get(drop.ItemId) != null)
                //{
                var slot = new InventorySlot(itemSlot);
                slot.Set(new Item(drop.ItemId, drop.Quantity, true));
                slot.DropChance = drop.Chance;
                Items.Add(slot);
                itemSlot++;

                //}
            }

            for (var i = 0; i < (int) Vitals.VitalCount; i++)
            {
                SetMaxVital(i, myBase.MaxVital[i]);
                SetVital(i, myBase.MaxVital[i]);
            }

            Range = (byte) myBase.SightRange;
            mPathFinder = new Pathfinder(this);
        }

        [NotNull]
        public NpcBase Base { get; private set; }

        private bool IsStunnedOrSleeping => Statuses.Values.Any(PredicateStunnedOrSleeping);

        private bool IsUnableToCastSpells => Statuses.Values.Any(PredicateUnableToCastSpells);

        public override EntityTypes GetEntityType()
        {
            return EntityTypes.GlobalEntity;
        }

        public override void Die(int dropitems = 100, Entity killer = null)
        {
            if (Base.DropPools.Count > 0 && killer != null)
            {
                DropPool(killer);
            }

            if (Base.DeathAnimationId != null)
            {
                PacketSender.SendAnimationToProximity(
                                Base.DeathAnimationId, -1, Guid.Empty, MapId, (byte)X, (byte)Y,
                                (sbyte)Dir
                            );
            }

            base.Die(dropitems, killer);
            AggroCenterMap = null;
            AggroCenterX = 0;
            AggroCenterY = 0;
            AggroCenterZ = 0;
            MapInstance.Get(MapId).RemoveEntity(this);
            PacketSender.SendEntityDie(this);
            PacketSender.SendEntityLeave(this);
        }
        
        public class NpcDropPoolItems
        {
            
            public Guid DropPoolItemId;

            public int minValue;

            public int maxValue;

        }

        public void DropPool(Entity killer)
        {
            var tempX = Base.DropPools.Count;
            var i = 0;
            while (i < Base.DropPools.Count)
            {
                var tempDP = DropPoolBase.Get(Base.DropPools[i].DropPoolId);

                var luck = 1.0 + (killer != null ? killer.GetLuck() : 0) / 100.0;
                double dropRng = (Randomization.NextDouble() * 100.0);

                if (dropRng >= Base.DropPools[i].Chance * luck)
                {
                    i++;
                }
                else
                {
                    var tempValue = 0;
                    List<NpcDropPoolItems> NpcDropPoolItems = new List<NpcDropPoolItems>();
                    foreach (ItemPool ip in tempDP.ItemPool)
                    {
                        NpcDropPoolItems TempItem = new NpcDropPoolItems();
                        TempItem.DropPoolItemId = ip.ItemId;
                        TempItem.minValue = tempValue;
                        TempItem.maxValue = tempValue + (int)ip.Chance;
                        tempValue = TempItem.maxValue;

                        NpcDropPoolItems.Add(TempItem);
                    }
                    var Picker = Randomization.Next(0, tempValue);

                    foreach (NpcDropPoolItems dpi in NpcDropPoolItems)
                    {
                        if (Picker <= dpi.maxValue && Picker >= dpi.minValue)
                        {
                            var TempItemToGive = tempDP.ItemPool.Where(item => item.ItemId == dpi.DropPoolItemId).FirstOrDefault();
                            DropPoolItem(ItemBase.Get(TempItemToGive.ItemId), Randomization.Next(TempItemToGive.MinQuantity, TempItemToGive.MaxQuantity + 1), TempItemToGive.Chance, killer);
                            i++;
                        }
                    }
                }
            }
        }

        private bool DropPoolItem(ItemBase item, int quantity, double dropChance, Entity killer)
        {
            if (killer == null)
            {
                return false;
            }
            if (item == null)
            {
                return false;
            }

            Item nItem = new Item(item.Id, quantity, true);
            var map = MapInstance.Get(MapId);

            //Find tiles to spawn items
            var tiles = new List<TileHelper>();
            for (var x = X - Options.ItemDropRange; x <= X + Options.ItemDropRange; x++)
            {
                for (var y = Y - Options.ItemDropRange; y <= Y + Options.ItemDropRange; y++)
                {
                    var tileHelper = new TileHelper(MapId, x, y);
                    if (tileHelper.TryFix())
                    {
                        //Tile is valid.. let's see if its open
                        map = MapInstance.Get(tileHelper.GetMapId());
                        if (map != null)
                        {
                            if (!map.TileBlocked(tileHelper.GetX(), tileHelper.GetY()))
                            {
                                tiles.Add(tileHelper);
                            }
                        }
                    }
                }
            }
            if (item.ItemType == ItemTypes.Equipment)
            {
                for (var j = 0; j < (int)Stats.StatCount; j++)
                {
                    nItem.StatBuffs[j] = Randomization.Next(ItemBase.Get(nItem.ItemId).StatsGiven[j], ItemBase.Get(nItem.ItemId).StatGrowths[j] + 1);
                }
            }
            if (tiles.Count > 0)
            {
                var tile = tiles[Randomization.Next(tiles.Count)];
                map = MapInstance.Get(tile.GetMapId());
                map?.SpawnItem(tile.GetX(), tile.GetY(), nItem, quantity, killer.Id);
                return true;
            }
            else
            {
                map = MapInstance.Get(MapId);
                map?.SpawnItem(X, Y, nItem, quantity, killer.Id);
                return true;
            }

        }

        //Targeting
        public void AssignTarget(Entity en)
        {
            //Can't assign a new target if taunted, unless we're resetting their target somehow.
            var pathTarget = mPathFinder.GetTarget();
            if (en != null || (pathTarget != null && (pathTarget.TargetMapId != AggroCenterMap.Id || pathTarget.TargetX != AggroCenterX || pathTarget.TargetY != AggroCenterY)))
            {
                var statuses = Statuses.Values.ToArray();
                foreach (var status in statuses)
                {
                    if (status.Type == StatusTypes.Taunt)
                    {
                        return;
                    }
                }
            }

            if (en.GetType() == typeof(Projectile))
            {
                if (((Projectile) en).Owner != this)
                {
                    Target = ((Projectile) en).Owner;
                }
            }
            else
            {
                if (en.GetType() == typeof(Npc))
                {
                    if (((Npc) en).Base == Base)
                    {
                        if (Base.AttackAllies == false)
                        {
                            return;
                        }
                    }
                }

                if (en.GetType() == typeof(Player))
                {
                    //TODO Make sure that the npc can target the player
                    if (this != en)
                    {
                        Target = en;
                    }
                }
                else
                {
                    if (this != en)
                    {
                        Target = en;
                    }
                }
            }
            // Are we configured to handle resetting NPCs after they chase a target for a specified amount of tiles?
            if (Options.Npc.AllowResetRadius)
            {
                // Are we configured to allow new reset locations before they move to their original location, or do we simply not have an original location yet?
                if (Options.Npc.AllowNewResetLocationBeforeFinish || AggroCenterMap == null)
                {
                    AggroCenterMap = Map;
                    AggroCenterX = X;
                    AggroCenterY = Y;
                    AggroCenterZ = Z;
                }
            }
            PacketSender.SendNpcAggressionToProximity(this);
        }

        public void RemoveTarget()
        {
            if (Target != null)
            {
                if (DamageMap.ContainsKey(Target))
                {
                    DamageMap.TryRemove(Target, out var val);
                }
            }

            Target = null;
            PacketSender.SendNpcAggressionToProximity(this);
        }

        public override int CalculateAttackTime()
        {
            if (Base.AttackSpeedModifier == 1) //Static
            {
                return Base.AttackSpeedValue;
            }

            return base.CalculateAttackTime();
        }

        public override bool CanAttack(Entity entity, SpellBase spell)
        {
            if (!base.CanAttack(entity, spell))
            {
                return false;
            }

            if (entity.GetType() == typeof(EventPageInstance))
            {
                return false;
            }

            //Check if the attacker is stunned or blinded.
            var statuses = Statuses.Values.ToArray();
            foreach (var status in statuses)
            {
                if (status.Type == StatusTypes.Stun || status.Type == StatusTypes.Sleep || status.Type == StatusTypes.Fear)
                {
                    return false;
                }
            }

            if (entity.GetType() == typeof(Resource))
            {
                if (!entity.Passable)
                {
                    return false;
                }
            }
            else if (entity.GetType() == typeof(Npc))
            {
                return CanNpcCombat(entity, spell != null && spell.Combat.Friendly) || entity == this;
            }
            else if (entity.GetType() == typeof(Player))
            {
                var player = (Player) entity;
                var friendly = spell != null && spell.Combat.Friendly;
                if (friendly && IsAllyOf(player))
                {
                    return true;
                }

                if (!friendly && !IsAllyOf(player))
                {
                    return true;
                }

                return false;
            }

            return true;
        }

        public override void TryAttack(Entity target)
        {
            if (target.IsDisposed)
            {
                return;
            }

            if (!CanAttack(target, null))
            {
                return;
            }

            if (!IsOneBlockAway(target))
            {
                return;
            }

            if (!IsFacingTarget(target))
            {
                return;
            }

            var deadAnimations = new List<KeyValuePair<Guid, sbyte>>();
            var aliveAnimations = new List<KeyValuePair<Guid, sbyte>>();

            //We were forcing at LEAST 1hp base damage.. but then you can't have guards that won't hurt the player.
            //https://www.ascensiongamedev.com/community/bug_tracker/intersect/npc-set-at-0-attack-damage-still-damages-player-by-1-initially-r915/
            if (AttackTimer < Globals.Timing.TimeMs)
            {
                if (Base.AttackAnimation != null)
                {
                    PacketSender.SendAnimationToProximity(
                        Base.AttackAnimationId, -1, Guid.Empty, target.MapId, (byte) target.X, (byte) target.Y,
                        (sbyte) Dir
                    );
                }

                base.TryAttackNPC(
                    target, Base.Damage, (DamageType) Base.DamageType, (Stats) Base.ScalingStat, Base.Scaling,
                    Base.CritChance, Base.CritMultiplier, deadAnimations, aliveAnimations
                );

                PacketSender.SendEntityAttack(this, CalculateAttackTime());
            }
        }

        public bool CanNpcCombat(Entity enemy, bool friendly = false)
        {
            //Check for NpcVsNpc Combat, both must be enabled and the attacker must have it as an enemy or attack all types of npc.
            if (!friendly)
            {
                if (enemy != null && enemy.GetType() == typeof(Npc) && Base != null)
                {
                    if (((Npc) enemy).Base.NpcVsNpcEnabled == false)
                    {
                        return false;
                    }

                    if (Base.AttackAllies && ((Npc) enemy).Base == Base)
                    {
                        return true;
                    }

                    for (var i = 0; i < Base.AggroList.Count; i++)
                    {
                        if (NpcBase.Get(Base.AggroList[i]) == ((Npc) enemy).Base)
                        {
                            return true;
                        }
                    }

                    return false;
                }

                if (enemy != null && enemy.GetType() == typeof(Player))
                {
                    return true;
                }
            }
            else
            {
                if (enemy != null &&
                    enemy.GetType() == typeof(Npc) &&
                    Base != null &&
                    ((Npc) enemy).Base == Base &&
                    Base.AttackAllies == false)
                {
                    return true;
                }
                else if (enemy != null && enemy.GetType() == typeof(Player))
                {
                    return false;
                }
            }

            return false;
        }

        private static bool PredicateStunnedOrSleeping(Status status)
        {
            switch (status?.Type)
            {
                case StatusTypes.Sleep:
                case StatusTypes.Stun:
                case StatusTypes.Fear:
                    return true;

                case StatusTypes.Silence:
                case StatusTypes.None:
                case StatusTypes.Snare:
                case StatusTypes.Blind:
                case StatusTypes.Stealth:
                case StatusTypes.Transform:
                case StatusTypes.Cleanse:
                case StatusTypes.Invulnerable:
                case StatusTypes.Shield:
                case StatusTypes.OnHit:
                case StatusTypes.Taunt:
                case StatusTypes.CooldownReduction:
                case StatusTypes.Drunk:
                case StatusTypes.Exp:
                case StatusTypes.Lifesteal:
                case StatusTypes.Luck:
                case StatusTypes.Mount:
                case StatusTypes.Tenacity:
                case StatusTypes.ChanceOnAnyHit:
                case StatusTypes.ChanceOnMeleeHit:
                case StatusTypes.ChanceOnSpellHit:
                case StatusTypes.ChanceOnTakingDamage:

                case null:
                    return false;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static bool PredicateUnableToCastSpells(Status status)
        {
            switch (status?.Type)
            {
                case StatusTypes.Silence:
                case StatusTypes.Sleep:
                case StatusTypes.Stun:
                case StatusTypes.Fear:
                    return true;

                case StatusTypes.None:
                case StatusTypes.Snare:
                case StatusTypes.Blind:
                case StatusTypes.Stealth:
                case StatusTypes.Transform:
                case StatusTypes.Cleanse:
                case StatusTypes.Invulnerable:
                case StatusTypes.Shield:
                case StatusTypes.OnHit:
                case StatusTypes.Taunt:
                case StatusTypes.CooldownReduction:
                case StatusTypes.Drunk:
                case StatusTypes.Exp:
                case StatusTypes.Lifesteal:
                case StatusTypes.Luck:
                case StatusTypes.Mount:
                case StatusTypes.Tenacity:
                case StatusTypes.ChanceOnAnyHit:
                case StatusTypes.ChanceOnMeleeHit:
                case StatusTypes.ChanceOnSpellHit:
                case StatusTypes.ChanceOnTakingDamage:
                case null:
                    return false;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TryCastSpells()
        {
            // Check if NPC is stunned/sleeping
            if (IsStunnedOrSleeping)
            {
                return;
            }

            //Check if NPC is casting a spell
            if (CastTime > Globals.Timing.TimeMs)
            {
                return; //can't move while casting
            }

            if (CastFreq >= Globals.Timing.TimeMs)
            {
                return;
            }

            // Check if the NPC is able to cast spells
            if (IsUnableToCastSpells)
            {
                return;
            }

            if (Base.Spells == null || Base.Spells.Count <= 0)
            {
                return;
            }

            // Pick a random spell
            var spellIndex = Randomization.Next(0, Spells.Count);
            var spellId = Base.Spells[spellIndex];
            var spellBase = SpellBase.Get(spellId);
            if (spellBase == null)
            {
                return;
            }

            if (!NpcConditions.MeetsConditionLists(spellBase.CastingRequirements, this, null))
            {
                return;
            }

            if (spellBase.Combat == null)
            {
                Log.Warn($"Combat data missing for {spellBase.Id}.");
            }

            var range = spellBase.Combat?.CastRange ?? 0;
            var targetType = spellBase.Combat?.TargetType ?? SpellTargetTypes.Single;
            var projectileBase = spellBase.Combat?.Projectile;

            if (spellBase.SpellType == SpellTypes.CombatSpell &&
                targetType == SpellTargetTypes.Projectile &&
                projectileBase != null &&
                InRangeOf(Target, projectileBase.Range))
            {
                range = projectileBase.Range;
                var dirToEnemy = DirToEnemy(Target);
                if (dirToEnemy != Dir)
                {
                    if (LastRandomMove >= Globals.Timing.TimeMs)
                    {
                        return;
                    }

                    //Face the target -- next frame fire -- then go on with life
                    ChangeDir(dirToEnemy); // Gotta get dir to enemy
                    LastRandomMove = Globals.Timing.TimeMs + Randomization.Next(1000, 3000);

                    return;
                }
            }

            if (spellBase.SpellType == SpellTypes.CombatSpell &&
                targetType == SpellTargetTypes.Single)
            {
                if (!InRangeOf(Target, spellBase.Combat.CastRange))
                {
                    return;
                }
            }

            if (spellBase.VitalCost == null)
            {
                return;
            }

            if (spellBase.VitalCost[(int) Vitals.Mana] > GetVital(Vitals.Mana))
            {
                return;
            }

            if (spellBase.VitalCost[(int) Vitals.Health] > GetVital(Vitals.Health))
            {
                return;
            }

            var spell = Spells[spellIndex];
            if (spell == null)
            {
                return;
            }

            if (SpellCooldowns.ContainsKey(spell.SpellId) && SpellCooldowns[spell.SpellId] >= Globals.Timing.RealTimeMs)
            {
                return;
            }
            //needs testing!!
            if (spellBase.SpellType == SpellTypes.CombatSpell &&
                targetType == SpellTargetTypes.AoE)
            {
                range = spellBase.Combat?.HitRadius ?? 0;
            }

            if (!InRangeOf(Target, range))
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (targetType)
                {
                    case SpellTargetTypes.Self:
                    case SpellTargetTypes.AoE:
                        return;
                }
            }

            CastTime = Globals.Timing.TimeMs + spellBase.CastDuration;

            if (spellBase.VitalCost[(int) Vitals.Mana] > 0)
            {
                SubVital(Vitals.Mana, spellBase.VitalCost[(int) Vitals.Mana]);
            }
            else
            {
                AddVital(Vitals.Mana, -spellBase.VitalCost[(int) Vitals.Mana]);
            }

            if (spellBase.VitalCost[(int) Vitals.Health] > 0)
            {
                SubVital(Vitals.Health, spellBase.VitalCost[(int) Vitals.Health]);
            }
            else
            {
                AddVital(Vitals.Health, -spellBase.VitalCost[(int) Vitals.Health]);
            }

            if ((spellBase.Combat?.Friendly ?? false) && spellBase.SpellType != SpellTypes.WarpTo)
            {
                CastTarget = this;
            }
            else
            {
                CastTarget = Target;
            }

            switch (Base.SpellFrequency)
            {
                case 0:
                    CastFreq = Globals.Timing.TimeMs + 30000;

                    break;

                case 1:
                    CastFreq = Globals.Timing.TimeMs + 15000;

                    break;

                case 2:
                    CastFreq = Globals.Timing.TimeMs + 8000;

                    break;

                case 3:
                    CastFreq = Globals.Timing.TimeMs + 4000;

                    break;

                case 4:
                    CastFreq = Globals.Timing.TimeMs + 2000;

                    break;
            }

            SpellCastSlot = spellIndex;

            if (spellBase.CastAnimationId != Guid.Empty)
            {
                PacketSender.SendAnimationToProximity(spellBase.CastAnimationId, 1, Id, MapId, 0, 0, (sbyte) Dir);

                //Target Type 1 will be global entity
            }

            PacketSender.SendEntityVitals(this);
            PacketSender.SendEntityCastTime(this, spellId);
        }

        private void BossBehavior()
        {
            // Check if NPC is stunned/sleeping
            if (IsStunnedOrSleeping)
            {
                return;
            }

            // Check if NPC is casting a spell
            if (CastTime > Globals.Timing.TimeMs)
            {
                return; //can't move while casting
            }

            if (CastFreq >= Globals.Timing.TimeMs)
            {
                return;
            }

            // Check if the NPC is able to cast spells
            if (IsUnableToCastSpells)
            {
                return;
            }

            // Check if the NPC has a behavior linked to it
            if (Base.Behavior == null || Base.Behavior == Guid.Empty || BehaviorBase.Get(Base.Behavior).SpellSequences.Count() <= 0)
            {
                return;
            }

            var behaviorBase = BehaviorBase.Get(Base.Behavior);
            var spellIndex = newSpellIndex;

            // Check if the behavior has Enrage enabled
            if (behaviorBase.Enrage)
            {
                if (behaviorBase.EnrageSkill != Guid.Empty)
                {
                    if (!EnrageTimerStarted)
                    {
                        EnrageTimer = Globals.Timing.TimeMs + (long)behaviorBase.EnrageTimer;
                        EnrageTimerStarted = true;
                    }
                    else
                    {
                        if (!EnrageReceived)
                        {
                            if (Globals.Timing.TimeMs >= EnrageTimer)
                            {
                                var tempspellId = behaviorBase.EnrageSkill;
                                var tempspellBase = SpellBase.Get(tempspellId);

                                if (tempspellBase.CastAnimationId != Guid.Empty)
                                {
                                    PacketSender.SendAnimationToProximity(tempspellBase.CastAnimationId, 1, Id, MapId, 0, 0, (sbyte)Dir);
                                    //Target Type 1 will be global entity
                                }

                                PacketSender.SendEntityVitals(this);
                                PacketSender.SendEntityCastTime(this, tempspellId);
                                PacketSender.SendActionMsg(this, "ENRAGE", Color.Orange);

                                // Set temptarget to current target, then set target to self for the enrage skill, cast it and restore target
                                tempCastTarget = CastTarget;
                                CastTarget = this;
                                CastSpell(tempspellId, -1, -2);
                                EnrageReceived = true;
                                CastTarget = tempCastTarget;
                            }
                        }
                    }
                }
            }

            if (behaviorBase.BehaviorType == BehaviorTypes.Random)
            {
                // Pick a random spell
                spellIndex = Randomization.Next(0, behaviorBase.SpellSequences.Count);
            }

            if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
            {
                if (behaviorBase.SpellSequences.Count > 1)
                {
                    // Set the time between this and the next attack
                    CustomTime = behaviorBase.SpellSequences[spellIndex].TimeBeforeNextPhase;
                }
                else
                {
                    spellIndex = 0;
                }
            }

            if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
            {
                // Chronological - If the counter goes higher than the count, reset to 0
                if (SpellCounter > behaviorBase.SpellSequences.Count - 1)
                {
                    SpellCounter = 0;
                    spellIndex = SpellCounter;
                    newSpellIndex = SpellCounter;
                }
            }

            if (behaviorBase.BehaviorType == BehaviorTypes.Pong)
            {
                // PingPong - todo...

                // Pick a random spell
                spellIndex = Randomization.Next(0, behaviorBase.SpellSequences.Count);
            }

            var spellId = behaviorBase.SpellSequences[spellIndex].Spell;
            var spellBase = SpellBase.Get(spellId);

            if (spellBase == null)
            {
                return;
            }

            var lvlStat = 0;
            var maxStat = 0;
            maxStat = GetMaxVital((int)behaviorBase.SpellSequences[spellIndex].Vital);
            lvlStat = GetVital((int)behaviorBase.SpellSequences[spellIndex].Vital);

            // Do the conditional checks, could be optimized, but it works...
            switch (behaviorBase.SpellSequences[spellIndex].ConditionUnit)
            {
                case 0:
                    switch (behaviorBase.SpellSequences[spellIndex].Comperator) //Comparator
                    {
                        case 0:
                            if (lvlStat == (maxStat / 100) * behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                        case 1:
                            if (lvlStat >= (maxStat / 100) * behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                        case 2:
                            if (lvlStat <= (maxStat / 100) * behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                        case 3:
                            if (lvlStat > (maxStat / 100) * behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                        case 4:
                            if (lvlStat < (maxStat / 100) * behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                        case 5:
                            if (lvlStat != behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                    }
                    break;
                case 1:
                    switch (behaviorBase.SpellSequences[spellIndex].Comperator) //Comparator
                    {
                        case 0:
                            if (lvlStat == behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                        case 1:
                            if (lvlStat >= behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                        case 2:
                            if (lvlStat <= behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                        case 3:
                            if (lvlStat > behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                        case 4:
                            if (lvlStat < behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                        case 5:
                            if (lvlStat != behaviorBase.SpellSequences[spellIndex].ConditionValue)
                            {
                            }
                            else
                            {
                                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                                {
                                    SpellCounter++;
                                    newSpellIndex = SpellCounter;
                                }
                                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                                {
                                    if (behaviorBase.SpellSequences.Count > 1)
                                    {
                                        // Pick a custom set spellsequence
                                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                                        newSpellIndex = spellIndex;
                                    }
                                    else
                                    {
                                        newSpellIndex = 0;
                                    }
                                }
                                return;
                            }

                            break;
                    }
                    break;
            }

            // Do conditional checks on the spell itself
            if (!NpcConditions.MeetsConditionLists(spellBase.CastingRequirements, this, null))
            {
                if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
                {
                    SpellCounter++;
                    newSpellIndex = SpellCounter;
                }
                if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
                {
                    if (behaviorBase.SpellSequences.Count > 1)
                    {
                        // Pick a custom set spellsequence
                        spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                        newSpellIndex = spellIndex;
                    }
                    else
                    {
                        newSpellIndex = 0;
                    }
                }
                return;
            }

            MovementType = behaviorBase.SpellSequences[spellIndex].MovementType;
            var oldDistance = KeepDistance;
            var tempDistance = GetDistanceTo(Target);
            var tempRange = behaviorBase.SpellSequences[spellIndex].AttackRange;

            // Hacky way of comparing the distance and the attack range
            if (tempDistance < tempRange - 1 && errorCounter < 4)
            {
                //remove comments to enable auto attacks if in melee range (stops the spells though, so fix that first!)
                /*if (GetDistanceTo(Target) <= 1)
                {
                    ChangeDir(DirToEnemy(Target));
                    if (CanAttack(Target, null))
                    {
                        TryAttack(Target);
                    }
                }*/

                KeepDistance = tempRange;
                MovementType = -1;
                errorCounter++;
                return;
            }

            else if (tempDistance > tempRange + 1 && errorCounter < 4)
            {
                KeepDistance = tempRange;
                MovementType = -1;
                errorCounter++;
                return;
            }

            else
            {
                KeepDistance = behaviorBase.SpellSequences[spellIndex].AttackRange;
                MovementType = 3;
            }

            if (spellBase.Combat == null)
            {
                Log.Warn($"Combat data missing for {spellBase.Id}.");
            }

            var range = spellBase.Combat?.CastRange ?? 0;
            var targetType = spellBase.Combat?.TargetType ?? SpellTargetTypes.Single;
            var projectileBase = spellBase.Combat?.Projectile;

            if (spellBase.SpellType == SpellTypes.CombatSpell &&
                targetType == SpellTargetTypes.Projectile &&
                projectileBase != null &&
                InRangeOf(Target, projectileBase.Range))
            {
                range = projectileBase.Range;
                var dirToEnemy = DirToEnemy(Target);
                if (dirToEnemy != Dir)
                {
                    if (LastRandomMove >= Globals.Timing.TimeMs)
                    {
                        return;
                    }

                    //Face the target -- next frame fire -- then go on with life
                    ChangeDir(dirToEnemy); // Gotta get dir to enemy
                    LastRandomMove = Globals.Timing.TimeMs + Randomization.Next(1, 3000);

                    return;
                }
            }

            if (spellBase.VitalCost == null)
            {
                return;
            }

            if (spellBase.VitalCost[(int)Vitals.Mana] > GetVital(Vitals.Mana))
            {
                return;
            }

            if (spellBase.VitalCost[(int)Vitals.Health] > GetVital(Vitals.Health))
            {
                return;
            }

            var spell = SpellBase.Get(behaviorBase.SpellSequences[spellIndex].Spell);
            if (spell == null)
            {
                return;
            }

            if (SpellCooldowns.ContainsKey(spell.Id) && SpellCooldowns[spell.Id] >= Globals.Timing.RealTimeMs)
            {
                return;
            }
            //needs testing!!
            if (spellBase.SpellType == SpellTypes.CombatSpell &&
                targetType == SpellTargetTypes.AoE)
            {
                range = spellBase.Combat?.HitRadius ?? 0;
            }

            if (!InRangeOf(Target, range))
            {
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (targetType)
                {
                    case SpellTargetTypes.Self:
                    case SpellTargetTypes.AoE:
                        KeepDistance = tempRange;
                        MovementType = -1;
                        errorCounter++;
                        return;
                }
            }

            CastTime = Globals.Timing.TimeMs + spellBase.CastDuration;

            if (spellBase.VitalCost[(int)Vitals.Mana] > 0)
            {
                SubVital(Vitals.Mana, spellBase.VitalCost[(int)Vitals.Mana]);
            }
            else
            {
                AddVital(Vitals.Mana, -spellBase.VitalCost[(int)Vitals.Mana]);
            }

            if (spellBase.VitalCost[(int)Vitals.Health] > 0)
            {
                SubVital(Vitals.Health, spellBase.VitalCost[(int)Vitals.Health]);
            }
            else
            {
                AddVital(Vitals.Health, -spellBase.VitalCost[(int)Vitals.Health]);
            }

            if ((spellBase.Combat?.Friendly ?? false) && spellBase.SpellType != SpellTypes.WarpTo)
            {
                CastTarget = this;
            }
            else
            {
                CastTarget = Target;
            }
            if (CustomTime > 0)
            {
                CastFreq = Globals.Timing.TimeMs + CustomTime;
            }
            else
            {
                switch (Base.SpellFrequency)
                {
                    case 0:
                        CastFreq = Globals.Timing.TimeMs + 30000;

                        break;

                    case 1:
                        CastFreq = Globals.Timing.TimeMs + 15000;

                        break;

                    case 2:
                        CastFreq = Globals.Timing.TimeMs + 8000;

                        break;

                    case 3:
                        CastFreq = Globals.Timing.TimeMs + 4000;

                        break;

                    case 4:
                        CastFreq = Globals.Timing.TimeMs + 1;

                        break;
                }
            }

            SpellCastSlot = spellIndex;
            SpellsType = 1;
            Behavior = Base.Behavior;

            if (spellBase.CastAnimationId != Guid.Empty)
            {
                PacketSender.SendAnimationToProximity(spellBase.CastAnimationId, 1, Id, MapId, 0, 0, (sbyte)Dir);

                //Target Type 1 will be global entity
            }

            PacketSender.SendEntityVitals(this);
            PacketSender.SendEntityCastTime(this, spellId);


            if (behaviorBase.BehaviorType == BehaviorTypes.Chrono)
            {
                SpellCounter++;
                newSpellIndex = SpellCounter;
            }

            if (behaviorBase.BehaviorType == BehaviorTypes.Custom)
            {
                if (behaviorBase.SpellSequences.Count > 1)
                {
                    // Pick a custom set spellsequence
                    spellIndex = behaviorBase.SpellSequences[spellIndex].nextPhase;
                    newSpellIndex = spellIndex;
                }
                else
                {
                    newSpellIndex = 0;
                }
            }
            errorCounter = 0;
        }

        // TODO: Improve NPC movement to be more fluid like a player
        //General Updating
        public override void Update(long timeMs)
        {
            var curMapLink = MapId;
            base.Update(timeMs);

            var statuses = Statuses.Values.ToArray();
            foreach (var status in statuses)
            {
                if (status.Type == StatusTypes.Stun || status.Type == StatusTypes.Sleep || status.Type == StatusTypes.Fear)
                {
                    return;
                }
            }

            //TODO Clear Damage Map if out of combat (target is null and combat timer is to the point that regen has started)
            if (Target == null && Globals.Timing.TimeMs > CombatTimer && Globals.Timing.TimeMs > RegenTimer)
            {
                DamageMap.Clear();
            }

            var fleeing = false;
            if (Base.FleeHealthPercentage > 0)
            {
                var fleeHpCutoff = GetMaxVital(Vitals.Health) * ((float) Base.FleeHealthPercentage / 100f);
                if (GetVital(Vitals.Health) < fleeHpCutoff)
                {
                    fleeing = true;
                }
            }

            if (MoveTimer < Globals.Timing.TimeMs)
            {
                var targetMap = Guid.Empty;
                var targetX = 0;
                var targetY = 0;
                var targetZ = 0;

                //Check if there is a target, if so, run their ass down.
                if (Target != null)
                {
                    if (!Target.IsDead() && CanAttack(Target, null))
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
                        if (CastTime <= 0)
                        {
                            RemoveTarget();
                        }
                    }
                }
                else //Find a target if able
                {
                    long dmg = 0;
                    Entity tgt = null;
                    foreach (var pair in DamageMap)
                    {
                        if (pair.Value > dmg)
                        {
                            dmg = pair.Value;
                            tgt = pair.Key;
                        }
                    }

                    if (tgt != null)
                    {
                        AssignTarget(tgt);
                    }
                    else
                    {
                        // Check if attack on sight or have other npc's to target
                        TryFindNewTarget(timeMs);
                    }
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

                }

                if (mPathFinder.GetTarget() != null)
                {
                    var tempmovement = false;
                    var randSeq = 0;
                    if (this.Base.Behavior != Guid.Empty)
                    {
                        BossBehavior();
                        keepDistance = KeepDistance;

                        switch (MovementType)
                        {
                            case -1: //random
                                tempmovement = GetDistanceTo(Target) < keepDistance;
                                randSeq = 0;
                                //randSeq = Randomization.Next(0, 5);
                                break;
                            case 0: //quirky
                                tempmovement = IsXBlocksAway(
                                    mPathFinder.GetTarget().TargetMapId, mPathFinder.GetTarget().TargetX,
                                    mPathFinder.GetTarget().TargetY, keepDistance, mPathFinder.GetTarget().TargetZ
                                );
                                //randSeq = Randomization.Next(0, 2);
                                randSeq = 0;
                                break;
                            case 1: //stoned
                                tempmovement = GetDistanceTo(Target) < keepDistance;
                                randSeq = 0;
                                //randSeq = Randomization.Next(0, 1);
                                break;
                            case 2: //normal
                                tempmovement = IsXBlocksAway(
                                    mPathFinder.GetTarget().TargetMapId, mPathFinder.GetTarget().TargetX,
                                    mPathFinder.GetTarget().TargetY, keepDistance, mPathFinder.GetTarget().TargetZ
                                );
                                randSeq = 0;
                                break;
                            default:
                                var behaviorBase = BehaviorBase.Get(Base.Behavior);
                                var spellIndex = SpellCastSlot;
                                var spellId = behaviorBase.SpellSequences[spellIndex].Spell;
                                var spellBase = SpellBase.Get(spellId);
                                var projectileBase = spellBase.Combat?.Projectile;

                                if (projectileBase != null)
                                {
                                    if (InRangeOf(Target, projectileBase.Range))
                                    {
                                        randSeq = 0;
                                        if (IsXBlocksAway(
                                                mPathFinder.GetTarget().TargetMapId, mPathFinder.GetTarget().TargetX,
                                                mPathFinder.GetTarget().TargetY, GetDistanceTo(Target), mPathFinder.GetTarget().TargetZ
                                            ))
                                        {
                                            return;
                                        }
                                        else
                                        {
                                            tempmovement = IsXBlocksAway(
                                                mPathFinder.GetTarget().TargetMapId, mPathFinder.GetTarget().TargetX,
                                                mPathFinder.GetTarget().TargetY, GetDistanceTo(Target), mPathFinder.GetTarget().TargetZ
                                            );
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
                                                //check if NPC is snared or stunned
                                                statuses = Statuses.Values.ToArray();
                                                foreach (var status in statuses)
                                                {
                                                    if (status.Type == StatusTypes.Stun ||
                                                        status.Type == StatusTypes.Snare ||
                                                        status.Type == StatusTypes.Sleep ||
                                                        status.Type == StatusTypes.Fear)
                                                    {
                                                        return;
                                                    }
                                                }

                                                Move((byte)dir, null);
                                            }
                                            else
                                            {
                                                mPathFinder.PathFailed(timeMs);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    return;
                                }
                                break;
                        }
                    }
                    else
                    {
                        if (Target != null)
                        {
                            TryCastSpells();
                        }
                    }
                    if (tempmovement)
                    {
                        var dir = DirToEnemy(Target);
                        if (randSeq == 0)
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
                        else
                        {
                            dir = (byte)Randomization.Next(0, 8);
                        }


                        if (CanMove(dir) == -1 || CanMove(dir) == -4)
                        {
                            //check if NPC is snared or stunned
                            statuses = Statuses.Values.ToArray();
                            foreach (var status in statuses)
                            {
                                if (status.Type == StatusTypes.Stun ||
                                    status.Type == StatusTypes.Snare ||
                                    status.Type == StatusTypes.Sleep ||
                                    status.Type == StatusTypes.Fear)
                                {
                                    return;
                                }
                            }

                            Move(dir, null);
                        }
                        else
                        {
                            dir = (byte)Randomization.Next(0, 8);
                            Move(dir, null);
                        }
                    }

                    else if (!tempmovement)
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
                                        //check if NPC is snared or stunned
                                        statuses = Statuses.Values.ToArray();
                                        foreach (var status in statuses)
                                        {
                                            if (status.Type == StatusTypes.Stun ||
                                                status.Type == StatusTypes.Snare ||
                                                status.Type == StatusTypes.Sleep)
                                            {
                                                return;
                                            }
                                        }

                                        Move((byte)dir, null);
                                    }
                                    else
                                    {
                                        mPathFinder.PathFailed(timeMs);
                                    }


                                    // Have we reached our destination? If so, clear it.
                                    var tloc = mPathFinder.GetTarget();
                                    if (tloc.TargetMapId == MapId && tloc.TargetX == X && tloc.TargetY == Y)
                                    {
                                        targetMap = Guid.Empty;

                                        // Reset our aggro center so we can get "pulled" again.
                                        AggroCenterMap = null;
                                        AggroCenterX = 0;
                                        AggroCenterY = 0;
                                        AggroCenterZ = 0;
                                    }
                                }

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
                            if (Target != null && fleeing)
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
                                    //check if NPC is snared or stunned
                                    statuses = Statuses.Values.ToArray();
                                    foreach (var status in statuses)
                                    {
                                        if (status.Type == StatusTypes.Stun ||
                                            status.Type == StatusTypes.Snare ||
                                            status.Type == StatusTypes.Sleep ||
                                            status.Type == StatusTypes.Fear)
                                        {
                                            return;
                                        }
                                    }

                                    Move(dir, null);
                                    fleed = true;
                                }
                            }

                        if (!fleed)
                        {
                            if (Target != null)
                            {
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
                                    else
                                    {
                                        if (CanAttack(Target, null))
                                        {
                                            TryAttack(Target);
                                        }
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

                if (Base.Movement == (int) NpcMovement.StandStill)
                {
                    LastRandomMove = Globals.Timing.TimeMs + Randomization.Next(1000, 3000);

                    return;
                }
                else if (Base.Movement == (int) NpcMovement.TurnRandomly)
                {
                    ChangeDir((byte)Randomization.Next(0, 4));
                    LastRandomMove = Globals.Timing.TimeMs + Randomization.Next(1000, 3000);

                    return;
                }

                var i = Randomization.Next(0, 1);
                if (i == 0)
                {
                    i = Randomization.Next(0, 8);
                    if (CanMove(i) == -1)
                    {
                        //check if NPC is snared or stunned
                        statuses = Statuses.Values.ToArray();
                        foreach (var status in statuses)
                        {
                            if (status.Type == StatusTypes.Stun ||
                                status.Type == StatusTypes.Snare ||
                                status.Type == StatusTypes.Sleep ||
                                status.Type == StatusTypes.Fear)
                            {
                                return;
                            }
                        }

                        Move((byte) i, null);
                        
                    }
                }

                LastRandomMove = Globals.Timing.TimeMs + Randomization.Next(500, 3000);

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
            // Check if we've moved out of our range we're allowed to move from after being "aggro'd" by something.
            // If so, remove target and move back to the origin point.
            if (Options.Npc.AllowResetRadius && AggroCenterMap != null && GetDistanceTo(AggroCenterMap, AggroCenterX, AggroCenterY) > Options.Npc.ResetRadius)
            {
                // Remove our target.
                RemoveTarget();

                // Reset our vitals and statusses when configured.
                if (Options.Npc.ResetVitalsAndStatusses)
                {
                    Statuses.Clear();
                    DoT.Clear();
                    for (var v = 0; v < (int)Vitals.VitalCount; v++)
                    {
                        RestoreVital((Vitals)v);
                    }
                }

                // Try and move back to where we came from before we started chasing something.
                mPathFinder.SetTarget(new PathfinderTarget(AggroCenterMap.Id, AggroCenterX, AggroCenterY, AggroCenterZ));
            }
            // End of the Npc Movement
        }

        public override void NotifySwarm(Entity attacker)
        {
            var mapEntities = MapInstance.Get(MapId).GetEntities(true);
            foreach (var en in mapEntities)
            {
                if (en.GetType() == typeof(Npc))
                {
                    var npc = (Npc) en;
                    if (npc.Target == null & npc.Base.Swarm && npc.Base == Base)
                    {
                        if (npc.InRangeOf(attacker, npc.Base.SightRange))
                        {
                            npc.AssignTarget(attacker);
                        }
                    }
                }
            }
        }

        public bool CanPlayerAttack(Player en)
        {
            //Check to see if the npc is a friend/protector...
            if (IsAllyOf(en))
            {
                return false;
            }

            //If not then check and see if player meets the conditions to attack the npc...
            if (Base.PlayerCanAttackConditions.Lists.Count == 0 ||
                Conditions.MeetsConditionLists(Base.PlayerCanAttackConditions, en, null))
            {
                return true;
            }

            return false;
        }

        public override bool IsAllyOf(Entity otherEntity)
        {
            switch (otherEntity)
            {
                case Npc otherNpc:
                    return Base == otherNpc.Base;
                case Player otherPlayer:
                    var conditionLists = Base.PlayerFriendConditions;
                    if ((conditionLists?.Count ?? 0) == 0)
                    {
                        return false;
                    }

                    return Conditions.MeetsConditionLists(conditionLists, otherPlayer, null);
                default:
                    return base.IsAllyOf(otherEntity);
            }
        }

        public bool ShouldAttackPlayerOnSight(Player en)
        {
            if (IsAllyOf(en))
            {
                return false;
            }

            if (Base.Aggressive)
            {
                if (Base.AttackOnSightConditions.Lists.Count > 0 &&
                    Conditions.MeetsConditionLists(Base.AttackOnSightConditions, en, null))
                {
                    return false;
                }

                return true;
            }
            else
            {
                if (Base.AttackOnSightConditions.Lists.Count > 0 &&
                    Conditions.MeetsConditionLists(Base.AttackOnSightConditions, en, null))
                {
                    return true;
                }
            }

            return false;
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
                    if (entity != null && entity.IsDead() == false && entity != this && entity.Id != avoidId)
                    {
                        //TODO Check if NPC is allowed to attack player with new conditions
                        if (entity.GetType() == typeof(Player))
                        {
                            if (ShouldAttackPlayerOnSight((Player) entity))
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
                        else if (entity.GetType() == typeof(Npc))
                        {
                            if (Base.Aggressive && Base.AggroList.Contains(((Npc) entity).Base.Id))
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
            }

            if (closestIndex != -1)
            {
                AssignTarget(possibleTargets[closestIndex]);
            }

            FindTargetWaitTime = timeMs + FindTargetDelay;
        }

        public override void ProcessRegen()
        {
            if (Base == null)
            {
                return;
            }

            foreach (Vitals vital in Enum.GetValues(typeof(Vitals)))
            {
                if (vital >= Vitals.VitalCount)
                {
                    continue;
                }

                var vitalId = (int) vital;
                var vitalValue = GetVital(vital);
                var maxVitalValue = GetMaxVital(vital);
                if (vitalValue >= maxVitalValue)
                {
                    continue;
                }

                var vitalRegenRate = Base.VitalRegen[vitalId] / 100f;
                var regenValue = (int) Math.Max(1, maxVitalValue * vitalRegenRate) *
                                 Math.Abs(Math.Sign(vitalRegenRate));

                AddVital(vital, regenValue);
            }
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
            //Determines the aggression level of this npc to send to the player
            if (this.Target != null)
            {
                return -1;
            }
            else
            {
                //Guard = 3
                //Will attack on sight = 1
                //Will attack if attacked = 0
                //Can't attack nor can attack = 2
                var ally = IsAllyOf(player);
                var attackOnSight = ShouldAttackPlayerOnSight(player);
                var canPlayerAttack = CanPlayerAttack(player);
                if (ally && !canPlayerAttack)
                {
                    return 3;
                }

                if (attackOnSight)
                {
                    return 1;
                }

                if (!ally && !attackOnSight && canPlayerAttack)
                {
                    return 0;
                }

                if (!ally && !attackOnSight && !canPlayerAttack)
                {
                    return 2;
                }
            }

            return 2;
        }

        public override EntityPacket EntityPacket(EntityPacket packet = null, Player forPlayer = null)
        {
            if (packet == null)
            {
                packet = new NpcEntityPacket();
            }

            packet = base.EntityPacket(packet, forPlayer);

            var pkt = (NpcEntityPacket) packet;
            pkt.Aggression = GetAggression(forPlayer);

            return pkt;
        }

    }

}
