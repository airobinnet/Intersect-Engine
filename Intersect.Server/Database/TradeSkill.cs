using System;
using System.ComponentModel.DataAnnotations.Schema;

using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.Server.Database.PlayerData.Players;
using Intersect.Server.General;
using Intersect.Utilities;

using Newtonsoft.Json;

namespace Intersect.Server.Database
{

    public class TradeSkill
    {
        public TradeSkill()
        {
        }

        public TradeSkill(Guid tradeskillid, bool unlocked = false) : this(
            tradeskillid, unlocked, 0, 0
        )
        {
        }

        public TradeSkill(Guid tradeskillid, bool unlocked, int currentlevel, int currentxp)
        {
            TradeSkillId = tradeskillid;
            Unlocked = unlocked;
            CurrentLevel = currentlevel;
            CurrentXp = currentxp;

            var descriptor = TradeSkillBase.Get(TradeSkillId);
            if (descriptor == null)
            {
                return;
            }
        }

        public TradeSkill(TradeSkill tradeskill) : this(tradeskill.TradeSkillId, tradeskill.Unlocked, tradeskill.CurrentLevel, tradeskill.CurrentXp)
        {
        }

        public Guid TradeSkillId { get; set; } = Guid.Empty;

        public bool Unlocked { get; set; }

        public int CurrentLevel { get; set; }

        public int CurrentXp { get; set; }

        [JsonIgnore, NotMapped]
        public TradeSkillBase Descriptor => TradeSkillBase.Get(TradeSkillId);

        public static TradeSkill None => new TradeSkill();

        public virtual void Set(TradeSkill tradeskill)
        {
            TradeSkillId = tradeskill.TradeSkillId;
            Unlocked = tradeskill.Unlocked;
            CurrentLevel = tradeskill.CurrentLevel;
            CurrentXp = tradeskill.CurrentXp;
        }

        public string Data()
        {
            return JsonConvert.SerializeObject(this);
        }

        public TradeSkill Clone()
        {
            return new TradeSkill(this);
        }

    }

}
