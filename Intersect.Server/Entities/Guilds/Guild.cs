﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Intersect.Enums;
using Intersect.Logging;
using Intersect.Server.Localization;
using Intersect.Server.Networking;
using Intersect.Server.Database;
using Intersect.Server.Database.PlayerData.Players;

using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace Intersect.Server.Entities.Guilds
{
    public class Guild
    {
        /// <summary>
        /// The Identifier by which this Guild can be uniquely identified.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        /// <summary>
        /// The Guild's full name.
        /// </summary>
        [Column(Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// The display tag that shows next to a player's name when in a guild.
        /// </summary>
        [Column(Order = 2)]
        public string Tag { get; set; }

        [Column("Members", Order = 3)]
        [JsonIgnore]
        public string MembersJson
        {
            get => JsonConvert.SerializeObject(Members);
            set => Members = JsonConvert.DeserializeObject<Dictionary<Guid, Guid>>(value);
        }

        /// <summary>
        /// A Dictionary of all Members in this guild. Key is Player, Value is Rank.
        /// </summary>
        [NotMapped]
        public Dictionary<Guid, Guid> Members = new Dictionary<Guid, Guid>();

        [Column("Ranks", Order = 4)]
        [JsonIgnore]
        public string RanksJson
        {
            get => JsonConvert.SerializeObject(Ranks);
            set => Ranks = JsonConvert.DeserializeObject<List<GuildRank>>(value);
        }

        /// <summary>
        /// A list of all Ranks in this guild.
        /// </summary>
        [NotMapped]
        public List<GuildRank> Ranks = new List<GuildRank>();

        /// <summary>
        /// Determines which rank a player will get by default upon joining this guild.
        /// </summary>
        public Guid DefaultMemberRank { get; set; }

        /// <summary>
        /// Determines which rank within this guild is the leader rank.
        /// </summary>
        public Guid LeaderRank { get; set; }

        /// <summary>
        /// The date on which this guild was founded.
        /// </summary>
        [Column(Order = 6)]
        public DateTime FoundingDate { get; set; }

        //Bank
        [NotNull, JsonIgnore]
        public virtual List<GuildBankSlot> GuildBank { get; set; } = new List<GuildBankSlot>();

        /// <summary>
        /// Determines which level this guild is.
        /// </summary>
        public int GuildLevel { get; set; }

        /// <summary>
        /// Determines the current experience of the guild.
        /// </summary>
        public int GuildExperience { get; set; }


        public Guild() : this(Guid.NewGuid())
        {

        }

        public Guild(Guid guid)
        {
            Id = guid;
        }

        public static void Create(Player player, string name, string tag)
        {
            Database.DbInterface.CreateGuild(player, name, tag);


            PacketSender.updateGuild(player);
            PacketSender.SendEntityDataToProximity(player);
        }

        public bool ValidateLists()
        {
            var changes = false;
            
            changes |= SlotHelper.ValidateSlots(GuildBank, Options.MaxBankSlots);

            return changes;
        }
        public void SetupDefaultRanks()
        {
            // Clear existing ranks, if any.
            Ranks.Clear();

            // Create new ranks
            Guid defaultRank = Guid.Empty;
            foreach (var rank in Options.GuildOptions.DefaultRanks)
            {
                // Create a new rank and set it up as configured.
                var newRank = new GuildRank(true) { Title = rank.Title, Permissions = rank.Permissions };
                Ranks.Add(newRank);

                // If this rank matches our default member rank setting, set it as such!
                if (Options.GuildOptions.DefaultMemberRank == rank.Title) DefaultMemberRank = newRank.Id;

                // If this rank matches our default creation rank setting, set it as our Leader Rank
                if (Options.GuildOptions.DefaultLeaderRank == rank.Title) LeaderRank = newRank.Id;
            }
            
            // If our Leader rank is empty, something went horribly awry?
            if (LeaderRank == Guid.Empty) 
            {
                Log.Error($@"Created guild with Id {Id} without a LeaderRank. Is the Guild configuration invalid? Setting to First rank!");
                LeaderRank = Ranks.First().Id;
            }

            // If our Default Member rank is empty, something went horribly awry?
            if (DefaultMemberRank == Guid.Empty)
            {
                Log.Error($@"Created guild with Id {Id} without a DefaultMemberRank. Is the Guild configuration invalid? Setting to First rank!");
                DefaultMemberRank = Ranks.First().Id;
            }
        }

        public GuildRank GetRank(Player player)
        {
            if (!Members.ContainsKey(player.Id))
            {
                return null;
            }
            return Ranks.Where(r => r.Id == Members[player.Id]).FirstOrDefault();
        }

        public bool ChangeRank(Guid player, Guid rank)
        {
            if (player == null)
            {
                return false;
            }
            if (!Members.ContainsKey(player))
            {
                return false;
            }
            Members[player] = rank;
            // Find every online player in the guild and send the update.
            foreach (var playerId in Members.Keys)
            {
                var tempplayer = Player.FindOnline(playerId);
                PacketSender.SendGuildData(tempplayer);
            }
            return true;
        }

        public bool Join(Player player, Guid rank) 
        { 
            // Check if this player is already in a guild.
            if (player.Guild != null)
            {
                PacketSender.SendChatMsg(player, Strings.Guilds.AlreadyInGuild, CustomColors.Alerts.Error);
                return false;
            }

            // Set this player to be in this guild.
            player.Guild = this;
            player.guildInvite = null;
            Members.Add(player.Id, rank);

            // Notify them they've joined!
            PacketSender.SendChatMsg(player, Strings.Guilds.Welcome.ToString(Name), CustomColors.Alerts.Success);
            PacketSender.SendGuildMsg(this, Strings.Guilds.HasJoined.ToString(player.Name, Name), CustomColors.Alerts.Success);

            foreach (var playerId in Members.Keys)
            {
                var tempplayer = Player.FindOnline(playerId);
                PacketSender.SendGuildData(tempplayer);
            }
            PacketSender.updateGuild(player);
            PacketSender.SendEntityDataToProximity(player);

            return true;
        }

        public bool Set(Player player)
        {
            // Check if this player is already in a guild.
            if (player.Guild != null)
            {
                PacketSender.SendChatMsg(player, Strings.Guilds.AlreadyInGuild, CustomColors.Alerts.Error);
                return false;
            }

            // Set this player to be in this guild.
            player.Guild = this;
            return true;
        }

        public bool Leave(Player player)
        {
            if (player == null)
            {
                return false;
            }

            // Does this member exist?
            if (!Members.Keys.Contains(player.Id))
            {
                Log.Warn($@"Player {player.Id} tried to leave Guild {this.Id} but is not a member!");
                return false;
            }

            // Can this member leave?
            if (Members[player.Id] == LeaderRank)
            {
                PacketSender.SendChatMsg(player, Strings.Guilds.LeaderCantLeave.ToString(), CustomColors.Alerts.Error);
                return false;
            }

            // Remove the member from the guild.
            Members.Remove(player.Id);
            player.Guild = null;
            player.GuildId = null;
            DbInterface.SavePlayerDatabaseAsync();


            // Notify them they've left!
            PacketSender.SendChatMsg(player, Strings.Guilds.Goodbye.ToString(Name), CustomColors.Alerts.Success);
            PacketSender.SendGuildMsg(this, Strings.Guilds.HasLeft.ToString(player.Name, Name), CustomColors.Alerts.Info);
            // Find every online player in the guild and send the update.
            foreach (var playerId in Members.Keys)
            {
                var tempplayer = Player.FindOnline(playerId);
                PacketSender.SendGuildData(tempplayer);
            }

            PacketSender.updateGuild(player);
            PacketSender.SendEntityDataToProximity(player);


            return true;
        }

        public bool Kick(Player player)
        {
            if (player == null)
            {
                return false;
            }

            // Does this member exist?
            if (!Members.Keys.Contains(player.Id))
            {
                Log.Warn($@"Player {player.Id} cant be kicked from the Guild {this.Id} cuz (s)hes not a member!");
                return false;
            }

            // Can this member leave?
            if (Members[player.Id] == LeaderRank)
            {
                if (Members.Count == 1)
                {
                    Disband(player);
                    return false;
                }
                else
                {
                    PacketSender.SendChatMsg(player, Strings.Guilds.LeaderCantBeKicked.ToString(), CustomColors.Alerts.Error);
                    return false;
                }
            }
            // Remove the member from the guild.
            Members.Remove(player.Id);

            // Notify them they've left!
            PacketSender.SendChatMsg(player, Strings.Guilds.Kicked.ToString(Name), CustomColors.Alerts.Success);
            PacketSender.SendGuildMsg(this, Strings.Guilds.HasLeftbyKick.ToString(player.Name, Name), CustomColors.Alerts.Info);
            foreach (var playerId in Members.Keys)
            {
                var tempplayer = Player.FindOnline(playerId);
                PacketSender.SendGuildData(tempplayer);
            }
            
            player.Guild = null;
            player.GuildId = null;
            DbInterface.SavePlayerDatabaseAsync();
            PacketSender.updateGuild(player);
            PacketSender.SendEntityDataToProximity(player);
            //log the player back out, because for some reason when changing player.Guild, that player physically logged into the game
            //nobody should notice the player coming online i guess
            if (player.Client == null)
            {
                player.TryLogout();
            }

            return true;
        }

        public bool Disband(Player player)
        {
            // Remove the member from the guild.
            Members.Remove(player.Id);

            foreach (var playerId in Members.Keys)
            {
                var tempplayer = Player.FindOnline(playerId);
                PacketSender.SendGuildData(tempplayer);
            }

            player.Guild = null;
            player.GuildId = null;
            PacketSender.SendEntityDataToProximity(player);
            DbInterface.RemoveGuild(this);
            PacketSender.SendChatMsg(player, Strings.Guilds.Disband.ToString(Name), CustomColors.Alerts.Success);
            DbInterface.SavePlayerDatabaseAsync();
            PacketSender.updateGuild(player);

            return true;
        }

        public void GiveExperience(long amount)
        {
            GuildExperience += (int)amount;
            if (GuildExperience < 0)
            {
                GuildExperience = 0;
            }

            if (!CheckLevelUp())
            {
                if (amount > 0)
                {
                    PacketSender.SendGuildMsg(this, "The Guild gained " + (int)amount + " experience.", CustomColors.Alerts.Info);
                    foreach (var playerId in Members.Keys)
                    {
                        var tempplayer = Player.FindOnline(playerId);
                        PacketSender.SendGuildData(tempplayer);
                    }
                }
            }
        }

        private bool CheckLevelUp()
        {
            float MaxLvlExp = 5000;

            MaxLvlExp = Options.GuildOptions.GuildLevels[GuildLevel];
            
            var levelCount = 0;
            while (GuildExperience >= MaxLvlExp &&
                   MaxLvlExp > 0)
            {
                GuildExperience -= (int)MaxLvlExp;
                levelCount++;
            }

            if (levelCount <= 0)
            {
                return false;
            }

            GuildLevel = GuildLevel + levelCount;
            PacketSender.SendGuildMsg(this, "The Guild leveled up to level " + (int)GuildLevel + ".", CustomColors.Alerts.Info);
            foreach (var playerId in Members.Keys)
            {
                var tempplayer = Player.FindOnline(playerId);
                PacketSender.SendGuildData(tempplayer);
            }

            return true;
        }
    }
}
