using System;
using System.Collections.Generic;

using Intersect.Collections;
using Intersect.GameObjects;

using Steamworks;

namespace Intersect.Network.Packets.Client
{

    public class SendSteamMTxnAuthorizedPacket : CerasPacket
    {

        public SendSteamMTxnAuthorizedPacket(AppId appid, ulong orderid, bool authorized)
        {
            AppId = appid;
            OrderId = orderid;
            Authorized = authorized;
        }
        

        public AppId AppId { get; set; }

        public ulong OrderId { get; set; }

        public bool Authorized { get; set; }

    }

}
