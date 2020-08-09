namespace Intersect.Network.Packets.Client
{

    public class DepositGuildItemPacket : SlotQuantityPacket
    {

        public DepositGuildItemPacket(int slot, int quantity) : base(slot, quantity)
        {
        }

    }

}
