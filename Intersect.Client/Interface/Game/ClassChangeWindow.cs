using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.GameObjects;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using System.Timers;


using Intersect.Client.Framework.Graphics;

using System;

using Intersect.Client.Core.Controls;
using System.Threading.Tasks;
using System.Collections.Generic;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Enums;

namespace Intersect.Client.Interface.Game
{

    public class ClassChangeWindow
    {

        private ScrollControl mClassChangeArea;

        private RichLabel mClassChangeAreaLabel;

        private Label mClassChangeAreaLabelTemplate;


        Label ClassNameLabel;

        Label ClassMainStatLabel;

        Label ClassMainStatLabelInfo;

        //Window Controls
        private ImagePanel mClassChangeWindow;

        private ImagePanel mClass1;

        private ImagePanel mClass2;

        private ImagePanel mClass3;

        private ImagePanel mClass4;

        private Button btnClass1;

        private Button btnClass2;

        private Button btnClass3;

        private Button btnClass4;

        private Button btnClassChangeConfirm;

        private Timer mTimerFace;

        private Label mLblDemoSpells;

        //Item/Spell Rendering
        private ScrollControl mItemContainer;

        static long keyTimer = Globals.System.GetTimeMs() + 1000;

        int counter;

        int len;

        byte choice = 1;

        //Location
        public int X;

        public int Y;

        private bool Initialized;

        //Demo Spell List
        public List<DemoSpellItem> Items = new List<DemoSpellItem>();

        private GameTexture Class1Texture;
        private GameTexture Class2Texture;
        private GameTexture Class3Texture;
        private GameTexture Class4Texture;

        //Init
        public ClassChangeWindow(Canvas gameCanvas)
        {
            //Event Dialog Window
            mClassChangeWindow = new ImagePanel(gameCanvas, "ClassChangeWindow");
            mClassChangeWindow.Hide();
            Interface.InputBlockingElements.Add(mClassChangeWindow);

            mClass1 = new ImagePanel(mClassChangeWindow, "Class1Image");
            mClass2 = new ImagePanel(mClassChangeWindow, "Class2Image");
            mClass3 = new ImagePanel(mClassChangeWindow, "Class3Image");
            mClass4 = new ImagePanel(mClassChangeWindow, "Class4Image");

            mClassChangeArea = new ScrollControl(mClassChangeWindow, "ClassChangeArea");
            mClassChangeAreaLabelTemplate = new Label(mClassChangeArea, "ClassChangeLabel");
            mClassChangeAreaLabel = new RichLabel(mClassChangeArea);

            btnClass1 = new Button(mClassChangeWindow, "ClassChange1Btn");
            btnClass1.Clicked += btnClass1_Clicked;

            btnClass2 = new Button(mClassChangeWindow, "ClassChange2Btn");
            btnClass2.Clicked += btnClass2_Clicked;

            btnClass3 = new Button(mClassChangeWindow, "ClassChange3Btn");
            btnClass3.Clicked += btnClass3_Clicked;

            btnClass4 = new Button(mClassChangeWindow, "ClassChange4Btn");
            btnClass4.Clicked += btnClass4_Clicked;

            btnClassChangeConfirm = new Button(mClassChangeWindow, "ClassChangeConfirmBtn");
            btnClassChangeConfirm.SetText("Confirm");
            btnClassChangeConfirm.Clicked += btnClassChangeConfirm_Clicked;

            ClassNameLabel = new Label(mClassChangeWindow, "ClassNameLabel");
            ClassMainStatLabel = new Label(mClassChangeWindow, "ClassMainStatLabel");
            ClassMainStatLabelInfo = new Label(mClassChangeWindow, "ClassMainStatLabelInfo");

            mLblDemoSpells = new Label(mClassChangeWindow, "DemoSpellsLabel");

            mItemContainer = new ScrollControl(mClassChangeWindow, "SpellsContainer");
            mItemContainer.EnableScroll(false, false);
        }

        //Update
        public void Update()
        {

            X = mClassChangeWindow.X;
            Y = mClassChangeWindow.Y;

            if (Globals.ClassChange.Count > 0)
            {
                if (mClassChangeWindow.IsHidden)
                {
                    mClassChangeWindow.Show();
                    mClassChangeWindow.MakeModal();
                    mClassChangeArea.ScrollToTop();
                    mClassChangeWindow.BringToFront();

                    var responseCount = 0;
                    var maxResponse = 1;


                    mClassChangeWindow.Name = "ClassChangeWindow";
                    btnClass1.Name = "btnClass1";
                    btnClass2.Name = "btnClass2";
                    btnClass3.Name = "btnClass3";
                    btnClass4.Name = "btnClass4";
                    btnClass1.Hide();
                    btnClass2.Hide();
                    btnClass3.Hide();
                    btnClass4.Hide();


                    if (Globals.ClassChange[0].Class1 != Guid.Empty)
                    {
                        responseCount++;
                        Class1Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, ClassBase.Get(Globals.ClassChange[0].Class1).Name + ".png");
                        btnClass1.Show();
                    }

                    if (Globals.ClassChange[0].Class2 != Guid.Empty)
                    {
                        responseCount++;
                        maxResponse = 2;
                        Class2Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, ClassBase.Get(Globals.ClassChange[0].Class2).Name + ".png");
                        btnClass2.Show();
                    }

                    if (Globals.ClassChange[0].Class3 != Guid.Empty)
                    {
                        responseCount++;
                        maxResponse = 3;
                        Class3Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, ClassBase.Get(Globals.ClassChange[0].Class3).Name + ".png");
                        btnClass3.Show();
                    }

                    if (Globals.ClassChange[0].Class4 != Guid.Empty)
                    {
                        responseCount++;
                        maxResponse = 4;
                        Class4Texture = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Image, ClassBase.Get(Globals.ClassChange[0].Class4).Name + ".png");
                        btnClass4.Show();
                    }

                    mClassChangeWindow.LoadJsonUi(
                        GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString()
                    );

                    if (Class1Texture != null)
                    {
                        mClass1.Texture = Class1Texture;
                    }

                    if (Class2Texture != null)
                    {
                        mClass2.Texture = Class2Texture;
                        mClass2.Hide();
                    }

                    if (Class3Texture != null)
                    {
                        mClass3.Texture = Class3Texture;
                        mClass3.Hide();
                    }
                    if (Class4Texture != null)
                    {
                        mClass4.Texture = Class4Texture;
                        mClass4.Hide();
                    }

                    if (responseCount == 0)
                    {
                        btnClass1.Show();
                        btnClass1.SetText(Strings.EventWindow.Continue);
                        btnClass2.Hide();
                        btnClass3.Hide();
                        btnClass4.Hide();
                    }
                    else
                    {
                        if (Globals.ClassChange[0].Class1 != Guid.Empty)
                        {
                            btnClass1.Show();
                            btnClass1.SetText(ClassBase.GetName(Globals.ClassChange[0].Class1));
                            btnClass1.SetPosition(
                                50,
                                1 * 50
                            );
                        }
                        else
                        {
                            btnClass1.Hide();
                        }

                        if (Globals.ClassChange[0].Class2 != Guid.Empty)
                        {
                            btnClass2.Show();
                            btnClass2.SetText(ClassBase.GetName(Globals.ClassChange[0].Class2));
                            btnClass2.SetPosition(
                                50,
                                2 * 50
                            );
                        }
                        else
                        {
                            btnClass2.Hide();
                        }

                        if (Globals.ClassChange[0].Class3 != Guid.Empty)
                        {
                            btnClass3.Show();
                            btnClass3.SetText(ClassBase.GetName(Globals.ClassChange[0].Class3));
                            btnClass3.SetPosition(
                                50,
                                3 * 50
                            );
                        }
                        else
                        {
                            btnClass3.Hide();
                        }

                        if (Globals.ClassChange[0].Class4 != Guid.Empty)
                        {
                            btnClass4.Show();
                            btnClass4.SetText(ClassBase.GetName(Globals.ClassChange[0].Class4));
                            btnClass4.SetPosition(
                                50,
                                4 * 50
                            );
                        }
                        else
                        {
                            btnClass4.Hide();
                        }
                    }

                    mLblDemoSpells.Text = "Spells Preview:";
                    
                    mClassChangeWindow.SetSize(
                        mClassChangeWindow.Texture.GetWidth(), mClassChangeWindow.Texture.GetHeight()
                    );
                }
                if (!Initialized)
                {
                    Initialize();
                }
            }
        }

        public void Initialize()
        {
            var tempClass = Guid.Empty;

            switch (choice)
            {
                case 1:
                    tempClass = Globals.ClassChange[0].Class1;
                    break;
                case 2:
                    tempClass = Globals.ClassChange[0].Class2;
                    break;
                case 3:
                    tempClass = Globals.ClassChange[0].Class3;
                    break;
                case 4:
                    tempClass = Globals.ClassChange[0].Class4;
                    break;
                default:
                    tempClass = Globals.ClassChange[0].Class1;
                    break;
            }
            var tempNumber = 0;
            var highest = 0;

            for (var i = 0; i < (int)Stats.StatCount; i++)
            {
                if (ClassBase.Get(tempClass).BaseStat[i] > tempNumber)
                {
                    tempNumber = ClassBase.Get(tempClass).BaseStat[i];
                    highest = i;
                }
            }

            ClassMainStatLabel.Text = "Main stat:";
            ClassMainStatLabelInfo.Text = Strings.ItemDesc.rawstats[highest];
            ClassNameLabel.Text = ClassBase.GetName(tempClass);
            Items.Clear();
            for (var i = 0; i < Math.Min(ClassBase.Get(tempClass).Spells.Count, 3); i++)
            {
                Items.Add(new DemoSpellItem(this, tempClass, i));
                Items[i].Container = new ImagePanel(mItemContainer, "DemoSpell");
                Items[i].Setup();

                Items[i].Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
                var xPadding = Items[i].Container.Margin.Left + Items[i].Container.Margin.Right;
                var yPadding = Items[i].Container.Margin.Top + Items[i].Container.Margin.Bottom;
                Items[i]
                    .Container.SetPosition(
                        i %
                        (mItemContainer.Width / (Items[i].Container.Width + xPadding)) *
                        (Items[i].Container.Width + xPadding) +
                        xPadding,
                        i /
                        (mItemContainer.Width / (Items[i].Container.Width + xPadding)) *
                        (Items[i].Container.Height + yPadding) +
                        yPadding
                    );
                Items[i].Update();
            }
            Initialized = true;
        }


        //Input Handlers

        void btnClassChangeConfirm_Clicked(Base sender, ClickedEventArgs arguments)
        {
            if (Globals.ClassChange.Count > 0)
            {
                var ed = Globals.ClassChange[0] ?? null;
                if (ed.ResponseSent != 0)
                {
                    return;
                }

                PacketSender.SendClassChangeResponse(choice, ed);
                mClassChangeWindow.RemoveModal();
                mClassChangeWindow.IsHidden = true;
                ed.ResponseSent = 1;
                choice = 1;
                Initialized = false;
            }
        }

        void btnClass4_Clicked(Base sender, ClickedEventArgs arguments)
        {
            mClass4.Show();
            mClass3.Hide();
            mClass2.Hide();
            mClass1.Hide();
            choice = 4;
            Initialized = false;
        }

        void btnClass3_Clicked(Base sender, ClickedEventArgs arguments)
        {
            mClass3.Show();
            mClass1.Hide();
            mClass2.Hide();
            mClass4.Hide();
            choice = 3;
            Initialized = false;
        }

        void btnClass2_Clicked(Base sender, ClickedEventArgs arguments)
        {
            mClass2.Show();
            mClass1.Hide();
            mClass3.Hide();
            mClass4.Hide();
            choice = 2;
            Initialized = false;
        }

        void btnClass1_Clicked(Base sender, ClickedEventArgs arguments)
        {
            mClass1.Show();
            mClass2.Hide();
            mClass3.Hide();
            mClass4.Hide();
            choice = 1;
            Initialized = false;
        }


        public FloatRect RenderBounds()
        {
            var rect = new FloatRect()
            {
                X = mClassChangeWindow.LocalPosToCanvas(new Point(0, 0)).X -
                    (Items[0].Container.Padding.Left + Items[0].Container.Padding.Right) / 2,
                Y = mClassChangeWindow.LocalPosToCanvas(new Point(0, 0)).Y -
                    (Items[0].Container.Padding.Top + Items[0].Container.Padding.Bottom) / 2,
                Width = mClassChangeWindow.Width + Items[0].Container.Padding.Left + Items[0].Container.Padding.Right,
                Height = mClassChangeWindow.Height + Items[0].Container.Padding.Top + Items[0].Container.Padding.Bottom
            };

            return rect;
        }
    }

}
