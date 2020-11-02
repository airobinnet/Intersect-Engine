using System;

using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Graphics;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.Framework.Gwen.Input;
using Intersect.Client.Framework.Input;
using Intersect.Client.General;
using Intersect.Client.Interface;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects;
using Intersect.Enums;

using System.Collections.Generic;
using System.Dynamic;

using Intersect.Client.Core;
using Intersect.Enums;
using System.Linq;
using Newtonsoft.Json;

namespace Intersect.Client.Interface.Game.TradeSkills
{

    public class TradeSkillItem
    {

        public ImagePanel Container;

        private Label mNameText;

        private Label mFolderText;

        private Label mLevelText;

        private Label mXPText;

        public ImagePanel ExpBackground;

        public ImagePanel ExpBar;

        public Label ExpLbl;

        public Label ExpTitle;

        public ImagePanel PnlBackground;
        public ImagePanel Pnl;

        //Temp variables
        private string mTempName;

        public float CurExpWidth;

        //Slot info
        private Guid mIndex;

        private long mLastUpdateTime;

        //Drag/Drop References
        private TradeSkillWindow mTradeSkillWindow;

        public TradeSkillItem(TradeSkillWindow tradeSkillWindow, Guid index)
        {
            mTradeSkillWindow = tradeSkillWindow;
            mIndex = index;
        }

        public void Setup()
        {
            mNameText = new Label(Container, "NameText");
            mNameText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mFolderText = new Label(Container, "FolderNameText");
            mFolderText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mLevelText = new Label(Container, "LevelText");
            mLevelText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mXPText = new Label(Container, "XPText");
            mXPText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);

            ExpBackground = new ImagePanel(Container, "EXPBackground");
            ExpBar = new ImagePanel(Container, "EXPBar");
            ExpTitle = new Label(Container, "EXPTitle");
            ExpTitle.SetText(Strings.EntityBox.exp);
            ExpLbl = new Label(Container, "EXPLabel");

            PnlBackground = new ImagePanel(Container, "TradeSkillIconBg");
            Pnl = new ImagePanel(PnlBackground, "TradeSkillIcon");

            mLastUpdateTime = Globals.System.GetTimeMs();
        }

        public void LoadItem()
        {
            var TradeSkillData = Globals.Me.TradeSkills.Where(ts => ts.TradeSkillId == mIndex).FirstOrDefault();
            var name = "";

            mFolderText.Hide();

            mLevelText.Text = "";

            if (TradeSkillData.Base != null)
            {
                var Category = TradeSkillData.Base.Folder;
                name = TradeSkillData.Base.Name;
                if (TradeSkillData.Base.TradeskillType == TradeSkillTypes.Reputation)
                {
                    mLevelText.Text = "Standing: " + (Standing)TradeSkillData.CurrentLevel;
                }
                else
                {
                    mLevelText.Text = "Level: " + TradeSkillData.CurrentLevel.ToString();
                }

                //var xptolevel = TradeSkillBase.Get(mIndex).XPBase + (TradeSkillBase.Get(mIndex).XPIncrease * TradeSkillData.CurrentLevel);
                var xptolevel = Math.Round(TradeSkillBase.Get(mIndex).XPBase * (decimal)Math.Pow(1 + ((double)TradeSkillBase.Get(mIndex).XPIncrease / 100), ((double)TradeSkillData.CurrentLevel - 1) / 3));

                var itemTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Item, TradeSkillData.Base.Icon);
                if (itemTex != null)
                {
                    Pnl.Texture = itemTex;
                    if (!TradeSkillData.Unlocked)
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


            if (TradeSkillData.Unlocked)
            {
                mNameText.TextColor = Color.Green;
                mLevelText.TextColor = Color.Green;
            }
            else
            {
                mNameText.TextColor = Color.Red;
                mLevelText.TextColor = Color.Red;
            }

            Container.Clicked += tradeskill_Clicked;
            Container.RightClicked += tradeskill_RightClicked;
        }

        private void UpdateXpBar(float elapsedTime)
        {

            var TradeSkillData = Globals.Me.TradeSkills.Where(ts => ts.TradeSkillId == mIndex).FirstOrDefault();
            //var NextLevelExperience = TradeSkillBase.Get(mIndex).XPBase + (TradeSkillBase.Get(mIndex).XPIncrease * TradeSkillData.CurrentLevel);
            var NextLevelExperience = Math.Round(TradeSkillBase.Get(mIndex).XPBase * (decimal)Math.Pow(1 + ((double)TradeSkillBase.Get(mIndex).XPIncrease / 100), ((double)TradeSkillData.CurrentLevel - 1) / 3));
            float targetExpWidth = 1;
            if (NextLevelExperience > 0)
            {
                targetExpWidth = (float)TradeSkillData.CurrentXp /
                                 (float)NextLevelExperience;

                ExpLbl.Text = TradeSkillData.CurrentXp + "/" + NextLevelExperience;
            }
            else
            {
                targetExpWidth = 1f;
                ExpLbl.Text = Strings.EntityBox.maxlevel;
            }

            targetExpWidth *= ExpBackground.Width;
            if (Math.Abs((int)targetExpWidth - CurExpWidth) < 0.01)
            {
                return;
            }

            if ((int)targetExpWidth > CurExpWidth)
            {
                CurExpWidth = targetExpWidth;
            }
            else
            {
                if (CurExpWidth < targetExpWidth)
                {
                    CurExpWidth = targetExpWidth;
                }
            }

            if (CurExpWidth == 0)
            {
                ExpBar.IsHidden = true;
            }
            else
            {
                ExpBar.Width = (int)CurExpWidth;
                ExpBar.SetTextureRect(0, 0, (int)CurExpWidth, ExpBar.Height);
                ExpBar.IsHidden = false;
            }
        }

        public void LoadFolder(string folder)
        {
            var name = folder;

            mFolderText.Show();
            mFolderText.Text = name.ToString();
            mFolderText.TextColor = Color.White;
            ExpBar.Hide();
            ExpBackground.Hide();
            ExpLbl.Hide();
            ExpTitle.Hide();
            mNameText.Hide();
        }

        void tradeskill_Clicked(Base sender, ClickedEventArgs arguments)
        {
            var clickedMember = (TradeSkillItem)sender.UserData;
            Interface.GameUi.OpenTradeSkillInfo(mIndex, mTradeSkillWindow.X, mTradeSkillWindow.Y);
        }

        void tradeskill_RightClicked(Base sender, ClickedEventArgs arguments)
        {
            
        }
        
        public void Update()
        {
            //Time since this window was last updated (for bar animations)
            var elapsedTime = (Globals.System.GetTimeMs() - mLastUpdateTime) / 1000.0f;

            UpdateXpBar(elapsedTime);

            mLastUpdateTime = Globals.System.GetTimeMs();
        }

    }

}
