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

namespace Intersect.Client.Interface.Game
{

    public class GuildWindow
    {
        private Button mAddButton;

        private Button mAddPopupButton;

        private List<Button> mKickButtons = new List<Button>();

        private List<Label> mLblnames = new List<Label>();

        private ImagePanel mLeader;

        private Label mNameText;

        private Label mTagText;

        private Label mRankText;

        private Button mLeaveCreateButton;

        private Button mCreateButton;

        private ListBox mMembers;

        private int tempTimer = 1000;

        private TextBox mSearchTextbox;

        //Temp variables
        private string mTempName;

        private ImagePanel mTextboxContainer;

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

            mMembers = new ListBox(mGuildWindow, "MemberList");

            mTagText = new Label(mGuildWindow, "TagText");
            mTagText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mTagText.Text = Globals.Me.GuildTag;

            mLeaveCreateButton = new Button(mGuildWindow, "LeaveCreateGuildButton");
            mLeaveCreateButton.Text = "Create Guild";
            mLeaveCreateButton.SetToolTipText(Strings.Parties.leavetip);
            mLeaveCreateButton.Clicked += leavecreate_Clicked;

            /*mAddButton = new Button(mGuildWindow, "AddMemberButton");
            mAddButton.SetText("+");
            mAddButton.Clicked += addButton_Clicked;*/

            /*mTextboxContainer = new ImagePanel(mGuildWindow, "SearchContainer");
            mSearchTextbox = new TextBox(mTextboxContainer, "SearchTextbox");
            Interface.FocusElements.Add(mSearchTextbox);*/

            mAddPopupButton = new Button(mGuildWindow, "AddMemberPopupButton");
            mAddPopupButton.IsHidden = true;
            mAddPopupButton.SetText(Strings.Guilds.addmember);
            mAddPopupButton.Clicked += addPopupButton_Clicked;

            mGuildWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
        }

        //Methods
        public void Update()
        {

            if (mGuildWindow.IsHidden)
            {
                return;
            }

            if (tempTimer >= 1000)
            {
                PacketSender.SendRequestGuildInfo();
                UpdateList();
                tempTimer = 0;
            }

            UpdateList();

            mLeader.Hide();
            mNameText.Hide();
            mTagText.Hide();
            mLeaveCreateButton.Hide();
            mRankText.Hide();
            mMembers.Hide();
            mAddPopupButton.Hide();

            if (Globals.Me.GuildName == null || Globals.Me.GuildName == "")
            {
                mNameText.Text = "No guild info, join a guild first!";
                mLeaveCreateButton.Text = "Create Guild";
                mLeaveCreateButton.Show();
                mNameText.Show();
                mRankText.Hide();
                mMembers.Hide();
                mAddPopupButton.Hide();
            } else
            {
                mNameText.Text = Globals.Me.GuildName;
                mTagText.Text = Globals.Me.GuildTag;
                mLeaveCreateButton.Text = "Leave Guild";
                mNameText.Show();
                mTagText.Show();
                mRankText.Show();
                mLeaveCreateButton.Show();
                mMembers.Show();
            }

            if (Globals.Me.GuildMembers != null)
            {
                var gMembers = JsonConvert.DeserializeObject<Dictionary<Guid, Guid>>(Globals.Me.GuildMembers);
                //var gMembersNames = JsonConvert.DeserializeObject<Dictionary<string, Guid>>(Globals.Me.GuildMembersNames);
                Guid RankId = gMembers[Globals.Me.Id];

                var RankInfo = JsonConvert.DeserializeObject<List<GuildRanks>>(Globals.Me.GuildRanks);
                
                var rankText = RankInfo.FirstOrDefault(n => n.Id == RankId);

                mRankText.Text = rankText.Title;

                if (rankText.Permissions.ContainsKey(GuildPermissions.InvitePlayers))
                {
                    mAddPopupButton.Show();
                }

                }
            tempTimer++;
            //var rank = player.Guild.GetRank(player);
        }

        public class GuildRanks
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public Dictionary<GuildPermissions, bool> Permissions = new Dictionary<GuildPermissions, bool>();
        }

        public class GuildMembers
        {
            //public Guid Key { get; set; }
            public string Name { get; set; }
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
            if (mMembers != null)
            {
                mMembers.Clear();
            }
            if (Globals.Me.GuildMembersNames != null)
            {
                foreach (var f in JsonConvert.DeserializeObject<List<GuildMembers>>(Globals.Me.GuildMembersNames))
                {
                    var row = mMembers.AddRow(f.Name + " (lvl " + f.Level + " " + f.Class + ") Map: " + f.Map);
                    row.UserData = f.Name;
                    row.Clicked += members_Clicked;
                    row.RightClicked += members_RightClicked;
                    if (f.Online == true)
                    {
                        row.SetTextColor(Color.Green);
                    }
                    else
                    {
                        row.SetTextColor(Color.Red);
                    }
                    row.RenderColor = new Color(255, 255, 255, 255);
                }
            }
        }

        void members_Clicked(Base sender, ClickedEventArgs arguments)
        {
            var row = (ListBoxRow)sender;

            /*
            foreach (var member in Globals.Me.GuildMembers)
            {
                if (member.Name.ToLower() == member.Name.ToLower())
                {
                    if (member.Online == true)
                    {
                        Interface.GameUi.SetChatboxText("/pm " + (string)row.UserData + " ");
                    }
                }
            }*/
        }
        private void AddMember(Object sender, EventArgs e)
        {
            var ibox = (InputBox)sender;
            if (ibox.TextValue.Trim().Length >= 3) //Don't bother sending a packet less than the char limit
            {
                PacketSender.SendChatMsg("/guildinvite " + ibox.TextValue.ToString(), 0);
                //PacketSender.SendAddFriend(ibox.TextValue);
            }
        }

        void addPopupButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            var iBox = new InputBox(
                Strings.Guilds.addmember, Strings.Guilds.addmemberprompt, true, InputBox.InputType.TextInput,
                AddMember, null, 0
            );
        }

        void members_RightClicked(Base sender, ClickedEventArgs arguments)
        {
            var row = (ListBoxRow)sender;
            mTempName = (string)row.UserData;

            var iBox = new InputBox(
                Strings.Guilds.removeguildmember, Strings.Guilds.removeguildmemberprompt.ToString(mTempName), true,
                InputBox.InputType.YesNo, RemoveMember, null, 0
            );
        }

        private void RemoveMember(Object sender, EventArgs e)
        {
            //PacketSender.SendRemoveFriend(mTempName);
        }

        private void CreateGuild(Object sender, EventArgs e)
        {
            var ibox = (InputBox)sender;
            if (ibox.TextValue.Trim().Length >= 3) //Don't bother sending a packet less than the char limit
            {
                PacketSender.SendChatMsg("/guildcreate " + ibox.TextValue.ToString(), 0);
                //PacketSender.SendAddFriend(ibox.TextValue);
            }
            //PacketSender.SendRemoveFriend(mTempName);
        }

        public void Hide()
        {
            mGuildWindow.IsHidden = true;
        }

        //Input Handlers
        void kick_Clicked(Base sender, ClickedEventArgs arguments)
        {
            
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
