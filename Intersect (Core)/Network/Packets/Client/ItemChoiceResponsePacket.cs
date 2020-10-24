using System;

namespace Intersect.Network.Packets.Client
{

    public class ItemChoiceResponsePacket : CerasPacket
    {

        public ItemChoiceResponsePacket(Guid eventId, int response)
        {
            EventId = eventId;
            Response = response;
        }

        public Guid EventId { get; set; }

        public int Response { get; set; }

    }

}
