using System;
using System.Collections.Generic;

using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.Enums;

namespace Intersect.Client.Interface.Game
{

    public class GuildWindow
    {
        private List<Button> mKickButtons = new List<Button>();

        private List<Label> mLblnames = new List<Label>();

        private ImagePanel mLeader;

        private Label mNameText;

        private Label mTagText;

        private Label mRankText;

        private Button mLeaveButton;

        //Controls
        private WindowControl mGuildWindow;

        //Init
        public GuildWindow(Canvas gameCanvas)
        {
            mGuildWindow = new WindowControl(gameCanvas, Strings.Guilds.title, false, "GuildWindow");
            mGuildWindow.DisableResizing();
            
            mLeader = new ImagePanel(mGuildWindow, "LeaderIcon");
            mLeader.SetToolTipText(Globals.Me.GuildId.ToString());

            mNameText = new Label(mGuildWindow, "NameText");
            mNameText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mNameText.Text = Globals.Me.GuildName;

            mRankText = new Label(mGuildWindow, "RankText");
            mRankText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mRankText.Text = "";

            mTagText = new Label(mGuildWindow, "TagText");
            mTagText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mTagText.Text = Globals.Me.GuildTag;

            mLeaveButton = new Button(mGuildWindow, "LeaveGuildButton");
            mLeaveButton.Text = "Leave Guild";
            mLeaveButton.SetToolTipText(Strings.Parties.leavetip);
            mLeaveButton.Clicked += leave_Clicked;

            mGuildWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
        }

        //Methods
        public void Update()
        {
            if (mGuildWindow.IsHidden)
            {
                return;
            }

            mLeader.Hide();
            mNameText.Hide();
            mTagText.Hide();
            mLeaveButton.Hide();

            if (Globals.Me.GuildName == null || Globals.Me.GuildName == "")
            {
                mNameText.Text = "No guild info, join a guild first!";
                mNameText.Show();
            } else
            {
                mNameText.Text = Globals.Me.GuildName;
                mTagText.Text = Globals.Me.GuildTag;
                mNameText.Show();
                mTagText.Show();
            }

            //var rank = player.Guild.GetRank(player);
        }

        public void Show()
        {
            mGuildWindow.IsHidden = false;
        }

        public bool IsVisible()
        {
            return !mGuildWindow.IsHidden;
        }

        public void Hide()
        {
            mGuildWindow.IsHidden = true;
        }

        //Input Handlers
        void kick_Clicked(Base sender, ClickedEventArgs arguments)
        {
            
        }

        void leave_Clicked(Base sender, ClickedEventArgs arguments)
        {
            
        }

    }

}
