using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Intersect.Enums;
using Intersect.GameObjects.Conditions;
using Intersect.GameObjects.Events;
using Intersect.Models;
using Intersect.Utilities;

using JetBrains.Annotations;

using Newtonsoft.Json;

namespace Intersect.GameObjects
{

    public class TradeSkillBase : DatabaseObject<TradeSkillBase>, IFolderable
    {
        [JsonConstructor]
        public TradeSkillBase(Guid id) : base(id)
        {
            Name = "New Tradeskill";
        }

        //Parameterless constructor for EF
        public TradeSkillBase()
        {
            Name = "New Tradeskill";
        }


        [NotMapped] public List<CraftUnlock> CraftUnlocks = new List<CraftUnlock>();

        [NotMapped] public List<WeaponUnlock> WeaponUnlocks = new List<WeaponUnlock>();

        [NotMapped] public List<SkillUnlock> SkillUnlocks = new List<SkillUnlock>();

        public TradeSkillTypes TradeskillType { get; set; }

        //General
        public int XPBase { get; set; }

        public int XPIncrease { get; set; }

        public int MaxLevel { get; set; }

        public string Icon { get; set; } = "";

        [Column("LevelUpAnimation")]
        public Guid LevelUpAnimationId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public AnimationBase LevelUpAnimation
        {
            get => AnimationBase.Get(LevelUpAnimationId);
            set => LevelUpAnimationId = value?.Id ?? Guid.Empty;
        }

        //CraftSkill
        [Column("CraftUnlocks")]
        [JsonIgnore]
        public string JsonCraftUnlocks
        {
            get => JsonConvert.SerializeObject(CraftUnlocks);
            set => CraftUnlocks = JsonConvert.DeserializeObject<List<CraftUnlock>>(value ?? "[]");
        }

        //CraftSkill
        [Column("WeaponUnlocks")]
        [JsonIgnore]
        public string JsonWeaponUnlocks
        {
            get => JsonConvert.SerializeObject(WeaponUnlocks);
            set => WeaponUnlocks = JsonConvert.DeserializeObject<List<WeaponUnlock>>(value ?? "[]");
        }

        //NormalSkill


        //CraftSkill
        [Column("SkillUnlocks")]
        [JsonIgnore]
        public string JsonSkillUnlocks
        {
            get => JsonConvert.SerializeObject(SkillUnlocks);
            set => SkillUnlocks = JsonConvert.DeserializeObject<List<SkillUnlock>>(value ?? "[]");
        }
        
        /// <inheritdoc />
        public string Folder { get; set; } = "";

    }

    public class CraftUnlock
    {

        public Guid CraftId;

        public int LevelRequired;

        public CraftUnlock(Guid craftid, int levelreq)
        {
            CraftId = craftid;
            LevelRequired = levelreq;
        }

    }

    public class WeaponUnlock
    {

        public string WeaponTag;

        public int DamageIncrease;

        public int WeaponXpGain;

        public WeaponUnlock(string weapontag, int damageincrease, int weaponxpgain)
        {
            WeaponTag = weapontag;
            DamageIncrease = damageincrease;
            WeaponXpGain = weaponxpgain;
        }

    }

    public class SkillUnlock
    {

        public Guid Skill;

        public int DamageIncrease;

        public int SkillXpGain;

        public SkillUnlock(Guid skill, int damageincrease, int skillxpgain)
        {
            Skill = skill;
            DamageIncrease = damageincrease;
            SkillXpGain = skillxpgain;
        }

    }

}
