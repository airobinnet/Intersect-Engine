using Intersect.Client.Core;
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
using System.Timers;
using Intersect.GameObjects.Maps;
using System;
using Intersect.Enums;
using System.Collections.Generic;

namespace Intersect.Client.Interface.Game
{

    public class Minimap
    {

        private readonly ImagePanel mMiniMap;

        private readonly ImagePanel mMiniMapBg;

        private readonly ImagePanel PlayerDot;

        private readonly ImagePanel EntityDot;

        private readonly Button mCharacterButton;

        private Label Xcoords;

        private Label Ycoords;

        private Label Info;
        
        //Menu Container
        private readonly ImagePanel mMiniMapContainer;

        private int mBackgroundHeight = 42;

        private int mBackgroundWidth = 42;

        private int mButtonHeight = 34;

        private int mButtonMargin = 8;

        private int mButtonWidth = 34;

        private bool Initialized;

        private readonly ImagePanel MMiniMapBorder;

        private Timer mTimer;

        //Canvas instance
        private Canvas mGameCanvas;

        //Init
        public Minimap(Canvas gameCanvas)
        {
            mGameCanvas = gameCanvas;

            mMiniMapContainer = new ImagePanel(gameCanvas, "MinimapContainer");
            mMiniMapContainer.ShouldCacheToTexture = true;

            mMiniMapBg = new ImagePanel(mMiniMapContainer, "MapContainerBg");
            mMiniMap = new ImagePanel(mMiniMapContainer, "MapContainer");

            PlayerDot = new ImagePanel(mMiniMap, "PlayerDot");
            MMiniMapBorder = new ImagePanel(mMiniMapContainer, "MiniMapBorder");

            Xcoords = new Label(mMiniMapContainer, "Xcoords");
            Ycoords = new Label(mMiniMapContainer, "Ycoords");
            Info = new Label(mMiniMapContainer, "Info");



            mMiniMapContainer.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

            mTimer = new Timer();
            mTimer.Interval = 100;
            // Have the timer fire repeated events (true is the default)
            mTimer.AutoReset = true;

            // Start the timer
            mTimer.Enabled = true;
            mTimer.Elapsed += mTimer_Tick;

            Update();
        }

        //Methods
        public void Update()
        {
            Init();
        }

        private void mTimer_Tick(object sender, ElapsedEventArgs elapsedEventArg)
        {
            Initialized = false;
            
            Init();
        }

        public void Init()
        {
            if (!Initialized)
            {

                if (Globals.Me != null)
                {
                    Xcoords.Text = Globals.Me?.WorldPos.X.ToString() + "/" + Globals.Me?.WorldPos.Y.ToString();
                    if (Globals.Me?.MapInstance != null)
                    {
                        var maptag = MapBase.Get(Globals.Me.CurrentMap).Tags;
                        var firsttag = "unknown";
                        if (maptag.Count > 0)
                        {
                            firsttag = maptag[0];
                        }

                        var mapTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, firsttag + ".png");
                        if (mapTex != null)
                        {
                            mMiniMap.Hide();
                            mMiniMap.Texture = mapTex;

                            Ycoords.Text ="";                            

                            var tempX = Globals.Me?.WorldPos.X;
                            var tempY = Globals.Me?.WorldPos.Y;

                            var tempW = Math.Min(1000, mapTex.GetWidth());
                            var tempH = Math.Min(1000, mapTex.GetHeight());
                            if (mapTex.GetWidth() > 1000)
                            {
                                mMiniMap.SetTextureRect(((int)tempX - (int)tempW) / 4, ((int)tempY - (int)tempH) / 4, (int)tempW / 2, (int)tempH / 2);

                                /*var dotX = (float)mMiniMapContainer.Width / 2;
                                var dotY = (float)mMiniMapContainer.Height / 2;

                                Info.Text = tempX + "," + mapTex.GetWidth();

                                if ((int)tempY < (int)tempH)
                                {
                                    dotY = (float)((tempY - tempH) / 8) + 125;
                                }
                                if ((int)tempX < (int)tempW)
                                {
                                    dotX = (float)((tempX - tempW) / 8) + 125;
                                }

                                PlayerDot.SetPosition(dotX, dotY);*/

                                mMiniMap.SetSize(250, 250);
                            } else
                            {
                                mMiniMap.SetTextureRect(0,0, mapTex.GetWidth(), mapTex.GetHeight());
                                mMiniMap.SetSize(Math.Min(mapTex.GetWidth(),250), Math.Min(mapTex.GetHeight(),250));
                                //PlayerDot.SetPosition((float)(tempX/4), (float)(tempY/4));
                            }
                            PlayerDot.Hide();
                            mMiniMap.Show();
                        }
                    }
                }

                Initialized = true;
            }
        }

        //Input Handlers
        private static void MenuButtonClicked(Base sender, ClickedEventArgs arguments)
        {
            Interface.GameUi?.EscapeMenu?.ToggleHidden();
        }
        
    }

}
