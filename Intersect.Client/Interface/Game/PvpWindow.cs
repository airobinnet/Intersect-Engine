using System;

using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;

namespace Intersect.Client.Interface.Game
{

    class PvpWindow
    {
        //Controls
        private WindowControl mPvpWindow;

        private Label currentLevel;

        private Label mInfoText;

        private ListBox mTopList;


        //Temp variables
        private string mTempName;

        //Init
        public PvpWindow(Canvas gameCanvas)
        {
            mPvpWindow = new WindowControl(gameCanvas, "PVP", false, "PvpWindow");
            mPvpWindow.DisableResizing();

            mInfoText = new Label(mPvpWindow, "InfoText");
            mInfoText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mInfoText.Text = "Your level is too low!! PVP starts at level 20!!!";

            currentLevel = new Label(mPvpWindow, "LevelText");
            currentLevel.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            currentLevel.Text = "Your level is " + Globals.Me.Level;

            mTopList = new ListBox(mPvpWindow, "TopList");

            UpdateList();

            mPvpWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
        }

        //Methods
        public void Update()
        {
            if (mPvpWindow.IsHidden)
            {
                return;
            }
            mInfoText.Hide();
            currentLevel.Hide();

            if (Globals.Me.Level < 20)
            {
                mInfoText.Text = "Your level is too low!! PVP starts at level 20!!!";
            }
            else
            {
                mInfoText.Text = "Go to Floor 1 and queue for 1vs1 Arena.\r\nOpen World pvp starts on Floor 3.";
            }
            mInfoText.Show();
            currentLevel.Show();
        }

        public void Show()
        {
            mPvpWindow.IsHidden = false;
        }

        public bool IsVisible()
        {
            return !mPvpWindow.IsHidden;
        }

        public void Hide()
        {
            mPvpWindow.IsHidden = true;
        }

        public void UpdateList()
        {
            //Clear previous instances if already existing
            if (mTopList != null)
            {
                mTopList.Clear();
            }
            /*foreach (var f in Globals.Me.PvpToplist)
            {
                var row = mTopList.AddRow(f);
                row.UserData = f;
                row.SetTextColor(Color.Green);
            }*/
        }

    }

}
