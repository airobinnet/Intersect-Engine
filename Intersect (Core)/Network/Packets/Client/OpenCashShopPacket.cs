using Intersect.Enums;
using System;

namespace Intersect.Network.Packets.Client
{

    public class OpenCashShopPacket : CerasPacket
    {
        public OpenCashShopPacket(Guid shopid)
        {
            ShopId = shopid;
        }

        public Guid ShopId { get; set; }
    }

}
