using System.Collections.Generic;

using Intersect.Enums;
using System;
using System.Linq;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace Intersect.Config
{
    /// <summary>
    /// Contains the options pertaining to all things guild related.
    /// </summary>
    public class GuildOptions
    {
        /// <summary>
        /// Determines whether the client should render the Guild Tag (true) or the Guild Name (false) by players their names.
        /// </summary>
        public bool ShowGuildTag = true;

        /// <summary>
        /// Configures which rank will be used by default for the person creating a guild.
        /// </summary>
        public string DefaultLeaderRank = "Leader";

        /// <summary>
        /// Configures which rank will be used by default for each person invited to a guild.
        /// </summary>
        public string DefaultMemberRank = "New Member";

        /// <summary>
        /// Configures how many extra members a guild can invite each level (starts with 5)
        /// </summary>
        public int MemberIncrease = 5;

        /// <summary>
        /// Configures how many extra guildbank slots a guild can have each level (starts with 10)
        /// Guildbanks unlock at level 1
        /// </summary>
        public int GuildBankSlotsIncrease = 5;

        /// <summary>
        /// Configures the experience needed to level up the guild.
        /// Guilds start at level 0
        /// enter 0 for the last level
        /// </summary>
        public List<int> GuildLevels = new List<int>()
        {
            5000,
            50000,
            100000,
            250000,
            1000000,
            0
        };
        /// <summary>
        /// Configures the default ranks and their permissions for a guild.
        /// </summary>
        public List<GuildRankOptions> DefaultRanks = new List<GuildRankOptions>() {

            new GuildRankOptions() {
                Title = "New Member",
                Permissions = new Dictionary<GuildPermissions, bool>() {
                    { GuildPermissions.UseGuildChat, true },
                }
            },

            // Member
            new GuildRankOptions() {
                Title = "Member",
                Permissions = new Dictionary<GuildPermissions, bool>() {
                    { GuildPermissions.UseGuildChat, true },
                    { GuildPermissions.InvitePlayers, true },
                    { GuildPermissions.ViewBank, true },
                    { GuildPermissions.DepositBank, true },
                }
            },

            // Officer
            new GuildRankOptions() {
                Title = "Officer",
                Permissions = new Dictionary<GuildPermissions, bool>() {
                    { GuildPermissions.UseGuildChat, true },
                    { GuildPermissions.InvitePlayers, true },
                    { GuildPermissions.KickPlayers, true },
                    { GuildPermissions.ViewBank, true },
                    { GuildPermissions.DepositBank, true },
                }
            },

            // Leader
            new GuildRankOptions() {
                Title = "Leader",
                Permissions = new Dictionary<GuildPermissions, bool>() {
                    { GuildPermissions.UseGuildChat, true },
                    { GuildPermissions.InvitePlayers, true },
                    { GuildPermissions.KickPlayers, true },
                    { GuildPermissions.ChangeGuildName, true },
                    { GuildPermissions.ChangeGuildTag, true },
                    { GuildPermissions.ViewBank, true },
                    { GuildPermissions.DepositBank, true },
                    { GuildPermissions.WithdrawBank, true },
                }
            },
        };

        [OnDeserializing]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            GuildLevels.Clear();
            DefaultRanks.Clear();
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Validate();
        }

        public void Validate()
        {
            GuildLevels = new List<int>(GuildLevels);
            DefaultRanks = new List<GuildRankOptions>(DefaultRanks.Distinct());
        }
    }

    /// <summary>
    /// Contains settings pertaining to each (default) guild rank.
    /// </summary>
    public class GuildRankOptions
    {
        public string Title { get; set; }

        public Dictionary<GuildPermissions, bool> Permissions = new Dictionary<GuildPermissions, bool>();
    }

}
