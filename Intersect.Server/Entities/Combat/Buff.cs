﻿using Intersect.GameObjects;
using Intersect.Server.General;

namespace Intersect.Server.Entities.Combat
{

    public class Buff
    {

        public int BuffType;

        public long Duration;

        public bool Passive;

        public SpellBase Spell;

        public Buff(SpellBase spell, int buff, int duration, bool passive)
        {
            Spell = spell;
            BuffType = buff;
            Duration = Globals.Timing.TimeMs + duration;
            Passive = passive;
        }

    }

}
