namespace Intersect.Network.Packets.Client
{

    public class SwapGuildBankItemsPacket : SlotSwapPacket
    {

        public SwapGuildBankItemsPacket(int slot1, int slot2) : base(slot1, slot2) { }

    }

}
