using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersect.Network.Packets.Client
{
	public class AddHDVPacket : CerasPacket
	{

		public AddHDVPacket(int slot, int[] statBuffs, int quantity, int price, double expires)
		{
			Slot = slot;
            StatBuffs = statBuffs;
            Quantity = quantity;
			Price = price;
            Expires = expires;
		}

		public int Slot { get; set; }
        public int[] StatBuffs { get; set; } = new int[(int)Enums.Stats.StatCount];
        public int Quantity { get; set; }
		public int Price { get; set; }
        public double Expires { get; set; }
	}
}
