using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using System.Timers;

using Intersect.Client.Core.Controls;
using System.Threading.Tasks;

namespace Intersect.Client.Interface.Game
{

    public class EventWindow
    {

        private ScrollControl mEventDialogArea;

        private ScrollControl mEventDialogAreaNoFace;

        private RichLabel mEventDialogLabel;

        private RichLabel mEventDialogLabelNoFace;

        private Label mEventDialogLabelNoFaceTemplate;

        private Label mEventDialogLabelTemplate;

        //Window Controls
        private ImagePanel mEventDialogWindow;

        private ImagePanel mEventFace;

        private Button mEventResponse1;

        private Button mEventResponse2;

        private Button mEventResponse3;

        private Button mEventResponse4;

        private Timer mTimer;

        private Timer mTimerFace;

        static long keyTimer = Globals.System.GetTimeMs() + 1000;

        int counter;

        int len;

        //Init
        public EventWindow(Canvas gameCanvas)
        {
            //Event Dialog Window
            mEventDialogWindow = new ImagePanel(gameCanvas, "EventDialogueWindow");
            mEventDialogWindow.Hide();
            Interface.InputBlockingElements.Add(mEventDialogWindow);

            mEventFace = new ImagePanel(mEventDialogWindow, "EventFacePanel");

            mEventDialogArea = new ScrollControl(mEventDialogWindow, "EventDialogArea");
            mEventDialogLabelTemplate = new Label(mEventDialogArea, "EventDialogLabel");
            mEventDialogLabel = new RichLabel(mEventDialogArea);

            mEventDialogAreaNoFace = new ScrollControl(mEventDialogWindow, "EventDialogAreaNoFace");
            mEventDialogLabelNoFaceTemplate = new Label(mEventDialogAreaNoFace, "EventDialogLabel");
            mEventDialogLabelNoFace = new RichLabel(mEventDialogAreaNoFace);

            mEventResponse1 = new Button(mEventDialogWindow, "EventResponse1");
            mEventResponse1.Clicked += EventResponse1_Clicked;

            mEventResponse2 = new Button(mEventDialogWindow, "EventResponse2");
            mEventResponse2.Clicked += EventResponse2_Clicked;

            mEventResponse3 = new Button(mEventDialogWindow, "EventResponse3");
            mEventResponse3.Clicked += EventResponse3_Clicked;

            mEventResponse4 = new Button(mEventDialogWindow, "EventResponse4");
            mEventResponse4.Clicked += EventResponse4_Clicked;

            mTimer = new Timer();
            mTimer.Interval = 20;
            mTimer.Elapsed += mTimer_Tick;

            mTimerFace = new Timer();
            mTimerFace.Interval = 20;
            mTimerFace.Elapsed += mTimerFace_Tick;
            mEventDialogLabel.AddText(
                                "", mEventDialogLabelTemplate.TextColor,
                                mEventDialogLabelTemplate.CurAlignments.Count > 0
                                    ? mEventDialogLabelTemplate.CurAlignments[0]
                                    : Alignments.Left, mEventDialogLabelTemplate.Font
                            );
            mEventDialogLabelNoFace.AddText(
                        "", mEventDialogLabelTemplate.TextColor,
                        mEventDialogLabelTemplate.CurAlignments.Count > 0
                            ? mEventDialogLabelTemplate.CurAlignments[0]
                            : Alignments.Left, mEventDialogLabelTemplate.Font
                    );
            mEventDialogLabel.ClearText();
            mEventDialogLabelNoFace.ClearText();

            keyTimer = Globals.System.GetTimeMs() + 1000;
        }

        //Update
        public void Update()
        {
            if (Globals.EventDialogs.Count > 0)
            {
                if (mEventDialogWindow.IsHidden)
                {
                    keyTimer = Globals.System.GetTimeMs() + 1000;
                    mEventDialogWindow.Show();
                    mEventDialogWindow.MakeModal();
                    mEventDialogArea.ScrollToTop();
                    mEventDialogWindow.BringToFront();
                    var faceTex = Globals.ContentManager.GetTexture(
                        GameContentManager.TextureType.Face, Globals.EventDialogs[0].Face
                    );

                    var responseCount = 0;
                    var maxResponse = 1;
                    if (Globals.EventDialogs[0].Opt1.Length > 0)
                    {
                        responseCount++;
                    }

                    if (Globals.EventDialogs[0].Opt2.Length > 0)
                    {
                        responseCount++;
                        maxResponse = 2;
                    }

                    if (Globals.EventDialogs[0].Opt3.Length > 0)
                    {
                        responseCount++;
                        maxResponse = 3;
                    }

                    if (Globals.EventDialogs[0].Opt4.Length > 0)
                    {
                        responseCount++;
                        maxResponse = 4;
                    }

                    mEventResponse1.Name = "";
                    mEventResponse2.Name = "";
                    mEventResponse3.Name = "";
                    mEventResponse4.Name = "";
                    switch (maxResponse)
                    {
                        case 1:
                            mEventDialogWindow.Name = "EventDialogWindow_1Response";
                            mEventResponse1.Name = "Response1Button";

                            break;
                        case 2:
                            mEventDialogWindow.Name = "EventDialogWindow_2Responses";
                            mEventResponse1.Name = "Response1Button";
                            mEventResponse2.Name = "Response2Button";

                            break;
                        case 3:
                            mEventDialogWindow.Name = "EventDialogWindow_3Responses";
                            mEventResponse1.Name = "Response1Button";
                            mEventResponse2.Name = "Response2Button";
                            mEventResponse3.Name = "Response3Button";

                            break;
                        case 4:
                            mEventDialogWindow.Name = "EventDialogWindow_4Responses";
                            mEventResponse1.Name = "Response1Button";
                            mEventResponse2.Name = "Response2Button";
                            mEventResponse3.Name = "Response3Button";
                            mEventResponse4.Name = "Response4Button";

                            break;
                    }

                    mEventDialogWindow.LoadJsonUi(
                        GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString()
                    );

                    if (faceTex != null)
                    {
                        mEventFace.Show();
                        mEventFace.Texture = faceTex;
                        mEventDialogArea.Show();
                        mEventDialogAreaNoFace.Hide();
                    }
                    else
                    {
                        mEventFace.Hide();
                        mEventDialogArea.Hide();
                        mEventDialogLabelNoFace.ClearText();
                        mEventDialogAreaNoFace.Show();
                    }

                    if (responseCount == 0)
                    {
                        mEventResponse1.Show();
                        mEventResponse1.SetText(Strings.EventWindow.Continue);
                        mEventResponse2.Hide();
                        mEventResponse3.Hide();
                        mEventResponse4.Hide();
                    }
                    else
                    {
                        if (Globals.EventDialogs[0].Opt1 != "")
                        {
                            mEventResponse1.Show();
                            mEventResponse1.SetText(Globals.EventDialogs[0].Opt1);
                        }
                        else
                        {
                            mEventResponse1.Hide();
                        }

                        if (Globals.EventDialogs[0].Opt2 != "")
                        {
                            mEventResponse2.Show();
                            mEventResponse2.SetText(Globals.EventDialogs[0].Opt2);
                        }
                        else
                        {
                            mEventResponse2.Hide();
                        }

                        if (Globals.EventDialogs[0].Opt3 != "")
                        {
                            mEventResponse3.Show();
                            mEventResponse3.SetText(Globals.EventDialogs[0].Opt3);
                        }
                        else
                        {
                            mEventResponse3.Hide();
                        }

                        if (Globals.EventDialogs[0].Opt4 != "")
                        {
                            mEventResponse4.Show();
                            mEventResponse4.SetText(Globals.EventDialogs[0].Opt4);
                        }
                        else
                        {
                            mEventResponse4.Hide();
                        }
                    }

                    mEventDialogWindow.SetSize(
                        mEventDialogWindow.Texture.GetWidth(), mEventDialogWindow.Texture.GetHeight()
                    );

                    if (faceTex != null)
                    {
                        if (Globals.EventDialogs[0].isDialog)
                        {
                            mEventDialogLabel.ClearText();
                            mEventDialogLabel.Width = mEventDialogArea.Width -
                                                      mEventDialogArea.GetVerticalScrollBar().Width;

                            mEventDialogLabel.AddText(
                                "", mEventDialogLabelTemplate.TextColor,
                                mEventDialogLabelTemplate.CurAlignments.Count > 0
                                    ? mEventDialogLabelTemplate.CurAlignments[0]
                                    : Alignments.Left, mEventDialogLabelTemplate.Font
                            );

                            mEventDialogLabel.SizeToChildren(false, true);
                            mEventDialogArea.ScrollToTop();
                            len = Globals.EventDialogs[0].Prompt.Length;
                            mTimerFace.Start();
                        }
                        else
                        {
                            mEventDialogLabel.ClearText();
                            mEventDialogLabel.Width = mEventDialogArea.Width -
                                                      mEventDialogArea.GetVerticalScrollBar().Width;

                            mEventDialogLabel.AddText(
                                Globals.EventDialogs[0].Prompt, mEventDialogLabelTemplate.TextColor,
                                mEventDialogLabelTemplate.CurAlignments.Count > 0
                                    ? mEventDialogLabelTemplate.CurAlignments[0]
                                    : Alignments.Left, mEventDialogLabelTemplate.Font
                            );

                            mEventDialogLabel.SizeToChildren(false, true);
                            mEventDialogArea.ScrollToTop();
                        }
                    }
                    else
                    {
                        if (Globals.EventDialogs[0].isDialog)
                        {
                            mEventDialogLabelNoFace.ClearText();
                            mEventDialogLabelNoFace.Width = mEventDialogAreaNoFace.Width -
                                                            mEventDialogAreaNoFace.GetVerticalScrollBar().Width;

                            mEventDialogLabelNoFace?.AddText(
                                "", mEventDialogLabelNoFaceTemplate.TextColor,
                                mEventDialogLabelNoFaceTemplate.CurAlignments.Count > 0
                                    ? mEventDialogLabelNoFaceTemplate.CurAlignments[0]
                                    : Alignments.Left, mEventDialogLabelNoFaceTemplate.Font
                            );

                            mEventDialogLabelNoFace.SizeToChildren(false, true);
                            mEventDialogAreaNoFace.ScrollToTop();
                            len = Globals.EventDialogs[0].Prompt.Length;
                            mTimer.Start();
                        } else
                        {
                            mEventDialogLabelNoFace.ClearText();
                            mEventDialogLabelNoFace.Width = mEventDialogAreaNoFace.Width -
                                                            mEventDialogAreaNoFace.GetVerticalScrollBar().Width;

                            mEventDialogLabelNoFace?.AddText(
                                Globals.EventDialogs[0].Prompt, mEventDialogLabelNoFaceTemplate.TextColor,
                                mEventDialogLabelNoFaceTemplate.CurAlignments.Count > 0
                                    ? mEventDialogLabelNoFaceTemplate.CurAlignments[0]
                                    : Alignments.Left, mEventDialogLabelNoFaceTemplate.Font
                            );

                            mEventDialogLabelNoFace.SizeToChildren(false, true);
                            mEventDialogAreaNoFace.ScrollToTop();
                        }
                    }                    
                }
                if (Controls.KeyDown(Control.AttackInteract) && !Globals.EventDialogs[0].isDialog && !mEventDialogWindow.IsHidden && keyTimer < Globals.System.GetTimeMs())
                {
                    keyTimer = Globals.System.GetTimeMs() + 1000;
                    EventResponse1_Clicked(null, null);
                }
                if (Controls.KeyDown(Control.AttackInteract) && !mTimer.Enabled && counter > len && !mEventDialogWindow.IsHidden && keyTimer < Globals.System.GetTimeMs())
                {
                    keyTimer = Globals.System.GetTimeMs() + 1000;
                    EventResponse1_Clicked(null, null);
                }
                if (Controls.KeyDown(Control.AttackInteract) && !mTimerFace.Enabled && counter > len && !mEventDialogWindow.IsHidden && keyTimer < Globals.System.GetTimeMs())
                {
                    keyTimer = Globals.System.GetTimeMs() + 1000;
                    EventResponse1_Clicked(null, null);
                }
                if (Controls.KeyDown(Control.Hotkey1) && mEventResponse1.IsVisible && mEventResponse2.IsVisible && !mEventDialogWindow.IsHidden && keyTimer < Globals.System.GetTimeMs())
                {
                    keyTimer = Globals.System.GetTimeMs() + 1000;
                    EventResponse1_Clicked(null, null);
                }
                if (Controls.KeyDown(Control.Hotkey2) && mEventResponse2.IsVisible && !mEventDialogWindow.IsHidden && keyTimer < Globals.System.GetTimeMs())
                {
                    keyTimer = Globals.System.GetTimeMs() + 1000;
                    EventResponse2_Clicked(null, null);
                }
                if (Controls.KeyDown(Control.Hotkey3) && mEventResponse3.IsVisible && !mEventDialogWindow.IsHidden && keyTimer < Globals.System.GetTimeMs())
                {
                    keyTimer = Globals.System.GetTimeMs() + 1000;
                    EventResponse3_Clicked(null, null);
                }
                if (Controls.KeyDown(Control.Hotkey4) && mEventResponse4.IsVisible && !mEventDialogWindow.IsHidden && keyTimer < Globals.System.GetTimeMs())
                {
                    keyTimer = Globals.System.GetTimeMs() + 1000;
                    EventResponse4_Clicked(null, null);
                }
            }
        }


        private void mTimer_Tick(object sender, ElapsedEventArgs elapsedEventArg)
        {
            len = Globals.EventDialogs[0].Prompt.Length;
            if (Controls.KeyDown(Control.PickUp) && counter < len)
            {
                counter = len;
            }

            if (counter == len)
            {
                mEventDialogLabelNoFace.ClearText();
                mEventDialogLabelNoFace.Width = mEventDialogAreaNoFace.Width -
                                                mEventDialogAreaNoFace.GetVerticalScrollBar().Width;
                mEventDialogLabelNoFace.AddText(
                    Globals.EventDialogs[0].Prompt, mEventDialogLabelNoFaceTemplate.TextColor,
                    mEventDialogLabelNoFaceTemplate.CurAlignments.Count > 0
                        ? mEventDialogLabelNoFaceTemplate.CurAlignments[0]
                        : Alignments.Left, mEventDialogLabelNoFaceTemplate.Font
                );
                mEventDialogLabelNoFace.SizeToChildren(false, true);
                mEventDialogAreaNoFace.ScrollToBottom();
                counter++;
                mTimer.Stop();
                mTimer.Enabled = false;
            }

            else
            {
                mEventDialogLabelNoFace.ClearText();
                mEventDialogLabelNoFace.Width = mEventDialogAreaNoFace.Width -
                                                mEventDialogAreaNoFace.GetVerticalScrollBar().Width;

                mEventDialogLabelNoFace?.AddText(
                    Globals.EventDialogs[0].Prompt.Substring(0, counter), mEventDialogLabelNoFaceTemplate.TextColor,
                    mEventDialogLabelNoFaceTemplate.CurAlignments.Count > 0
                        ? mEventDialogLabelNoFaceTemplate.CurAlignments[0]
                        : Alignments.Left, mEventDialogLabelNoFaceTemplate.Font
                );
                int x = 6;
                if (counter % x == 0)
                {
                    mEventDialogLabelNoFace.SizeToChildren(false, true);
                    mEventDialogAreaNoFace.ScrollToBottom();
                }

                counter++;
            }
        }

        private void mTimerFace_Tick(object sender, ElapsedEventArgs elapsedEventArg)
        {

            len = Globals.EventDialogs[0].Prompt.Length;
            if (Controls.KeyDown(Control.PickUp) && counter < len)
            {
                counter = len;
            }

            if (counter == len)
            {
                mEventDialogLabel.ClearText();
                mEventDialogLabel.Width = mEventDialogLabel.Width -
                                                mEventDialogArea.GetVerticalScrollBar().Width;
                mEventDialogLabel.AddText(
                    Globals.EventDialogs[0].Prompt, mEventDialogLabelTemplate.TextColor,
                    mEventDialogLabelTemplate.CurAlignments.Count > 0
                        ? mEventDialogLabelTemplate.CurAlignments[0]
                        : Alignments.Left, mEventDialogLabelTemplate.Font
                );
                mEventDialogLabel.SizeToChildren(false, true);
                mEventDialogArea.ScrollToBottom();
                counter++;
                mTimerFace.Stop();
                mTimerFace.Enabled = false;
            }

            else
            {
                mEventDialogLabel.ClearText();
                mEventDialogLabel.Width = mEventDialogArea.Width -
                                                mEventDialogArea.GetVerticalScrollBar().Width;

                mEventDialogLabel?.AddText(
                    Globals.EventDialogs[0].Prompt.Substring(0, counter), mEventDialogLabelTemplate.TextColor,
                    mEventDialogLabelTemplate.CurAlignments.Count > 0
                        ? mEventDialogLabelTemplate.CurAlignments[0]
                        : Alignments.Left, mEventDialogLabelTemplate.Font
                );
                int x = 6;
                if (counter % x == 0)
                {
                    mEventDialogLabel.SizeToChildren(false, true);
                    mEventDialogArea.ScrollToBottom();
                }
                counter++;
            }
        }

        //Input Handlers
        void EventResponse4_Clicked(Base sender, ClickedEventArgs arguments)
        {
            var ed = Globals.EventDialogs[0];
            if (ed.ResponseSent != 0)
            {
                return;
            }

            PacketSender.SendEventResponse(4, ed);
            mTimer.Stop();
            mTimerFace.Stop();
            counter = 0;
            mEventDialogLabelNoFace.ClearText();
            mEventDialogLabel.ClearText();
            mEventDialogWindow.RemoveModal();
            mEventDialogWindow.IsHidden = true;
            ed.ResponseSent = 1;
        }

        void EventResponse3_Clicked(Base sender, ClickedEventArgs arguments)
        {
            var ed = Globals.EventDialogs[0];
            if (ed.ResponseSent != 0)
            {
                return;
            }

            PacketSender.SendEventResponse(3, ed);
            mTimer.Stop();
            mTimerFace.Stop();
            counter = 0;
            mEventDialogLabelNoFace.ClearText();
            mEventDialogLabel.ClearText();
            mEventDialogWindow.RemoveModal();
            mEventDialogWindow.IsHidden = true;
            ed.ResponseSent = 1;
        }

        void EventResponse2_Clicked(Base sender, ClickedEventArgs arguments)
        {
            var ed = Globals.EventDialogs[0];
            if (ed.ResponseSent != 0)
            {
                return;
            }

            PacketSender.SendEventResponse(2, ed);
            mTimer.Stop();
            mTimerFace.Stop();
            counter = 0;
            mEventDialogLabelNoFace.ClearText();
            mEventDialogLabel.ClearText();
            mEventDialogWindow.RemoveModal();
            mEventDialogWindow.IsHidden = true;
            ed.ResponseSent = 1;
        }

        void EventResponse1_Clicked(Base sender, ClickedEventArgs arguments)
        {
            var ed = Globals.EventDialogs[0];
            if (ed.ResponseSent != 0)
            {
                return;
            }

            PacketSender.SendEventResponse(1, ed);
            mTimer.Stop();
            mTimerFace.Stop();
            counter = 0;
            mEventDialogLabelNoFace.ClearText();
            mEventDialogLabel.ClearText();
            mEventDialogWindow.RemoveModal();
            mEventDialogWindow.IsHidden = true;
            ed.ResponseSent = 1;
        }

    }

}
