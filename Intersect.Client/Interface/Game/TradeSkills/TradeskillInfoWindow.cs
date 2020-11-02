using System;
using System.Collections.Generic;

using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Interface.Game.Chat;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects;
using Intersect.GameObjects.Crafting;
using Intersect.Enums;

using System.Linq;

namespace Intersect.Client.Interface.Game.TradeSkills
{

    public class TradeSkillInfoWindow
    {
        private TradeSkillUnlock mCombinedItem;

        private Label mCombinedValue;

        private Guid mTradeSkillId;

        //Controls
        private WindowControl mTradeSkillInfoWindow;

        private bool mInitialized = false;

        private List<TradeSkillUnlock> mItems = new List<TradeSkillUnlock>();

        private ImagePanel mTradeSkillIcon;

        private Label mLblTradeSkillInfo;

        private Label mLblTradeSkillName;

        private Label mLblUnlocks;

        private ScrollControl mTradeSkillUnlockContainer;

        private int tempX;

        private int tempY;

        //Objects
        private ListBox mRecipes;

        private List<Label> mValues = new List<Label>();

        public TradeSkillInfoWindow(Canvas gameCanvas, Guid tradeskill, int x, int y)
        {
            mTradeSkillId = tradeskill;
            mTradeSkillInfoWindow = new WindowControl(gameCanvas, "Info", false, "TradeSkillInfoWindow");
            mTradeSkillInfoWindow.DisableResizing();

            //Labels
            mLblUnlocks = new Label(mTradeSkillInfoWindow, "Unlocks");
            mLblTradeSkillInfo = new Label(mTradeSkillInfoWindow, "TradeSkillInfo");
            mLblTradeSkillName = new Label(mTradeSkillInfoWindow, "TradeSkillName");


            mTradeSkillUnlockContainer = new ScrollControl(mTradeSkillInfoWindow, "TradeSkillUnlockContainer");
            mTradeSkillUnlockContainer.EnableScroll(false, true);
            mTradeSkillUnlockContainer.ShouldCacheToTexture = false;

            Close();

            mTradeSkillInfoWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

            LoadTradeSkillInfo(mTradeSkillId);

            tempX = x;
            tempY = y;

            mTradeSkillInfoWindow.MoveTo(x - mTradeSkillInfoWindow.Width - mTradeSkillInfoWindow.Padding.Right, y + mTradeSkillInfoWindow.Padding.Top);
        }

        //Location
        public int X => mTradeSkillInfoWindow.X;

        public int Y => mTradeSkillInfoWindow.Y;

        private void LoadTradeSkillInfo(Guid tradeskillid)
        {
            
        }

        public void Close()
        {
            mTradeSkillInfoWindow.Close();
        }

        public bool IsVisible()
        {
            return !mTradeSkillInfoWindow.IsHidden;
        }

        public void Hide()
        {
            mTradeSkillInfoWindow.IsHidden = true;
        }

        //Send a Craftrequest
        void craft_Clicked(Base sender, ClickedEventArgs arguments)
        { 
        }

        public void Move(int x, int y)
        {

            mTradeSkillInfoWindow.MoveTo(x - mTradeSkillInfoWindow.Width - mTradeSkillInfoWindow.Padding.Right, y + mTradeSkillInfoWindow.Padding.Top);
        }
        
        public void Update()
        {

            mTradeSkillInfoWindow.MoveTo(tempX - mTradeSkillInfoWindow.Width - mTradeSkillInfoWindow.Padding.Right, tempY + mTradeSkillInfoWindow.Padding.Top);
            if (!mInitialized)
            {
                //Clear previous instances if already existing
                if (mItems != null)
                {
                    mItems.Clear();
                }

                if (mTradeSkillId != Guid.Empty)
                {
                    var TradeSkillData = Globals.Me.TradeSkills.Where(ts => ts.TradeSkillId == mTradeSkillId).FirstOrDefault();
                    var TempTs = TradeSkillBase.Get(mTradeSkillId);

                    mLblTradeSkillName.Text = TempTs.Folder + ": " + TempTs.Name;

                    if (TempTs.TradeskillType == TradeSkillTypes.Reputation)
                    {
                        mLblTradeSkillInfo.Text = "Standing: " + (Standing)TradeSkillData.CurrentLevel + " - Max Standing: " + (Standing)Math.Min(TempTs.MaxLevel, Enum.GetNames(typeof(Standing)).Length-1);
                    }
                    else
                    {
                        mLblTradeSkillInfo.Text = "Level: " + TradeSkillData.CurrentLevel + " - Max level: " + TempTs.MaxLevel;
                    }


                    var i = 0;

                    if (TempTs.TradeskillType == TradeSkillTypes.Craft)
                    {

                        mLblUnlocks.Text = "Craft Unlocks";
                        foreach (var tradeskill in TempTs.CraftUnlocks)
                        {
                            mItems.Add(new TradeSkillUnlock(this, tradeskill.CraftId, tradeskill.LevelRequired, TradeSkillData.CurrentLevel));
                            mItems[i].Container = new ImagePanel(mTradeSkillUnlockContainer, "TradeSkillUnlocks");
                            mItems[i].Setup();

                            mItems[i].Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

                            mItems[i].LoadCraft();
                            mItems[i].Update();
                            mItems[i].Container.SetPosition(
                            5,
                            i * 40
                            );
                            i++;
                        }
                    }
                    else if (TempTs.TradeskillType == TradeSkillTypes.Weapon)
                    {

                        mLblUnlocks.Text = "Weapon Progress";
                        for (var j = 0; j < TradeSkillData.CurrentLevel + 10; j++)
                        {
                            mItems.Add(new TradeSkillUnlock(this, TradeSkillData.Base.WeaponUnlocks[0].DamageIncrease, j, TradeSkillData.CurrentLevel));
                            mItems[j].Container = new ImagePanel(mTradeSkillUnlockContainer, "TradeSkillUnlocks");
                            mItems[j].Setup();

                            mItems[j].Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

                            mItems[j].LoadDamage();
                            mItems[j].Update();
                            mItems[j].Container.SetPosition(
                            5,
                            j * 40
                            );
                        }
                    }
                    else if (TempTs.TradeskillType == TradeSkillTypes.Spell)
                    {
                        mLblUnlocks.Text = "Skill Progress";
                        foreach (var tradeskill in TempTs.SkillUnlocks)
                        {
                            mItems.Add(new TradeSkillUnlock(this, tradeskill.Skill, tradeskill.DamageIncrease, TradeSkillData.CurrentLevel, true));
                            mItems[i].Container = new ImagePanel(mTradeSkillUnlockContainer, "TradeSkillUnlocks");
                            mItems[i].Setup();

                            mItems[i].Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

                            mItems[i].LoadSkill();
                            mItems[i].Update();
                            mItems[i].Container.SetPosition(
                            5,
                            i * 40
                            );
                            i++;
                        }
                    }
                    else if (TempTs.TradeskillType == TradeSkillTypes.Reputation)
                    {

                        mLblUnlocks.Text = "Reputation Unlocks";
                        foreach (var tradeskill in TempTs.ReputationUnlocks)
                        {
                            mItems.Add(new TradeSkillUnlock(this, tradeskill.ItemId, tradeskill.LevelRequired, TradeSkillData.CurrentLevel));
                            mItems[i].Container = new ImagePanel(mTradeSkillUnlockContainer, "TradeSkillUnlocks");
                            mItems[i].Setup();

                            mItems[i].Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

                            mItems[i].LoadItem(true);
                            mItems[i].Update();
                            mItems[i].Container.SetPosition(
                            5,
                            i * 40
                            );
                            i++;
                        }
                    }
                }
                mInitialized = true;
            }
        }

    }

}
