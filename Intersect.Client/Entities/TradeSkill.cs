using System;

using Intersect.Enums;
using Intersect.GameObjects;

namespace Intersect.Client.Entities
{

    public class TradeSkill
    {
        public Guid TradeSkillId { get; set; } = Guid.Empty;

        public bool Unlocked { get; set; }

        public int CurrentLevel { get; set; }

        public int CurrentXp { get; set; }

        public TradeSkillBase Base => TradeSkillBase.Get(TradeSkillId);

        public void Load(Guid tradeskillid, bool unlocked, int currentlevel, int currentxp)
        {
            TradeSkillId = tradeskillid;
            Unlocked = unlocked;
            CurrentLevel = currentlevel;
            CurrentXp = currentxp;
        }

        public TradeSkill Clone()
        {
            var newTradeSkill = new TradeSkill()
            {
                TradeSkillId = TradeSkillId,
                Unlocked = Unlocked,
                CurrentLevel = CurrentLevel,
                CurrentXp = CurrentXp
            };

            return newTradeSkill;
        }

    }

}
