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

using System.Timers;
using Steamworks;

namespace Intersect.Client.Interface.Game.CashShop
{

    public class CashShopWindow
    {
        private Label mNameText;

        private Button mBuy1Button;

        private Button mBuy2Button;

        private Button mBuy3Button;

        private Button mBuy4Button;

        private Button mBuy5Button;

        private Button mBuy6Button;

        private Button mShop1Button;

        private Button mShop2Button;

        private Button mShop3Button;

        private ComboBox orderCB;

        //private ListBox mMembers;

        private int tempTimer = 99;

        private TextBox mSearchTextbox;

        //Temp variables
        private string mTempName;

        private ImagePanel mTextboxContainer;

        //Controls
        private WindowControl mCashShopWindow;

        private Timer mTimer;

        private bool imageSwitch = false;

        //Init
        public CashShopWindow(Canvas gameCanvas)
        {
            mCashShopWindow = new WindowControl(gameCanvas, "Cash Shop", false, "CashShopWindow");
            mCashShopWindow.DisableResizing();
            
            mNameText = new Label(mCashShopWindow, "NameText");
            mNameText.SetTextColor(new Color(0, 0, 0, 0), Label.ControlState.Normal);
            mNameText.Text = "Cash Shop";

            mBuy1Button = new Button(mCashShopWindow, "Buy1Button");
            mBuy1Button.Text = "";
            mBuy1Button.SetToolTipText("Buy pack 1");
            mBuy1Button.Clicked += mBuy1Button_Clicked;

            mBuy2Button = new Button(mCashShopWindow, "Buy2Button");
            mBuy2Button.Text = "";
            mBuy2Button.SetToolTipText("Buy pack 2");
            mBuy2Button.Clicked += mBuy2Button_Clicked;

            mBuy3Button = new Button(mCashShopWindow, "Buy3Button");
            mBuy3Button.Text = "";
            mBuy3Button.SetToolTipText("Buy pack 3");
            mBuy3Button.Clicked += mBuy3Button_Clicked;

            mBuy4Button = new Button(mCashShopWindow, "Buy4Button");
            mBuy4Button.Text = "";
            mBuy4Button.SetToolTipText("Buy pack 4");
            mBuy4Button.Clicked += mBuy4Button_Clicked;

            mBuy5Button = new Button(mCashShopWindow, "Buy5Button");
            mBuy5Button.Text = "";
            mBuy5Button.SetToolTipText("Buy pack 5");
            mBuy5Button.Clicked += mBuy5Button_Clicked;

            mBuy6Button = new Button(mCashShopWindow, "Buy6Button");
            mBuy6Button.Text = "";
            mBuy6Button.SetToolTipText("Buy pack 6");
            mBuy6Button.Clicked += mBuy6Button_Clicked;

            mShop1Button = new Button(mCashShopWindow, "OpenShop1");
            mShop1Button.Text = "";
            mShop1Button.SetToolTipText("Open Pets Shop");
            mShop1Button.Clicked += mOpenShop1Button_Clicked;

            mShop2Button = new Button(mCashShopWindow, "OpenShop2");
            mShop2Button.Text = "";
            mShop2Button.SetToolTipText("Open Cosmetics Shop");
            mShop2Button.Clicked += mOpenShop2Button_Clicked;

            mShop3Button = new Button(mCashShopWindow, "OpenShop3");
            mShop3Button.Text = "";
            mShop3Button.SetToolTipText("Open Boosts Shop");
            mShop3Button.Clicked += mOpenShop3Button_Clicked;

            mTimer = new Timer();
            mTimer.Interval = 500;
            mTimer.Elapsed += mTimer_Tick;

            Start();

            mCashShopWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
        }

        private void mTimer_Tick(object sender, ElapsedEventArgs elapsedEventArg)
        {
           
        }

        public void Start()
        {
            mTimer.Start();
        }

        //Methods
        public void Update()
        {

            if (mCashShopWindow.IsHidden)
            {
                return;
            }
            
        }
        
        public void Show()
        {
            mCashShopWindow.IsHidden = false;
        }

        public bool IsVisible()
        {
            return !mCashShopWindow.IsHidden;
        }

        public void UpdateList()
        {
            
        }

        public void Hide()
        {
            mCashShopWindow.IsHidden = true;
        }

        void mBuy1Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            SteamFriends.OpenWebOverlay("https://floor100.com/steamshop.php?item=" + Options.CashShopOptions.ShopItem1 + "&steamid=" + SteamClient.SteamId);
        }

        void mBuy2Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            SteamFriends.OpenWebOverlay("https://floor100.com/steamshop.php?item=" + Options.CashShopOptions.ShopItem2 + "&steamid=" + SteamClient.SteamId);
        }

        void mBuy3Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            SteamFriends.OpenWebOverlay("https://floor100.com/steamshop.php?item=" + Options.CashShopOptions.ShopItem3 + "&steamid=" + SteamClient.SteamId);
        }

        void mBuy4Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            SteamFriends.OpenWebOverlay("https://floor100.com/steamshop.php?item=" + Options.CashShopOptions.ShopItem4 + "&steamid=" + SteamClient.SteamId);
        }

        void mBuy5Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            SteamFriends.OpenWebOverlay("https://floor100.com/steamshop.php?item=" + Options.CashShopOptions.ShopItem5 + "&steamid=" + SteamClient.SteamId);
        }

        void mBuy6Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            SteamFriends.OpenWebOverlay("https://floor100.com/steamshop.php?item=" + Options.CashShopOptions.ShopItem6 + "&steamid=" + SteamClient.SteamId);
        }


        void mOpenShop1Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.OpenCashShop(Options.CashShopOptions.ShopLink1);
        }

        void mOpenShop2Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.OpenCashShop(Options.CashShopOptions.ShopLink2);
        }

        void mOpenShop3Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            PacketSender.OpenCashShop(Options.CashShopOptions.ShopLink3);
        }

    }

}
