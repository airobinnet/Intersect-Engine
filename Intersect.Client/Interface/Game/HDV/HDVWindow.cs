﻿using System;
using System.Collections.Generic;
using System.Linq;
using Intersect.Client;
using Intersect.Client.Core;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Gwen.Control;
using Intersect.Client.Framework.Gwen.Control.EventArguments;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Networking;
using Intersect.GameObjects;
using Intersect.Utilities;

namespace Intersect.Client.Interface.Game.HDV
{
	public class HDVWindow
	{
		private WindowControl mWindow;

		private Button mBuySellButton;
		private Button mCloseButton;

		private Button mPageMinusButton;
		private Button mPagePlusButton;

		private Label mPageLabel;

		// Buy
		private List<HDVItem> mHdvObject;

		private Label searchLabel;
		private TextBox searchBox;
		private Button searchButton;
        private ComboBox searchCB;
        private ComboBox orderCB;
        private ComboBox expiracyCB;


        // Sell
        private HDVSellItem mSellItem;
		private Label mQuantity;
		private TextBoxNumeric mQuantityTextBoxNumeric;
        private Label mPrice;
        private Label mExpiracy;
        private TextBoxNumeric mPriceTextBoxNumeric;
		private Button mToSellButton;

		public int X { get => mWindow.X; }
		public int Y { get => mWindow.Y; }


		private bool sellMode = false;

		private static int PageItemCount = 8;
		private int page = 0;
        private int searchMode = -1;
        private int sortMode = 0;
        private string searchKey = "";
        private int expiracyTimeChoice = 0;

		private List<Client.HDV> itemList {
			get
			{
				if (string.IsNullOrEmpty(searchKey) || string.IsNullOrWhiteSpace(searchKey))
				{

					if (searchMode == -2)
					{
						return Globals.HDVObjet.Where(i => i.Base.ItemType != Enums.ItemTypes.Equipment).ToList<Client.HDV>();
					}
					else if (searchMode >= 0)
					{
						return Globals.HDVObjet.Where(i => i.Base.ItemType == Enums.ItemTypes.Equipment && i.Base.EquipmentSlot == searchMode).ToList<Client.HDV>();
					}
					return Globals.HDVObjet;
				}
				if (searchMode == -2)
				{
					return Globals.HDVObjet.Where(i => i.Base.ItemType != Enums.ItemTypes.Equipment && i.Base.Name.ContainsIgnoreCase(searchKey)).ToList<Client.HDV>();
				}
				else if (searchMode >= 0)
				{
					return Globals.HDVObjet.Where(i => i.Base.ItemType == Enums.ItemTypes.Equipment && i.Base.EquipmentSlot == searchMode && i.Base.Name.ContainsIgnoreCase(searchKey)).ToList<Client.HDV>();
				}
				return Globals.HDVObjet.Where(i => i.Base.Name.ContainsIgnoreCase(searchKey)).ToList<Client.HDV>();
			}
		}

		private int pageNB {
			get
			{
				return (((itemList.Count - 1) / PageItemCount) + 1);
			}
		}

		private int mSellQuantity = 0;

		public HDVWindow(Canvas gameCanvas)
		{
			mWindow = new WindowControl(gameCanvas, "HDV", false, "HDVWindow");
			mWindow.DisableResizing();
			Interface.InputBlockingElements.Add(mWindow);

			mBuySellButton = new Button(mWindow, "SellBuyButton");
			mBuySellButton.SetText("Sell");
			mBuySellButton.Clicked += BuySellButton_Clicked;

			mCloseButton = new Button(mWindow, "CloseButton");
			mCloseButton.SetText("Close");
			mCloseButton.Clicked += CloseButton_Clicked;

			mPageMinusButton = new Button(mWindow, "PageMinusButton");
			mPageMinusButton.SetText("-");
			mPageMinusButton.Clicked += PageMinusButton_Clicked;

			mPagePlusButton = new Button(mWindow, "PagePlusButton");
			mPagePlusButton.SetText("+");
			mPagePlusButton.Clicked += PagePlusButton_Clicked;

			mPageLabel = new Label(mWindow, "PageLabel");


			mSellItem = new HDVSellItem(this, -1, new ImagePanel(mWindow, "HDVSellItem"));

			mQuantity = new Label(mWindow, "Quantity")
			{
				Text = "Quantity"
            };
			mQuantity.IsHidden = true;
			mQuantityTextBoxNumeric = new TextBoxNumeric(mWindow, "QuantityTextBoxNumeric");
			mQuantityTextBoxNumeric.IsHidden = true;
			mQuantityTextBoxNumeric.TextChanged += Quantity_ChangeTextBoxNumeric;
			Interface.FocusElements.Add(mQuantityTextBoxNumeric);

			mPrice = new Label(mWindow, "Price")
			{
				Text = "Price"
			};
			mPriceTextBoxNumeric = new TextBoxNumeric(mWindow, "PriceTextBoxNumeric");
			mPriceTextBoxNumeric.IsHidden = true;
			mPriceTextBoxNumeric.TextChanged += Price_ChangeTextBoxNumeric;
			Interface.FocusElements.Add(mQuantityTextBoxNumeric);

			mToSellButton = new Button(mWindow, "ToSellButton");
			mToSellButton.SetText("Sell");
			mToSellButton.Clicked += ToSellButton_Clicked;


			searchLabel = new Label(mWindow, "Search")
			{
				Text = "Search"
			};
			searchBox = new TextBox(mWindow, "SearchBox");
			searchBox.SetMaxLength(20);
			Interface.FocusElements.Add(searchBox);
			searchButton = new Button(mWindow, "SearchButton");
			searchButton.SetText("Search");
			searchButton.Clicked += SearchButton_Clicked;

			searchCB = new ComboBox(mWindow, "searchCB");
			searchCB.AddItem("All", "", -1);
			for (int i = 0; i < Options.EquipmentSlots.Count; i++)
			{
				searchCB.AddItem(Options.EquipmentSlots[i], "", i);
			}
			searchCB.AddItem("Other", "", -2);
			searchCB.ItemSelected += SearchCB_Selected;

            orderCB = new ComboBox(mWindow, "orderCB");
            orderCB.AddItem("Sort by Date", "", 0);
            orderCB.AddItem("Sort by Price", "", 1);
            orderCB.AddItem("Sort by Seller", "", 2);
            orderCB.AddItem("Sort by Name", "", 3);
            orderCB.ItemSelected += orderCB_Selected;

            mExpiracy = new Label(mWindow, "Expiration")
            {
                Text = "Expiration"
            };
            expiracyCB = new ComboBox(mWindow, "expiracyCB");
            expiracyCB.AddItem("6h", "", 0);
            expiracyCB.AddItem("12h", "", 1);
            expiracyCB.AddItem("24h", "", 2);
            expiracyCB.ItemSelected += expiracyCB_Selected;

            mWindow.LoadJsonUi(GameContentManager.UI.InGame, Graphics.Renderer.GetResolutionString());
			mHdvObject = new List<HDVItem>();
			page = 0;

			HDVBase hdv = HDVBase.Get(Globals.HdvID);
			if (hdv != null) mWindow.Title = hdv.Name;

			UpdateHDV();
		}

		private void SearchButton_Clicked(Base sender, ClickedEventArgs arguments)
		{
			searchKey = searchBox.Text.Trim();
			UpdateHDV();
		}


		private void SearchCB_Selected(Base sender, ItemSelectedEventArgs arguments)
		{
			searchMode = (int)arguments.SelectedItem.UserData;
			page = 0;
			UpdateHDV();
		}

        private void expiracyCB_Selected(Base sender, ItemSelectedEventArgs arguments)
        {
            expiracyTimeChoice = (int)arguments.SelectedItem.UserData;
            UpdateHDV();
        }

        private void orderCB_Selected(Base sender, ItemSelectedEventArgs arguments)
        {
            sortMode = (int)arguments.SelectedItem.UserData;
            page = 0;
            UpdateHDV();
        }

        private void ToSellButton_Clicked(Base sender, ClickedEventArgs arguments)
		{
			if (mSellItem.GetSlot() < 0)
				return;
			int price = (int)mPriceTextBoxNumeric.Value;
			if (price <= 0) price = 1;
            /*if (expiracyTimeChoice == 0)
            {
                //expiracyTime = 21600000;
                expiracyTime = 60000;
            }
            if (expiracyTimeChoice == 1)
            {
                //expiracyTime = 43200000;
                expiracyTime = 600000;
            }
            if (expiracyTimeChoice == 2)
            {
                //expiracyTime = 86400000;
                expiracyTime = 360000;
            }*/
            //MOVE THIS SERVERSIDE!!!!!!!
            //PacketSender.SendAddToHDV(mSellItem.GetSlot(), UpdateQuantity((int)mQuantityTextBoxNumeric.Value), price, DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + expiracyTime);
            PacketSender.SendAddToHDV(mSellItem.GetSlot(), UpdateQuantity((int)mQuantityTextBoxNumeric.Value), price, expiracyTimeChoice);
            mSellItem.SetSlot(-1);
			sellMode = false;
			mBuySellButton.SetText("Sell");
			UpdateHDV();
		}

		private void Price_ChangeTextBoxNumeric(Base sender, EventArgs arguments)
		{
			int value = (int)mPriceTextBoxNumeric.Value;
			if (value <= 0)
			{
				value = 1;
			}
			mPrice.Text = $"Price: {value}";
		}

		private void Quantity_ChangeTextBoxNumeric(Base sender, EventArgs arguments)
		{
			int invSlot = mSellItem.GetSlot();
			int val = UpdateQuantity((int)mQuantityTextBoxNumeric.Value);
			mQuantity.Text = $"Quantity: {val}";
		}


		public void UpdateItemListBySlot(int index)
		{
			mSellItem.SetSlot(index);
			int invSlot = index;
			if (invSlot < 0)
			{
				mQuantityTextBoxNumeric.Value = 0;
				mQuantityTextBoxNumeric.IsHidden = true;
				mQuantity.IsHidden = true;
			}
			else
			{
				Guid itemID = Globals.Me.Inventory[invSlot].ItemId;
				if (itemID == Guid.Empty)
				{
					mQuantityTextBoxNumeric.Value = 0;
					mQuantityTextBoxNumeric.IsHidden = true;
					mQuantity.IsHidden = true;
				}
				else
				{
					var ibase = ItemBase.Get(itemID);
					if (ibase != null)
					{
						mQuantityTextBoxNumeric.Value = 1;
						mQuantityTextBoxNumeric.IsHidden = !ibase.IsStackable;
						mQuantity.IsHidden = !ibase.IsStackable;

						sellMode = true;
						mBuySellButton.SetText("Buy");
						UpdateHDV();
					}
				}
			}
		}

		private int UpdateQuantity(int quantity)
		{
			if (quantity < 0)
			{
				quantity = 0;
			}
			if (mSellItem.GetSlot() >= 0)
			{
				Items.Item item = Globals.Me.Inventory[mSellItem.GetSlot()];
				if (item == null || item.ItemId == Guid.Empty)
				{
					return 0;
				}
				if (quantity > item.Quantity)
				{
					quantity = item.Quantity;
				}
				if (item.Base.IsStackable == false)
				{
					return 1;
				}
				return quantity;
			}
			return 0;
		}

		private void PageMinusButton_Clicked(Base sender, ClickedEventArgs arguments)
		{
			if (sellMode)
			{

			}
			else
			{
				page -= 1;
				if (page < 0) page = pageNB - 1;
			}
			UpdateHDV();
		}

		private void PagePlusButton_Clicked(Base sender, ClickedEventArgs arguments)
		{
			if (sellMode)
			{

			}
			else
			{
				page = (page + 1);
				if (page >= pageNB) page = 0;
			}
			UpdateHDV();
		}

		private void CloseButton_Clicked(Base sender, ClickedEventArgs arguments)
		{
			PacketSender.SendCloseHDV();
			Interface.GameUi.CloseHDV();
		}

		private void BuySellButton_Clicked(Base sender, ClickedEventArgs arguments)
		{
			page = 0;
			sellMode = !sellMode;
			mBuySellButton.SetText(sellMode ? "Buy" : "Sell");
			UpdateHDV();
		}

		public void UpdateHDV()
		{

			searchLabel.Hide();
			searchBox.Hide();
			searchButton.Hide();
            searchCB.Hide();
            orderCB.Hide();
            expiracyCB.Hide();

            mSellItem.Container.Hide();
			mQuantity.Hide();
			mQuantityTextBoxNumeric.Hide();
			mPrice.Hide();
			mPriceTextBoxNumeric.Hide();
			mToSellButton.Hide();
            mExpiracy.Hide();



			for (int i = 0; i < mHdvObject.Count; i++)
			{
				mHdvObject[i].Close();
				mHdvObject[i] = null;
			}
			mHdvObject.Clear();
			if (sellMode)
			{

				mSellItem.Container.Show();
				mQuantity.Show();
				mQuantityTextBoxNumeric.Show();
				mPrice.Show();
				mPriceTextBoxNumeric.Show();
				mToSellButton.Show();
                expiracyCB.Show();
                mExpiracy.Show();

				mPageLabel.SetText($"{(page + 1)} / {pageNB}");

				return;
			}

			searchLabel.Show();
			searchBox.Show();
			searchButton.Show();
			searchCB.Show();
            orderCB.Show();

			mPageLabel.SetText($"{(page + 1)} / {pageNB}");
			List<Client.HDV> items = itemList;
            if (sortMode == 0)
            {
                items = itemList.OrderBy(o => o.Expires).ToList();
            }
            if (sortMode == 1)
            {
                items = itemList.OrderBy(o => o.Price).ToList();
            }
            if (sortMode == 2)
            {
                items = itemList.OrderBy(o => o.Seller).ToList();
            }
            if (sortMode == 3)
            {
                items = itemList.OrderBy(o => ItemBase.GetName(o.ItemId)).ToList();
            }
            for (int i = 0; i < PageItemCount; i++)
			{
				int index = page * PageItemCount + i;
				HDVItem item;
				if (index < items.Count)
				{
					item = new HDVItem(this, items[index], new ImagePanel(mWindow, "HDVItem"));
				}
				else
				{
					item = new HDVItem(this, null, new ImagePanel(mWindow, "HDVItem"));
				}
				item.Container.SetPosition(
					5,
					i * 39
				);
				mHdvObject.Add(item);
			}
		}

		public void Hide()
		{
			mWindow.Hide();
		}

		public bool IsVisible()
		{
			return mWindow.IsVisible;
		}

		public void Close()
		{
            PacketSender.SendCloseHDV();
            //Interface.GameUi.CloseHDV();
            mWindow.Close();

		}


		public int GetSellQuantity()
		{
			return mSellQuantity;
		}
	}
}
