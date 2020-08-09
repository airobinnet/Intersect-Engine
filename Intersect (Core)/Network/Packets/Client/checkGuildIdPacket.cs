using System;

namespace Intersect.Network.Packets.Client
{

    public class checkGuildIdPacket : CerasPacket
    {

        public checkGuildIdPacket(Guid player)
        {
            Player = player;
        }

        public Guid Player { get; set; }

    }

}
