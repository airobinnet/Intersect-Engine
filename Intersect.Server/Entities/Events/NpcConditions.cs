using System;
using System.Linq;

using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.GameObjects.Conditions;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Switches_and_Variables;
using Intersect.Server.General;
using Intersect.Server.Maps;

namespace Intersect.Server.Entities.Events
{

    public static class NpcConditions
    {

        public static bool CanSpawnPage(EventPage page, Entity player, Event activeInstance)
        {
            return MeetsConditionLists(page.ConditionLists, player, activeInstance);
        }

        public static bool MeetsConditionLists(
            ConditionLists lists,
            Entity player,
            Event eventInstance,
            bool singleList = true,
            QuestBase questBase = null
        )
        {
            if (player == null)
            {
                return false;
            }

            //If no condition lists then this passes
            if (lists.Lists.Count == 0)
            {
                return true;
            }

            for (var i = 0; i < lists.Lists.Count; i++)
            {
                if (MeetsConditionList(lists.Lists[i], player, eventInstance, questBase))

                //Checks to see if all conditions in this list are met
                {
                    //If all conditions are met.. and we only need a single list to pass then return true
                    if (singleList)
                    {
                        return true;
                    }

                    continue;
                }

                //If not.. and we need all lists to pass then return false
                if (!singleList)
                {
                    return false;
                }
            }

            //There were condition lists. If single list was true then we failed every single list and should return false.
            //If single list was false (meaning we needed to pass all lists) then we've made it.. return true.
            return !singleList;
        }

        public static bool MeetsConditionList(
            ConditionList list,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            for (var i = 0; i < list.Conditions.Count; i++)
            {
                var meetsCondition = MeetsCondition((dynamic)list.Conditions[i], player, eventInstance, questBase);
                if (list.Conditions[i].Negated)
                {
                    meetsCondition = !meetsCondition;
                }

                if (!meetsCondition)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool MeetsCondition(
            VariableIsCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            VariableValue value = null;
            if (condition.VariableType == VariableTypes.PlayerVariable)
            {
                return false;
            }
            else if (condition.VariableType == VariableTypes.ServerVariable)
            {
                value = ServerVariableBase.Get(condition.VariableId)?.Value;
            }

            if (value == null)
            {
                value = new VariableValue();
            }

            return CheckVariableComparison(value, (dynamic)condition.Comparison, player, eventInstance);
        }

        public static bool MeetsCondition(
            HasItemCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {

            return false;
        }

        public static bool MeetsCondition(
            HasItemWTagCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        public static bool MeetsCondition(
            EquippedItemTagIsCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        public static bool MeetsCondition(
            ClassIsCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        public static bool MeetsCondition(
            KnowsSpellCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        public static bool MeetsCondition(
            LevelOrStatCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            var lvlStat = 0;
            if (condition.ComparingLevel)
            {
                lvlStat = player.Level;
            }
            else
            {
                lvlStat = player.Stat[(int)condition.Stat].Value();
                if (condition.IgnoreBuffs)
                {
                    lvlStat = player.Stat[(int)condition.Stat].BaseStat +
                              player.StatPointAllocations[(int)condition.Stat];
                }
            }

            switch (condition.Comparator) //Comparator
            {
                case VariableComparators.Equal:
                    if (lvlStat == condition.Value)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.GreaterOrEqual:
                    if (lvlStat >= condition.Value)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.LesserOrEqual:
                    if (lvlStat <= condition.Value)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.Greater:
                    if (lvlStat > condition.Value)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.Less:
                    if (lvlStat < condition.Value)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.NotEqual:
                    if (lvlStat != condition.Value)
                    {
                        return true;
                    }

                    break;
            }

            return false;
        }

        public static bool MeetsCondition(
            SelfSwitchCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            if (eventInstance != null)
            {
                if (eventInstance.Global)
                {
                    var evts = MapInstance.Get(eventInstance.MapId).GlobalEventInstances.Values.ToList();
                    for (var i = 0; i < evts.Count; i++)
                    {
                        if (evts[i] != null && evts[i].BaseEvent == eventInstance.BaseEvent)
                        {
                            return evts[i].SelfSwitch[condition.SwitchIndex] == condition.Value;
                        }
                    }
                }
                else
                {
                    return eventInstance.SelfSwitch[condition.SwitchIndex] == condition.Value;
                }
            }

            return false;
        }

        public static bool MeetsCondition(
            AccessIsCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        public static bool MeetsCondition(
            TimeBetweenCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            if (condition.Ranges[0] > -1 &&
                condition.Ranges[1] > -1 &&
                condition.Ranges[0] < 1440 / TimeBase.GetTimeBase().RangeInterval &&
                condition.Ranges[1] < 1440 / TimeBase.GetTimeBase().RangeInterval)
            {
                return Time.GetTimeRange() >= condition.Ranges[0] && Time.GetTimeRange() <= condition.Ranges[1];
            }

            return true;
        }

        public static bool MeetsCondition(
            CanStartQuestCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        public static bool MeetsCondition(
            QuestInProgressCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        public static bool MeetsCondition(
            QuestCompletedCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        public static bool MeetsCondition(
            NoNpcsOnMapCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            var map = MapInstance.Get(eventInstance?.MapId ?? Guid.Empty);
            if (map == null)
            {
                map = MapInstance.Get(player.MapId);
            }

            if (map != null)
            {
                var entities = map.GetEntities();
                foreach (var en in entities)
                {
                    if (en.GetType() == typeof(Npc))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public static bool MeetsCondition(
            MapHasNPCWTag condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            // Get the map our event is handled on, or if that fails the one our player is on.
            var map = MapInstance.Get(eventInstance?.MapId ?? Guid.Empty);
            if (map == null)
            {
                map = MapInstance.Get(player.MapId);
            }

            // if we have a map, actually process the condition.
            if (map != null)
            {
                // Go through all our map entities and loook for any NPCs, if we have one check to see if they have a matching tag.
                foreach (var en in map.GetEntities())
                {
                    if (en.GetType() == typeof(Npc))
                    {
                        var npc = (Npc)en;
                        if (npc.Base.Tags.Contains(condition.Tag))
                        {
                            return true;
                        }
                    }

                }
            }

            return false;
        }

        public static bool MeetsCondition(
            GenderIsCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }
        /*
        public static bool MeetsCondition(
            HasStatusEffectCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {

            return player.Statuses.ContainsKey(SpellBase.Get(condition.SpellId));
        }*/

        public static bool MeetsCondition(
            MapIsCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return player.MapId == condition.MapId;
        }

        public static bool MeetsCondition(
            MapHasTag condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return player.Map.Tags.Contains(condition.Tag);
        }

        public static bool MeetsCondition(
            IsItemEquippedCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        public static bool MeetsCondition(
            HasFreeInventorySlots condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        //Variable Comparison Processing
        public static bool CheckVariableComparison(
            VariableValue currentValue,
            VariableCompaison comparison,
            Entity player,
            Event instance
        )
        {
            return false;
        }

        public static bool CheckVariableComparison(
            VariableValue currentValue,
            BooleanVariableComparison comparison,
            Entity player,
            Event instance
        )
        {
            VariableValue compValue = null;
            if (comparison.CompareVariableId != Guid.Empty)
            {
                if (comparison.CompareVariableType == VariableTypes.PlayerVariable)
                {
                    return false;
                }
                else if (comparison.CompareVariableType == VariableTypes.ServerVariable)
                {
                    compValue = ServerVariableBase.Get(comparison.CompareVariableId)?.Value;
                }
            }
            else
            {
                compValue = new VariableValue();
                compValue.Boolean = comparison.Value;
            }

            if (compValue == null)
            {
                compValue = new VariableValue();
            }

            if (currentValue.Type == 0)
            {
                currentValue.Boolean = false;
            }

            if (compValue.Type != currentValue.Type)
            {
                return false;
            }

            if (comparison.ComparingEqual)
            {
                return currentValue.Boolean == compValue.Boolean;
            }
            else
            {
                return currentValue.Boolean != compValue.Boolean;
            }
        }

        public static bool CheckVariableComparison(
            VariableValue currentValue,
            IntegerVariableComparison comparison,
            Entity player,
            Event instance
        )
        {
            long compareAgainst = 0;

            VariableValue compValue = null;
            if (comparison.CompareVariableId != Guid.Empty)
            {
                if (comparison.CompareVariableType == VariableTypes.PlayerVariable)
                {
                    return false;
                }
                else if (comparison.CompareVariableType == VariableTypes.ServerVariable)
                {
                    compValue = ServerVariableBase.Get(comparison.CompareVariableId)?.Value;
                }
            }
            else
            {
                compValue = new VariableValue();
                compValue.Integer = comparison.Value;
            }

            if (compValue == null)
            {
                compValue = new VariableValue();
            }

            if (currentValue.Type == 0)
            {
                currentValue.Integer = 0;
            }

            if (compValue.Type != currentValue.Type)
            {
                return false;
            }

            var varVal = currentValue.Integer;
            compareAgainst = compValue.Integer;

            switch (comparison.Comparator) //Comparator
            {
                case VariableComparators.Equal:
                    if (varVal == compareAgainst)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.GreaterOrEqual:
                    if (varVal >= compareAgainst)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.LesserOrEqual:
                    if (varVal <= compareAgainst)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.Greater:
                    if (varVal > compareAgainst)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.Less:
                    if (varVal < compareAgainst)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.NotEqual:
                    if (varVal != compareAgainst)
                    {
                        return true;
                    }

                    break;
            }

            return false;
        }

        public static bool CheckVariableComparison(
            VariableValue currentValue,
            StringVariableComparison comparison,
            Entity player,
            Event instance
        )
        {
            return false;
        }

        public static bool MeetsCondition(
             TradeSkillHasLevelCondition condition,
             Player player,
             Event eventInstance,
             QuestBase questBase
         )
        {
            return false;
        }


        public static bool MeetsCondition(
            HasTradeSkillCondition condition,
            Player player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            return false;
        }

        public static bool MeetsCondition(
            HporManaCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {
            var lvlStat = 0;
            lvlStat = player.GetVital((int)condition.Vital);

            switch (condition.Comparator) //Comparator
            {
                case VariableComparators.Equal:
                    if (lvlStat == condition.Value)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.GreaterOrEqual:
                    if (lvlStat >= condition.Value)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.LesserOrEqual:
                    if (lvlStat <= condition.Value)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.Greater:
                    if (lvlStat > condition.Value)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.Less:
                    if (lvlStat < condition.Value)
                    {
                        return true;
                    }

                    break;
                case VariableComparators.NotEqual:
                    if (lvlStat != condition.Value)
                    {
                        return true;
                    }

                    break;
            }

            return false;
        }


        public static bool MeetsCondition(
            HasStatusEffectCondition condition,
            Entity player,
            Event eventInstance,
            QuestBase questBase
        )
        {

            return player.HasStatusEffect(condition.SpellId);
        }
    }

}