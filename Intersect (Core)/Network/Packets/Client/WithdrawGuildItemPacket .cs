namespace Intersect.Network.Packets.Client
{

    public class WithdrawGuildItemPacket : SlotQuantityPacket
    {

        public WithdrawGuildItemPacket(int slot, int quantity) : base(slot, quantity)
        {
        }

    }

}
