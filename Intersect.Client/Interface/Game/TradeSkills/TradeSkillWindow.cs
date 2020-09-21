using System;
using System.Collections.Generic;
using System.Dynamic;

using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.GameObjects;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.Enums;

using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Intersect.Client.Interface.Game.TradeSkills
{

    public class TradeSkillWindow
    {
        public List<TradeSkillItem> TradeSkillList = new List<TradeSkillItem>();

        private ScrollControl mTradeSkillContainer;

        //Temp variables
        private string mTempName;

        //Controls
        private WindowControl mTradeSkillWindow;

        private int sortMode = 0;

        private long mLastUpdateTime;

        public int X => mTradeSkillWindow.X;

        public int Y => mTradeSkillWindow.Y;

        //Init
        public TradeSkillWindow(Canvas gameCanvas)
        {
            mTradeSkillWindow = new WindowControl(gameCanvas, "TradeSkills", false, "TradeSkillWindow");
            mTradeSkillWindow.DisableResizing();

            mTradeSkillContainer = new ScrollControl(mTradeSkillWindow, "TradeSkillContainer");
            mTradeSkillContainer.EnableScroll(false, true);
            mTradeSkillContainer.ShouldCacheToTexture = false;

            mTradeSkillWindow.AfterDraw += MoveChild;

            UpdateList();

            mTradeSkillWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());


            mLastUpdateTime = Globals.System.GetTimeMs();
        }

        //Methods
        public void Update()
        {

            if (mTradeSkillWindow.IsHidden)
            {
                return;
            }
        }

        public void Show()
        {
            mTradeSkillWindow.IsHidden = false;
        }

        public bool IsVisible()
        {
            return !mTradeSkillWindow.IsHidden;
        }

        void MoveChild(Base sender, EventArgs arguments)
        {
            Interface.GameUi.MoveTradeSkillInfo(mTradeSkillWindow.X, mTradeSkillWindow.Y);
        }

        public void UpdateList()
        {

            //Clear previous instances if already existing
            if (TradeSkillList != null)
            {
                TradeSkillList.Clear();
                mTradeSkillContainer.Children.Clear();
            }

            if (Globals.Me.TradeSkills != null)
            {
                List<string> Folders = new List<string>();

                foreach (var itm in TradeSkillBase.ItemPairs)
                {
                    bool alreadyExist = Folders.Contains(TradeSkillBase.Get(itm.Key).Folder);
                    if (!alreadyExist)
                    {
                        Folders.Add(TradeSkillBase.Get(itm.Key).Folder);
                    }
                }
                var i = 0;
                var MaxTradeSkills = Options.MaxTradeSkills;

                foreach (var folder in Folders)
                {
                    TradeSkillList.Add(new TradeSkillItem(this, Guid.Empty));
                    TradeSkillList[i].Container = new ImagePanel(mTradeSkillContainer, "TradeSkill");
                    TradeSkillList[i].Setup();

                    TradeSkillList[i].Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

                    TradeSkillList[i].LoadFolder(folder);
                    TradeSkillList[i].Container.SetPosition(
                    5,
                    i * 40
                    );
                    i++;
                    MaxTradeSkills++;
                    foreach (var tradeskill in Globals.Me.TradeSkills.Where(ts => ts.Base?.Folder == folder))
                    {
                        TradeSkillList.Add(new TradeSkillItem(this, tradeskill.TradeSkillId));
                        TradeSkillList[i].Container = new ImagePanel(mTradeSkillContainer, "TradeSkill");
                        TradeSkillList[i].Setup();

                        TradeSkillList[i].Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

                        TradeSkillList[i].LoadItem();
                        TradeSkillList[i].Update();
                        TradeSkillList[i].Container.SetPosition(
                        5,
                        i * 40
                        );
                        i++;
                    }
                }
            }
        }

        public void Hide()
        {
            mTradeSkillWindow.IsHidden = true;
        }
    }

}
