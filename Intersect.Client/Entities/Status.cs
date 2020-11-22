using System;

using Intersect.Client.General;
using Intersect.Enums;

namespace Intersect.Client.Entities
{

    public class Status
    {

        public string Data = "";

        public int[] Shield = new int[(int) Vitals.VitalCount];

        public Guid SpellId;

        public long TimeRecevied = 0;

        public long TimeRemaining = 0;

        public long TotalDuration = 1;

        public bool Passive;

        public int ExtraBuff = 0;

        public StatusTypes Type;

        public Status(Guid spellId, StatusTypes type, string data, long timeRemaining, long totalDuration, bool passive, int extraBuff)
        {
            SpellId = spellId;
            Type = type;
            Data = data;
            TimeRemaining = timeRemaining;
            TotalDuration = totalDuration;
            Passive = passive;
            TimeRecevied = Globals.System.GetTimeMs();
            ExtraBuff = extraBuff;
        }

        public bool IsActive()
        {
            return RemainingMs() > 0;
        }

        public long RemainingMs()
        {
            var timeDiff = Globals.System.GetTimeMs() - TimeRecevied;

            return TimeRemaining - timeDiff;
        }

    }

}
