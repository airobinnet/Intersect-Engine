﻿using System;
using System.Linq;

using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.Server.General;
using Intersect.Server.Localization;
using Intersect.Server.Networking;

namespace Intersect.Server.Entities.Combat
{

    public class Status
    {

        public string Data = "";

        public long Duration;

        private Entity mEntity;

        public SpellBase Spell;

        public long StartTime;

        public StatusTypes Type;

        public int ExtraBuff;

        public Guid PassiveSpell;

        public bool Passive;

        public bool OnSelf;

        public Status(Entity en, SpellBase spell, StatusTypes type, int duration, bool passive, string data, int extraBuff, Guid passivespell, bool onself)
        {
            mEntity = en;
            Spell = spell;
            Type = type;
            StartTime = Globals.Timing.TimeMs;
            Passive = passive;
            Duration = Globals.Timing.TimeMs + duration;
            Data = data;
            ExtraBuff = extraBuff;
            PassiveSpell = passivespell;
            OnSelf = onself;

            if (en.GetType() == typeof(Player))
            {
                if (type == StatusTypes.Blind ||
                    type == StatusTypes.Silence ||
                    type == StatusTypes.Sleep ||
                    type == StatusTypes.Snare ||
                    type == StatusTypes.Stun ||
                    type == StatusTypes.Taunt ||
                    type == StatusTypes.Fear)
                {
                    Duration = Globals.Timing.TimeMs + duration - (long) (((Player) en).GetTenacity() / 100 * duration);
                }
            }

            if (type == StatusTypes.Shield)
            {
                for (var i = (int) Vitals.Health; i < (int) Vitals.VitalCount; i++)
                {
                    shield[i] = Math.Abs(spell.Combat.VitalDiff[i]) +
                                (int) (spell.Combat.Scaling * en.Stat[spell.Combat.ScalingStat].BaseStat / 100f);
                }
            }

            if ((type == StatusTypes.ChanceOnAnyHit ||
                type == StatusTypes.ChanceOnMeleeHit ||
                type == StatusTypes.ChanceOnSpellHit ||
                type == StatusTypes.ChanceOnTakingDamage) &&
                onself == true
                )
            {
                if (duration <= 0)
                {
                    var statuses = en.Statuses.Values.ToArray();
                    foreach (var status in statuses)
                    {
                        if (status.Spell == Spell)
                        {
                            RemoveStatus();
                            return;
                        }
                    }
                }
            }

            //If new Cleanse spell, remove all over status effects.
            if (Type == StatusTypes.Cleanse)
            {
                en.Statuses.Clear();
            }
            else
            {
                //If user has a cleanse on, don't add status
                var statuses = en.Statuses.Values.ToArray();
                foreach (var status in statuses)
                {
                    if (status.Type == StatusTypes.Cleanse)
                    {
                        PacketSender.SendActionMsg(en, Strings.Combat.status[(int) Type], CustomColors.Combat.Cleanse);

                        return;
                    }
                }
            }

            if (en.Statuses.ContainsKey(spell))
            {
                en.Statuses[spell].Duration = Duration;
                en.Statuses[spell].StartTime = StartTime;
            }
            else
            {
                en.Statuses.Add(Spell, this);
            }

            PacketSender.SendEntityVitals(mEntity);
        }

        public int[] shield { get; set; } = new int[(int) Enums.Vitals.VitalCount];

        public void TryRemoveStatus()
        {
            if (!Passive)
            {
                if (Duration <= Globals.Timing.TimeMs) //Check the timer
                {
                    RemoveStatus();
                }
            }

            //If shield check for out of hp
            if (Type == StatusTypes.Shield)
            {
                for (var i = (int) Vitals.Health; i < (int) Vitals.VitalCount; i++)
                {
                    if (shield[i] > 0)
                    {
                        return;
                    }
                }

                RemoveStatus();
            }
        }

        public void RemoveStatus()
        {
            mEntity.Statuses.Remove(Spell);
            PacketSender.SendEntityVitals(mEntity);
        }

        public void DamageShield(Vitals vital, ref int amount)
        {
            if (Type == StatusTypes.Shield)
            {
                shield[(int) vital] -= amount;
                if (shield[(int) vital] <= 0)
                {
                    amount = -shield[(int) vital]; //Return piercing damage.
                    shield[(int) vital] = 0;
                    TryRemoveStatus();
                }
                else
                {
                    amount = 0; //Sheild is stronger than the damage dealt, so no piercing damage.
                }
            }
        }

    }

}
