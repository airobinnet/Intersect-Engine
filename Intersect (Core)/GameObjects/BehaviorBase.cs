using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Intersect.Enums;
using Intersect.GameObjects.Conditions;
using Intersect.GameObjects.Events;
using Intersect.Models;
using Intersect.Utilities;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace Intersect.GameObjects
{

    public class BehaviorBase : DatabaseObject<BehaviorBase>, IFolderable
    {
        [JsonConstructor]
        public BehaviorBase(Guid id) : base(id)
        {
            Name = "New Behavior";
        }

        public BehaviorBase()
        {
            Name = "New Behavior";
        }

        public BehaviorTypes BehaviorType { get; set; }

        public string Description { get; set; } = "";

        public bool Enrage { get; set; }

        public int EnrageTimer { get; set; }

        public Guid EnrageSkill { get; set; }

        //SpellSequences
        [JsonIgnore]
        [Column("SpellSequences")]
        public string SpellSequencesJson
        {
            get => JsonConvert.SerializeObject(SpellSequences, Formatting.None);
            set => SpellSequences = JsonConvert.DeserializeObject<List<SpellSequence>>(value);
        }

        //SpellSequences
        [NotMapped]
        public List<SpellSequence> SpellSequences { get; set; } = new List<SpellSequence>();


        /// <inheritdoc />
        public string Folder { get; set; } = "";

        public class SpellSequence
        {
            public Guid Spell { get; set; }

            public Vitals Vital { get; set; } = 0;

            public int Comperator { get; set; } = 0;

            public int ConditionValue { get; set; } = 1;

            public int ConditionUnit { get; set; } = 0;

            public int AttackRange { get; set; } = 1;

            public int MovementType { get; set; } = 0;

            public int nextPhase { get; set; }

            public int TimeBeforeNextPhase { get; set; }

        }
    }

}