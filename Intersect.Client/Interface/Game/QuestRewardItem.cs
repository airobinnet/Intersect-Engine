using System;

using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.Framework.Gwen.Input;
using Intersect.Client.Framework.Input;
using Intersect.Client.General;
using Intersect.Client.Items;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects;

namespace Intersect.Client.Interface.Game
{

    public class QuestRewardItem
    {

        public ImagePanel Container;

        public Label EquipLabel;

        public ImagePanel EquipPanel;

        public bool IsDragging;

        //Dragging
        private bool mCanDrag;

        private long mClickTime;

        private Label mCooldownLabel;

        private int mCurrentAmt = 0;

        private Guid mCurrentItemId;

        private ItemDescWindow mDescWindow;

        private ItemCompareWindow mCompWindow;

        private Draggable mDragIcon;

        private bool mIconCd;

        //Drag/Drop References
        private QuestsWindow mInventoryWindow;

        private bool mIsEquipped;

        //Mouse Event Variables
        private bool mMouseOver;

        private int mMouseX = -1;

        private int mMouseY = -1;

        //Slot info
        private int mMySlot;

        private ItemBase tempItem;

        private string mTexLoaded = "";

        public ImagePanel Pnl;

        private QuestBase mSelectedQuest;

        public int originalslot;

        public bool HasChoice;

        private Label mValue;

        private int Experience;

        private Guid TradeSkill;

        private int TradeSkillExperience;

        public QuestRewardItem(QuestsWindow inventoryWindow, int index, QuestBase selectedQuest, bool haschoice)
        {
            mInventoryWindow = inventoryWindow;
            mMySlot = index;
            mSelectedQuest = selectedQuest;
            HasChoice = haschoice;
        }

        public QuestRewardItem(QuestsWindow inventoryWindow, int experience)
        {
            mInventoryWindow = inventoryWindow;
            Experience = experience;
        }

        public QuestRewardItem(QuestsWindow inventoryWindow, Guid tradeskill, int tradeskillexperience)
        {
            mInventoryWindow = inventoryWindow;
            TradeSkill = tradeskill;
            TradeSkillExperience = tradeskillexperience;
        }

        public void Setup()
        {
            Pnl = new ImagePanel(Container, "ItemChoiceItemIcon");
            Pnl.HoverEnter += pnl_HoverEnter;
            Pnl.HoverLeave += pnl_HoverLeave;
            Pnl.RightClicked += pnl_RightClicked;
            Pnl.Clicked += pnl_Clicked;

            mValue = new Label(Container, "ItemChoiceItemAmount");
            for (var i = 0; i < mSelectedQuest.Tasks.Count; i++)
            {
                if (mSelectedQuest.Tasks[i].Id == Globals.Me.QuestProgress[mSelectedQuest.Id].TaskId)
                {
                    if (mSelectedQuest.Tasks[i].mTargets[mMySlot] != Guid.Empty)
                    {
                        mValue.Text = mSelectedQuest.Tasks[i].mTargetsQuantity[mMySlot].ToString();
                    }
                }
            }
        }


        public void SetupFixed()
        {
            Pnl = new ImagePanel(Container, "ItemChoiceItemIcon");
            Pnl.HoverEnter += pnl_HoverEnterFixed;
            Pnl.HoverLeave += pnl_HoverLeaveFixed;
            //Pnl.RightClicked += pnl_RightClicked;
            //Pnl.Clicked += pnl_Clicked;

            mValue = new Label(Container, "ItemChoiceItemAmount");
            
            if (TradeSkillExperience > 0)
            {
                mValue.Text = TradeSkillExperience.ToString();
                Pnl.SetToolTipText(TradeSkillBase.GetName(TradeSkill) + " +" + TradeSkillExperience.ToString());
            }
            if (Experience > 0)
            {
                mValue.Text = Experience.ToString();
                Pnl.SetToolTipText("+" + Experience.ToString() + " Experience");
            }
        }

        void pnl_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (HasChoice)
            {
                mInventoryWindow.Choice = mMySlot;
                mInventoryWindow.Update(true);
            }
        }

        void pnl_RightClicked(Base sender, ClickedEventArgs arguments)
        {
        }

        void pnl_HoverLeave(Base sender, EventArgs arguments)
        {
            mMouseOver = false;
            mMouseX = -1;
            mMouseY = -1;
            if (mDescWindow != null)
            {
                mDescWindow.Dispose();
                mDescWindow = null;
            }
            if (mCompWindow != null)
            {
                mCompWindow.Dispose();
                mCompWindow = null;
            }
        }

        void pnl_HoverLeaveFixed(Base sender, EventArgs arguments)
        {

        }

        void pnl_HoverEnterFixed(Base sender, EventArgs arguments)
        {
            
        }

        void pnl_HoverEnter(Base sender, EventArgs arguments)
        {
            if (InputHandler.MouseFocus != null)
            {
                return;
            }

            mMouseOver = true;
            mCanDrag = true;
            if (Globals.InputManager.MouseButtonDown(GameInput.MouseButtons.Left))
            {
                mCanDrag = false;

                return;
            }

            if (mDescWindow != null)
            {
                mDescWindow.Dispose();
                mDescWindow = null;
            }
            if (mCompWindow != null)
            {
                mCompWindow.Dispose();
                mCompWindow = null;
            }

            if (Globals.GameShop == null)
            {
                for (var i = 0; i < mSelectedQuest.Tasks.Count; i++)
                {
                    if (mSelectedQuest.Tasks[i].Id == Globals.Me.QuestProgress[mSelectedQuest.Id].TaskId)
                    {
                        if (mSelectedQuest.Tasks[i].mTargets[mMySlot] != Guid.Empty)
                        {
                            tempItem = ItemBase.Get(mSelectedQuest.Tasks[i].mTargets[mMySlot]);

                            mDescWindow = new ItemDescWindow(
                                tempItem, mSelectedQuest.Tasks[i].mTargetsQuantity[mMySlot], mInventoryWindow.X,
                                mInventoryWindow.Y, tempItem.StatsGiven
                            );
                            if (!Globals.Me.IsEquipped(mMySlot))
                            {
                                if (tempItem.ItemType == Enums.ItemTypes.Equipment)
                                {
                                    var j = 0;
                                    foreach (var equip in Globals.Me.Equipment)
                                    {
                                        if (ItemBase.Get(equip)?.EquipmentSlot == tempItem.EquipmentSlot)
                                        {
                                            mCompWindow = new ItemCompareWindow(
                                                           ItemBase.Get(equip), tempItem, Globals.Me.Inventory[mMySlot].Quantity, mInventoryWindow.X,
                                                           mInventoryWindow.Y, Globals.Me.Inventory[Globals.Me.MyEquipment[ItemBase.Get(equip).EquipmentSlot]]?.StatBuffs, Globals.Me.Inventory[mMySlot]?.StatBuffs, "", Strings.ItemDesc.equippeditem
                                                        );
                                            j++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public FloatRect RenderBounds()
        {
            var rect = new FloatRect()
            {
                X = Pnl.LocalPosToCanvas(new Point(0, 0)).X,
                Y = Pnl.LocalPosToCanvas(new Point(0, 0)).Y,
                Width = Pnl.Width,
                Height = Pnl.Height
            };

            return rect;
        }

        public void Update()
        {
            for (var i = 0; i < mSelectedQuest.Tasks.Count; i++)
            {
                if (mSelectedQuest.Tasks[i].Id == Globals.Me.QuestProgress[mSelectedQuest.Id].TaskId)
                {
                    if (mSelectedQuest.Tasks[i].mTargets[mMySlot] != Guid.Empty)
                    {
                        var item = ItemBase.Get(mSelectedQuest.Tasks[i].mTargets[mMySlot]);

                        if (item != null)
                        {
                            var itemTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Item, item.Icon);
                            if (itemTex != null)
                            {
                                Pnl.Texture = itemTex;
                            }
                            else
                            {
                                if (Pnl.Texture != null)
                                {
                                    Pnl.Texture = null;
                                }
                            }

                            mTexLoaded = item.Icon;
                        }
                        else
                        {
                            if (Pnl.Texture != null)
                            {
                                Pnl.Texture = null;
                            }

                            mTexLoaded = "";
                        }
                    }
                    else
                    {
                        Container.Hide();
                    }
                }
            }
            if (mDescWindow != null)
            {
                mDescWindow.Dispose();
                mDescWindow = null;
                pnl_HoverEnter(null, null);
            }

            if (mCompWindow != null)
            {
                mCompWindow.Dispose();
                mCompWindow = null;
                pnl_HoverEnter(null, null);
            }
        }

        public void UpdateFixed()
        {
            var tempIcon = "default.png";

            if (TradeSkillExperience > 0)
            {
                if (TradeSkillBase.Get(TradeSkill).TradeskillType == Enums.TradeSkillTypes.Reputation)
                {
                    tempIcon = "experiencereputation.png";
                }
                else
                {
                    tempIcon = "experienceskill.png";
                }
            }
            if (Experience > 0)
            {
                tempIcon = "experience.png";
            }
            var itemTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Item, tempIcon);
            if (itemTex != null)
            {
                Pnl.Texture = itemTex;
            }
            else
            {
                if (Pnl.Texture != null)
                {
                    Pnl.Texture = null;
                }
            }

            mTexLoaded = tempIcon;

            if (mDescWindow != null)
            {
                mDescWindow.Dispose();
                mDescWindow = null;
                pnl_HoverEnter(null, null);
            }

            if (mCompWindow != null)
            {
                mCompWindow.Dispose();
                mCompWindow = null;
                pnl_HoverEnter(null, null);
            }
        }
    }
}
