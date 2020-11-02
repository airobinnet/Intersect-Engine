using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Switches_and_Variables;
using JetBrains.Annotations;
using System;

namespace Intersect.Client.Interface.Game
{

    public class ItemDescWindow
    {

        ImagePanel mDescWindow;

        public ItemDescWindow(
            [NotNull] ItemBase item,
            int amount,
            int x,
            int y,
            int[] statBuffs,
            string titleOverride = "",
            string valueLabel = "",
            bool centerHorizontally = false
        )
        {
            var title = titleOverride;
            if (string.IsNullOrWhiteSpace(title))
            {
                title = item.Name;
            }

            mDescWindow = new ImagePanel(Interface.GameUi.GameCanvas, "ItemDescWindow");
            if (item != null && item.ItemType == ItemTypes.Equipment)
            {
                mDescWindow.Name = "ItemDescWindowExpanded";
            }

            if (item != null)
            {
                var icon = new ImagePanel(mDescWindow, "ItemIcon");

                var itemName = new Label(mDescWindow, "ItemNameLabel");
                itemName.Text = title;

                var itemQuantity = new Label(mDescWindow, "ItemQuantityLabel");

                if (amount > 1)
                {
                    itemQuantity.Text += amount.ToString("N0").Replace(",", Strings.Numbers.comma);
                }

                itemName.AddAlignment(Alignments.CenterH);

                var itemType = new Label(mDescWindow, "ItemTypeLabel");
                var itemValue = new Label(mDescWindow, "ItemValueLabel");

                itemType.Text = Strings.ItemDesc.itemtypes[(int) item.ItemType];
                itemValue.SetText(valueLabel);

                if (item.ItemType == ItemTypes.Equipment &&
                    item.EquipmentSlot >= 0 &&
                    item.EquipmentSlot < Options.EquipmentSlots.Count)
                {
                    itemType.Text = Options.EquipmentSlots[item.EquipmentSlot];
                    if (item.EquipmentSlot == Options.WeaponIndex && item.TwoHanded)
                    {
                        itemType.Text += " - " + Strings.ItemDesc.twohand;
                    }
                }

                if (item.Rarity > 0)
                {
                    itemType.Text += " - " + Strings.ItemDesc.rarity[item.Rarity];
                    var rarity = CustomColors.Items.Rarities.ContainsKey(item.Rarity)
                        ? CustomColors.Items.Rarities[item.Rarity]
                        : Color.White;

                    itemType.TextColorOverride.R = rarity.R;
                    itemType.TextColorOverride.G = rarity.G;
                    itemType.TextColorOverride.B = rarity.B;
                    itemType.TextColorOverride.A = rarity.A;
                }

                var itemDesc = new RichLabel(mDescWindow, "ItemDescription");
                var itemDescText = new Label(mDescWindow, "ItemDescText");
                itemDescText.Font = itemDescText.Parent.Skin.DefaultFont;
                var itemStatsText = new Label(mDescWindow, item.ItemType == ItemTypes.Equipment ? "ItemStatsText" : "");
                itemStatsText.Font = itemStatsText.Parent.Skin.DefaultFont;
                var itemStats = new RichLabel(mDescWindow, item.ItemType == ItemTypes.Equipment ? "ItemStats" : "");
                itemDescText.IsHidden = true;
                itemStatsText.IsHidden = true;

                //Load this up now so we know what color to make the text when filling out the desc
                mDescWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
                if (item.Description.Length > 0)
                {
                    itemDesc.AddText(
                        Strings.ItemDesc.desc.ToString(item.Description), itemDesc.RenderColor,
                        itemDescText.CurAlignments.Count > 0 ? itemDescText.CurAlignments[0] : Alignments.Left,
                        itemDescText.Font
                    );

                    itemDesc.AddLineBreak();
                    itemDesc.AddText(
                         " ", itemDesc.RenderColor,
                         itemDescText.CurAlignments.Count > 0 ? itemDescText.CurAlignments[0] : Alignments.Left,
                         itemDescText.Font
                     );
                    itemDesc.AddLineBreak();
                }
                var itemBase = item;
                for (var i = 0; i < itemBase.UsageRequirements.Lists.Count; i++)
                {
                    for (var j = 0; j < itemBase.UsageRequirements.Lists[i].Conditions.Count; j++)
                    {
                        var tempCondition = Strings.GetEventConditionalDesc((dynamic)itemBase.UsageRequirements.Lists[i].Conditions[j]) + "\n\r";
                        var tempColor = Color.Green;

                        var condition = (dynamic)itemBase.UsageRequirements.Lists[i].Conditions[j];
                        if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.TradeSkillHasLevel)
                        {
                            var hasSkill = false;
                            foreach (var tradeskill in Globals.Me.TradeSkills)
                            {
                                if (tradeskill.TradeSkillId == condition.TradeSkill)
                                {
                                    hasSkill = true;
                                    if (tradeskill.CurrentLevel < condition.TradeSkillLevel)
                                    {
                                        tempColor = Color.Red;
                                    }
                                }
                            }
                            if (!hasSkill)
                            {
                                tempColor = Color.Red;
                            }

                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.ClassIs)
                        {
                            if (Globals.Me.Class != condition.ClassId)
                            {
                                tempColor = Color.Red;
                            }
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.IsItemEquipped)
                        {
                            var HasItem = false;
                            for (var f = 0; f < Options.EquipmentSlots.Count; f++)
                            {
                                if (Globals.Me.Equipment[f] != Guid.Empty)
                                {
                                    if (Globals.Me.Equipment[f] == condition.ItemId)
                                    {
                                        HasItem = true;
                                    }
                                }
                            }
                            if (!HasItem)
                            {
                                tempColor = Color.Red;
                            }
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.VariableIs)
                        {
                            tempColor = Color.Gray;
                            tempCondition = "";
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.HasItem)
                        {
                            var HasItem = false;
                            for (var f = 0; f < Options.MaxInvItems; f++)
                            {
                                if (Globals.Me.Inventory[f] != null)
                                {
                                    if (Globals.Me.Inventory[f].ItemId == condition.ItemId)
                                    {
                                        HasItem = true;
                                    }
                                }
                            }
                            if (!HasItem)
                            {
                                tempColor = Color.Red;
                            }
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.HasItemWTag)
                        {
                            var tempcounter = 0;
                            var HasItem = false;
                            for (var g = 0; g < Options.MaxInvItems; g++)
                            {
                                if (Globals.Me.Inventory[g].ItemId != Guid.Empty)
                                {
                                    if (ItemBase.Get(Globals.Me.Inventory[g].ItemId).Tags?.Contains(condition.Tag))
                                    {
                                        if (Globals.Me.Inventory[g].Quantity >= condition.Quantity)
                                        {
                                            HasItem = true;
                                        }
                                        tempcounter++;
                                    }
                                }
                            }
                            if (tempcounter >= condition.Quantity)
                            {
                                HasItem = true;
                            }
                            if (!HasItem)
                            {
                                tempColor = Color.Red;
                            }
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.EquippedItemTagIs)
                        {
                            var HasItem = false;
                            for (var f = 0; f < Options.EquipmentSlots.Count; f++)
                            {
                                if (Globals.Me.Equipment[f] != Guid.Empty)
                                {
                                    if (ItemBase.Get(Globals.Me.Equipment[f]).Tags?.Contains(condition.Tag))
                                    {
                                        HasItem = true;
                                    }
                                }
                            }
                            if (!HasItem)
                            {
                                tempColor = Color.Red;
                            }
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.KnowsSpell)
                        {
                            var HasSpell = false;
                            for (var f = 0; f < Options.MaxPlayerSkills; f++)
                            {
                                if (Globals.Me.Spells[f].SpellId != Guid.Empty)
                                {
                                    if (SpellBase.Get(Globals.Me.Spells[f].SpellId).Id == condition.SpellId)
                                    {
                                        HasSpell = true;
                                    }
                                }
                            }
                            if (!HasSpell)
                            {
                                tempColor = Color.Red;
                            }
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.LevelOrStat)
                        {
                            var lvlStat = 0;
                            if (condition.ComparingLevel)
                            {
                                lvlStat = Globals.Me.Level;
                            }
                            else
                            {
                                lvlStat = Globals.Me.Stat[(int)condition.Stat];
                                if (condition.IgnoreBuffs)
                                {
                                    lvlStat = Globals.Me.Stat[(int)condition.Stat];
                                }
                            }

                            switch (condition.Comparator) //Comparator
                            {
                                case VariableComparators.Equal:
                                    if (lvlStat == condition.Value)
                                    {
                                    }
                                    else
                                    {
                                        tempColor = Color.Red;
                                    }

                                    break;
                                case VariableComparators.GreaterOrEqual:
                                    if (lvlStat >= condition.Value)
                                    {
                                    }
                                    else
                                    {
                                        tempColor = Color.Red;
                                    }

                                    break;
                                case VariableComparators.LesserOrEqual:
                                    if (lvlStat <= condition.Value)
                                    {
                                    }
                                    else
                                    {
                                        tempColor = Color.Red;
                                    }

                                    break;
                                case VariableComparators.Greater:
                                    if (lvlStat > condition.Value)
                                    {
                                    }
                                    else
                                    {
                                        tempColor = Color.Red;
                                    }

                                    break;
                                case VariableComparators.Less:
                                    if (lvlStat < condition.Value)
                                    {
                                    }
                                    else
                                    {
                                        tempColor = Color.Red;
                                    }

                                    break;
                                case VariableComparators.NotEqual:
                                    if (lvlStat != condition.Value)
                                    {
                                    }
                                    else
                                    {
                                        tempColor = Color.Red;
                                    }

                                    break;
                                default:
                                    tempColor = Color.Orange;
                                    break;
                            }
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.SelfSwitch)
                        {
                            tempColor = Color.Gray;
                            tempCondition = "";
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.AccessIs)
                        {
                            tempColor = Color.Gray;
                            tempCondition = "";
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.TimeBetween)
                        {
                            tempColor = Color.Gray;
                            tempCondition = "";
                        }

                        else if (itemBase.UsageRequirements.Lists[i].Conditions[j].Type == ConditionTypes.CanStartQuest)
                        {
                            tempColor = Color.Gray;
                            tempCondition = "";
                        }

                        else
                        {
                            tempColor = Color.Pink;
                            tempCondition = "";
                        }


                        itemDesc.AddText(
                               tempCondition, tempColor,
                               itemDescText.CurAlignments.Count > 0 ? itemDescText.CurAlignments[0] : Alignments.Left,
                         itemDescText.Font
                           );
                        if (tempCondition != "")
                        {
                            itemDesc.AddLineBreak();
                        }
                    }
                }

                var stats = "";
                if (item.ItemType == ItemTypes.Equipment)
                {
                    stats = Strings.ItemDesc.bonuses;
                    itemStats.AddText(
                        stats, itemStats.RenderColor,
                        itemStatsText.CurAlignments.Count > 0 ? itemStatsText.CurAlignments[0] : Alignments.Left,
                        itemDescText.Font
                    );

                    itemStats.AddLineBreak();
                    if (item.ItemType == ItemTypes.Equipment && item.EquipmentSlot == Options.WeaponIndex)
                    {
                        stats = Strings.ItemDesc.damage.ToString(item.Damage);
                        itemStats.AddText(
                            stats, itemStats.RenderColor,
                            itemStatsText.CurAlignments.Count > 0 ? itemStatsText.CurAlignments[0] : Alignments.Left,
                            itemDescText.Font
                        );

                        itemStats.AddLineBreak();
                    }

                    for (var i = 0; i < (int) Vitals.VitalCount; i++)
                    {
                        var bonus = item.VitalsGiven[i].ToString();
                        if (item.PercentageVitalsGiven[i] > 0)
                        {
                            if (item.VitalsGiven[i] > 0)
                            {
                                bonus += " + ";
                            }
                            else
                            {
                                bonus = "";
                            }

                            bonus += item.PercentageVitalsGiven[i] + "%";
                        }

                        var vitals = Strings.ItemDesc.vitals[i].ToString(bonus);
                        itemStats.AddText(
                            vitals, itemStats.RenderColor,
                            itemStatsText.CurAlignments.Count > 0 ? itemStatsText.CurAlignments[0] : Alignments.Left,
                            itemDescText.Font
                        );

                        itemStats.AddLineBreak();
                    }

                    if (statBuffs != null)
                    {
                        for (var i = 0; i < Options.MaxStats; i++)
                        {
                            var flatStat = item.StatsGiven[i] + statBuffs[i];
                            var bonus = flatStat.ToString();

                            if (item.PercentageStatsGiven[i] > 0)
                            {
                                if (flatStat > 0)
                                {
                                    bonus += " + ";
                                }
                                else
                                {
                                    bonus = "";
                                }

                                bonus += item.PercentageStatsGiven[i] + "%";
                            }

                            stats = Strings.ItemDesc.stats[i].ToString(bonus);
                            itemStats.AddText(
                                stats, itemStats.RenderColor,
                                itemStatsText.CurAlignments.Count > 0
                                    ? itemStatsText.CurAlignments[0]
                                    : Alignments.Left, itemDescText.Font
                            );

                            itemStats.AddLineBreak();
                        }
                    }
                }

                if (item.ItemType == ItemTypes.Equipment &&
                    item.Effect.Type != EffectType.None &&
                    item.Effect.Percentage > 0)
                {
                    itemStats.AddText(
                        Strings.ItemDesc.effect.ToString(
                            item.Effect.Percentage, Strings.ItemDesc.effects[(int) item.Effect.Type - 1]
                        ), itemStats.RenderColor,
                        itemStatsText.CurAlignments.Count > 0 ? itemStatsText.CurAlignments[0] : Alignments.Left,
                        itemDescText.Font
                    );
                }

                //Load Again for positioning purposes.
                mDescWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
                var itemTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Item, item.Icon);
                if (itemTex != null)
                {
                    icon.Texture = itemTex;
                }

                itemDesc.SizeToChildren(false, true);
                itemStats.SizeToChildren(false, true);
                itemDescText.IsHidden = true;
                itemStatsText.IsHidden = true;
                mDescWindow.SizeToChildren(true, true);
                if (centerHorizontally)
                {
                    mDescWindow.MoveTo(x - mDescWindow.Width / 2, y + mDescWindow.Padding.Top);
                }
                else
                {
                    mDescWindow.MoveTo(x - mDescWindow.Width - mDescWindow.Padding.Right, y + mDescWindow.Padding.Top);
                }
            }
        }

        public void Dispose()
        {
            Interface.GameUi?.GameCanvas?.RemoveChild(mDescWindow, false);
            mDescWindow.Dispose();
        }

    }

}
