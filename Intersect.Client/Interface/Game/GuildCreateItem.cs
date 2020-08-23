using System;

using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.Framework.Gwen.Input;
using Intersect.Client.Framework.Input;
using Intersect.Client.General;
using Intersect.Client.Networking;
using Intersect.GameObjects;

namespace Intersect.Client.Interface.Game
{

    public class GuildCreateItem
    {

        private static int sItemXPadding = 4;

        private static int sItemYPadding = 4;

        public ImagePanel Container;

        public bool IsDragging;

        //Drag/Drop References
        private GuildCreateWindow mGuildCreateWindow;

        //Dragging
        private bool mCanDrag;

        private long mClickTime;

        private Guid mCurrentItemId;

        private ItemDescWindow mDescWindow;

        private Draggable mDragIcon;

        //Mouse Event Variables
        private bool mMouseOver;

        private int mMouseX = -1;

        private int mMouseY = -1;

        //Slot info
        private int mMySlot;

        public ImagePanel Pnl;

        public GuildCreateItem(GuildCreateWindow GuildCreateWindow, int index, ImagePanel container)
        {
            mGuildCreateWindow = GuildCreateWindow;
            mMySlot = index;
            Container = container;
            Pnl = new ImagePanel(Container, "mGuildCreateItemIcon");
            Pnl.HoverEnter += pnl_HoverEnter;
            Pnl.HoverLeave += pnl_HoverLeave;
        }

        void pnl_HoverLeave(Base sender, EventArgs arguments)
        {
            mMouseOver = false;
            mMouseX = -1;
            mMouseY = -1;
            if (mDescWindow != null)
            {
                mDescWindow.Dispose();
                mDescWindow = null;
            }
        }

        void pnl_HoverEnter(Base sender, EventArgs arguments)
        {
            if (InputHandler.MouseFocus != null)
            {
                return;
            }

            mMouseOver = true;
            mCanDrag = false;
            if (Globals.InputManager.MouseButtonDown(GameInput.MouseButtons.Left))
            {
                mCanDrag = false;

                return;
            }

            if (mDescWindow != null)
            {
                mDescWindow.Dispose();
                mDescWindow = null;
            }

            if (Globals.GuildCreateItem != null)
            {
                mDescWindow = new ItemDescWindow(
                    ItemBase.Get(Globals.GuildCreateItem), 1, mGuildCreateWindow.X, mGuildCreateWindow.Y,
                    ItemBase.Get(Globals.GuildCreateItem).StatsGiven
                );
            }
        }

        public FloatRect RenderBounds()
        {
            var rect = new FloatRect()
            {
                X = Pnl.LocalPosToCanvas(new Point(0, 0)).X,
                Y = Pnl.LocalPosToCanvas(new Point(0, 0)).Y,
                Width = Pnl.Width,
                Height = Pnl.Height
            };

            return rect;
        }

        public void Update()
        {
            
        }

        public void SetSlot()
        {

            if (Globals.GuildCreateItem != null)
            {
                var item = ItemBase.Get(Globals.GuildCreateItem);
                if (item != null)
                {
                    var itemTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Item, item.Icon);
                    if (itemTex != null)
                    {
                        Pnl.Texture = itemTex;
                    }
                    else
                    {
                        if (Pnl.Texture != null)
                        {
                            Pnl.Texture = null;
                        }
                    }
                }
                else
                {
                    if (Pnl.Texture != null)
                    {
                        Pnl.Texture = null;
                    }
                }
            }
            else
            {
                if (Pnl.Texture != null)
                {
                    Pnl.Texture = null;
                }
            }
        }

    }

}
