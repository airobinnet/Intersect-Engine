﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intersect.Network.Packets.Server
{
	public class SendOpenGuildCreatePacket : CerasPacket
	{
		public SendOpenGuildCreatePacket(Guid itemid, bool close)
		{
            ItemId = itemid;
            Close = close;
		}
		public Guid ItemId { get; set; }

        public bool Close { get; set; }
	}
}
