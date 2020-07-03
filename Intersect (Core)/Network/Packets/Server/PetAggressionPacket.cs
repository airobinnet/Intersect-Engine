using System;

namespace Intersect.Network.Packets.Server
{

    public class PetAggressionPacket : CerasPacket
    {

        public PetAggressionPacket(Guid entityId, int aggression)
        {
            EntityId = entityId;
            Aggression = aggression;
        }

        public Guid EntityId { get; set; }

        public int Aggression { get; set; }

    }

}
