using System;
using System.Collections.Generic;

using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.GameObjects;

namespace Intersect.Client.Interface.Game.GuildBank
{

    public class GuildBankWindow
    {

        private static int sItemXPadding = 4;

        private static int sItemYPadding = 4;

        public List<GuildBankItem> Items = new List<GuildBankItem>();

        //Controls
        private WindowControl mGuildBankWindow;

        private ScrollControl mItemContainer;

        private List<Label> mValues = new List<Label>();

        //Location
        public int X;

        public int Y;

        //Init
        public GuildBankWindow(Canvas gameCanvas)
        {
            mGuildBankWindow = new WindowControl(gameCanvas, Strings.GuildBank.title, false, "GuildBankWindow");
            mGuildBankWindow.DisableResizing();
            Interface.InputBlockingElements.Add(mGuildBankWindow);

            mItemContainer = new ScrollControl(mGuildBankWindow, "ItemContainer");
            mItemContainer.EnableScroll(false, true);

            mGuildBankWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
            InitItemContainer();
        }

        public void Close()
        {
            mGuildBankWindow.Close();
        }

        public bool IsVisible()
        {
            return !mGuildBankWindow.IsHidden;
        }

        public void Hide()
        {
            mGuildBankWindow.IsHidden = true;
        }

        public void Update()
        {
            if (mGuildBankWindow.IsHidden == true)
            {
                return;
            }

            X = mGuildBankWindow.X;
            Y = mGuildBankWindow.Y;
            var MaxSlots = Math.Min(Globals.Me.GuildLevel * Options.GuildOptions.GuildBankSlotsIncrease, Options.MaxBankSlots);
            for (var i = 0; i < MaxSlots; i++)
            {
                if (Globals.GuildBank[i] != null && Globals.GuildBank[i].ItemId != Guid.Empty)
                {
                    var item = ItemBase.Get(Globals.GuildBank[i].ItemId);
                    if (item != null)
                    {
                        Items[i].Pnl.IsHidden = false;
                        if (item.IsStackable)
                        {
                            mValues[i].IsHidden = false;
                            mValues[i].Text = Globals.GuildBank[i].Quantity.ToString();
                        }
                        else
                        {
                            mValues[i].IsHidden = true;
                        }

                        if (Items[i].IsDragging)
                        {
                            Items[i].Pnl.IsHidden = true;
                            mValues[i].IsHidden = true;
                        }

                        Items[i].Update();
                    }
                }
                else
                {
                    Items[i].Pnl.IsHidden = true;
                    mValues[i].IsHidden = true;
                }
            }
        }

        private void InitItemContainer()
        {
            var MaxSlots = Math.Min(Globals.Me.GuildLevel * Options.GuildOptions.GuildBankSlotsIncrease, Options.MaxBankSlots);
            for (var i = 0; i < MaxSlots; i++)
            {
                Items.Add(new GuildBankItem(this, i));
                Items[i].Container = new ImagePanel(mItemContainer, "GuildBankItem");
                Items[i].Setup();

                mValues.Add(new Label(Items[i].Container, "GuildBankItemValue"));
                mValues[i].Text = "";

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
            }
        }

        public FloatRect RenderBounds()
        {
            var rect = new FloatRect()
            {
                X = mGuildBankWindow.LocalPosToCanvas(new Point(0, 0)).X - sItemXPadding / 2,
                Y = mGuildBankWindow.LocalPosToCanvas(new Point(0, 0)).Y - sItemYPadding / 2,
                Width = mGuildBankWindow.Width + sItemXPadding,
                Height = mGuildBankWindow.Height + sItemYPadding
            };

            return rect;
        }

    }

}
