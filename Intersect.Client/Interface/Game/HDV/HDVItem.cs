using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.Framework.Gwen.Input;
using Intersect.Client.General;
using Intersect.Client.Networking;
using Intersect.GameObjects;
using System;
using Intersect.Client.Localization;

namespace Intersect.Client.Interface.Game.HDV
{
	public class HDVItem
	{
		private HDVWindow mWindow;
		private ItemDescWindow mDescWindow;
		public ImagePanel Container;


		public ImagePanel PnlBackground;
		public ImagePanel Pnl;
		private Client.HDV mHDV;

		private Button mRetirerButton;
		private Button mBuyButton;
		private Label mItemName;
		private Label mSellerName;
		private Label mPriceName;
        public ItemCompareWindow mCompWindow;


        public HDVItem(HDVWindow window, Client.HDV hdv, ImagePanel container)
		{
			mWindow = window;
			Container = container;
			mHDV = hdv;

			PnlBackground = new ImagePanel(Container, "HDVItemBG");

			Pnl = new ImagePanel(PnlBackground, "HDVItem");
			Pnl.HoverEnter += pnl_HoverEnter;
			Pnl.HoverLeave += pnl_HoverLeave;

			mRetirerButton = new Button(Container, "RemoveButton");
			mRetirerButton.SetText("Cancel");
			mRetirerButton.Clicked += RemoveButton_Clicked;

			mBuyButton = new Button(Container, "BuyButton");
			mBuyButton.SetText("Buy");
			mBuyButton.Clicked += BuyButton_Clicked;

			mItemName = new Label(Container, "ItemName");
			mItemName.SetText("A");

			mSellerName = new Label(Container, "SellerName");
			mSellerName.SetText("B");

			mPriceName = new Label(Container, "PriceName");
			mPriceName.SetText("C");


			Container.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());

			mRetirerButton.Hide();
			mBuyButton.Hide();
			mItemName.Hide();
			mSellerName.Hide();
			mPriceName.Hide();

			if (mHDV != null)
			{

				var item = ItemBase.Get(mHDV.ItemId);
				if (item != null)
                {
                    //mRetirerButton.IsHidden = Globals.Me.Name.ToLower().Equals(hdv.Seller.ToLower()) == false;
                    mRetirerButton.IsHidden = Globals.Me.Id.ToString().Equals(hdv.Seller) == false;
                    mBuyButton.Show();
					mItemName.Show();
                    //mSellerName.IsHidden = Globals.Me.Name.ToLower().Equals(hdv.Seller.ToLower()) == true;
                    //mSellerName.IsHidden = Globals.Me.Id.ToString().Equals(hdv.Seller) == true;
                    mSellerName.IsHidden = true;
                    //mSellerName.Show();
                    mPriceName.Show();

					mItemName.SetText(item.Name + " x" + mHDV.Quantity);
					mSellerName.SetText(mHDV.Seller);
					var hdvBase = HDVBase.Get(Globals.HdvID);
					mPriceName.SetText($"{mHDV.Price} {hdvBase.Currency.Name}");
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

		private void BuyButton_Clicked(Base sender, ClickedEventArgs arguments)
		{
			PacketSender.SendActionHDV(mHDV.Id, 1);
		}

		private void RemoveButton_Clicked(Base sender, ClickedEventArgs arguments)
		{
			PacketSender.SendActionHDV(mHDV.Id, -1);
		}

		internal void Close()
		{
			Container.Hide();
			Container.CloseMenus();
			Container.Dispose();
		}

		private void pnl_HoverEnter(Base sender, EventArgs arguments)
		{
			if (InputHandler.MouseFocus != null)
			{
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
            if (mHDV != null)
			{
				var item = ItemBase.Get(mHDV.ItemId);
				if (item != null)
				{
					mDescWindow = new ItemDescWindow(
						item,
						mHDV.Quantity,
						mWindow.X, mWindow.Y,
						mHDV.StatBuffs
					);
                    if (ItemBase.Get(mHDV.ItemId).ItemType == Enums.ItemTypes.Equipment)
                    {
                        var i = 0;
                        foreach (var equip in Globals.Me.Equipment)
                        {
                            if (ItemBase.Get(equip)?.EquipmentSlot == ItemBase.Get(mHDV.ItemId).EquipmentSlot)
                            {
                                mCompWindow = new ItemCompareWindow(
                                               ItemBase.Get(equip), ItemBase.Get(mHDV.ItemId), 1, mWindow.X,
                                               mWindow.Y, Globals.Me.Inventory[Globals.Me.MyEquipment[ItemBase.Get(equip).EquipmentSlot]].StatBuffs, mHDV.StatBuffs, "", Strings.ItemDesc.equippeditem
                                            );
                                i++;
                            }
                        }
                    }
                }
			}
		}

		private void pnl_HoverLeave(Base sender, EventArgs arguments)
		{
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
	}
}
