using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using Intersect.Enums;
using Intersect.GameObjects.Conditions;
using Intersect.GameObjects.Events;
using Intersect.Localization;
using Intersect.Models;
using Intersect.GameObjects.Maps;

using Newtonsoft.Json;
using Intersect.GameObjects.Maps.MapList;

namespace Intersect.GameObjects
{

    public enum QuestProgressState
    {

        OnAnyTask = 0,

        BeforeTask = 1,

        AfterTask = 2,

        OnTask = 3,

    }

    public class QuestProgress
    {

        public bool Completed;

        public Guid TaskId;

        public int TaskProgress;

        public long TimeCompleted;
        
        //multiple items or targets

        public List<int> mTaskProgress { get; set; } = new List<int>();

        public QuestProgress(string data)
        {
            JsonConvert.PopulateObject(data, this);
        }

    }

    public class QuestBase : DatabaseObject<QuestBase>, IFolderable
    {

        [NotMapped] [JsonIgnore]
        public Dictionary<Guid, EventBase>
            AddEvents = new Dictionary<Guid, EventBase>(); //Events that need to be added for the quest, int is task id

        [NotMapped] public List<Guid> RemoveEvents = new List<Guid>(); //Events that need to be removed for the quest

        [NotMapped] public List<QuestTask> Tasks = new List<QuestTask>();

        [JsonConstructor]
        public QuestBase(Guid Id) : base(Id)
        {
            Name = "New Quest";
        }

        //Parameterless EF Constructor
        public QuestBase()
        {
            Name = "New Quest";
        }

        //Basic Quest Properties
        public string StartDescription { get; set; } = "";

        public string BeforeDescription { get; set; } = "";

        public string EndDescription { get; set; } = "";

        public string InProgressDescription { get; set; } = "";

        public bool LogAfterComplete { get; set; }

        public bool LogBeforeOffer { get; set; }

        public bool Quitable { get; set; }

        public bool Repeatable { get; set; }

        public long RepeatTime { get; set; } = 0;

        //Requirements - Store with json
        [Column("Requirements")]
        [JsonIgnore]
        public string JsonRequirements
        {
            get => Requirements.Data();
            set => Requirements.Load(value);
        }

        [NotMapped]
        public ConditionLists Requirements { get; set; } = new ConditionLists();

        [Column("StartEvent")]
        public Guid StartEventId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public EventBase StartEvent
        {
            get => EventBase.Get(StartEventId);
            set => StartEventId = value.Id;
        }

        [Column("EndEvent")]
        public Guid EndEventId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public EventBase EndEvent
        {
            get => EventBase.Get(EndEventId);
            set => EndEventId = value.Id;
        }

        [Column("Tasks")]
        [JsonIgnore]
        public string TasksJson
        {
            get => JsonConvert.SerializeObject(Tasks);
            set => Tasks = JsonConvert.DeserializeObject<List<QuestTask>>(value);
        }

        [NotMapped]
        public string LocalEventsJson
        {
            get => JsonConvert.SerializeObject(
                AddEvents, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                    ObjectCreationHandling = ObjectCreationHandling.Replace
                }
            );
            set => JsonConvert.PopulateObject(
                value, AddEvents,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                    ObjectCreationHandling = ObjectCreationHandling.Replace
                }
            );
        }

        //Editor Only
        [NotMapped]
        [JsonIgnore]
        public Dictionary<Guid, Guid> OriginalTaskEventIds { get; set; } = new Dictionary<Guid, Guid>();

        /// <inheritdoc />
        public string Folder { get; set; } = "";

        public int GetTaskIndex(Guid taskId)
        {
            for (var i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].Id == taskId)
                {
                    return i;
                }
            }

            return -1;
        }

        public QuestTask FindTask(Guid taskId)
        {
            for (var i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].Id == taskId)
                {
                    return Tasks[i];
                }
            }

            return null;
        }

        public class QuestTask
        {

            [NotMapped] [JsonIgnore] public EventBase EditingEvent;

            public QuestTask(Guid id)
            {
                Id = id;
            }

            public Guid Id { get; set; }

            public Guid CompletionEventId { get; set; }

            [JsonIgnore]
            public EventBase CompletionEvent
            {
                get => EventBase.Get(CompletionEventId);
                set => CompletionEventId = value.Id;
            }

            //# of npcs to kill, # of X item to collect, or for event driven this value should be 1
            public QuestObjective Objective { get; set; } = QuestObjective.EventDriven;

            public Guid TargetId { get; set; }

            public int Quantity { get; set; }

            public string Description { get; set; } = "";

            public string GetTaskString(Dictionary<int, LocalizedString> descriptions)
            {
                var taskString = "";
                switch (Objective)
                {
                    case QuestObjective.EventDriven: //Event Driven
                        taskString = descriptions[(int) Objective].ToString(Description);

                        break;
                    case QuestObjective.GatherItems: //Gather Items
                        taskString = descriptions[(int) Objective]
                            .ToString(ItemBase.GetName(TargetId), Quantity, Description);

                        break;
                    case QuestObjective.KillNpcs: //Kill Npcs
                        taskString = descriptions[(int) Objective]
                            .ToString(NpcBase.GetName(TargetId), Quantity, Description);

                        break;
                    case QuestObjective.VisitTile: //Go to Tile

                        var tempMapName = "Hmmm";
                        for (var i = 0; i < MapList.OrderedMaps.Count; i++)
                        {
                            if (MapList.OrderedMaps[i].MapId == MapId)
                            {
                                tempMapName = MapList.OrderedMaps[i].Name;
                                i = MapList.OrderedMaps.Count;
                            }
                        }
                        taskString = descriptions[(int) Objective]
                            .ToString(tempMapName, X, Y, Description, X+AreaWidth-1, Y+AreaHeight-1);

                        break;
                    case QuestObjective.KillNpcsWithTag: //KillNpcsWithTag
                        taskString = descriptions[(int)Objective]
                            .ToString(Tag, Quantity, Description);

                        break;
                    case QuestObjective.PressKey: //presskey
                        taskString = descriptions[(int)Objective]
                            .ToString(KeyPressed, Description);

                        break;
                    case QuestObjective.KillMultipleNpcs: //kill multiple npcs
                        taskString = "Kill: ";
                        for (var i = 0; i < mTargets.Count; i++)
                        {
                            taskString += descriptions[(int)Objective]
                            .ToString(NpcBase.GetName(mTargets[i]), mTargetsQuantity[i]) + " - ";
                        }
                        taskString += Description;

                        break;
                    case QuestObjective.GatherMultipleItems: //gather multiple items
                        taskString = "Gather: ";
                        for (var i = 0; i < mTargets.Count; i++)
                        {
                            taskString += descriptions[(int)Objective]
                            .ToString(ItemBase.GetName(mTargets[i]), mTargetsQuantity[i]) + " - ";
                        }
                        taskString += Description;

                        break;
                    case QuestObjective.ChooseItem: //choose item(s)
                        if (HasChoice)
                        {
                            taskString = "Choose Reward: ";
                        }
                        else
                        {
                            taskString = "Reward: ";
                        }
                        for (var i = 0; i < mTargets.Count; i++)
                        {
                            taskString += descriptions[(int)Objective]
                            .ToString(ItemBase.GetName(mTargets[i]), mTargetsQuantity[i]) + " - ";
                        }
                        if (Experience > 0)
                        {
                            taskString += "[Exp + " + Experience + "] ";
                        }
                        if (Tradeskill != Guid.Empty && TradeskillAmount > 0)
                        {
                            taskString += "[Skill " + TradeSkillBase.GetName(Tradeskill) + " + " + TradeskillAmount + "] ";
                        }
                        taskString += Description;

                        break;
                }

                return taskString;
            }

            //Visit Tile Data
            public Guid MapId { get; set; }

            public byte X { get; set; }

            public byte Y { get; set; }

            public WarpDirection Direction { get; set; } = WarpDirection.Retain;

            public int AreaWidth { get; set; }

            public int AreaHeight { get; set; }

            //NpcWithTag Data
            public string Tag { get; set; }

            //KeyPress
            public int KeyPressed { get; set; }

            //Multiple Tasks
            public List<Guid> mTargets { get; set; } = new List<Guid>();

            public List<int> mTargetsQuantity { get; set; } = new List<int>();

            //Choose Items
            public bool HasChoice { get; set; }

            //Reward Experience
            public int Experience { get; set; }

            //Reward Tradeskill
            public Guid Tradeskill { get; set; }

            public int TradeskillAmount { get; set; }
        }

    }

}
