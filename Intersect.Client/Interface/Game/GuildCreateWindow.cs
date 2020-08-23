using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects;

using System.Collections.Generic;

namespace Intersect.Client.Interface.Game
{

    public class GuildCreateWindow
    {

        private Button mCreateButton;

        private TextBox mNamebox;

        private Label mNameLabel;

        private ImagePanel mNameboxBg;

        private TextBox mTagbox;

        private Label mTagLabel;

        private ImagePanel mTagboxBg;

        private GuildCreateItem mReqItem;

        //Controls
        private WindowControl mGuildCreateWindow;

        private Label mCreateTitle;

        private Label mReQuiredItem;

        //Location
        public int X;

        public int Y;

        public GuildCreateWindow(Canvas gameCanvas)
        {
            mGuildCreateWindow = new WindowControl(gameCanvas, "Create Guild", false, "GuildCreateWindow");
            mGuildCreateWindow.DisableResizing();
            mGuildCreateWindow.IsClosable = true;
            Interface.InputBlockingElements.Add(mGuildCreateWindow);

            //Menu Header
            mCreateTitle = new Label(mGuildCreateWindow, "CreateGuildTitle");

            mNameboxBg = new ImagePanel(mGuildCreateWindow, "NameBoxBg");
            mTagboxBg = new ImagePanel(mGuildCreateWindow, "TagboxBg");

            mNamebox = new TextBox(mNameboxBg, "NameBoxText");
            mNamebox.Focus();
            Interface.FocusElements.Add(mNamebox);

            mTagbox = new TextBox(mTagboxBg, "TagBoxText");
            Interface.FocusElements.Add(mTagbox);

            mNameLabel = new Label(mGuildCreateWindow, "NameLabel");
            mNameLabel.Text = "Name:";

            mTagLabel = new Label(mGuildCreateWindow, "TagLabel");
            mTagLabel.Text = "Tag:";

            mReQuiredItem = new Label(mGuildCreateWindow, "RequiredItemLabel");
            mReQuiredItem.Text = "Item Required:";

            mCreateButton = new Button(mGuildCreateWindow, "CreateGuildButton");
            mCreateButton.Text = "Create Guild";
            mCreateButton.SetToolTipText(Strings.Parties.leavetip);
            mCreateButton.Clicked += CreateButton_Clicked;

            mReqItem = new GuildCreateItem(this, -1, new ImagePanel(mGuildCreateWindow, "GuildCreateItem"));

            mGuildCreateWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
        }

        public void UpdateItem()
        {
            mReqItem.SetSlot();
        }

        private void CreateButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (Globals.Me.FindItem(Globals.GuildCreateItem,1) >= 0)
            {
                if (mNamebox.Text.Trim().Length < 4 && mNamebox.Text.Trim().Length > 20)
                {
                    Interface.MsgboxErrors.Add(new KeyValuePair<string, string>("", "Guildname needs to be between 4 and 20 characters"));
                    return;
                }

                if (mTagbox.Text.Trim().Length < 3 && mTagbox.Text.Trim().Length > 4)
                {
                    Interface.MsgboxErrors.Add(new KeyValuePair<string, string>("", "Guildtag needs to be between 2 and 4 characters"));
                    return;
                }
                PacketSender.SendCreateGuild(mNamebox.Text, mTagbox.Text);
            }
            else
            {
                Interface.MsgboxErrors.Add(new KeyValuePair<string, string>("", "You dont have the required item to create a guild!"));
                Close();
            }
            //PacketSender.SendCheckGuildName(mNamebox.Text);
            //PacketSender.SendCheckGuildTag(mTagbox.Text);
        }

        private void CheckButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            //PacketSender.SendCheckGuildName(mNamebox.Text);
            //PacketSender.SendCheckGuildTag(mTagbox.Text);
        }

        public void Update()
        {
            X = mGuildCreateWindow.X;
            Y = mGuildCreateWindow.Y;
        }

        public void Show()
        {
            mGuildCreateWindow.IsHidden = false;
        }

        public void Close()
        {
            mGuildCreateWindow.Close();
        }

        public bool IsVisible()
        {
            return !mGuildCreateWindow.IsHidden;
        }

        public void Hide()
        {
            mGuildCreateWindow.IsHidden = true;
        }

    }

}
