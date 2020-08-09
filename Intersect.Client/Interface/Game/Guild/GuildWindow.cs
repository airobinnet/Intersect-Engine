using System;
using System.Collections.Generic;
using System.Dynamic;

using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.Enums;

using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Intersect.Client.Interface.Game.Guild
{

    public class GuildWindow
    {
        private Button mAddButton;

        private Button mAddPopupButton;

        private List<Button> mKickButtons = new List<Button>();

        private List<Label> mLblnames = new List<Label>();

        public List<GuildMember> GuildList = new List<GuildMember>();

        private ScrollControl mMemberContainer;

        private ImagePanel mLeader;

        private Label mNameText;

        private Label mTagText;

        private Label mRankText;

        private Button mLeaveCreateButton;

        private Button mAcceptInviteButton;

        private Button mDeclineInviteButton;

        private Button mCreateButton;

        //private ListBox mMembers;

        private int tempTimer = 99;

        private TextBox mSearchTextbox;

        //Temp variables
        private string mTempName;

        private ImagePanel mTextboxContainer;

        //Controls
        private WindowControl mGuildWindow;

        //Init
        public GuildWindow(Canvas gameCanvas)
        {
            PacketSender.SendRequestGuildInfo();

            mGuildWindow = new WindowControl(gameCanvas, Strings.Guilds.title, false, "GuildWindow");
            mGuildWindow.DisableResizing();
            
            mLeader = new ImagePanel(mGuildWindow, "LeaderIcon");
            mLeader.SetToolTipText(Globals.Me.GuildId.ToString());

            mNameText = new Label(mGuildWindow, "NameText");
            mNameText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mNameText.Text = Globals.Me.GuildName;

            mRankText = new Label(mGuildWindow, "RankText");
            mRankText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);

            mMemberContainer = new ScrollControl(mGuildWindow, "MemberContainer");
            mMemberContainer.EnableScroll(false, true);
            mMemberContainer.ShouldCacheToTexture = false;

            //mMembers = new ListBox(mGuildWindow, "MemberList");

            mTagText = new Label(mGuildWindow, "TagText");
            mTagText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mTagText.Text = Globals.Me.GuildTag;

            mLeaveCreateButton = new Button(mGuildWindow, "LeaveCreateGuildButton");
            mLeaveCreateButton.Text = "Create Guild";
            mLeaveCreateButton.SetToolTipText(Strings.Parties.leavetip);
            mLeaveCreateButton.Clicked += leavecreate_Clicked;

            mAcceptInviteButton = new Button(mGuildWindow, "AcceptInviteButton");
            mAcceptInviteButton.Text = "Accept Invite";
            mAcceptInviteButton.SetToolTipText("Accept Invite");
            mAcceptInviteButton.Clicked += AcceptInvite_Clicked;

            mDeclineInviteButton = new Button(mGuildWindow, "DeclineInviteButton");
            mDeclineInviteButton.Text = "Decline Invite";
            mDeclineInviteButton.SetToolTipText("Decline Invite");
            mDeclineInviteButton.Clicked += DeclineInvite_Clicked;

            mAddPopupButton = new Button(mGuildWindow, "AddMemberPopupButton");
            mAddPopupButton.IsHidden = true;
            mAddPopupButton.SetText(Strings.Guilds.addmember);
            mAddPopupButton.Clicked += addPopupButton_Clicked;

            UpdateList();

            mGuildWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
        }

        //Methods
        public void Update()
        {

            if (mGuildWindow.IsHidden)
            {
                return;
            }

            if (Globals.Me.GuildUpdate == true)
            {
                //PacketSender.SendRequestGuildInfo();
                Globals.Me.GuildUpdate = false;
                UpdateList();
            }

            mLeader.Hide();
            mNameText.Hide();
            mTagText.Hide();
            mLeaveCreateButton.Hide();
            mRankText.Hide();
            //mMembers.Hide();
            mAddPopupButton.Hide();
            mMemberContainer.Hide();
            mAcceptInviteButton.Hide();
            mDeclineInviteButton.Hide();

            if (Globals.Me.GuildName == null || Globals.Me.GuildName == "")
            {
                if (Globals.Me.GuildInviteName != null)
                {
                    mAcceptInviteButton.Show();
                    mDeclineInviteButton.Show();
                    mNameText.Text = "You have a pending invite to " + Globals.Me.GuildInviteTag + ":" + Globals.Me.GuildInviteName + " with " + Globals.Me.GuildInviteMembers + " members.";
                    mNameText.Show();
                }
                else
                {
                    mNameText.Text = "No guild info, join a guild first!";
                    mLeaveCreateButton.Text = "Create Guild";
                    mLeaveCreateButton.Show();
                    mNameText.Show();
                    mRankText.Hide();
                    //mMembers.Hide();
                    mAddPopupButton.Hide();
                    mMemberContainer.Hide();
                    mAcceptInviteButton.Hide();
                    mDeclineInviteButton.Hide();
                }
                
            } else
            {
                Globals.Me.GuildInvite = Guid.Empty;
                mNameText.Text = Globals.Me.GuildName;
                mTagText.Text = Globals.Me.GuildTag;
                mLeaveCreateButton.Text = "Leave Guild";
                mNameText.Show();
                mTagText.Show();
                mRankText.Show();
                mLeaveCreateButton.Show();
                //mMembers.Show();
                mMemberContainer.Show();
                mAcceptInviteButton.Hide();
                mDeclineInviteButton.Hide();
            }
            
            if (Globals.Me.GuildMembers != null)
            {
                var gMembers = JsonConvert.DeserializeObject<Dictionary<Guid, Guid>>(Globals.Me.GuildMembers);
                Guid RankId = gMembers[Globals.Me.Id];

                var RankInfo = JsonConvert.DeserializeObject<List<GuildRanks>>(Globals.Me.GuildRanks);
                
                var rankText = RankInfo.FirstOrDefault(n => n.Id == RankId);

                mRankText.Text = rankText.Title;

                if (rankText.Permissions.ContainsKey(GuildPermissions.InvitePlayers))
                {
                    mAddPopupButton.Show();
                }

                }
        }

        private class GuildRanks
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public Dictionary<GuildPermissions, bool> Permissions = new Dictionary<GuildPermissions, bool>();
        }

        public class GuildMembers
        {
            public string Name { get; set; }
            public Guid Id { get; set; }
            public Guid Rank { get; set; }
            public int Level { get; set; }
            public string Class { get; set; }
            public string Map { get; set; }
            public bool Online { get; set; }
        }

        public void Show()
        {
            mGuildWindow.IsHidden = false;
        }

        public bool IsVisible()
        {
            return !mGuildWindow.IsHidden;
        }

        public void UpdateList()
        {
            //Clear previous instances if already existing
            if (GuildList != null)
            {
                GuildList.Clear();
                mMemberContainer.Children.Clear();
            }
            if (Globals.Me.GuildMembersNames != null)
            {
                var tempList = JsonConvert.DeserializeObject<List<GuildMembers>>(Globals.Me.GuildMembersNames);
                for (var i = 0; i < tempList.Count; i++)
                {
                    GuildList.Add(new GuildMember(this, i));
                    GuildList[i].Container = new ImagePanel(mMemberContainer, "GuildMember");
                    GuildList[i].Setup();

                    GuildList[i].Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

                    GuildList[i].LoadItem();
                    GuildList[i].Container.SetPosition(
                    5,
                    i * 20
                    );
                }
            }
        }
        
        private void AddMember(Object sender, EventArgs e)
        {
            var ibox = (InputBox)sender;
            if (ibox.TextValue.Trim().Length >= 3) //Don't bother sending a packet less than the char limit
            {
                PacketSender.SendChatMsg("/guildinvite " + ibox.TextValue.ToString(), 0);
            }
        }

        void addPopupButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            var iBox = new InputBox(
                Strings.Guilds.addmember, Strings.Guilds.addmemberprompt, true, InputBox.InputType.TextInput,
                AddMember, null, 0
            );
        }

        void AcceptInvite_Clicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.SendChatMsg("/guildaccept", 0);
            Globals.Me.GuildInvite = Guid.Empty;
            Globals.Me.GuildInviteName = null;
            Globals.Me.GuildInviteTag = null;
            Update();
        }

        void DeclineInvite_Clicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.SendChatMsg("/guilddecline", 0);
            Globals.Me.GuildInvite = Guid.Empty;
            Globals.Me.GuildInviteName = null;
            Globals.Me.GuildInviteTag = null;
            Update();
        }

        private void CreateGuild(Object sender, EventArgs e)
        {
            var ibox = (InputBox)sender;
            if (ibox.TextValue.Trim().Length >= 3) //Don't bother sending a packet less than the char limit
            {
                PacketSender.SendChatMsg("/guildcreate " + ibox.TextValue.ToString(), 0);
            }
        }

        public void Hide()
        {
            mGuildWindow.IsHidden = true;
        }

        void leavecreate_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (Globals.Me.GuildName == null || Globals.Me.GuildName == "")
            {
                //create guild
                var iBox = new InputBox(
                Strings.Guilds.createguild, Strings.Guilds.createguildprompt, true, InputBox.InputType.TextInput,
                CreateGuild, null, 0
            );
            }
            else
            {
                //leave guild
                PacketSender.SendGuildLeave();
            }
        }

    }

}
