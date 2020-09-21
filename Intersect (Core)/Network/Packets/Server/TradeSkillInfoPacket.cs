namespace Intersect.Network.Packets.Server
{

    public class TradeSkillInfoPacket : CerasPacket
    {

        public TradeSkillInfoPacket(bool close)
        {
            Close = close;
        }

        public bool Close { get; set; }

    }

}
