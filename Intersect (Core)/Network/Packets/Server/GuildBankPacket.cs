namespace Intersect.Network.Packets.Server
{

    public class GuildBankPacket : CerasPacket
    {

        public GuildBankPacket(bool close)
        {
            Close = close;
        }

        public bool Close { get; set; }

    }

}
