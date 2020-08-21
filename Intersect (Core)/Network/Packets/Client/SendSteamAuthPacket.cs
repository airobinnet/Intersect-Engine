using System;
using System.Collections.Generic;

using Intersect.Collections;
using Intersect.GameObjects;

using Steamworks;

namespace Intersect.Network.Packets.Client
{

    public class SendSteamAuthPacket : CerasPacket
    {

        public SendSteamAuthPacket(SteamId steamId, AuthTicket ticket)
        {
            SteamId = steamId;
            Ticket = ticket;
        }
        

        public SteamId SteamId { get; set; }

        public AuthTicket Ticket { get; set; }

    }

}
