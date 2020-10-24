using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Gwen;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intersect.Client.Interface.Game
{

    public class ItemChoiceWindow
    {

        private Button mAcceptButton;

        private Button mDeclineButton;

        private string mQuestOfferText = "";

        //Initialized Items?
        private bool mInitializedItems = false;

        //Controls
        private WindowControl mItemChoiceWindow;

        private ScrollControl mQuestPromptArea;

        private RichLabel mQuestPromptLabel;

        private Label mQuestPromptTemplate;

        private Label mQuestTitle;

        private int countItems = 0;

        public int Choice = -1;

        //Item List
        public List<ItemChoiceItem> Items = new List<ItemChoiceItem>();
       
        //Location
        public int X => mItemChoiceWindow.X;

        public int Y => mItemChoiceWindow.Y;

        public ItemChoiceWindow(Canvas gameCanvas)
        {
            mItemChoiceWindow = new WindowControl(gameCanvas, "Item Choice", false, "ItemChoiceWindow");
            mItemChoiceWindow.DisableResizing();
            mItemChoiceWindow.IsClosable = false;

            //Menu Header
            mQuestTitle = new Label(mItemChoiceWindow, "ItemChoiceTitle");

            mQuestPromptArea = new ScrollControl(mItemChoiceWindow, "ItemChoiceArea");

            mQuestPromptTemplate = new Label(mQuestPromptArea, "ItemChoiceTemplate");

            mQuestPromptLabel = new RichLabel(mQuestPromptArea);

            //Accept Button
            mAcceptButton = new Button(mItemChoiceWindow, "AcceptButton");
            mAcceptButton.SetText(Strings.QuestOffer.accept);
            mAcceptButton.Clicked += _acceptButton_Clicked;

            mItemChoiceWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
            Interface.InputBlockingElements.Add(mItemChoiceWindow);
        }

        private void _acceptButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            var ed = Globals.ItemChoice[0] ?? null;
            if (ed.ResponseSent != 0)
            {
                return;
            }
            if (Choice < 0)
            {
                Interface.MsgboxErrors.Add(new KeyValuePair<string, string>("", "Pick a reward!"));
                return;
            }
            else
            {
                PacketSender.SendItemChoiceResponse(Choice + 1, ed);
                mItemChoiceWindow.RemoveModal();
                mItemChoiceWindow.IsHidden = true;
                ed.ResponseSent = 1;
                mInitializedItems = false;
                Items.Clear();
                Globals.ItemChoice.Clear();
                Choice = -1;
            }
        }

        public void Update()
        {
            if (Globals.ItemChoice.Count > 0)
            {
                if (!mInitializedItems)
                {
                    mInitializedItems = true;
                    InitItemContainer();
                    Show();
                }
                for (var i = 0; i < Globals.ItemChoice[0].Items.Count; i++)
                {
                    if (Choice == i)
                    {
                        Items[i].Container.RenderColor = new Color(255, 0, 255, 0);
                    }
                    else
                    {
                        Items[i].Container.RenderColor = new Color(255, 255, 255, 255);
                    }
                }
            }
        }

        public void InitItemContainer()
        {
            Items.Clear();
            if (Globals.ItemChoice[0].Items.Count > 0)
            {
                for (var i = 0; i < 4; i++)
                {
                    Items.Add(new ItemChoiceItem(this, i));
                    Items[i].Container = new ImagePanel(mQuestPromptArea, "ItemChoiceItem");
                    Items[i].Setup();

                    Items[i].Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
                    /*if (Choice == i)
                    {
                        Items[i].Container.RenderColor = new Color(255, 0, 255, 0);
                    }*/
                    Items[i].Update();

                    var xPadding = Items[i].Container.Margin.Left + Items[i].Container.Margin.Right;
                    var yPadding = Items[i].Container.Margin.Top + Items[i].Container.Margin.Bottom;
                    Items[i]
                        .Container.SetPosition(
                            i %
                            (mQuestPromptArea.Width / (Items[i].Container.Width + xPadding)) *
                            (Items[i].Container.Width + xPadding) +
                            xPadding,
                            i /
                            (mQuestPromptArea.Width / (Items[i].Container.Width + xPadding)) *
                            (Items[i].Container.Height + yPadding) +
                            yPadding
                        );
                }
            }
        }

        public void Show()
        {
            mItemChoiceWindow.IsHidden = false;
        }

        public void Close()
        {
            mItemChoiceWindow.Close();
        }

        public bool IsVisible()
        {
            return !mItemChoiceWindow.IsHidden;
        }

        public void Hide()
        {
            mItemChoiceWindow.IsHidden = true;
        }

        public FloatRect RenderBounds()
        {
            var rect = new FloatRect()
            {
                X = mItemChoiceWindow.LocalPosToCanvas(new Point(0, 0)).X -
                    (Items[0].Container.Padding.Left + Items[0].Container.Padding.Right) / 2,
                Y = mItemChoiceWindow.LocalPosToCanvas(new Point(0, 0)).Y -
                    (Items[0].Container.Padding.Top + Items[0].Container.Padding.Bottom) / 2,
                Width = mItemChoiceWindow.Width + Items[0].Container.Padding.Left + Items[0].Container.Padding.Right,
                Height = mItemChoiceWindow.Height + Items[0].Container.Padding.Top + Items[0].Container.Padding.Bottom
            };

            return rect;
        }
    }

}
