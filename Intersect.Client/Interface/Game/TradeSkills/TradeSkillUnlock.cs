using System;

using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Graphics;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.Framework.Gwen.Input;
using Intersect.Client.Framework.Input;
using Intersect.Client.General;
using Intersect.GameObjects.Crafting;
using Intersect.Client.Interface;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects;

using System.Collections.Generic;
using System.Dynamic;

using Intersect.Client.Core;
using Intersect.Enums;
using System.Linq;
using Newtonsoft.Json;

namespace Intersect.Client.Interface.Game.TradeSkills
{

    public class TradeSkillUnlock
    {

        public ImagePanel Container;

        private Label mNameText;

        private Label mLevelText;

        public ImagePanel PnlBackground;
        public ImagePanel Pnl;

        public ItemCompareWindow mCompWindow;

        public ItemDescWindow DescWindow;

        private SpellDescWindow spDescWindow;

        //Temp variables
        private string mTempName;


        //Mouse Event Variables
        private bool mMouseOver;

        private int mMouseX = -1;

        private int mMouseY = -1;

        //Slot info
        private Guid mIndex;

        private int LevelRequired;

        private int DamageIncrease;

        private long mLastUpdateTime;

        private int CurrentLevel;

        private int ThisLevel;

        //Drag/Drop References
        private TradeSkillInfoWindow mTradeSkillWindow;

        public TradeSkillUnlock(TradeSkillInfoWindow tradeSkillWindow, Guid index, int levelrequired, int currentlevel)
        {
            mTradeSkillWindow = tradeSkillWindow;
            mIndex = index;
            LevelRequired = levelrequired;
            CurrentLevel = currentlevel;
        }

        public TradeSkillUnlock(TradeSkillInfoWindow tradeSkillWindow, int damageincrease,int thislevel, int currentlevel)
        {
            mTradeSkillWindow = tradeSkillWindow;
            DamageIncrease = damageincrease;
            CurrentLevel = currentlevel;
            ThisLevel = thislevel;
        }

        public TradeSkillUnlock(TradeSkillInfoWindow tradeSkillWindow, Guid index, int damageincrease, int currentlevel, bool isskill)
        {
            mTradeSkillWindow = tradeSkillWindow;
            mIndex = index;
            DamageIncrease = damageincrease;
            CurrentLevel = currentlevel;
        }

        public void Setup()
        {
            mNameText = new Label(Container, "NameText");
            mNameText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mLevelText = new Label(Container, "LevelText");
            mLevelText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);

            PnlBackground = new ImagePanel(Container, "TradeSkillIconBg");
            Pnl = new ImagePanel(PnlBackground, "TradeSkillIcon");

            mLastUpdateTime = Globals.System.GetTimeMs();
        }

        public void LoadItem(bool isRep)
        {
            var UnlockData = ItemBase.Get(mIndex);
            var name = "";

            mLevelText.Text = "";

            if (UnlockData != null)
            {
                name = UnlockData.Name;
                if (isRep)
                {
                    mLevelText.Text = "" + (Standing)LevelRequired;
                }
                else
                {
                    mLevelText.Text = "Level: " + LevelRequired;
                }
                var itemTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Item, ItemBase.Get(UnlockData.Id).Icon);
                if (itemTex != null)
                {
                    Pnl.Texture = itemTex;
                    if (LevelRequired > CurrentLevel)
                    {
                        Pnl.RenderColor = new Color(100, 255, 255, 255);
                    }
                    else
                    {
                        Pnl.RenderColor = new Color(255, 255, 255, 255);
                    }
                }
                else
                {
                    if (Pnl.Texture != null)
                    {
                        Pnl.Texture = null;
                    }
                }
            }

            mNameText.Text = name.ToString();


            if (LevelRequired <= CurrentLevel)
            {
                mNameText.TextColor = Color.Green;
                mLevelText.TextColor = Color.Green;
            }
            else
            {
                mNameText.TextColor = Color.Red;
                mLevelText.TextColor = Color.Red;
            }
            Container.HoverEnter += pnl_HoverItemEnter;
            Container.HoverLeave += pnl_HoverLeave;
            Pnl.HoverEnter += pnl_HoverItemEnter;
            Pnl.HoverLeave += pnl_HoverLeave;
        }

        public void LoadCraft()
        {
            var UnlockData = CraftBase.Get(mIndex);
            var name = "";

            mLevelText.Text = "";

            if (UnlockData != null)
            {
                name = UnlockData.Name;
                mLevelText.Text = "Level: " + LevelRequired;
                var itemTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Item, ItemBase.Get(UnlockData.ItemId).Icon);
                if (itemTex != null)
                {
                    Pnl.Texture = itemTex;
                    if (LevelRequired > CurrentLevel)
                    {
                        Pnl.RenderColor = new Color(100, 255, 255, 255);
                    }
                    else
                    {
                        Pnl.RenderColor = new Color(255, 255, 255, 255);
                    }
                }
                else
                {
                    if (Pnl.Texture != null)
                    {
                        Pnl.Texture = null;
                    }
                }
            }

            mNameText.Text = name.ToString();


            if (LevelRequired <= CurrentLevel)
            {
                mNameText.TextColor = Color.Green;
                mLevelText.TextColor = Color.Green;
            }
            else
            {
                mNameText.TextColor = Color.Red;
                mLevelText.TextColor = Color.Red;
            }
            Container.HoverEnter += pnl_HoverCraftEnter;
            Container.HoverLeave += pnl_HoverLeave;
            Pnl.HoverEnter += pnl_HoverCraftEnter;
            Pnl.HoverLeave += pnl_HoverLeave;
        }


        public void LoadSkill()
        {
            var UnlockData = SpellBase.Get(mIndex);
            var ExtraDamage = 1 + (CurrentLevel * DamageIncrease) / 100;
            var name = "";

            mLevelText.Text = "";

            if (UnlockData != null)
            {
                name = UnlockData.Name;
                mLevelText.Text = "Damage +" + ExtraDamage;
                var itemTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Spell, UnlockData.Icon);
                if (itemTex != null)
                {
                    Pnl.Texture = itemTex;
                    Pnl.RenderColor = new Color(255, 255, 255, 255);
                }
                else
                {
                    if (Pnl.Texture != null)
                    {
                        Pnl.Texture = null;
                    }
                }
            }

            mNameText.Text = name.ToString();
            
            mNameText.TextColor = Color.Green;
            mLevelText.TextColor = Color.Green;
            Container.HoverEnter += pnl_spHoverEnter;
            Container.HoverLeave += pnl_spHoverLeave;
            Pnl.HoverEnter += pnl_spHoverEnter;
            Pnl.HoverLeave += pnl_spHoverLeave;
        }

        public void LoadDamage()
        {
            var ExtraDamage = 1 + (ThisLevel * DamageIncrease) / 100;
            var name = "";
            
            name = "Level " + ThisLevel.ToString();
            mLevelText.Text = "Damage +" + ExtraDamage;

            mNameText.Text = name.ToString();

            if (ThisLevel <= CurrentLevel)
            {
                mNameText.TextColor = Color.Green;
                mLevelText.TextColor = Color.Green;
            }
            else
            {
                mNameText.TextColor = Color.Red;
                mLevelText.TextColor = Color.Red;
            }
        }

        void pnl_HoverLeave(Base sender, EventArgs arguments)
        {
            mMouseOver = false;
            mMouseX = -1;
            mMouseY = -1;
            if (DescWindow != null)
            {
                DescWindow.Dispose();
                DescWindow = null;
            }
            if (mCompWindow != null)
            {
                mCompWindow.Dispose();
                mCompWindow = null;
            }
        }

        void pnl_HoverItemEnter(Base sender, EventArgs arguments)
        {
            if (InputHandler.MouseFocus != null)
            {
                return;
            }

            mMouseOver = true;

            if (Globals.InputManager.MouseButtonDown(GameInput.MouseButtons.Left))
            {

                return;
            }

            if (DescWindow != null)
            {
                DescWindow.Dispose();
                DescWindow = null;
            }
            if (mCompWindow != null)
            {
                mCompWindow.Dispose();
                mCompWindow = null;
            }

            if (mIndex != null && ItemBase.Get(mIndex) != null)
            {
                DescWindow = new ItemDescWindow(
                    ItemBase.Get(mIndex), 1, mTradeSkillWindow.X, mTradeSkillWindow.Y,
                    new int[(int)Stats.StatCount]
                );
                if (ItemBase.Get(mIndex).ItemType == Enums.ItemTypes.Equipment)
                {
                    var i = 0;
                    foreach (var equip in Globals.Me.Equipment)
                    {
                        if (ItemBase.Get(equip)?.EquipmentSlot == ItemBase.Get(mIndex).EquipmentSlot)
                        {
                            mCompWindow = new ItemCompareWindow(
                                           ItemBase.Get(equip), ItemBase.Get(mIndex), 1, mTradeSkillWindow.X,
                                           mTradeSkillWindow.Y, Globals.Me.Inventory[Globals.Me.MyEquipment[ItemBase.Get(equip).EquipmentSlot]].StatBuffs, ItemBase.Get(mIndex).StatsGiven, "", Strings.ItemDesc.equippeditem
                                        );
                            i++;
                        }
                    }
                }
            }
        }

        void pnl_HoverCraftEnter(Base sender, EventArgs arguments)
        {
            if (InputHandler.MouseFocus != null)
            {
                return;
            }

            mMouseOver = true;

            if (Globals.InputManager.MouseButtonDown(GameInput.MouseButtons.Left))
            {

                return;
            }

            if (DescWindow != null)
            {
                DescWindow.Dispose();
                DescWindow = null;
            }
            if (mCompWindow != null)
            {
                mCompWindow.Dispose();
                mCompWindow = null;
            }

            if (mIndex != null && CraftBase.Get(mIndex) != null)
            {
                DescWindow = new ItemDescWindow(
                    ItemBase.Get(CraftBase.Get(mIndex).ItemId), 1, mTradeSkillWindow.X, mTradeSkillWindow.Y,
                    new int[(int)Stats.StatCount]
                );
                if (ItemBase.Get(CraftBase.Get(mIndex).ItemId).ItemType == Enums.ItemTypes.Equipment)
                {
                    var i = 0;
                    foreach (var equip in Globals.Me.Equipment)
                    {
                        if (ItemBase.Get(equip)?.EquipmentSlot == ItemBase.Get(CraftBase.Get(mIndex).ItemId).EquipmentSlot)
                        {
                            mCompWindow = new ItemCompareWindow(
                                           ItemBase.Get(equip), ItemBase.Get(CraftBase.Get(mIndex).ItemId), 1, mTradeSkillWindow.X,
                                           mTradeSkillWindow.Y, Globals.Me.Inventory[Globals.Me.MyEquipment[ItemBase.Get(equip).EquipmentSlot]].StatBuffs, ItemBase.Get(CraftBase.Get(mIndex).ItemId).StatsGiven, "", Strings.ItemDesc.equippeditem
                                        );
                            i++;
                        }
                    }
                }
            }
        }

        void pnl_spHoverLeave(Base sender, EventArgs arguments)
        {
            mMouseOver = false;
            mMouseX = -1;
            mMouseY = -1;
            if (spDescWindow != null)
            {
                spDescWindow.Dispose();
                spDescWindow = null;
            }
        }

        void pnl_spHoverEnter(Base sender, EventArgs arguments)
        {
            if (InputHandler.MouseFocus != null)
            {
                return;
            }

            mMouseOver = true;

            if (spDescWindow != null)
            {
                spDescWindow.Dispose();
                spDescWindow = null;
            }

            spDescWindow = new SpellDescWindow(SpellBase.Get(mIndex).Id, mTradeSkillWindow.X, mTradeSkillWindow.Y);
        }

        public void Update()
        {
        }

    }

}
