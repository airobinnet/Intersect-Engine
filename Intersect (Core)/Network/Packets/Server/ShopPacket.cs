using System;
using System.Collections.Generic;

namespace Intersect.Network.Packets.Server
{

    public class ShopPacket : CerasPacket
    {

        public ShopPacket(string shopData, bool close, List<Guid> reqcheck)
        {
            ShopData = shopData;
            Close = close;
            ReqCheck = reqcheck;
        }

        public string ShopData { get; set; }

        public bool Close { get; set; }

        public List<Guid> ReqCheck { get; set; }

    }

}
