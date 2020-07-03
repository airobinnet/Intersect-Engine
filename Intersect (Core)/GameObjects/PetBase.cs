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

    public class PetBase : DatabaseObject<PetBase>, IFolderable
    {
        [JsonConstructor]
        public PetBase(Guid id) : base(id)
        {
            Name = "New Pet";
        }

        //Parameterless constructor for EF
        public PetBase()
        {
            Name = "New Pet";
        }

        [Column("Animation1")]
        public Guid AnimationId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public AnimationBase Animation
        {
            get => AnimationBase.Get(AnimationId);
            set => AnimationId = value?.Id ?? Guid.Empty;
        }

        public int Level { get; set; } = 1;

        public int SightRange { get; set; } = 20;

        //Basic Info
        public int SpawnDuration { get; set; } = 9999;

        public string Sprite { get; set; } = "";

        /// <inheritdoc />
        public string Folder { get; set; } = "";
    }

}
