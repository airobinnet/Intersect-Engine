﻿using System;

using Intersect.Enums;

namespace Intersect.Network.Packets.Server
{

    public class StatusPacket : CerasPacket
    {

        public StatusPacket(
            Guid spellId,
            StatusTypes type,
            string transformSprite,
            long timeRemaining,
            long totalDuration,
            bool passive,
            int[] vitalShields,
            int extraBuff
        )
        {
            SpellId = spellId;
            Type = type;
            TransformSprite = transformSprite;
            TimeRemaining = timeRemaining;
            TotalDuration = totalDuration;
            VitalShields = vitalShields;
            ExtraBuff = extraBuff;
            Passive = passive;
        }

        public Guid SpellId { get; set; }

        public StatusTypes Type { get; set; }

        public string TransformSprite { get; set; }

        public long TimeRemaining { get; set; }

        public long TotalDuration { get; set; }

        public int[] VitalShields { get; set; }

        public int ExtraBuff { get; set; }

        public bool Passive { get; set; }

    }

}
