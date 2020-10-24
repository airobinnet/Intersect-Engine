using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.Enums;
using Intersect.GameObjects;
using System.Collections.Generic;

namespace Intersect.Client.Interface.Game
{

    public class QuestOfferWindow
    {

        private Button mAcceptButton;

        private Button mDeclineButton;

        private string mQuestOfferText = "";

        //Controls
        private WindowControl mQuestOfferWindow;

        private ScrollControl mQuestPromptArea;

        private RichLabel mQuestPromptLabel;

        private RichLabel mQuestRewardLabel;

        private Label mQuestPromptTemplate;

        private Label mQuestTitle;

        private QuestBase mSelectedQuest;

        private ScrollControl mQuestRewardArea;

        //Location
        public int X => mQuestOfferWindow.X;

        public int Y => mQuestOfferWindow.Y;

        //Item List
        public List<QuestOfferRewardItem> Items = new List<QuestOfferRewardItem>();

        public QuestOfferWindow(Canvas gameCanvas)
        {
            mQuestOfferWindow = new WindowControl(gameCanvas, Strings.QuestOffer.title, false, "QuestOfferWindow");
            mQuestOfferWindow.DisableResizing();
            mQuestOfferWindow.IsClosable = false;

            //Menu Header
            mQuestTitle = new Label(mQuestOfferWindow, "QuestTitle");

            mQuestPromptArea = new ScrollControl(mQuestOfferWindow, "QuestOfferArea");

            mQuestPromptTemplate = new Label(mQuestPromptArea, "QuestOfferTemplate");

            mQuestPromptLabel = new RichLabel(mQuestPromptArea);

            mQuestRewardLabel = new RichLabel(mQuestPromptArea);

            mQuestRewardArea = new ScrollControl(mQuestPromptArea, "QuestRewards");

            //Accept Button
            mAcceptButton = new Button(mQuestOfferWindow, "AcceptButton");
            mAcceptButton.SetText(Strings.QuestOffer.accept);
            mAcceptButton.Clicked += _acceptButton_Clicked;

            //Decline Button
            mDeclineButton = new Button(mQuestOfferWindow, "DeclineButton");
            mDeclineButton.SetText(Strings.QuestOffer.decline);
            mDeclineButton.Clicked += _declineButton_Clicked;

            mQuestOfferWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
            Interface.InputBlockingElements.Add(mQuestOfferWindow);
        }

        private void _declineButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (Globals.QuestOffers.Count > 0)
            {
                PacketSender.SendDeclineQuest(Globals.QuestOffers[0]);
                Globals.QuestOffers.RemoveAt(0);
            }
        }

        private void _acceptButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (Globals.QuestOffers.Count > 0)
            {
                PacketSender.SendAcceptQuest(Globals.QuestOffers[0]);
                Globals.QuestOffers.RemoveAt(0);
            }
        }

        public void Update(QuestBase quest)
        {
            if (quest == null)
            {
                Hide();
            }
            else
            {
                Show();
                mSelectedQuest = quest;
                mQuestTitle.Text = quest.Name;
                if (mQuestOfferText != quest.StartDescription)
                {
                    mQuestRewardLabel.ClearText();
                    mQuestPromptLabel.ClearText();
                    mQuestPromptLabel.Width = mQuestPromptArea.Width - (mQuestPromptArea.GetVerticalScrollBar().Width*2);
                    mQuestRewardLabel.Width = mQuestPromptArea.Width - (mQuestPromptArea.GetVerticalScrollBar().Width*2);
                    mQuestPromptLabel.AddText(
                        quest.StartDescription, mQuestPromptTemplate.TextColor,
                        mQuestPromptTemplate.CurAlignments.Count > 0
                            ? mQuestPromptTemplate.CurAlignments[0]
                            : Alignments.Left, mQuestPromptTemplate.Font
                    );

                    mQuestPromptLabel.AddLineBreak();
                    mQuestOfferText = quest.StartDescription;


                    if (mSelectedQuest.Tasks[mSelectedQuest.Tasks.Count - 1].Objective == QuestObjective.ChooseItem) //Reward Screen
                    {
                        if (mSelectedQuest.Tasks[mSelectedQuest.Tasks.Count - 1].HasChoice)
                        {
                            mQuestRewardLabel.AddText(Strings.QuestOffer.questrewardchoice, Color.White, Alignments.Left, mQuestPromptTemplate.Font);
                        }
                        else
                        {
                            mQuestRewardLabel.AddText(Strings.QuestOffer.questreward, Color.White, Alignments.Left, mQuestPromptTemplate.Font);
                        }
                        Items.Clear();
                        mQuestRewardArea.Children.Clear();
                        for (var j = 0; j < mSelectedQuest.Tasks[mSelectedQuest.Tasks.Count - 1].mTargets.Count; j++)
                        {
                            Items.Add(new QuestOfferRewardItem(this, j, mSelectedQuest, mSelectedQuest.Tasks[mSelectedQuest.Tasks.Count - 1].HasChoice));
                            Items[j].Container = new ImagePanel(mQuestRewardArea, "ItemChoiceItem");
                            Items[j].Setup();

                            Items[j].Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
                            Items[j].Update();

                            var xPadding = Items[j].Container.Margin.Left + Items[j].Container.Margin.Right;
                            var yPadding = Items[j].Container.Margin.Top + Items[j].Container.Margin.Bottom;
                            Items[j]
                                .Container.SetPosition(
                                    j %
                                    (mQuestPromptArea.Width / (Items[j].Container.Width + xPadding)) *
                                    (Items[j].Container.Width + xPadding) +
                                    xPadding,
                                    j /
                                    (mQuestPromptArea.Width / (Items[j].Container.Width + xPadding)) *
                                    (Items[j].Container.Height + yPadding) +
                                    yPadding
                                );
                            Items[j].Container.RenderColor = new Color(255, 255, 255, 255);

                        }
                        mQuestRewardLabel.Show();
                        mQuestRewardArea.Width = 245;
                        mQuestRewardArea.Height = 100;
                        mQuestPromptLabel.SizeToChildren(false, true);
                        mQuestRewardLabel.Y = mQuestPromptLabel.Y + mQuestPromptLabel.Height + 100;
                        mQuestRewardLabel.SizeToChildren(false, true);
                        mQuestRewardArea.Show();
                        mQuestRewardArea.Y = mQuestPromptLabel.Y + mQuestPromptLabel.Height + 100 + mQuestRewardLabel.Height + 5;
                    }
                    else
                    {
                        mQuestRewardArea.Height = 1;
                        mQuestRewardArea.Y = 1;
                        mQuestRewardLabel.Y = 1;
                        mQuestRewardLabel.Hide();
                        mQuestPromptLabel.SizeToChildren(false, true);
                        Items.Clear();
                        mQuestRewardArea.Children.Clear();
                        mQuestRewardArea.Hide();
                    }
                }
            }
        }

        public void Show()
        {
            mQuestOfferWindow.IsHidden = false;
        }

        public void Close()
        {
            mQuestOfferWindow.Close();
        }

        public bool IsVisible()
        {
            return !mQuestOfferWindow.IsHidden;
        }

        public void Hide()
        {
            mQuestOfferWindow.IsHidden = true;
        }

    }

}
