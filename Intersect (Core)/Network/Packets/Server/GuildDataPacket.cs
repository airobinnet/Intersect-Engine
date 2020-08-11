using Intersect.Enums;
using System;

namespace Intersect.Network.Packets.Server
{

    public class GuildDataPacket : CerasPacket
    {
        //player.Guild.Id, player.Guild.Name, player.Guild.Tag, player.Guild.FoundingDate, player.Guild.LeaderRank, player.Guild.Members, player.Guild.Ranks
        public GuildDataPacket(Guid guildId, string name, string tag, DateTime date, Guid leaderrank, string members, string membersnames, string ranks, int level, int experience)
        {
            GuildId = guildId;
            Name = name;
            Tag = tag;
            Date = date;
            LeaderRank = leaderrank;
            Members = members;
            MembersNames = membersnames;
            Ranks = ranks;
            GuildLevel = level;
            GuildExperience = experience;
        }

        public Guid GuildId { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }

        public DateTime Date { get; set; }

        public Guid LeaderRank { get; set; }

        public string Members { get; set; }

        public string MembersNames { get; set; }

        public string Ranks { get; set; }

        public int GuildLevel { get; set; }

        public int GuildExperience { get; set; }
    }

}
