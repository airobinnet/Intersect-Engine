﻿using System;

using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.Framework.Gwen.Input;
using Intersect.Client.Framework.Input;
using Intersect.Client.General;
using Intersect.Client.Networking;
using Intersect.GameObjects;
using Intersect.Client.Localization;

namespace Intersect.Client.Interface.Game.Bank
{

    public class BankItem
    {

        private static int sItemXPadding = 4;

        private static int sItemYPadding = 4;

        public ImagePanel Container;

        public bool IsDragging;

        //Drag/Drop References
        private BankWindow mBankWindow;

        //Dragging
        private bool mCanDrag;

        private long mClickTime;

        private Guid mCurrentItemId;

        private ItemDescWindow mDescWindow;

        private ItemCompareWindow mCompWindow;

        private Draggable mDragIcon;

        //Mouse Event Variables
        private bool mMouseOver;

        private int mMouseX = -1;

        private int mMouseY = -1;

        //Slot info
        private int mMySlot;

        public ImagePanel Pnl;

        public BankItem(BankWindow bankWindow, int index)
        {
            mBankWindow = bankWindow;
            mMySlot = index;
        }

        public void Setup()
        {
            Pnl = new ImagePanel(Container, "BankItemIcon");
            Pnl.HoverEnter += pnl_HoverEnter;
            Pnl.HoverLeave += pnl_HoverLeave;
            Pnl.RightClicked += Pnl_DoubleClicked; //Allow withdrawing via double click OR right click
            Pnl.DoubleClicked += Pnl_DoubleClicked;
            Pnl.Clicked += pnl_Clicked;
        }

        private void Pnl_DoubleClicked(Base sender, ClickedEventArgs arguments)
        {
            if (Globals.InBank)
            {
                Globals.Me.TryWithdrawItem(mMySlot);
            }
        }

        void pnl_Clicked(Base sender, ClickedEventArgs arguments)
        {
            mClickTime = Globals.System.GetTimeMs() + 500;
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

            if (mCompWindow != null)
            {
                mCompWindow.Dispose();
                mCompWindow = null;
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

            if (mCompWindow != null)
            {
                mCompWindow.Dispose();
                mCompWindow = null;
            }
            if (Globals.Bank[mMySlot]?.Base != null)
            {
                mDescWindow = new ItemDescWindow(
                    Globals.Bank[mMySlot].Base, Globals.Bank[mMySlot].Quantity, mBankWindow.X, mBankWindow.Y,
                    Globals.Bank[mMySlot].StatBuffs
                );
                if (Globals.Bank[mMySlot]?.Base.ItemType == Enums.ItemTypes.Equipment)
                {
                    var i = 0;
                    foreach (var equip in Globals.Me.Equipment)
                    {
                        if (ItemBase.Get(equip)?.EquipmentSlot == Globals.Bank[mMySlot]?.Base.EquipmentSlot)
                        {
                            mCompWindow = new ItemCompareWindow(
                                           ItemBase.Get(equip), Globals.Bank[mMySlot]?.Base, Globals.Me.Inventory[mMySlot].Quantity, mBankWindow.X,
                                           mBankWindow.Y, Globals.Me.Inventory[Globals.Me.MyEquipment[ItemBase.Get(equip).EquipmentSlot]].StatBuffs, Globals.Bank[mMySlot]?.StatBuffs, "", Strings.ItemDesc.equippeditem
                                        );
                            i++;
                        }
                    }
                }
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
            if (Globals.Bank[mMySlot].ItemId != mCurrentItemId)
            {
                mCurrentItemId = Globals.Bank[mMySlot].ItemId;
                var item = ItemBase.Get(Globals.Bank[mMySlot].ItemId);
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

            if (!IsDragging)
            {
                if (mMouseOver)
                {
                    if (!Globals.InputManager.MouseButtonDown(GameInput.MouseButtons.Left))
                    {
                        mCanDrag = true;
                        mMouseX = -1;
                        mMouseY = -1;
                        if (Globals.System.GetTimeMs() < mClickTime)
                        {
                            //Globals.Me.TryUseItem(_mySlot);
                            mClickTime = 0;
                        }
                    }
                    else
                    {
                        if (mCanDrag && Draggable.Active == null)
                        {
                            if (mMouseX == -1 || mMouseY == -1)
                            {
                                mMouseX = InputHandler.MousePosition.X - Pnl.LocalPosToCanvas(new Point(0, 0)).X;
                                mMouseY = InputHandler.MousePosition.Y - Pnl.LocalPosToCanvas(new Point(0, 0)).Y;
                            }
                            else
                            {
                                var xdiff = mMouseX -
                                            (InputHandler.MousePosition.X - Pnl.LocalPosToCanvas(new Point(0, 0)).X);

                                var ydiff = mMouseY -
                                            (InputHandler.MousePosition.Y - Pnl.LocalPosToCanvas(new Point(0, 0)).Y);

                                if (Math.Sqrt(Math.Pow(xdiff, 2) + Math.Pow(ydiff, 2)) > 5)
                                {
                                    IsDragging = true;
                                    mDragIcon = new Draggable(
                                        Pnl.LocalPosToCanvas(new Point(0, 0)).X + mMouseX,
                                        Pnl.LocalPosToCanvas(new Point(0, 0)).X + mMouseY, Pnl.Texture
                                    );
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (mDragIcon.Update())
                {
                    //Drug the item and now we stopped
                    IsDragging = false;
                    var dragRect = new FloatRect(
                        mDragIcon.X - sItemXPadding / 2, mDragIcon.Y - sItemYPadding / 2, sItemXPadding / 2 + 32,
                        sItemYPadding / 2 + 32
                    );

                    float bestIntersect = 0;
                    var bestIntersectIndex = -1;

                    //So we picked up an item and then dropped it. Lets see where we dropped it to.
                    //Check inventory first.
                    if (mBankWindow.RenderBounds().IntersectsWith(dragRect))
                    {
                        for (var i = 0; i < Options.MaxBankSlots; i++)
                        {
                            if (mBankWindow.Items[i].RenderBounds().IntersectsWith(dragRect))
                            {
                                if (FloatRect.Intersect(mBankWindow.Items[i].RenderBounds(), dragRect).Width *
                                    FloatRect.Intersect(mBankWindow.Items[i].RenderBounds(), dragRect).Height >
                                    bestIntersect)
                                {
                                    bestIntersect =
                                        FloatRect.Intersect(mBankWindow.Items[i].RenderBounds(), dragRect).Width *
                                        FloatRect.Intersect(mBankWindow.Items[i].RenderBounds(), dragRect).Height;

                                    bestIntersectIndex = i;
                                }
                            }
                        }

                        if (bestIntersectIndex > -1)
                        {
                            if (mMySlot != bestIntersectIndex)
                            {
                                //Try to swap....
                                PacketSender.SendMoveBankItems(bestIntersectIndex, mMySlot);

                                //Globals.Me.SwapItems(bestIntersectIndex, _mySlot);
                            }
                        }
                    }

                    mDragIcon.Dispose();
                }
            }
        }

    }

}
