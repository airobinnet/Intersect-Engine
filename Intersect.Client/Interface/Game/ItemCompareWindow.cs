using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Enums;
using Intersect.GameObjects;

using JetBrains.Annotations;

namespace Intersect.Client.Interface.Game
{

    public class ItemCompareWindow
    {

        ImagePanel mCompWindow;

        public ItemCompareWindow(
            [NotNull] ItemBase item,
            [NotNull] ItemBase originalitem,
            int amount,
            int x,
            int y,
            int[] statBuffs,
            int[] originalstatBuffs,
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

            mCompWindow = new ImagePanel(Interface.GameUi.GameCanvas, "ItemCompareWindow");
            if (item != null && item.ItemType == ItemTypes.Equipment)
            {
                mCompWindow.Name = "ItemCompareWindowExpanded";
            }

            if (item != null)
            {
                var icon = new ImagePanel(mCompWindow, "ItemIcon");

                var itemName = new Label(mCompWindow, "ItemNameLabel");
                itemName.Text = title;

                var itemQuantity = new Label(mCompWindow, "ItemQuantityLabel");

                if (amount > 1)
                {
                    itemQuantity.Text += amount.ToString("N0").Replace(",", Strings.Numbers.comma);
                }

                itemName.AddAlignment(Alignments.CenterH);

                var itemType = new Label(mCompWindow, "ItemTypeLabel");
                var itemValue = new Label(mCompWindow, "ItemValueLabel");

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

                var itemDesc = new RichLabel(mCompWindow, "ItemDescription");
                var itemDescText = new Label(mCompWindow, "ItemDescText");
                itemDescText.Font = itemDescText.Parent.Skin.DefaultFont;
                var itemStatsText = new Label(mCompWindow, item.ItemType == ItemTypes.Equipment ? "ItemStatsText" : "");
                itemStatsText.Font = itemStatsText.Parent.Skin.DefaultFont;
                var itemStats = new RichLabel(mCompWindow, item.ItemType == ItemTypes.Equipment ? "ItemStats" : "");
                itemDescText.IsHidden = true;
                itemStatsText.IsHidden = true;

                //Load this up now so we know what color to make the text when filling out the desc
                mCompWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
                if (item.Description.Length > 0)
                {
                    itemDesc.AddText(
                        Strings.ItemDesc.desc.ToString(item.Description), itemDesc.RenderColor,
                        itemDescText.CurAlignments.Count > 0 ? itemDescText.CurAlignments[0] : Alignments.Left,
                        itemDescText.Font
                    );

                    itemDesc.AddLineBreak();
                    itemDesc.AddLineBreak();
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
                        if (item.VitalsGiven[i] > originalitem.VitalsGiven[i])
                        {
                            bonus += " (+" + ((originalitem.VitalsGiven[i]-item.VitalsGiven[i])*-1).ToString() + ")";
                            var vitals = Strings.ItemDesc.vitals[i].ToString(bonus);
                            itemStats.AddText(
                                vitals, Color.Green,
                                itemStatsText.CurAlignments.Count > 0 ? itemStatsText.CurAlignments[0] : Alignments.Left,
                                itemDescText.Font
                            );
                        }
                        else if (item.VitalsGiven[i] < originalitem.VitalsGiven[i])
                        {
                            bonus += " (" + ((originalitem.VitalsGiven[i]-item.VitalsGiven[i])*-1).ToString() + ")";
                            var vitals = Strings.ItemDesc.vitals[i].ToString(bonus);
                            itemStats.AddText(
                                vitals, Color.Red,
                                itemStatsText.CurAlignments.Count > 0 ? itemStatsText.CurAlignments[0] : Alignments.Left,
                                itemDescText.Font
                            );
                        }
                        else
                        {
                            var vitals = Strings.ItemDesc.vitals[i].ToString(bonus);
                            itemStats.AddText(
                                vitals, itemStats.RenderColor,
                                itemStatsText.CurAlignments.Count > 0 ? itemStatsText.CurAlignments[0] : Alignments.Left,
                                itemDescText.Font
                            );
                        }


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
                            var originalflatStat = originalitem.StatsGiven[i] + originalstatBuffs[i];
                            if (flatStat > originalflatStat)
                            {
                            bonus += " (+" + ((originalflatStat-flatStat)*-1).ToString() + ")";
                                stats = Strings.ItemDesc.stats[i].ToString(bonus);
                                itemStats.AddText(
                                    stats, Color.Green,
                                    itemStatsText.CurAlignments.Count > 0
                                        ? itemStatsText.CurAlignments[0]
                                        : Alignments.Left, itemDescText.Font
                                );
                            }
                            else if (flatStat < originalflatStat)
                            {
                                bonus += " (" + ((originalflatStat-flatStat)*-1).ToString() + ")";
                                stats = Strings.ItemDesc.stats[i].ToString(bonus);
                                itemStats.AddText(
                                    stats, Color.Red,
                                    itemStatsText.CurAlignments.Count > 0
                                        ? itemStatsText.CurAlignments[0]
                                        : Alignments.Left, itemDescText.Font
                                );
                            }
                            else
                            {
                                bonus += " (" + ((originalflatStat - flatStat) * -1).ToString() + ")";
                                stats = Strings.ItemDesc.stats[i].ToString(bonus);
                                itemStats.AddText(
                                    stats, itemStats.RenderColor,
                                    itemStatsText.CurAlignments.Count > 0
                                        ? itemStatsText.CurAlignments[0]
                                        : Alignments.Left, itemDescText.Font
                                );
                            }

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
                mCompWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
                var itemTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Item, item.Icon);
                if (itemTex != null)
                {
                    icon.Texture = itemTex;
                }

                itemDesc.SizeToChildren(false, true);
                itemStats.SizeToChildren(false, true);
                itemDescText.IsHidden = true;
                itemStatsText.IsHidden = true;
                if (centerHorizontally)
                {
                    mCompWindow.MoveTo(x - mCompWindow.Width / 2, y + mCompWindow.Padding.Top);
                }
                else
                {
                    mCompWindow.MoveTo(x - mCompWindow.Width - mCompWindow.Padding.Right, y + mCompWindow.Padding.Top);
                }
            }
        }

        public void Dispose()
        {
            Interface.GameUi?.GameCanvas?.RemoveChild(mCompWindow, false);
            mCompWindow.Dispose();
        }

    }

}
