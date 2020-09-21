namespace Intersect.Network.Packets.Server
{

    public class TradeSkillsPacket : CerasPacket
    {

        public TradeSkillsPacket(TradeSkillUpdatePacket[] slots)
        {
            Slots = slots;
        }

        public TradeSkillUpdatePacket[] Slots { get; set; }

    }

}
