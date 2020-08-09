using System;

namespace Intersect.Network.Packets.Server
{

    public class GuildBankUpdatePacket : InventoryUpdatePacket
    {

        public GuildBankUpdatePacket(int slot, Guid id, int quantity, Guid? bagId, int[] statBuffs) : base(
            slot, id, quantity, bagId, statBuffs
        )
        {
        }

    }

}
