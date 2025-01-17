﻿using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.General;
using Intersect.Client.Interface.Game.Bag;
using Intersect.Client.Interface.Game.Bank;
using Intersect.Client.Interface.Game.GuildBank;
using Intersect.Client.Interface.Game.Chat;
using Intersect.Client.Interface.Game.Crafting;
using Intersect.Client.Interface.Game.EntityPanel;
using Intersect.Client.Interface.Game.HDV;
using Intersect.Client.Interface.Game.Hotbar;
using Intersect.Client.Interface.Game.Mail;
using Intersect.Client.Interface.Game.Shop;
using Intersect.Client.Interface.Game.Trades;
using Intersect.Client.Interface.Game.TradeSkills;
using Intersect.Client.Networking;
using Intersect.Enums;
using Intersect.GameObjects;
using System;

using JetBrains.Annotations;

namespace Intersect.Client.Interface.Game
{

    public class GameInterface
    {

        public bool FocusChat;

        //Public Components - For clicking/dragging
        public HotBarWindow Hotbar;

        private AdminWindow mAdminWindow;

        private BagWindow mBagWindow;

        private BankWindow mBankWindow;

        private GuildBankWindow mGuildBankWindow;

        private GuildCreateWindow mGuildCreateWindow;

        private Chatbox mChatBox;

        private CraftingWindow mCraftingWindow;

        private DebugMenu mDebugMenu;

        private EventWindow mEventWindow;

        private ClassChangeWindow mClassChangeWindow;

        private ItemChoiceWindow mItemChoiceWindow;

        private PictureWindow mPictureWindow;

        private QuestOfferWindow mQuestOfferWindow;

        private ShopWindow mShopWindow;

        private SendMailBoxWindow mSendMailBoxWindow;

        private MailBoxWindow mMailBoxWindow;

        private HDVWindow mHDVWindow;

        private TradeSkillInfoWindow mTradeSkillInfoWindow;

        private bool mShouldCloseBag;

        private bool mShouldCloseBank;

        private bool mShouldCloseTradeSkillInfo;

        private bool mShouldCloseGuildBank;

        private bool mShouldCloseCraftingTable;

        private bool mShouldCloseShop;

        private bool mShouldCloseTrading;

        private bool mShouldOpenAdminWindow;

        private bool mShouldOpenBag;

        private bool mShouldOpenBank;

        private bool mShouldOpenTradeSkillInfo;

        private bool mShouldOpenGuildBank;

        private bool mShouldOpenGuildCreate;

        private bool mShouldCloseGuildCreate;

        private bool mShouldOpenCraftingTable;

        private bool mShouldOpenShop;

        private bool mShouldOpenTrading;

        private bool mShouldUpdateQuestLog = true;

        private bool mShouldUpdateFriendsList;

        private bool mShouldUpdateTradeSkillWindow;

        private string mTradingTarget;

        private TradingWindow mTradingWindow;

        public EntityBox PlayerBox;

        public GameInterface([NotNull] Canvas myCanvas)
        {
            GameCanvas = myCanvas;
            EscapeMenu = new EscapeMenu(GameCanvas) {IsHidden = true};

            InitGameGui();
        }

        [NotNull]
        public Canvas GameCanvas { get; }

        [NotNull]
        public EscapeMenu EscapeMenu { get; }

        public Menu GameMenu { get; private set; }

        public Minimap MiniMap { get; private set; }

        public void InitGameGui()
        {
            mChatBox = new Chatbox(GameCanvas, this);
            GameMenu = new Menu(GameCanvas);
            MiniMap = new Minimap(GameCanvas);
            Hotbar = new HotBarWindow(GameCanvas);
            PlayerBox = new EntityBox(GameCanvas, EntityTypes.Player, Globals.Me, true);
            if (mPictureWindow == null)
            {
                mPictureWindow = new PictureWindow(GameCanvas);
            }

            mClassChangeWindow = new ClassChangeWindow(GameCanvas);
            mItemChoiceWindow = new ItemChoiceWindow(GameCanvas);
            mEventWindow = new EventWindow(GameCanvas);
            mQuestOfferWindow = new QuestOfferWindow(GameCanvas);
            mTradeSkillInfoWindow = new TradeSkillInfoWindow(GameCanvas,Guid.Empty,0,0);
            mTradeSkillInfoWindow.Hide();
            mDebugMenu = new DebugMenu(GameCanvas);
        }

        //Chatbox
        public void SetChatboxText(string msg)
        {
            mChatBox.SetChatboxText(msg);
        }

        //Friends Window
        public void NotifyUpdateFriendsList()
        {
            mShouldUpdateFriendsList = true;
        }


        public void NotifyUpdateTradeSkillWindow()
        {
            mShouldUpdateTradeSkillWindow = true;
        }

        //Admin Window
        public void NotifyOpenAdminWindow()
        {
            mShouldOpenAdminWindow = true;
        }

        public void OpenAdminWindow()
        {
            if (mAdminWindow == null)
            {
                mAdminWindow = new AdminWindow(GameCanvas);
            }
            else
            {
                if (mAdminWindow.IsVisible())
                {
                    mAdminWindow.Hide();
                }
                else
                {
                    mAdminWindow.Show();
                }
            }

            mShouldOpenAdminWindow = false;
        }

        //Shop
        public void NotifyOpenShop()
        {
            mShouldOpenShop = true;
        }

        public void NotifyCloseShop()
        {
            mShouldCloseShop = true;
        }

        public void OpenShop()
        {
            if (mShopWindow != null)
            {
                mShopWindow.Close();
            }

            mShopWindow = new ShopWindow(GameCanvas);
            mShouldOpenShop = false;
        }

        // Mail Box
        public void OpenSendMailBox()
        {
            if (mSendMailBoxWindow != null)
            {
                mSendMailBoxWindow.Close();
            }
            mSendMailBoxWindow = new SendMailBoxWindow(GameCanvas);
            mSendMailBoxWindow.UpdateItemListBySlot(-1);
            //mSendMailBoxWindow.UpdateItemList();
            Globals.InSendMailBox = true;
        }

        public void CloseSendMailBox()
        {
            mSendMailBoxWindow?.Hide();
            Globals.InSendMailBox = false;
        }

        public void UpdateSendMailItem(int slot)
        {
            mSendMailBoxWindow?.UpdateItemListBySlot(slot);
        }

        public void OpenMailBox()
        {
            if (mMailBoxWindow != null)
            {
                mMailBoxWindow.UpdateMail();
            }
            else
            {
                mMailBoxWindow = new MailBoxWindow(GameCanvas);
                mMailBoxWindow.UpdateMail();
            }
            Globals.InMailBox = true;
        }

        public void CloseMailBox()
        {
            mMailBoxWindow?.Hide();
            mMailBoxWindow?.Close();
            mMailBoxWindow = null;
            Globals.InMailBox = false;
        }

        // HDV
        public void OpenHDV()
        {
            if (mHDVWindow != null)
            {
                mHDVWindow.UpdateHDV();
            }
            else
            {
                mHDVWindow = new HDVWindow(GameCanvas);
                mHDVWindow.UpdateItemListBySlot(-1);
                mHDVWindow.UpdateHDV();
            }
            Globals.InHDV = true;
        }

        public void CloseHDV()
        {
            mHDVWindow?.Hide();
            mHDVWindow?.Close();
            mHDVWindow = null;
            Globals.InHDV = false;
        }

        public void UpdateSellHDVItem(int slot)
        {
            mHDVWindow?.UpdateItemListBySlot(slot);
        }

        //Bank
        public void NotifyOpenBank()
        {
            mShouldOpenBank = true;
        }

        public void NotifyCloseBank()
        {
            mShouldCloseBank = true;
        }

        public void OpenBank()
        {
            if (mBankWindow != null)
            {
                mBankWindow.Close();
            }

            mBankWindow = new BankWindow(GameCanvas);
            mShouldOpenBank = false;
            Globals.InBank = true;
        }


        //TradeSkillInfo
        public void NotifyOpenTradeSkillInfo()
        {
            mShouldOpenTradeSkillInfo = true;
        }

        public void NotifyCloseTradeSkillInfo()
        {
            mShouldCloseTradeSkillInfo = true;
        }

        public void OpenTradeSkillInfo(Guid tradeskill, int x, int y)
        {
            if (mTradeSkillInfoWindow != null)
            {
                mTradeSkillInfoWindow.Close();
            }

            mTradeSkillInfoWindow = new TradeSkillInfoWindow(GameCanvas, tradeskill,  x,  y);
            mShouldOpenTradeSkillInfo = false;
            mTradeSkillInfoWindow.Update();
        }


        public void MoveTradeSkillInfo( int x, int y)
        {
            if (mTradeSkillInfoWindow == null)
            {
                return;
            }

            mTradeSkillInfoWindow.Move(x,y);
        }

        //GuildCreate
        public void NotifyOpenGuildCreate()
        {
            mShouldOpenGuildCreate = true;

        }

        public void NotifyCloseGuildCreate()
        {
            mShouldCloseGuildCreate = true;

        }

        public void OpenGuildCreate()
        {
            if (mGuildCreateWindow != null)
            {
                mGuildCreateWindow.Close();
            }

            mGuildCreateWindow = new GuildCreateWindow(GameCanvas);
            mGuildCreateWindow.UpdateItem();
            mShouldOpenGuildCreate = false;
            Globals.InGuildCreate = true;
        }

        //GuildBank
        public void NotifyOpenGuildBank()
        {
            mShouldOpenGuildBank = true;
        }

        public void NotifyCloseGuildBank()
        {
            mShouldCloseGuildBank = true;
        }

        public void OpenGuildBank()
        {
            if (mGuildBankWindow != null)
            {
                mGuildBankWindow.Close();
            }

            mGuildBankWindow = new GuildBankWindow(GameCanvas);
            mShouldOpenGuildBank = false;
            Globals.InGuildBank = true;
        }

        //Bag
        public void NotifyOpenBag()
        {
            mShouldOpenBag = true;
        }

        public void NotifyCloseBag()
        {
            mShouldCloseBag = true;
        }

        public void OpenBag()
        {
            if (mBagWindow != null)
            {
                mBagWindow.Close();
            }

            mBagWindow = new BagWindow(GameCanvas);
            mShouldOpenBag = false;
            Globals.InBag = true;
        }

        //Crafting
        public void NotifyOpenCraftingTable()
        {
            mShouldOpenCraftingTable = true;
        }

        public void NotifyCloseCraftingTable()
        {
            mShouldCloseCraftingTable = true;
        }

        public void OpenCraftingTable()
        {
            if (mCraftingWindow != null)
            {
                mCraftingWindow.Close();
            }

            mCraftingWindow = new CraftingWindow(GameCanvas);
            mShouldOpenCraftingTable = false;
            Globals.InCraft = true;
        }

        //Quest Log
        public void NotifyQuestsUpdated()
        {
            mShouldUpdateQuestLog = true;
        }

        //Trading
        public void NotifyOpenTrading(string traderName)
        {
            mShouldOpenTrading = true;
            mTradingTarget = traderName;
        }

        public void NotifyCloseTrading()
        {
            mShouldCloseTrading = true;
        }

        public void OpenTrading()
        {
            if (mTradingWindow != null)
            {
                mTradingWindow.Close();
            }

            mTradingWindow = new TradingWindow(GameCanvas, mTradingTarget);
            mShouldOpenTrading = false;
            Globals.InTrade = true;
        }

        public void ShowHideDebug()
        {
            if (mDebugMenu.IsVisible())
            {
                mDebugMenu.Hide();
            }
            else
            {
                mDebugMenu.Show();
            }
        }

        public void ShowAdminWindow()
        {
            if (mAdminWindow == null)
            {
                mAdminWindow = new AdminWindow(GameCanvas);
            }

            mAdminWindow.Show();
        }

        public bool AdminWindowOpen()
        {
            if (mAdminWindow != null && mAdminWindow.IsVisible())
            {
                return true;
            }

            return false;
        }

        public void AdminWindowSelectName(string name)
        {
            mAdminWindow.SetName(name);
        }

        public void Draw()
        {
            if (Globals.Me != null && PlayerBox?.MyEntity != Globals.Me)
            {
                PlayerBox?.SetEntity(Globals.Me);
            }

            mChatBox?.Update();
            GameMenu?.Update(mShouldUpdateQuestLog);
            mShouldUpdateQuestLog = false;
            Hotbar?.Update();
            mDebugMenu?.Update();
            EscapeMenu.Update();
            PlayerBox?.Update();

            if (Globals.QuestOffers.Count > 0)
            {
                var quest = QuestBase.Get(Globals.QuestOffers[0]);
                mQuestOfferWindow.Update(quest);
            }
            else
            {
                mQuestOfferWindow.Hide();
            }

            if (Globals.ItemChoice.Count > 0)
            {
                mItemChoiceWindow.Update();
            }
            else
            {
                mItemChoiceWindow.Hide();
            }

            if (Globals.Picture != null)
            {
                if (mPictureWindow.Picture != Globals.Picture ||
                    mPictureWindow.Size != Globals.PictureSize ||
                    mPictureWindow.Clickable != Globals.PictureClickable)
                {
                    mPictureWindow.Setup(Globals.Picture, Globals.PictureSize, Globals.PictureClickable);
                }
            }
            else
            {
                if (mPictureWindow != null)
                {
                    mPictureWindow.Close();
                }
            }

            mEventWindow?.Update();
            mClassChangeWindow?.Update();
            mItemChoiceWindow?.Update();

            //Admin window update
            if (mShouldOpenAdminWindow)
            {
                OpenAdminWindow();
            }

            //Shop Update
            if (mShouldOpenShop)
            {
                OpenShop();
            }

            if (mShopWindow != null && (!mShopWindow.IsVisible() || mShouldCloseShop))
            {
                PacketSender.SendCloseShop();
                CloseShop();
            }

            mShouldCloseShop = false;

            if (mSendMailBoxWindow != null && !mSendMailBoxWindow.IsVisible())
            {
                mSendMailBoxWindow?.Close();
                mSendMailBoxWindow = null;
                Globals.InSendMailBox = false;
            }

            if (mMailBoxWindow != null && !mMailBoxWindow.IsVisible())
            {
                mMailBoxWindow?.Close();
                mMailBoxWindow = null;
                Globals.InMailBox = false;
            }

            if (mHDVWindow != null && !mHDVWindow.IsVisible())
            {
                mHDVWindow?.Close();
                mHDVWindow = null;
                Globals.InHDV = false;
            }

            //GuildCreate Update
            if (mShouldOpenGuildCreate)
            {
                OpenGuildCreate();
            }

            if (mGuildCreateWindow != null)
            {
                if (!mGuildCreateWindow.IsVisible() || mShouldCloseGuildCreate)
                {
                    PacketSender.SendCloseGuildCreate();
                    CloseGuildCreate();
                }
                else
                {
                    mGuildCreateWindow.Update();
                }
            }

            mShouldCloseGuildCreate = false;

            //Bank Update
            if (mShouldOpenBank)
            {
                OpenBank();
            }

            if (mBankWindow != null)
            {
                if (!mBankWindow.IsVisible() || mShouldCloseBank)
                {
                    PacketSender.SendCloseBank();
                    CloseBank();
                }
                else
                {
                    mBankWindow.Update();
                }
            }

            mShouldCloseBank = false;

            //GuildBank Update
            if (mShouldOpenGuildBank)
            {
                OpenGuildBank();
            }

            if (mGuildBankWindow != null)
            {
                if (!mGuildBankWindow.IsVisible() || mShouldCloseGuildBank)
                {
                    PacketSender.SendCloseGuildBank();
                    CloseGuildBank();
                }
                else
                {
                    mGuildBankWindow.Update();
                }
            }

            mShouldCloseGuildBank = false;

            //Bag Update
            if (mShouldOpenBag)
            {
                OpenBag();
            }

            if (mBagWindow != null)
            {
                if (!mBagWindow.IsVisible() || mShouldCloseBag)
                {
                    PacketSender.SendCloseBag();
                    CloseBagWindow();
                }
                else
                {
                    mBagWindow.Update();
                }
            }

            mShouldCloseBag = false;

            //Crafting station update
            if (mShouldOpenCraftingTable)
            {
                OpenCraftingTable();
            }

            if (mCraftingWindow != null)
            {
                if (!mCraftingWindow.IsVisible() || mShouldCloseCraftingTable)
                {
                    PacketSender.SendCloseCrafting();
                    CloseCraftingTable();
                }
                else
                {
                    mCraftingWindow.Update();
                }
            }

            mShouldCloseCraftingTable = false;

            //Trading update
            if (mShouldOpenTrading)
            {
                OpenTrading();
            }

            if (mTradingWindow != null)
            {
                if (mShouldCloseTrading)
                {
                    CloseTrading();
                    mShouldCloseTrading = false;
                }
                else
                {
                    if (!mTradingWindow.IsVisible())
                    {
                        PacketSender.SendDeclineTrade();
                        CloseTrading();
                    }
                    else
                    {
                        mTradingWindow.Update();
                    }
                }
            }

            if (mShouldUpdateFriendsList)
            {
                GameMenu.UpdateFriendsList();
            }

            if (mShouldUpdateTradeSkillWindow)
            {
                GameMenu.UpdateTradeSkillWindow();
                mShouldUpdateTradeSkillWindow = false;
            }

            mShouldCloseTrading = false;

            if (FocusChat)
            {
                mChatBox.Focus();
                FocusChat = false;
            }

            GameCanvas.RenderCanvas();
        }

        private void CloseShop()
        {
            Globals.GameShop = null;
            mShopWindow?.Close();
            mShopWindow = null;
        }

        private void CloseBank()
        {
            mBankWindow?.Close();
            mBankWindow = null;
            Globals.InBank = false;
        }

        private void CloseGuildCreate()
        {
            mGuildCreateWindow?.Close();
            mGuildCreateWindow = null;
            Globals.InGuildCreate = false;
        }

        private void CloseGuildBank()
        {
            mGuildBankWindow?.Close();
            mGuildBankWindow = null;
            Globals.InGuildBank = false;
        }


        private void CloseBagWindow()
        {
            mBagWindow?.Close();
            mBagWindow = null;
            Globals.InBag = false;
        }

        private void CloseCraftingTable()
        {
            mCraftingWindow?.Close();
            mCraftingWindow = null;
            Globals.InCraft = false;
        }

        private void CloseTrading()
        {
            mTradingWindow?.Close();
            mTradingWindow = null;
            Globals.InTrade = false;
        }

        //Dispose
        public void Dispose()
        {
            CloseBagWindow();
            CloseBank();
            CloseGuildBank();
            CloseCraftingTable();
            CloseShop();
            CloseTrading();
            CloseGuildCreate();
            GameCanvas.Dispose();
        }

    }

}
