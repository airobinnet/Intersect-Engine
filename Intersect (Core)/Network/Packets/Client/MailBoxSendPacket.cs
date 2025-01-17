﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersect.Network.Packets.Client
{
	public class MailBoxSendPacket : CerasPacket
	{
		public MailBoxSendPacket(string to, string title, string message, int slotID, int quantity, int[] statBuffs)
		{
			To = to;
			Title = title;
			Message = message;
			SlotID = slotID;
			Quantity = quantity;
            StatBuffs = statBuffs;
        }

		public string To { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
		public int SlotID { get; set; }
		public int Quantity { get; set; }
        public int[] StatBuffs { get; set; } = new int[(int)Enums.Stats.StatCount];
    }
}
