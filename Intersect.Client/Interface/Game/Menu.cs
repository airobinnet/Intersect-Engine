﻿using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Interface.Game.Character;
using Intersect.Client.Interface.Game.Inventory;
using Intersect.Client.Interface.Game.Spells;
using Intersect.Client.Interface.Game.Guild;
using Intersect.Client.Interface.Game.CashShop;
using Intersect.Client.Interface.Game.TradeSkills;
using Intersect.Client.Localization;
using Intersect.Client.Networking;

using JetBrains.Annotations;

namespace Intersect.Client.Interface.Game
{

    public class Menu
    {

        [NotNull] private readonly ImagePanel mCharacterBackground;

        [NotNull] private readonly Button mCharacterButton;

        [NotNull] private readonly CharacterWindow mCharacterWindow;

        [NotNull] private readonly ImagePanel mFriendsBackground;

        [NotNull] private readonly Button mFriendsButton;

        [NotNull] private readonly FriendsWindow mFriendsWindow;

        [NotNull] private readonly ImagePanel mInventoryBackground;

        [NotNull] private readonly Button mInventoryButton;

        [NotNull] private readonly InventoryWindow mInventoryWindow;

        [NotNull] private readonly ImagePanel mMenuBackground;

        [NotNull] private readonly Button mMenuButton;

        [NotNull] private readonly ImagePanel mPvpBackground;

        [NotNull] private readonly Button mPvpButton;

        [NotNull] private readonly ImagePanel mTradeSkillsBackground;

        [NotNull] private readonly Button mTradeSkillsButton;

        //Menu Container
        private readonly ImagePanel mMenuContainer;

        [NotNull] private readonly ImagePanel mPartyBackground;

        [NotNull] private readonly Button mPartyButton;

        [NotNull] private readonly ImagePanel mGuildBackground;

        [NotNull] private readonly ImagePanel mCashShopBackground;

        [NotNull] private readonly Button mCashShopButton;

        [NotNull] private readonly CashShopWindow mCashShopWindow;

        [NotNull] private readonly Button mGuildButton;

        [NotNull] private readonly PartyWindow mPartyWindow;

        [NotNull] private readonly GuildWindow mGuildWindow;

        [NotNull] private readonly ImagePanel mQuestsBackground;

        [NotNull] private readonly Button mQuestsButton;

        [NotNull] private readonly QuestsWindow mQuestsWindow;

        [NotNull] private readonly ImagePanel mSpellsBackground;

        [NotNull] private readonly Button mSpellsButton;

        [NotNull] private readonly SpellsWindow mSpellsWindow;

        [NotNull] private readonly PvpWindow mPvpWindow;

        [NotNull] private readonly TradeSkillWindow mTradeSkillWindow;

        private int mBackgroundHeight = 42;

        private int mBackgroundWidth = 42;

        private int mButtonHeight = 34;

        private int mButtonMargin = 8;

        private int mButtonWidth = 34;

        //Canvas instance
        private Canvas mGameCanvas;

        //Init
        public Menu(Canvas gameCanvas)
        {
            mGameCanvas = gameCanvas;

            mMenuContainer = new ImagePanel(gameCanvas, "MenuContainer");
            mMenuContainer.ShouldCacheToTexture = true;

            mInventoryBackground = new ImagePanel(mMenuContainer, "InventoryContainer");
            mInventoryButton = new Button(mInventoryBackground, "InventoryButton");
            mInventoryButton.SetToolTipText(Strings.GameMenu.items);
            mInventoryButton.Clicked += InventoryButton_Clicked;

            mSpellsBackground = new ImagePanel(mMenuContainer, "SpellsContainer");
            mSpellsButton = new Button(mSpellsBackground, "SpellsButton");
            mSpellsButton.SetToolTipText(Strings.GameMenu.spells);
            mSpellsButton.Clicked += SpellsButton_Clicked;

            mCharacterBackground = new ImagePanel(mMenuContainer, "CharacterContainer");
            mCharacterButton = new Button(mCharacterBackground, "CharacterButton");
            mCharacterButton.SetToolTipText(Strings.GameMenu.character);
            mCharacterButton.Clicked += CharacterButton_Clicked;

            mQuestsBackground = new ImagePanel(mMenuContainer, "QuestsContainer");
            mQuestsButton = new Button(mQuestsBackground, "QuestsButton");
            mQuestsButton.SetToolTipText(Strings.GameMenu.quest);
            mQuestsButton.Clicked += QuestBtn_Clicked;

            mFriendsBackground = new ImagePanel(mMenuContainer, "FriendsContainer");
            mFriendsButton = new Button(mFriendsBackground, "FriendsButton");
            mFriendsButton.SetToolTipText(Strings.GameMenu.friends);
            mFriendsButton.Clicked += FriendsBtn_Clicked;

            mPartyBackground = new ImagePanel(mMenuContainer, "PartyContainer");
            mPartyButton = new Button(mPartyBackground, "PartyButton");
            mPartyButton.SetToolTipText(Strings.GameMenu.party);
            mPartyButton.Clicked += PartyBtn_Clicked;

            mGuildBackground = new ImagePanel(mMenuContainer, "GuildyContainer");
            mGuildButton = new Button(mGuildBackground, "GuildButton");
            mGuildButton.SetToolTipText(Strings.GameMenu.guild);
            mGuildButton.Clicked += GuildBtn_Clicked;

            mCashShopBackground = new ImagePanel(mMenuContainer, "CashShopContainer");
            mCashShopButton = new Button(mCashShopBackground, "CashShopButton");
            mCashShopButton.SetToolTipText("Cash Shop");
            mCashShopButton.Clicked += CashShopBtn_Clicked;

            mPvpBackground = new ImagePanel(mMenuContainer, "PvpContainer");
            mPvpButton = new Button(mPvpBackground, "PvpButton");
            mPvpButton.SetToolTipText("Pvp");
            mPvpButton.Clicked += PvpBtn_Clicked;

            mTradeSkillsBackground = new ImagePanel(mMenuContainer, "TradeSkillContainer");
            mTradeSkillsButton = new Button(mTradeSkillsBackground, "TradeSkillButton");
            mTradeSkillsButton.SetToolTipText("Tradeskills");
            mTradeSkillsButton.Clicked += TradeSkillsBtn_Clicked;

            mMenuBackground = new ImagePanel(mMenuContainer, "MenuContainer");
            mMenuButton = new Button(mMenuBackground, "MenuButton");
            mMenuButton.SetToolTipText(Strings.GameMenu.Menu);
            mMenuButton.Clicked += MenuButtonClicked;

            mMenuContainer.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

            //Assign Window References
            mPartyWindow = new PartyWindow(gameCanvas);
            mGuildWindow = new GuildWindow(gameCanvas);
            mFriendsWindow = new FriendsWindow(gameCanvas);
            mInventoryWindow = new InventoryWindow(gameCanvas);
            mSpellsWindow = new SpellsWindow(gameCanvas);
            mCharacterWindow = new CharacterWindow(gameCanvas);
            mQuestsWindow = new QuestsWindow(gameCanvas);
            mPvpWindow = new PvpWindow(gameCanvas);
            mTradeSkillWindow = new TradeSkillWindow(gameCanvas);
            mCashShopWindow = new CashShopWindow(gameCanvas);
        }

        //Methods
        public void Update(bool updateQuestLog)
        {
            mInventoryWindow.Update();
            mSpellsWindow.Update();
            mCharacterWindow.Update();
            mPartyWindow.Update();
            mGuildWindow.Update();
            mFriendsWindow.Update();
            mCashShopWindow.Update();
            mTradeSkillWindow.Update();
            mPvpWindow.Update();
            mQuestsWindow.Update(updateQuestLog);
        }

        public void UpdateFriendsList()
        {
            mFriendsWindow.UpdateList();
        }

        public void UpdateTradeSkillWindow()
        {
            mTradeSkillWindow.UpdateList();
        }

        public void HideWindows()
        {
            if (!Globals.Database.HideOthersOnWindowOpen)
            {
                return;
            }

            mCharacterWindow.Hide();
            mFriendsWindow.Hide();
            mInventoryWindow.Hide();
            mPartyWindow.Hide();
            mGuildWindow.Hide();
            mQuestsWindow.Hide();
            mSpellsWindow.Hide();
            mTradeSkillWindow.Hide();
            mCashShopWindow.Hide();
            mPvpWindow.Hide();
        }

        public void ToggleCharacterWindow()
        {
            if (mCharacterWindow.IsVisible())
            {
                mCharacterWindow.Hide();
            }
            else
            {
                HideWindows();
                mCharacterWindow.Show();
            }
        }

        public bool ToggleFriendsWindow()
        {
            if (mFriendsWindow.IsVisible())
            {
                mFriendsWindow.Hide();
            }
            else
            {
                HideWindows();
                PacketSender.SendRequestFriends();
                mFriendsWindow.UpdateList();
                mFriendsWindow.Show();
            }

            return mFriendsWindow.IsVisible();
        }

        public void ToggleInventoryWindow()
        {
            if (mInventoryWindow.IsVisible())
            {
                mInventoryWindow.Hide();
            }
            else
            {
                HideWindows();
                mInventoryWindow.Show();
            }
        }

        public void TogglePartyWindow()
        {
            if (mPartyWindow.IsVisible())
            {
                mPartyWindow.Hide();
            }
            else
            {
                HideWindows();
                mPartyWindow.Show();
            }
        }

        public void ToggleGuildWindow()
        {
            if (mGuildWindow.IsVisible())
            {
                mGuildWindow.Hide();
            }
            else
            {
                HideWindows();
                PacketSender.SendRequestGuildInfo();
                mGuildWindow.UpdateList();
                mGuildWindow.Show();
                mGuildWindow.CurExpWidth = -1;
            }
        }

        public void TogglePvpWindow()
        {
            if (mPvpWindow.IsVisible())
            {
                mPvpWindow.Hide();
            }
            else
            {
                HideWindows();
                mPvpWindow.Show();
            }
        }

        public void ToggleTradeSkillWindow()
        {
            if (mTradeSkillWindow.IsVisible())
            {
                mTradeSkillWindow.Hide();
            }
            else
            {
                HideWindows();
                mTradeSkillWindow.Show();
            }
        }

        public void ToggleQuestsWindow()
        {
            if (mQuestsWindow.IsVisible())
            {
                mQuestsWindow.Hide();
            }
            else
            {
                HideWindows();
                mQuestsWindow.Show();
            }
        }

        public void ToggleCashShopWindow()
        {
            if (mCashShopWindow.IsVisible())
            {
                mCashShopWindow.Hide();
            }
            else
            {
                HideWindows();
                mCashShopWindow.Show();
            }
        }

        public void ToggleSpellsWindow()
        {
            if (mSpellsWindow.IsVisible())
            {
                mSpellsWindow.Hide();
            }
            else
            {
                HideWindows();
                mSpellsWindow.Show();
            }
        }

        //Input Handlers
        private static void MenuButtonClicked(Base sender, ClickedEventArgs arguments)
        {
            Interface.GameUi?.EscapeMenu?.ToggleHidden();
        }

        private void PartyBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            TogglePartyWindow();
        }

        private void CashShopBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            ToggleCashShopWindow();
        }

        private void GuildBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            ToggleGuildWindow();
        }

        private void PvpBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            TogglePvpWindow();
        }

        private void TradeSkillsBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            ToggleTradeSkillWindow();
        }

        private void FriendsBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            ToggleFriendsWindow();
        }

        private void QuestBtn_Clicked(Base sender, ClickedEventArgs arguments)
        {
            ToggleQuestsWindow();
        }

        private void InventoryButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            ToggleInventoryWindow();
        }

        private void SpellsButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            ToggleSpellsWindow();
        }

        private void CharacterButton_Clicked(Base sender, ClickedEventArgs arguments)
        {
            ToggleCharacterWindow();
        }

    }

}
