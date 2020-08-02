using System;

using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Graphics;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.Framework.Gwen.Input;
using Intersect.Client.Framework.Input;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects;

using System.Collections.Generic;
using System.Dynamic;

using Intersect.Client.Core;
using Intersect.Enums;
using System.Linq;
using Newtonsoft.Json;

namespace Intersect.Client.Interface.Game.Guild
{

    public class GuildMember
    {

        public ImagePanel Container;

        private Label mNameText;

        private Label mLevelText;

        private Label mClassText;

        private Label mRankText;

        private Label mMapText;

        private ComboBox mMenuCombobox;

        //Temp variables
        private string mTempName;

        //Slot info
        private int mIndex;
        
        //Drag/Drop References
        private GuildWindow mGuildWindow;

        public GuildMember(GuildWindow guildWindow, int index)
        {
            mGuildWindow = guildWindow;
            mIndex = index;
        }

        public void Setup()
        {
            mNameText = new Label(Container, "NameText");
            mNameText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mLevelText = new Label(Container, "LevelText");
            mLevelText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mClassText = new Label(Container, "ClassText");
            mClassText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mRankText = new Label(Container, "RankText");
            mRankText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mMapText = new Label(Container, "MapText");
            mMapText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mNameText.Text = "";
            mLevelText.Text = "";
            mClassText.Text = "";
            mMapText.Text = "";
            mRankText.Text = "";

            mMenuCombobox = new ComboBox(Container, "MenuCombobox");
            for (var i = 0; i < 4; i++)
            {
                var menuItem = mMenuCombobox.AddItem(Strings.Guilds.menuoptions[i]);
                menuItem.UserData = i;
            }
            mMenuCombobox.Hide();
            mMenuCombobox.SetText("");
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

        public void LoadItem()
        {
            var MemberData = JsonConvert.DeserializeObject<List<GuildMembers>>(Globals.Me.GuildMembersNames)[mIndex];
            var RankInfo = JsonConvert.DeserializeObject<List<GuildRanks>>(Globals.Me.GuildRanks);
            var rankText = RankInfo.FirstOrDefault(n => n.Id == MemberData.Rank).Title.ToString();

            Container.UserData = MemberData;
            mMenuCombobox.UserData = MemberData;
            mNameText.Text = MemberData.Name;
            mRankText.Text = rankText;
            mLevelText.Text = MemberData.Level.ToString();
            mClassText.Text = MemberData.Class;
            mMapText.Text = MemberData.Map;
            if (MemberData.Online)
            {
                mNameText.TextColor = Color.Green;
                mLevelText.TextColor = Color.Green;
                mRankText.TextColor = Color.Green;
                mClassText.TextColor = Color.Green;
                mMapText.TextColor = Color.Green;
            }
            else
            {
                mNameText.TextColor = Color.Red;
                mLevelText.TextColor = Color.Red;
                mRankText.TextColor = Color.Red;
                mClassText.TextColor = Color.Red;
                mMapText.TextColor = Color.Red;
            }

            Container.Clicked += members_Clicked;
            Container.RightClicked += members_RightClicked;
            mMenuCombobox.ItemSelected += menu_Clicked;
        }
        void members_Clicked(Base sender, ClickedEventArgs arguments)
        {
            var clickedMember = (GuildMembers)sender.UserData;

            if (clickedMember.Online || !clickedMember.Online)
            {
                Interface.GameUi.SetChatboxText("/pm " + (string)clickedMember.Name.ToString() + " ");
            }
        }

        private void RemoveMember(Object sender, EventArgs e)
        {
            
        }

        private void PromoteMember(Object sender, EventArgs e)
        {
            PacketSender.SendChatMsg("/guildpromote " + mTempName, 0);
        }

        private void DemoteMember(Object sender, EventArgs e)
        {
            PacketSender.SendChatMsg("/guilddemote " + mTempName, 0);
        }

        void members_RightClicked(Base sender, ClickedEventArgs arguments)
        {
            
        }

        void menu_Clicked(Base sender, ItemSelectedEventArgs arguments)
        {
            if (arguments.SelectedItem.UserData.ToString() == "0")
            {
                var clickedMember = (GuildMembers)sender.UserData;

                if (clickedMember.Online || !clickedMember.Online)
                {
                    Interface.GameUi.SetChatboxText("/pm " + (string)clickedMember.Name.ToString() + " ");
                }
            }
            if (arguments.SelectedItem.UserData.ToString() == "1")
            {
                var clickedMember = (GuildMembers)sender.UserData;
                var RankInfo = JsonConvert.DeserializeObject<List<GuildRanks>>(Globals.Me.GuildRanks);
                for (var i = 0; i < RankInfo.Count()-1; i++)
                {
                    var currentRank = RankInfo.FirstOrDefault(n => n.Id == clickedMember.Rank);
                    if (RankInfo[i].Id == currentRank.Id)
                    {
                        if (i < Globals.Me.GuildRanks.Count()-1)
                        {
                            mTempName = clickedMember.Name;

                            var iBox = new InputBox(
                                Strings.Guilds.promoteguildmember, Strings.Guilds.promoteguildmemberprompt.ToString(mTempName, RankInfo[i+1].Title), true,
                                InputBox.InputType.YesNo, PromoteMember, null, 0
                            );

                            return;
                        }
                    }
                }
            }
            if (arguments.SelectedItem.UserData.ToString() == "2")
            {
                var clickedMember = (GuildMembers)sender.UserData;
                var RankInfo = JsonConvert.DeserializeObject<List<GuildRanks>>(Globals.Me.GuildRanks);
                for (var i = 0; i < RankInfo.Count(); i++)
                {
                    var currentRank = RankInfo.FirstOrDefault(n => n.Id == clickedMember.Rank);
                    if (RankInfo[i].Id == currentRank.Id)
                    {
                        if (i > 0)
                        {
                            mTempName = clickedMember.Name;

                            var iBox = new InputBox(
                                Strings.Guilds.demoteguildmember, Strings.Guilds.demoteguildmemberprompt.ToString(mTempName, RankInfo[i - 1].Title), true,
                                InputBox.InputType.YesNo, DemoteMember, null, 0
                            );
                            return;
                        }
                    }
                }
            }
            if (arguments.SelectedItem.UserData.ToString() == "3")
            {
                var clickedMember = (GuildMembers)sender.UserData;
                var clickedMemberId = clickedMember.Id;
                mTempName = clickedMember.Name;

                var iBox = new InputBox(
                    Strings.Guilds.removeguildmember, Strings.Guilds.removeguildmemberprompt.ToString(mTempName), true,
                    InputBox.InputType.YesNo, RemoveMember, null, 0
                );
            }
        }

        public void Update()
        {
        }

    }

}
