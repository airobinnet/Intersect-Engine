using Intersect.Enums;
using System;

namespace Intersect.Network.Packets.Server
{

    public class GuildInvitePacket : CerasPacket
    {
        public GuildInvitePacket(Guid guildId, string name, string tag, int members)
        {
            GuildId = guildId;
            Name = name;
            Tag = tag;
            Members = members;
        }

        public Guid GuildId { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }

        public int Members { get; set; }

    }

}
