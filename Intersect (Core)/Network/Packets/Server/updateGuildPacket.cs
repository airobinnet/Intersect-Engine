using System;

namespace Intersect.Network.Packets.Server
{

    public class updateGuildPacket : CerasPacket
    {

        public updateGuildPacket(Guid player, Guid guildId, string tag, string name)
        {
            Player = player;
            GuildId = guildId;
            Tag = tag;
            Name = name;
        }

        public Guid Player { get; set; }

        public Guid GuildId { get; set; }

        public string Tag { get; set; }

        public string Name { get; set; }

    }

}
