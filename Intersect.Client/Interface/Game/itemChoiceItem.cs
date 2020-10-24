using System;

using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.GenericClasses;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.Framework.Gwen.Input;
using Intersect.Client.Framework.Input;
using Intersect.Client.General;
using Intersect.Client.Items;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects;

namespace Intersect.Client.Interface.Game
{

    public class ItemChoiceItem
    {

        public ImagePanel Container;

        public Label EquipLabel;

        public ImagePanel EquipPanel;

        public bool IsDragging;

        //Dragging
        private bool mCanDrag;

        private long mClickTime;

        private Label mCooldownLabel;

        private int mCurrentAmt = 0;

        private Guid mCurrentItemId;

        private ItemDescWindow mDescWindow;

        private ItemCompareWindow mCompWindow;

        private Draggable mDragIcon;

        private bool mIconCd;

        //Drag/Drop References
        private ItemChoiceWindow mInventoryWindow;

        private bool mIsEquipped;

        //Mouse Event Variables
        private bool mMouseOver;

        private int mMouseX = -1;

        private int mMouseY = -1;

        //Slot info
        private int mMySlot;

        private ItemBase tempItem;

        private string mTexLoaded = "";

        public ImagePanel Pnl;

        public int originalslot;

        public ItemChoiceItem(ItemChoiceWindow inventoryWindow, int index)
        {
            mInventoryWindow = inventoryWindow;
            mMySlot = index;
        }

        public void Setup()
        {
            Pnl = new ImagePanel(Container, "ItemChoiceItemIcon");
            Pnl.HoverEnter += pnl_HoverEnter;
            Pnl.HoverLeave += pnl_HoverLeave;
            Pnl.RightClicked += pnl_RightClicked;
            Pnl.Clicked += pnl_Clicked;
        }

        void pnl_Clicked(Base sender, ClickedEventArgs arguments)
        {
            mInventoryWindow.Choice = mMySlot;
            mInventoryWindow.Update();
        }

        void pnl_RightClicked(Base sender, ClickedEventArgs arguments)
        {
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

            if (Globals.GameShop == null)
            {
                if (Globals.ItemChoice[0] != null)
                {
                    if (Globals.ItemChoice[0].Items[mMySlot] != Guid.Empty)
                    {
                        tempItem = ItemBase.Get(Globals.ItemChoice[0].Items[mMySlot]);

                        mDescWindow = new ItemDescWindow(
                            tempItem, 1, mInventoryWindow.X,
                            mInventoryWindow.Y, tempItem.StatsGiven
                        );
                        if (!Globals.Me.IsEquipped(mMySlot))
                        {
                            if (tempItem.ItemType == Enums.ItemTypes.Equipment)
                            {
                                var i = 0;
                                foreach (var equip in Globals.Me.Equipment)
                                {
                                    if (ItemBase.Get(equip)?.EquipmentSlot == tempItem.EquipmentSlot)
                                    {
                                        mCompWindow = new ItemCompareWindow(
                                                       ItemBase.Get(equip), tempItem, Globals.Me.Inventory[mMySlot].Quantity, mInventoryWindow.X,
                                                       mInventoryWindow.Y, Globals.Me.Inventory[Globals.Me.MyEquipment[ItemBase.Get(equip).EquipmentSlot]]?.StatBuffs, Globals.Me.Inventory[mMySlot]?.StatBuffs, "", Strings.ItemDesc.equippeditem
                                                    );
                                        i++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                
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
            if (Globals.ItemChoice[0] != null)
            {
                if (Globals.ItemChoice[0].Items[mMySlot] != Guid.Empty)
                {
                    var item = ItemBase.Get(Globals.ItemChoice[0].Items[mMySlot]);

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

                        mTexLoaded = item.Icon;
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
                else
                {
                    Container.Hide();
                }
            }
            if (mDescWindow != null)
            {
                mDescWindow.Dispose();
                mDescWindow = null;
                pnl_HoverEnter(null, null);
            }

            if (mCompWindow != null)
            {
                mCompWindow.Dispose();
                mCompWindow = null;
                pnl_HoverEnter(null, null);
            }
        }
    }
}
