﻿using Intersect.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersect.Client
{
	public class HDV
	{
		public HDV(Guid id, string seller, Guid itemid, int quantity, int[] statBuffs, int price, double expires)
		{
			Id = id;
			Seller = seller;
			ItemId = itemid;
			Quantity = quantity;
			StatBuffs = statBuffs;
			Price = price;
            Expires = expires;
		}

		public Guid Id { get; set; }
		public string Seller { get; set; }
		public Guid ItemId { get; set; } = Guid.Empty;
		public ItemBase Base { get => ItemBase.Get(ItemId); }
		public int Quantity { get; set; }
		public int[] StatBuffs { get; set; } = new int[(int)Enums.Stats.StatCount];
		public int Price { get; set; }
        public double Expires { get; set; }
	}
}
