using System;

using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.Framework.Gwen.Input;
using Intersect.Client.Framework.Input;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects;

namespace Intersect.Client.Interface.Game
{

    public class DemoSpellItem
    {

        public ImagePanel Container;

        public bool IsDragging;

        private bool mCanDrag;

        private long mClickTime;
        
        private Guid mCurrentSpellId;

        private SpellDescWindow mDescWindow;

        private Draggable mDragIcon;

        private bool mIconCd;

        private bool mMouseOver;

        private int mMouseX = -1;

        private int mMouseY = -1;

        //Drag/Drop References
        private ClassChangeWindow mSpellWindow;

        private string mTexLoaded = "";

        private int mYindex;

        private Guid ClassId;

        public ImagePanel Pnl;

        public DemoSpellItem(ClassChangeWindow spellWindow, Guid classid, int index)
        {
            mSpellWindow = spellWindow;
            mYindex = index;
            ClassId = classid;
        }

        public void Setup()
        {
            Pnl = new ImagePanel(Container, "SpellIcon");
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
            mCanDrag = true;
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

            mDescWindow = new SpellDescWindow(ClassBase.Get(ClassId).Spells[mYindex].Id, mSpellWindow.X, mSpellWindow.Y);
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
            var tempSpell = ClassBase.Get(ClassId).Spells[mYindex].Id;
            var spell = SpellBase.Get(tempSpell);
            if (spell != null)
            {
                var spellTex = Globals.ContentManager.GetTexture(GameContentManager.TextureType.Spell, spell.Icon);
                if (spellTex != null)
                {
                    Pnl.Texture = spellTex;
                    Pnl.RenderColor = new Color(255, 255, 255, 255);
                }
                else
                {
                    if (Pnl.Texture != null)
                    {
                        Pnl.Texture = null;
                    }
                }

                mTexLoaded = spell.Icon;
                mCurrentSpellId = tempSpell;
            }
            else
            {
                if (Pnl.Texture != null)
                {
                    Pnl.Texture = null;
                }

                mTexLoaded = "";
            }
        }

    }

}
