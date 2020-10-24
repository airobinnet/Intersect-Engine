﻿using System;

namespace Intersect.Network.Packets.Server
{

    public class ItemChoicePacket : CerasPacket
    {

        public ItemChoicePacket(Guid eventId, byte type, string[] responses)
        {
            EventId = eventId;
            Responses = responses;
            Type = type;
        }

        public Guid EventId { get; set; }

        public byte Type { get; set; }

        public string[] Responses { get; set; }

    }

}
