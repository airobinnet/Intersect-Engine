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

        private ImagePanel mShop1Item;

        private ImagePanel mShop2Item;

        private ImagePanel mShop3Item;

        private ImagePanel mShop4Item;

        private Button mBuy1Button;

        private Button mBuy2Button;

        private Button mBuy3Button;

        private Button mBuy4Button;

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
            mBuy1Button.Text = "Buy";
            mBuy1Button.SetToolTipText("Buy pack 1");
            mBuy1Button.Clicked += mBuy1Button_Clicked;

            mBuy2Button = new Button(mCashShopWindow, "Buy2Button");
            mBuy2Button.Text = "Buy";
            mBuy2Button.SetToolTipText("Buy pack 2");
            mBuy2Button.Clicked += mBuy2Button_Clicked;

            mBuy3Button = new Button(mCashShopWindow, "Buy3Button");
            mBuy3Button.Text = "Buy";
            mBuy3Button.SetToolTipText("Buy pack 3");
            mBuy3Button.Clicked += mBuy3Button_Clicked;

            mBuy4Button = new Button(mCashShopWindow, "Buy4Button");
            mBuy4Button.Text = "Buy";
            mBuy4Button.SetToolTipText("Buy pack 4");
            mBuy4Button.Clicked += mBuy4Button_Clicked;

            mShop1Item = new ImagePanel(mCashShopWindow, "Shop1Item");
            mShop1Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop1item.png");

            mShop2Item = new ImagePanel(mCashShopWindow, "Shop2Item");
            mShop2Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop2item.png");

            mShop3Item = new ImagePanel(mCashShopWindow, "Shop3Item");
            mShop3Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop3item.png");

            mShop4Item = new ImagePanel(mCashShopWindow, "Shop4Item");
            mShop4Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop4item.png");

            mTimer = new Timer();
            mTimer.Interval = 500;
            mTimer.Elapsed += mTimer_Tick;

            Start();

            mCashShopWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
        }

        private void mTimer_Tick(object sender, ElapsedEventArgs elapsedEventArg)
        {
            if (!imageSwitch)
            {
                mShop1Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop1item.png");
                mShop2Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop2item.png");
                mShop3Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop3item.png");
                mShop4Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop4Item.png");
                imageSwitch = true;
            }
            else
            {
                mShop1Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop1itema.png");
                mShop2Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop2itema.png");
                mShop3Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop3itema.png");
                mShop4Item.Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, "shop4itema.png");
                imageSwitch = false;
            }
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
            SteamFriends.OpenWebOverlay("https://floor100.com/steamshop.php?item=1&steamid=" + SteamClient.SteamId);
        }

        void mBuy2Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            SteamFriends.OpenWebOverlay("https://floor100.com/steamshop.php?item=2&steamid=" + SteamClient.SteamId);
        }

        void mBuy3Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            SteamFriends.OpenWebOverlay("https://floor100.com/steamshop.php?item=3&steamid=" + SteamClient.SteamId);
        }

        void mBuy4Button_Clicked(Base sender, ClickedEventArgs arguments)
        {
            SteamFriends.OpenWebOverlay("https://floor100.com/steamshop.php?item=4&steamid=" + SteamClient.SteamId);
        }

    }

}
