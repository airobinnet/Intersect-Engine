using System;

namespace Intersect.Network.Packets.Server
{

    public class TradeSkillUpdatePacket : CerasPacket
    {

        public TradeSkillUpdatePacket(int slot, Guid id, bool unlocked, int level, int xp)
        {
            Slot = slot;
            TradeSkillId = id;
            Unlocked = unlocked;
            Level = level;
            Xp = xp;
        }
        
        public int Slot { get; set; }

        public Guid TradeSkillId { get; set; }

        public bool Unlocked { get; set; }

        public int Level { get; set; }

        public int Xp { get; set; }

    }

}
