﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Dynamic;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.GameObjects.Crafting;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Maps.MapList;
using Intersect.Logging;
using Intersect.Models;
using Intersect.Network;
using Intersect.Network.Packets.Server;
using Intersect.Server.Database;
using Intersect.Server.Database.PlayerData.Players;
using Intersect.Server.Database.PlayerData;
using Intersect.Server.Database.PlayerData.Security;
using Intersect.Server.Entities;
using Intersect.Server.Entities.Events;
using Intersect.Server.Entities.Guilds;
using Intersect.Server.General;
using Intersect.Server.Localization;
using Intersect.Server.Maps;

using JetBrains.Annotations;

using Newtonsoft.Json;

namespace Intersect.Server.Networking
{

    public static class PacketSender
    {

        //Cached GameDataPacket that gets sent to clients
        public static GameDataPacket CachedGameDataPacket = null;

        //reqcheck
        public static List<Guid> reqcheck = new List<Guid>();

        //PingPacket
        public static void SendPing(Client client, bool request = true)
        {
            if (client != null)
            {
                client.SendPacket(new PingPacket(request));
            }
        }

        //ConfigPacket
        public static void SendServerConfig(Client client)
        {
            client.SendPacket(new ConfigPacket(Options.OptionsData));
        }

        //EnteringGamePacket
        public static void SendEnteringGamePacket(Player player)
        {
            player.SendPacket(new EnteringGamePacket());
        }

        //JoinGamePacket
        public static void SendJoinGame(Client client)
        {
            if (!client.IsEditor)
            {
                SendEnteringGamePacket(client.Entity);
                SendEntityDataTo(client.Entity, client.Entity);
            }

            client.SendPacket(new JoinGamePacket());
            PacketSender.SendGameData(client);

            if (!client.IsEditor)
            {
                var player = client.Entity;
                player.RecalculateStatsAndPoints();
                player.InGame = true;

                SendTimeTo(client);

                if (client.Power.Editor)
                {
                    SendChatMsg(player, Strings.Player.adminjoined, CustomColors.Alerts.AdminJoined);
                }
                else if (client.Power.IsModerator)
                {
                    SendChatMsg(player, Strings.Player.modjoined, CustomColors.Alerts.ModJoined);
                }

                if (player.MapId == Guid.Empty)
                {
                    player.WarpToSpawn();
                }
                else
                {
                    player.Warp(
                        player.MapId, (byte) player.X, (byte) player.Y, (byte) player.Dir, false, (byte) player.Z
                    );
                }

                SendEntityDataTo(client.Entity, player);

                //Search for login activated events and run them
                foreach (EventBase evt in EventBase.Lookup.Values)
                {
                    if (evt != null)
                    {
                        player.StartCommonEvent(evt, CommonEventTrigger.Login);
                    }
                }
                if (player.Guild != null)
                {
                    foreach (var playerId in player.Guild.Members.Keys)
                    {
                        var tempplayer = Player.FindOnline(playerId);
                        if (playerId != player.Id)
                        {
                            PacketSender.SendGuildData(tempplayer);
                        }
                    }
                }
            }
        }

        //MapAreaPacket
        public static void SendAreaPacket(Player player)
        {
            var client = player.Client;
            if (client == null)
            {
                return;
            }

            var surroundingMaps = MapInstance.Get(player.MapId).GetSurroundingMaps(true);
            var packets = new List<MapPacket>();
            foreach (var map in surroundingMaps)
            {
                packets.Add(GenerateMapPacket(client, map.Id));
            }

            player.SendPacket(new MapAreaPacket(packets.ToArray()));
        }

        //MapPacket
        public static MapPacket GenerateMapPacket(Client client, Guid mapId)
        {
            if (client == null)
            {
                Log.Error("Attempted to send packet to null client.");

                return null;
            }

            var map = MapInstance.Get(mapId);
            if (map == null)
            {
                return new MapPacket(mapId, true);
            }
            else
            {
                var mapPacket = new MapPacket(
                    mapId, false, map.JsonData, map.TileData, map.AttributeData, map.Revision, map.MapGridX,
                    map.MapGridY, new bool[4]
                );

                if (client.IsEditor)
                {
                    foreach (var id in map.EventIds)
                    {
                        var evt = EventBase.Get(id);
                        if (evt != null)
                        {
                            SendGameObject(client, evt);
                        }
                    }
                }
                else
                {
                    switch (Options.GameBorderStyle)
                    {
                        case 1:
                            mapPacket.CameraHolds = new bool[4] {true, true, true, true};

                            break;

                        case 0:
                            var grid = DbInterface.GetGrid(map.MapGrid);
                            if (grid != null)
                            {
                                mapPacket.CameraHolds = new bool[4]
                                {
                                    0 == map.MapGridY, grid.YMax - 1 == map.MapGridY,
                                    0 == map.MapGridX, grid.XMax - 1 == map.MapGridX
                                };
                            }

                            break;
                    }
                }

                if (client.IsEditor)
                {
                    return mapPacket;
                }
                else
                {
                    mapPacket.MapItems = GenerateMapItemsPacket(mapId);
                    mapPacket.MapEntities = GenerateMapEntitiesPacket(mapId, client.Entity);

                    return mapPacket;
                }
            }
        }

        //MapPacket
        public static void SendMap(Client client, Guid mapId, bool allEditors = false)
        {
            if (client == null)
            {
                return;
            }

            var map = MapInstance.Get(mapId);

            if (!client.IsEditor)
            {
                if (client.SentMaps.TryGetValue(mapId, out var sentMap))
                {
                    if (sentMap.Item1 > Globals.Timing.TimeMs && sentMap.Item2 == map.Revision)
                    {
                        return;
                    }

                    client.SentMaps.Remove(mapId);
                }

                try
                {
                    client.SentMaps.Add(mapId, new Tuple<long, int>(Globals.Timing.TimeMs + 5000, map.Revision));
                }
                catch (Exception exception)
                {
                    Log.Error($"Current Map #: {mapId}");
                    Log.Error($"# Sent maps: {client.SentMaps.Count}");
                    Log.Error($"# Maps: {MapInstance.Lookup.Count}");
                    Log.Error(exception);

                    throw;
                }
            }

            if (client.IsEditor)
            {
                if (allEditors)
                {
                    SendDataToEditors(GenerateMapPacket(client, mapId));
                }
                else
                {
                    client.SendPacket(GenerateMapPacket(client, mapId));
                }
            }
            else
            {
                client.SendPacket(GenerateMapPacket(client, mapId));
                var entity = client.Entity;
                if (entity != null)
                {
                    //TODO: INCLUDE EVENTS IN MAP PACKET
                    if (mapId == entity.MapId)
                    {
                        entity.SendEvents();
                    }
                }

                //TODO - Include Aggression and Equipment in ENTITY DATA PACKETS!
                //SendMapEntityEquipmentTo(client, sendEntities); //Send the equipment of each player

                //for (var i = 0; i < sendEntities.Count; i++)
                //{
                //    if (sendEntities[i].GetType() == typeof(Npc))
                //    {
                //        SendNpcAggressionTo(client.Entity, (Npc)sendEntities[i]);
                //    }
                //}
            }
        }

        //MapPacket
        public static void SendMapToEditors(Guid mapId)
        {
            MapPacket packet = null;
            var map = MapInstance.Get(mapId);
            if (map == null)
            {
                packet = new MapPacket(mapId, true);
            }
            else
            {
                packet = new MapPacket(
                    mapId, false, map.JsonData, map.TileData, map.AttributeData, map.Revision, map.MapGridX,
                    map.MapGridY
                );
            }

            SendDataToEditors(packet);
        }

        //MapEntitiesPacket
        public static MapEntitiesPacket GenerateMapEntitiesPacket(Guid mapId, Player forPlayer = null)
        {
            var map = MapInstance.Get(mapId);
            if (map != null)
            {
                var entities = map.GetEntities(false);
                var sendEntities = new List<Entity>();
                for (var i = 0; i < entities.Count; i++)
                {
                    if (entities[i] != null)
                    {
                        sendEntities.Add(entities[i]);
                    }
                }

                var enPackets = new List<EntityPacket>();
                for (var i = 0; i < sendEntities.Count; i++)
                {
                    enPackets.Add(sendEntities[i].EntityPacket(null, forPlayer));
                }

                return new MapEntitiesPacket(enPackets.ToArray());
            }

            return null;
        }

        //EntityPacket
        public static void SendEntityDataTo(Player player, Entity en)
        {
            if (en == null)
            {
                return;
            }

            var packet = en.EntityPacket(null, player);
            packet.IsSelf = en == player;
            player.SendPacket(packet);

            if (en == player)
            {
                SendExperience(player);
                SendInventory(player);
                SendPlayerSpells(player);
                SendPointsTo(player);
                SendHotbarSlots(player);
                SendQuestsProgress(player);
                SendItemCooldowns(player);
                SendSpellCooldowns(player);
                SendTradeSkills(player);
            }

            //If a player, send equipment to all (for paperdolls)
            //Also send Custom Sprite Layers
            if (en.GetType() == typeof(Player))
            {
                SendPlayerEquipmentTo(player, (Player) en);
                SendCustomSpriteLayersTo(player, (Player) en);
            }

            if (en.GetType() == typeof(Npc))
            {
                SendNpcAggressionTo(player, (Npc)en);
            }
            if (en.GetType() == typeof(Pet))
            {
                SendPetAggressionTo(player, (Pet)en);
            }
        }

        //MapEntitiesPacket
        public static void SendMapEntitiesTo(Player player, ConcurrentDictionary<Guid, Entity> entities)
        {
            var sendEntities = new List<Entity>();

            foreach (var en in entities)
            {
                if (en.Value != null && en.Value != player)
                {
                    sendEntities.Add(en.Value);
                }
            }

            var enPackets = new List<EntityPacket>();
            for (var i = 0; i < sendEntities.Count; i++)
            {
                enPackets.Add(sendEntities[i].EntityPacket(null, player));
            }

            player.SendPacket(new MapEntitiesPacket(enPackets.ToArray()));

            SendMapEntityEquipmentTo(player, sendEntities); //Send the equipment of each player
            SendMapCustomSpriteLayersTo(player, sendEntities); //Send the custom sprite layers of each player.

            for (var i = 0; i < sendEntities.Count; i++)
            {
                if (sendEntities[i].GetType() == typeof(Npc))
                {
                    SendNpcAggressionTo(player, (Npc)sendEntities[i]);
                }
                if (sendEntities[i].GetType() == typeof(Pet))
                {
                    SendPetAggressionTo(player, (Pet)sendEntities[i]);
                }
            }
        }

        public static void SendMapEntityEquipmentTo(Player player, List<Entity> entities)
        {
            for (var i = 0; i < entities.Count; i++)
            {
                if (entities[i] != null && entities[i] != player)
                {
                    //If a player, send equipment to all (for paperdolls)
                    if (entities[i].GetType() == typeof(Player) && player != entities[i])
                    {
                        SendPlayerEquipmentTo(player, (Player) entities[i]);
                    }
                }
            }
        }

        public static void SendMapCustomSpriteLayersTo(Player player, List<Entity> entities)
        {
            for (var i = 0; i < entities.Count; i++)
            {
                if (entities[i] != null && entities[i] != player)
                {
                    //If a player, send equipment to all (for paperdolls)
                    if (entities[i].GetType() == typeof(Player) && player != entities[i])
                    {
                        SendCustomSpriteLayersTo(player, (Player)entities[i]);
                    }
                }
            }
        }

        //EntityDataPacket
        public static void SendEntityDataToProximity(Entity en, Player except = null)
        {
            if (en == null)
            {
                return;
            }

            foreach (var map in en.Map.GetSurroundingMaps(true))
            {
                foreach (var player in map.GetPlayersOnMap())
                {
                    if (player != except)
                    {
                        SendEntityDataTo(player, en);
                    }
                }
            }

            SendEntityVitals(en);
            SendEntityStats(en);

            //If a player, send equipment to all (for paperdolls)
            if (en.GetType() == typeof(Player))
            {
                SendPlayerEquipmentToProximity((Player) en);
                SendCustomSpriteLayersToProximity((Player) en);
            }

            if (en.GetType() == typeof(Npc))
            {
                SendNpcAggressionToProximity((Npc) en);
            }
        }

        //UpdateGuild
        public static void updateGuild(Player player)
        {
            if (player == null)
            {
                return;
            }
            if (player.Guild != null)
            {
                player.SendPacket(new updateGuildPacket(player.Id, (Guid)player.Guild.Id, player.Guild?.Tag ?? "", player.Guild?.Name ?? ""));
            } else
            {
                player.SendPacket(new updateGuildPacket(player.Id, Guid.Empty, "", ""));
            }
            SendEntityDataToProximity(player);
        }

        //EntityPositionPacket
        public static void SendEntityPositionTo(Client client, Entity en)
        {
            if (en == null)
            {
                return;
            }

            client.SendPacket(
                new EntityPositionPacket(
                    en.Id, en.GetEntityType(), en.MapId, (byte) en.X, (byte) en.Y, (byte) en.Dir, en.Passable,
                    en.HideName
                )
            );
        }

        //EntityPositionPacket
        public static void SendEntityPositionToAll(Entity en)
        {
            if (en == null)
            {
                return;
            }

            SendDataToProximity(
                en.MapId,
                new EntityPositionPacket(
                    en.Id, en.GetEntityType(), en.MapId, (byte) en.X, (byte) en.Y, (byte) en.Dir, en.Passable,
                    en.HideName
                )
            );
        }

        public static void SendNpcAggressionToProximity(Npc en)
        {
            if (en == null)
            {
                return;
            }

            var map = en.Map;
            foreach (var mp in en.Map.GetSurroundingMaps(true))
            {
                var players = mp.GetPlayersOnMap();
                foreach (var pl in players)
                {
                    SendNpcAggressionTo(pl, en);
                }
            }
        }

        public static void SendPetAggressionToProximity(Pet en)
        {
            if (en == null)
            {
                return;
            }

            var map = en.Map;
            foreach (var mp in en.Map.GetSurroundingMaps(true))
            {
                var players = mp.GetPlayersOnMap();
                foreach (var pl in players)
                {
                    SendPetAggressionTo(pl, en);
                }
            }
        }

        //NpcAggressionPacket
        public static void SendNpcAggressionTo(Player player, Npc npc)
        {
            if (player == null || npc == null)
            {
                return;
            }

            player.SendPacket(new NpcAggressionPacket(npc.Id, npc.GetAggression(player)));
        }

        //PetAggressionPacket
        public static void SendPetAggressionTo(Player player, Pet pet)
        {
            if (player == null || pet == null)
            {
                return;
            }

            player.SendPacket(new PetAggressionPacket(pet.Id, pet.GetAggression(player)));
        }

        //EntityLeftArea
        public static void SendEntityLeaveMap(Entity en, Guid leftMap)
        {
            SendDataToMap(leftMap, new EntityLeftPacket(en.Id, en.GetEntityType(), en.MapId));
        }

        //EntityLeftPacket
        public static void SendEntityLeave(Entity en)
        {
            SendDataToProximity(en.MapId, new EntityLeftPacket(en.Id, en.GetEntityType(), en.MapId));
        }

        //EntityLeavePacket
        public static void SendEntityLeaveTo(Player player, Entity en)
        {
            player.SendPacket(new EntityLeftPacket(en.Id, en.GetEntityType(), en.MapId));
        }

        //EventLeavePacket
        public static void SendEntityLeaveTo(Player player, Event evt)
        {
            player.SendPacket(new EntityLeftPacket(evt.Id, EntityTypes.Event, evt.MapId));
        }

        //ChatMsgPacket
        public static void SendChatMsg(Player player, string message, string target = "")
        {
            SendChatMsg(player, message, CustomColors.Chat.PlayerMsg, target);
        }

        //ChatMsgPacket
        public static void SendChatMsg(Player player, string message, Color clr, string target = "")
        {
            if (player == null)
            {
                return;
            }

            player.SendPacket(new ChatMsgPacket(message, clr, target));
        }
        public class Guilddata
        {
            public string Name { get; set; }
            public Guid Id { get; set; }
            public Guid Rank { get; set; }
            public int Level { get; set; }
            public string Class { get; set; }
            public string Map { get; set; }
            public bool Online { get; set; }
        }
        //SendGuildData
        public static void SendGuildData(Player player)
        {
            if (player == null)
            {
                return;
            }
            if (player.Guild != null) {

                string MembersJsonNames = "";

                var jsonData = player.Guild.MembersJson;
                var memberList = new List<Guilddata>();

                var jObj = JsonConvert.DeserializeObject<Dictionary<Guid, Guid>>(player.Guild.MembersJson);

                foreach (var item in jObj)
                {
                    Guid ClassId = Guid.Empty;
                    if (item.Key == player.Id)
                    {
                        memberList.Add(new Guilddata()
                        {
                            Name = player.Name,
                            Id = player.Id,
                            Rank = item.Value,
                            Level = player.Level,
                            Class = ClassBase.GetName(player.ClassId),
                            Map = player.Map.Name,
                            Online = true
                        });

                    } else
                    {
                        memberList.Add(new Guilddata()
                        {
                            Name = DbInterface.GetPlayer(item.Key).Name,
                            Id = item.Key,
                            Rank = item.Value,
                            Level = DbInterface.GetPlayer(item.Key).Level,
                            Class = ClassBase.GetName(DbInterface.GetPlayer(item.Key).ClassId),
                            Map = DbInterface.GetPlayer(item.Key).Map.Name,
                            Online = DbInterface.GetPlayer(item.Key).InGame
                        });
                    }

                    jsonData = JsonConvert.SerializeObject(memberList);
                }
                //if (player.InGuild) { // save some bandwith by only sending updates if the guildwindow is open, still todo
                player.SendPacket(new GuildDataPacket(player.Guild.Id, player.Guild.Name, player.Guild.Tag, player.Guild.FoundingDate, player.Guild.LeaderRank, player.Guild.MembersJson, jsonData, player.Guild.RanksJson,player.Guild.GuildLevel, player.Guild.GuildExperience));
                //}
            }
            else if (player.guildInvite != null)
            {
                player.SendPacket(new GuildInvitePacket(player.guildInvite.Id, player.guildInvite.Name, player.guildInvite.Tag, player.guildInvite.Members.Count(),player.guildInvite.GuildLevel));
            }

            else
            {
                return;
            }
        }

        //GameDataPacket
        public static void SendGameData(Client client)
        {
            if (!client.IsEditor)
            {
                var sw = new Stopwatch();
                sw.Start();
                client.SendPacket(CachedGameDataPacket);
                SendGameObject(client, ClassBase.Get(client.Entity.ClassId));
                Log.Debug("Took " + sw.ElapsedMilliseconds + "ms to send game data to client!");

                return;
            }

            var gameObjects = new List<GameObjectPacket>();

            //Send massive amounts of game data
            foreach (var val in Enum.GetValues(typeof(GameObjectType)))
            {
                if ((GameObjectType) val == GameObjectType.Map)
                {
                    continue;
                }

                if (((GameObjectType) val == GameObjectType.Shop ||
                     (GameObjectType) val == GameObjectType.Event ||
                     (GameObjectType) val == GameObjectType.PlayerVariable ||
                     (GameObjectType) val == GameObjectType.ServerVariable) &&
                    !client.IsEditor)
                {
                    continue;
                }

                SendGameObjects(client, (GameObjectType) val, gameObjects);
            }

            //Let the client/editor know they have everything now
            client.SendPacket(new GameDataPacket(gameObjects.ToArray(), CustomColors.Json()));
        }

        //GameDataPacket
        public static void CacheGameDataPacket()
        {
            var gameObjects = new List<GameObjectPacket>();

            //Send massive amounts of game data
            foreach (var val in Enum.GetValues(typeof(GameObjectType)))
            {
                if ((GameObjectType) val == GameObjectType.Map)
                {
                    continue;
                }

                if ((GameObjectType) val == GameObjectType.Shop ||
                    (GameObjectType) val == GameObjectType.Event ||
                    (GameObjectType) val == GameObjectType.PlayerVariable ||
                    (GameObjectType) val == GameObjectType.ServerVariable)
                {
                    continue;
                }

                SendGameObjects(null, (GameObjectType) val, gameObjects);
            }

            CachedGameDataPacket = new GameDataPacket(gameObjects.ToArray(), CustomColors.Json());
        }

        //ChatMsgPacket
        public static void SendGlobalMsg(string message, string target = "")
        {
            SendGlobalMsg(message, CustomColors.Chat.AnnouncementChat, target);
        }

        //ChatMsgPacket
        public static void SendGlobalMsg(string message, Color clr, string target = "")
        {
            SendDataToAllPlayers(new ChatMsgPacket(message, clr, target));
        }

        //ChatMsgPacket
        public static bool SendProximityMsg(string message, Guid mapId, string target = "")
        {
            return SendProximityMsg(message, mapId, CustomColors.Chat.ProximityMsg);
        }

        //ChatMsgPacket
        public static bool SendProximityMsg(string message, Guid mapId, Color clr, string target = "")
        {
            return SendDataToProximity(mapId, new ChatMsgPacket(message, clr, target));
        }

        //ChatMsgPacket
        public static void SendAdminMsg(string message, Color clr, string target = "")
        {
            foreach (var player in Globals.OnlineList)
            {
                if (player != null)
                {
                    if (player.Power != UserRights.None)
                    {
                        SendChatMsg(player, message, clr, target);
                    }
                }
            }
        }

        //ChatMsgPacket
        public static void SendPartyMsg(Player player, string message, Color clr, string target = "")
        {
            foreach (var p in player.Party)
            {
                if (p != null)
                {
                    SendChatMsg(p, message, clr, target);
                }
            }
        }

        /// <summary>
        /// Send a chat message to this guild.
        /// </summary>
        /// <param name="guild">TThe guild to send the message to.</param>
        /// <param name="message">The message to send.</param>
        /// <param name="clr">The colour of the message to send.</param>
        /// <param name="target">???</param>
        public static void SendGuildMsg(Guild guild, string message, Color clr, string target = "")
        {
            if (guild == null)
            {
                return;
            }

            // Find every online player in the guild and send them this message.
            foreach (var playerId in guild.Members.Keys)
            {
                var player = Player.FindOnline(playerId);
                SendChatMsg(player, message, target);
            }
        }

        //ProjectileDeadPacket
        public static void SendRemoveProjectileSpawn(Guid mapId, Guid baseEntityId, int spawnIndex)
        {
            SendDataToProximity(mapId, new ProjectileDeadPacket(baseEntityId, spawnIndex));
        }

        //EntityMovePacket
        public static void SendEntityMove(Entity en, bool correction = false)
        {
            SendDataToProximity(
                en.MapId,
                new EntityMovePacket(
                    en.Id, en.GetEntityType(), en.MapId, (byte) en.X, (byte) en.Y, (byte) en.Dir, correction
                )
            );
        }

        //EntityMovePacket
        public static void SendEntityMoveTo(Player player, Entity en, bool correction = false)
        {
            player.SendPacket(
                new EntityMovePacket(
                    en.Id, en.GetEntityType(), en.MapId, (byte) en.X, (byte) en.Y, (byte) en.Dir, correction
                )
            );
        }

        //EntityVitalsPacket
        public static EntityVitalsPacket GenerateEntityVitalsPacket(Entity en)
        {
            var statuses = en.Statuses.Values.ToArray();

            return new EntityVitalsPacket(
                en.Id, en.GetEntityType(), en.MapId, en.GetVitals(), en.GetMaxVitals(), en.StatusPackets(),
                en.CombatTimer - Globals.Timing.TimeMs
            );
        }

        //EntityVitalsPacket
        public static void SendEntityVitals(Entity en)
        {
            if (en == null)
            {
                return;
            }

            //If player and in party send vitals to party just in case party members are not in the proximity
            if (en.GetType() == typeof(Player))
            {
                for (var i = 0; i < ((Player) en).Party.Count; i++)
                {
                    SendPartyUpdateTo(((Player) en).Party[i], (Player) en);
                }
            }

            SendDataToProximity(en.MapId, GenerateEntityVitalsPacket(en));
        }

        //EntityStatsPacket
        public static void SendEntityStats(Entity en)
        {
            if (en == null)
            {
                return;
            }

            SendDataToProximity(en.MapId, GenerateEntityStatsPacket(en));
        }

        //EntityVitalsPacket
        public static void SendEntityVitalsTo(Client client, Entity en)
        {
            if (en == null)
            {
                return;
            }

            client.SendPacket(GenerateEntityVitalsPacket(en));
        }

        //EntityStatsPacket
        public static EntityStatsPacket GenerateEntityStatsPacket(Entity en)
        {
            var stats = new int[(int) Stats.StatCount];
            for (var i = 0; i < (int) Stats.StatCount; i++)
            {
                stats[i] = en.Stat[i].Value();
            }

            return new EntityStatsPacket(en.Id, en.GetEntityType(), en.MapId, stats);
        }

        //EntityStatsPacket
        public static void SendEntityStatsTo(Client client, Entity en)
        {
            client.SendPacket(GenerateEntityStatsPacket(en));
        }

        //EntityDirectionPacket
        public static void SendEntityDir(Entity en)
        {
            SendDataToProximity(
                en.MapId, new EntityDirectionPacket(en.Id, en.GetEntityType(), en.MapId, (byte) en.Dir)
            );
        }

        //EntityAttackPacket
        public static void SendEntityAttack(Entity en, int attackTime)
        {
            SendDataToProximity(en.MapId, new EntityAttackPacket(en.Id, en.GetEntityType(), en.MapId, attackTime));
        }

        //EntityDiePacket
        public static void SendEntityDie(Entity en)
        {
            SendDataToProximity(en.MapId, new EntityDiePacket(en.Id, en.GetEntityType(), en.MapId));
        }

        //EntityDirectionPacket
        public static void SendEntityDirTo(Player player, Entity en)
        {
            player.SendPacket(new EntityDirectionPacket(en.Id, en.GetEntityType(), en.MapId, (byte) en.Dir));
        }

        //EventDialogPacket
        public static void SendEventDialog(Player player, string prompt, string face, Guid eventId, bool isdialog, bool isfishing)
        {
            player.SendPacket(new EventDialogPacket(eventId, prompt, face, 0, null, isdialog, isfishing));
        }

        //EventDialogPacket
        public static void SendEventDialog(
            Player player,
            string prompt,
            string opt1,
            string opt2,
            string opt3,
            string opt4,
            string face,
            Guid eventId,
            bool isdialog,
            bool isfishing
        )
        {
            player.SendPacket(new EventDialogPacket(eventId, prompt, face, 1, new string[4] {opt1, opt2, opt3, opt4}, isdialog, isfishing));
        }

        public static void SendInputVariableDialog(
            Player player,
            string title,
            string prompt,
            VariableDataTypes type,
            Guid eventId
        )
        {
            player.SendPacket(new InputVariablePacket(eventId, title, prompt, type));
        }
        
        //ClassChangePacket
        public static void SendClassChangeDialog(
            Player player,
            string opt1,
            string opt2,
            string opt3,
            string opt4,
            Guid eventId
        )
        {
            player.SendPacket(new ClassChangePacket(eventId, 8, new string[4] { opt1, opt2, opt3, opt4 }));
        }

        //ItemChoicePacket
        public static void SendItemChoiceWindow(
            Player player,
            string opt1,
            string opt2,
            string opt3,
            string opt4,
            Guid eventId
        )
        {
            player.SendPacket(new ItemChoicePacket(eventId, 8, new string[4] { opt1, opt2, opt3, opt4 }));
        }

        //MapListPacket
        public static void SendMapList(Client client)
        {
            client.SendPacket(new MapListPacket(MapList.List.JsonData));
        }

        //MapListPacket
        public static void SendMapListToAll()
        {
            SendDataToAll(new MapListPacket(MapList.List.JsonData));
        }

        //ErrorPacket
        public static void SendError(Client client, string error, string header = "")
        {
            client.SendPacket(new ErrorMessagePacket(header, error));
        }

        //MapItemsPacket
        public static MapItemsPacket GenerateMapItemsPacket(Guid mapId)
        {
            var map = MapInstance.Get(mapId);
            var items = new string[map.MapItems.Count];
            for (var i = 0; i < map.MapItems.Count; i++)
            {
                if (map.MapItems[i] != null)
                {
                    items[i] = map.MapItems[i].Data();
                }
            }

            return new MapItemsPacket(mapId, items);
        }

        //MapItemsPacket
        public static void SendMapItems(Player player, Guid mapId)
        {
            player.SendPacket(GenerateMapItemsPacket(mapId));
        }

        //MapItemsPacket
        public static void SendMapItemsToProximity(Guid mapId)
        {
            var map = MapInstance.Get(mapId);
            var items = new string[map.MapItems.Count];
            for (var i = 0; i < map.MapItems.Count; i++)
            {
                if (map.MapItems[i] != null)
                {
                    items[i] = map.MapItems[i].Data();
                }
            }

            SendDataToProximity(mapId, new MapItemsPacket(mapId, items));
        }

        //MapItemUpdatePacket
        public static void SendMapItemUpdate(Guid mapId, int index)
        {
            var map = MapInstance.Get(mapId);
            string itemData = null;
            if (map != null && map.MapItems[index].ItemId != Guid.Empty)
            {
                itemData = map.MapItems[index].Data();
            }

            SendDataToProximity(mapId, new MapItemUpdatePacket(mapId, index, itemData));
        }

        //InventoryPacket
        public static void SendInventory(Player player)
        {
            if (player == null)
            {
                return;
            }

            var invItems = new InventoryUpdatePacket[Options.MaxInvItems];
            for (var i = 0; i < Options.MaxInvItems; i++)
            {
                invItems[i] = new InventoryUpdatePacket(
                    i, player.Items[i].ItemId, player.Items[i].Quantity, player.Items[i].BagId,
                    player.Items[i].StatBuffs
                );
            }

            player.SendPacket(new InventoryPacket(invItems));
        }

        //InventoryUpdatePacket
        public static void SendInventoryItemUpdate(Player player, int slot)
        {
            if (player == null)
            {
                return;
            }

            player.SendPacket(
                new InventoryUpdatePacket(
                    slot, player.Items[slot].ItemId, player.Items[slot].Quantity, player.Items[slot].BagId,
                    player.Items[slot].StatBuffs
                )
            );
        }


        //TradeSkillsPacket
        public static void SendTradeSkills(Player player)
        {
            if (player == null)
            {
                return;
            }

            var tradeskill = new TradeSkillUpdatePacket[player.TradeSkills.Count];
            for (var i = 0; i < player.TradeSkills.Count; i++)
            {
                tradeskill[i] = new TradeSkillUpdatePacket(
                    i, player.TradeSkills[i].TradeSkillId, player.TradeSkills[i].Unlocked, player.TradeSkills[i].CurrentLevel,
                    player.TradeSkills[i].CurrentXp
                );
            }

            player.SendPacket(new TradeSkillsPacket(tradeskill));
        }


        //InventoryUpdatePacket
        public static void SendTradeSkillUpdate(Player player, int i)
        {
            if (player == null)
            {
                return;
            }

            player.SendPacket(
                new TradeSkillUpdatePacket(
                    i, player.TradeSkills[i].TradeSkillId, player.TradeSkills[i].Unlocked, player.TradeSkills[i].CurrentLevel,
                    player.TradeSkills[i].CurrentXp
                )
            );
        }


        //SpellsPacket
        public static void SendPlayerSpells(Player player)
        {
            if (player == null)
            {
                return;
            }

            var spells = new SpellUpdatePacket[Options.MaxPlayerSkills];
            for (var i = 0; i < Options.MaxPlayerSkills; i++)
            {
                spells[i] = new SpellUpdatePacket(i, player.Spells[i].SpellId);
            }

            player.SendPacket(new SpellsPacket(spells));
        }

        //SpellUpdatePacket
        public static void SendPlayerSpellUpdate(Player player, int slot)
        {
            if (player == null)
            {
                return;
            }

            player.SendPacket(new SpellUpdatePacket(slot, player.Spells[slot].SpellId));
        }

        //CustomSpriteLayerPacket
        public static CustomSpriteLayersPacket GenerateCustomSpriteLayersPacket(Player en)
        {
            return new CustomSpriteLayersPacket(en.Id, en.CustomSpriteLayers);
        }

        public static void SendCustomSpriteLayersTo(Player forPlayer, Player en)
        {
            forPlayer.SendPacket(GenerateCustomSpriteLayersPacket(en));
        }

        public static void SendCustomSpriteLayersToProximity(Player en)
        {
            SendDataToProximity(en.MapId, GenerateCustomSpriteLayersPacket(en));
        }

        //EquipmentPacket
        public static EquipmentPacket GenerateEquipmentPacket(Player forPlayer, Player en)
        {
            if (forPlayer != null && forPlayer == en)
            {
                return new EquipmentPacket(en.Id, en.Equipment, null);
            }
            else
            {
                var equipment = new Guid[Options.EquipmentSlots.Count];
                for (var i = 0; i < Options.EquipmentSlots.Count; i++)
                {
                    if (en.Equipment[i] == -1 || en.Items[en.Equipment[i]].ItemId == Guid.Empty)
                    {
                        equipment[i] = Guid.Empty;
                    }
                    else
                    {
                        equipment[i] = en.Items[en.Equipment[i]].ItemId;
                    }
                }

                return new EquipmentPacket(en.Id, null, equipment);
            }
        }

        //EquipmentPacket
        public static void SendPlayerEquipmentTo(Player forPlayer, Player en)
        {
            forPlayer.SendPacket(GenerateEquipmentPacket(forPlayer, en));
        }

        //EquipmentPacket
        public static void SendPlayerEquipmentToProximity(Player en)
        {
            SendDataToProximity(en.MapId, GenerateEquipmentPacket(null, en));
            SendPlayerEquipmentTo(en, en);
        }

        //StatPointsPacket
        public static void SendPointsTo(Player player)
        {
            player.SendPacket(new StatPointsPacket(player.StatPoints));
        }

        //HotbarPacket
        public static void SendHotbarSlots(Player player)
        {
            var hotbarData = new string[Options.MaxHotbar];
            for (var i = 0; i < Options.MaxHotbar; i++)
            {
                hotbarData[i] = player.Hotbar[i].Data();
            }

            player.SendPacket(new HotbarPacket(hotbarData));
        }

        //CreateCharacterPacket
        public static void SendCreateCharacter(Client client)
        {
            client.SendPacket(new CharacterCreationPacket());
        }

        //SendHasAccount
        public static void SendHasAccount(Client client, bool hasaccount)
        {
            client.SendPacket(new HasAccountPacket(hasaccount));
        }

        //CharactersPacket
        public static void SendPlayerCharacters(Client client)
        {
            var characters = new List<CharacterPacket>();
            if (client.User == null)
            {
                return;
            }

            if (client.Characters.Count > 0)
            {
                foreach (var character in client.Characters.OrderByDescending(p => p.LastOnline))
                {
                    var equipmentArray = character.Equipment;
                    var equipment = new string[Options.EquipmentSlots.Count + 1];

                    //Draw the equipment/paperdolls
                    for (var z = 0; z < Options.PaperdollOrder[1].Count; z++)
                    {
                        if (Options.EquipmentSlots.IndexOf(Options.PaperdollOrder[1][z]) > -1)
                        {
                            if (equipmentArray[Options.EquipmentSlots.IndexOf(Options.PaperdollOrder[1][z])] > -1 &&
                                equipmentArray[Options.EquipmentSlots.IndexOf(Options.PaperdollOrder[1][z])] <
                                Options.MaxInvItems)
                            {
                                var itemId = character
                                    .Items[equipmentArray[Options.EquipmentSlots.IndexOf(Options.PaperdollOrder[1][z])]]
                                    .ItemId;

                                if (ItemBase.Get(itemId) != null)
                                {
                                    var itemdata = ItemBase.Get(itemId);
                                    if (character.Gender == 0)
                                    {
                                        equipment[z] = itemdata.MalePaperdoll;
                                    }
                                    else
                                    {
                                        equipment[z] = itemdata.FemalePaperdoll;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Options.PaperdollOrder[1][z] == "Player")
                            {
                                equipment[z] = "Player";
                            }
                        }
                    }

                    characters.Add(
                        new CharacterPacket(
                            character.Id, character.Name, character.Sprite, character.Face, character.Level,
                        ClassBase.GetName(character.ClassId), equipment, character.CustomSpriteLayers
                        )
                    );
                }
            }

            client.SendPacket(
                new CharactersPacket(characters.ToArray(), client.Characters.Count < Options.MaxCharacters)
            );
        }

        //AdminPanelPacket
        public static void SendOpenAdminWindow(Client client)
        {
            client.SendPacket(new AdminPanelPacket());
        }

        //MapGridPacket
        public static void SendMapGridToAll(int gridId)
        {
            SendMapGridToAll(DbInterface.GetGrid(gridId));
        }
        public static void SendMapGridToAll(MapGrid grid)
        {
            if (grid == null) return;
            for (var i = 0; i < Globals.Clients.Count; i++)
            {
                if (Globals.Clients[i] != null)
                {
                    if (Globals.Clients[i].IsEditor)
                    {
                        if (grid.HasMap(Globals.Clients[i].EditorMap))
                        {
                            SendMapGrid(Globals.Clients[i], grid);
                        }
                    }
                    else
                    {
                        if (Globals.Clients[i].Entity != null)
                        {
                            if (grid.HasMap(Globals.Clients[i].Entity.MapId))
                            {
                                SendMapGrid(Globals.Clients[i], grid, true);
                            }
                        }
                    }
                }
            }
        }

        //MapGridPacket
        public static void SendMapGrid([NotNull] Client client, int gridId, bool clearKnownMaps = false)
        {
            var grid = DbInterface.GetGrid(gridId);
            SendMapGrid(client,grid,clearKnownMaps);
        }
        public static void SendMapGrid([NotNull] Client client, MapGrid grid, bool clearKnownMaps = false)
        {
            if (client == null || grid == null)
            {
                return;
            }

            if (clearKnownMaps)
            {
                client.SentMaps.Clear();
            }

            if (client.IsEditor)
            {
                client.SendPacket(new MapGridPacket(null, grid.GetEditorData(), clearKnownMaps));
            }
            else
            {
                client.SendPacket(new MapGridPacket(grid.GetClientData(), null, clearKnownMaps));
                if (clearKnownMaps)
                {
                    SendAreaPacket(client.Entity);
                }
            }
        }

        //SpellCastPacket
        public static void SendEntityCastTime(Entity en, Guid spellId)
        {
            SendDataToProximity(en.MapId, new SpellCastPacket(en.Id, spellId));
        }

        //SpellCooldownPacket
        public static void SendSpellCooldown(Player player, Guid spellId)
        {
            if (player.SpellCooldowns.ContainsKey(spellId))
            {
                var cds = new Dictionary<Guid, long>();
                cds.Add(spellId, player.SpellCooldowns[spellId] - Globals.Timing.RealTimeMs);
                player.SendPacket(new SpellCooldownPacket(cds));
            }
        }

        public static void SendSpellCooldowns(Player player)
        {
            if (player.SpellCooldowns.Count > 0)
            {
                var cds = new Dictionary<Guid, long>();
                foreach (var cd in player.SpellCooldowns)
                {
                    cds.Add(cd.Key, cd.Value - Globals.Timing.RealTimeMs);
                }

                player.SendPacket(new SpellCooldownPacket(cds));
            }
        }

        //ItemCooldownPacket
        public static void SendItemCooldown(Player player, Guid itemId)
        {
            if (player.ItemCooldowns.ContainsKey(itemId))
            {
                var cds = new Dictionary<Guid, long>();
                cds.Add(itemId, player.ItemCooldowns[itemId] - Globals.Timing.RealTimeMs);
                player.SendPacket(new ItemCooldownPacket(cds));
            }
        }

        public static void SendItemCooldowns(Player player)
        {
            if (player.ItemCooldowns.Count > 0)
            {
                var cds = new Dictionary<Guid, long>();
                foreach (var cd in player.ItemCooldowns)
                {
                    cds.Add(cd.Key, cd.Value - Globals.Timing.RealTimeMs);
                }

                player.SendPacket(new ItemCooldownPacket(cds));
            }
        }

        //ExperiencePacket
        public static void SendExperience(Player player)
        {
            player.SendPacket(new ExperiencePacket(player.Exp, player.ExperienceToNextLevel));
        }

        //PlayAnimationPacket
        public static void SendAnimationToProximity(
            Guid animId,
            int targetType,
            Guid entityId,
            Guid mapId,
            byte x,
            byte y,
            sbyte direction
        )
        {
            SendDataToProximity(mapId, new PlayAnimationPacket(animId, targetType, entityId, mapId, x, y, direction));
        }

        //PlayAnimationPacket
        public static void SendAnimationToPrivateProximity(
            Guid animId,
            int targetType,
            Guid entityId,
            Guid mapId,
            byte x,
            byte y,
            sbyte direction,
            Player entity
        )
        {
            SendDataToProximityPrivate(mapId, new PlayAnimationPacket(animId, targetType, entityId, mapId, x, y, direction), entity);
        }

        //HoldPlayerPacket
        public static void SendHoldPlayer(Player player, Guid eventId, Guid mapId)
        {
            player.SendPacket(new HoldPlayerPacket(eventId, mapId, false));
        }

        //HoldPlayerPacket
        public static void SendReleasePlayer(Player player, Guid eventId)
        {
            player.SendPacket(new HoldPlayerPacket(eventId, Guid.Empty, true));
        }

        //PlayMusicPacket
        public static void SendPlayMusic(Player player, string bgm)
        {
            player.SendPacket(new PlayMusicPacket(bgm));
        }

        //StopMusicPacket
        public static void SendFadeMusic(Player player)
        {
            player.SendPacket(new StopMusicPacket());
        }

        //PlaySoundPacket
        public static void SendPlaySound(Player player, string sound)
        {
            player.SendPacket(new PlaySoundPacket(sound));
        }

        //StopSoundPacket
        public static void SendStopSounds(Player player)
        {
            player.SendPacket(new StopSoundsPacket());
        }

        //ShowPicturePacket
        public static void SendShowPicture(Player player, string picture, int size, bool clickable)
        {
            player.SendPacket(new ShowPicturePacket(picture, size, clickable));
        }

        //HidePicturePacket
        public static void SendHidePicture(Player player)
        {
            player.SendPacket(new HidePicturePacket());
        }

        //ShopPacket
        public static void SendOpenShop(Player player, ShopBase shop)
        {

            if (shop != null)
            {
                reqcheck.Clear();
                for (var i = 0; i < shop?.SellingItems?.Count; ++i)
                {
                    if (shop.SellingItems[i].ItemId != null)
                    {
                        if (!Conditions.MeetsConditionLists(shop.SellingItems[i].Item.UsageRequirements, player, null))
                        {
                            reqcheck.Add(shop.SellingItems[i].ItemId);
                        }
                    }
                }
                player.SendPacket(new ShopPacket(shop.JsonData, false, reqcheck));
            }
            else
            {
                return;
            }
            
        }

        //ShopPacket
        public static void SendCloseShop(Player player)
        {
            player.SendPacket(new ShopPacket(null, true, null));
        }

        //BankPacket
        public static void SendOpenBank(Player player)
        {
            for (var i = 0; i < Options.MaxBankSlots; i++)
            {
                SendBankUpdate(player, i);
            }

            player.SendPacket(new BankPacket(false));
        }

        //BankPacket
        public static void SendCloseBank(Player player)
        {
            player.SendPacket(new BankPacket(true));
        }

        //SendCloseTradeSkillInfo
        public static void SendCloseTradeSkillInfo(Player player)
        {
            player.SendPacket(new TradeSkillInfoPacket(true));
        }

        //GuildBankPacket
        public static void SendOpenGuildBank(Player player)
        {
            var MaxSlots = Math.Min(player.Guild.GuildLevel * Options.GuildOptions.GuildBankSlotsIncrease, Options.MaxBankSlots);
            for (var i = 0; i < MaxSlots; i++)
            {
                SendGuildBankUpdate(player, i);
            }

            player.SendPacket(new GuildBankPacket(false));
        }

        //GuildBankPacket
        public static void SendCloseGuildBank(Player player)
        {
            player.SendPacket(new GuildBankPacket(true));
        }

        //CraftingTablePacket
        public static void SendOpenCraftingTable(Player player, CraftingTableBase table)
        {
            if (table != null)
            {
                reqcheck.Clear();
                for (var i = 0; i < table?.Crafts?.Count; ++i) {                    
                    if (!Conditions.MeetsConditionLists(CraftBase.Get(table.Crafts[i]).CraftRequirements, player, null))
                    {
                        reqcheck.Add(table.Crafts[i]);
                    }
                }
                player.SendPacket(new CraftingTablePacket(table.JsonData, false, reqcheck));
            }
        }

        //CraftingTablePacket
        public static void SendCloseCraftingTable(Player player)
        {
            player.SendPacket(new CraftingTablePacket(null, true, null));
        }

        //CraftStartPacket
        public static void SendStartCraft(Player player, Guid craft)
        {
            if (craft != null)
            {
                player.SendPacket(new CraftStartPacket(craft, true));
            }
        }

        //CraftStartPacket
        public static void SendStartCraft(Player player)
        {
            player.SendPacket(new CraftStartPacket(Guid.Empty, false));
        }

        //BankUpdatePacket
        public static void SendBankUpdate(Player player, int slot)
        {
            if (player.Bank[slot] != null && player.Bank[slot].ItemId != Guid.Empty && player.Bank[slot].Quantity > 0)
            {
                player.SendPacket(
                    new BankUpdatePacket(
                        slot, player.Bank[slot].ItemId, player.Bank[slot].Quantity, player.Bank[slot].BagId,
                        player.Bank[slot].StatBuffs
                    )
                );
            }
            else
            {
                player.SendPacket(new BankUpdatePacket(slot, Guid.Empty, 0, null, null));
            }
        }

        public static void SendOpenMailBox(Player player)
        {
            MailBox.GetMails(DbInterface.GetPlayerContext(), player);
            // TODO : Mail List
            List<MailBoxUpdatePacket> mails = new List<MailBoxUpdatePacket>();

            foreach (MailBox mail in player.MailBoxs)
            {
                //DbInterface.GetPlayerContext().Player_MailBox.Add(mail);
                MailBoxUpdatePacket m = new MailBoxUpdatePacket(mail.Id, mail.Title, mail.Message, mail.Sender.Name, mail.ItemId, mail.Quantity);
                mails.Add(m);
            }
            player.SendPacket(new MailBoxsUpdatePacket(mails.ToArray<MailBoxUpdatePacket>()));
            player.SendPacket(new MailBoxPacket(true, false));
        }
        public static void SendCloseMailBox(Player player)
        {
            player.SendPacket(new MailBoxPacket(false, false));
        }

        public static void SendOpenSendMail(Player player)
        {
            SendInventory(player);
            player.SendPacket(new MailBoxPacket(true, true));
        }

        public static void SendItemHDV(Player player, Guid hdvID, HDV item, bool update = false)
        {
            if (!player.InHDV || player.HdvID != hdvID)
            {
                return;
            }
            Player seller = DbInterface.GetPlayer(item.SellerId);
            if (seller == null)
            {
                return;
            }
            player.SendPacket(new HDVItemPacket(
                item.Id,
                seller.Id.ToString(),
                item.ItemId,
                item.Quantity,
                item.StatBuffs,
                item.Price,
                item.Expires,
                update
            ));
        }

        public static void SendAddHDVItem(Player player, Guid hdvID, HDV item)
        {
            SendItemHDV(player, hdvID, item, true);
        }

        public static void SendRemoveHDVItem(Player player, Guid removeItem)
        {
            player.SendPacket(new RemoveHDVItemPacket(removeItem));
        }

        //openguildcreate
        public static void SendOpenGuildCreate(Player player, Guid itemId)
        {
            player.SendPacket(new SendOpenGuildCreatePacket(itemId, false));
        }

        //close guildcreate
        public static void SendCloseGuildCreate(Player player)
        {
            player.SendPacket(new SendOpenGuildCreatePacket(Guid.Empty, true));
        }

        public static void SendOpenHDV(Player player, Guid hdvID)
        {
            player.HdvID = hdvID;
            player.InHDV = true;
            SendInventory(player);
            HDV[] HDVItems = HDV.List(hdvID).ToArray<HDV>();
            List<HDVItemPacket> hdvItemPackets = new List<HDVItemPacket>();
            List<HDV> toRemove = new List<HDV>();
            for (int i = 0; i < HDVItems.Length; i++)
            {
                //fix the seller name/id
                //Player seller = DbInterface.GetPlayer(HDVItems[i].SellerId);
                /*if (seller == null)
                {
                    toRemove.Add(HDVItems[i]);
                    continue;
                }*/
                if (HDVItems[i].Expires <= DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
                {
                    toRemove.Add(HDVItems[i]);
                    var seller = DbInterface.GetPlayer(HDVItems[i].SellerId);
                    seller.MailBoxs.Add(new MailBox(seller, player, "AH", "AH Item expired: ", HDVItems[i].ItemId, HDVItems[i].Quantity, HDVItems[i].StatBuffs));
                    continue;
                }

                hdvItemPackets.Add(new HDVItemPacket(
                    HDVItems[i].Id,
                    HDVItems[i].SellerId.ToString(),
                    //seller.Name,
                    HDVItems[i].ItemId,
                    HDVItems[i].Quantity,
                    HDVItems[i].StatBuffs,
                    HDVItems[i].Price,
                    HDVItems[i].Expires
                ));
                //SendChatMsg(player, HDVItems[i].Id.ToString(), CustomColors.Alerts.Accepted);
                //player.SendPacket(new HDVPacket(hdvID, hdvItemPackets.ToArray<HDVItemPacket>()));
            }
            if (toRemove.Count > 0)
            {
                DbInterface.GetPlayerContext().HDV.RemoveRange(toRemove);
                DbInterface.SavePlayerDatabaseAsync();
            }
            player.SendPacket(new HDVPacket(hdvID, hdvItemPackets.ToArray<HDVItemPacket>()));
        }

        //GuildBankUpdatePacket
        public static void SendGuildBankUpdate(Player player, int slot)
        {
            if (player.Guild.GuildBank[slot] != null && player.Guild.GuildBank[slot].ItemId != Guid.Empty && player.Guild.GuildBank[slot].Quantity > 0)
            {
                player.SendPacket(
                    new GuildBankUpdatePacket(
                        slot, player.Guild.GuildBank[slot].ItemId, player.Guild.GuildBank[slot].Quantity, player.Guild.GuildBank[slot].BagId,
                        player.Guild.GuildBank[slot].StatBuffs
                    )
                );
            }
            else
            {
                player.SendPacket(new GuildBankUpdatePacket(slot, Guid.Empty, 0, null, null));
            }
        }

        //GameObjectPacket
        public static void SendGameObjects(Client client, GameObjectType type, List<GameObjectPacket> packetList = null)
        {
            switch (type)
            {
                case GameObjectType.Animation:
                    foreach (var obj in AnimationBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Class:
                    foreach (var obj in ClassBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Item:
                    foreach (var obj in ItemBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Npc:
                    foreach (var obj in NpcBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Pet:
                    foreach (var obj in PetBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Projectile:
                    foreach (var obj in ProjectileBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Quest:
                    foreach (var obj in QuestBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Resource:
                    foreach (var obj in ResourceBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Shop:
                    foreach (var obj in ShopBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Spell:
                    foreach (var obj in SpellBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.CraftTables:
                    foreach (var obj in CraftingTableBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Crafts:
                    foreach (var obj in CraftBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Map:
                    throw new Exception("Maps are not sent as batches, use the proper send map functions");
                case GameObjectType.Event:
                    foreach (var obj in EventBase.Lookup)
                    {
                        if (((EventBase) obj.Value).CommonEvent)
                        {
                            SendGameObject(client, obj.Value, false, false, packetList);
                        }
                    }

                    break;
                case GameObjectType.PlayerVariable:
                    foreach (var obj in PlayerVariableBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.ServerVariable:
                    foreach (var obj in ServerVariableBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Tileset:
                    foreach (var obj in TilesetBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }

                    break;
                case GameObjectType.Time:
                    break;
                case GameObjectType.HDVs:
                    foreach (var obj in HDVBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }
                    break;
                case GameObjectType.DropPool:
                    foreach (var obj in DropPoolBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }
                    break;
                case GameObjectType.Tradeskill:
                    foreach (var obj in TradeSkillBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }
                    break;
                case GameObjectType.Behavior:
                    foreach (var obj in BehaviorBase.Lookup)
                    {
                        SendGameObject(client, obj.Value, false, false, packetList);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        //GameObjectPacket
        public static void SendGameObject(
            Client client,
            IDatabaseObject obj,
            bool deleted = false,
            bool another = false,
            List<GameObjectPacket> packetList = null
        )
        {
            if (client == null && packetList == null || obj == null)
            {
                return;
            }

            if (client != null && client.IsEditor)
            {
                //If editor send quest events and map events
                if (obj.Type == GameObjectType.Quest)
                {
                    SendQuestEventsTo(client, (QuestBase) obj);
                }
            }

            if (packetList == null)
            {
                client.SendPacket(
                    new GameObjectPacket(obj.Id, obj.Type, deleted ? null : obj.JsonData, deleted, another)
                );
            }
            else
            {
                packetList.Add(new GameObjectPacket(obj.Id, obj.Type, deleted ? null : obj.JsonData, deleted, another));
            }
        }

        //GameObjectPacket
        public static void SendQuestEventsTo(Client client, QuestBase qst)
        {
            SendEventIfExists(client, qst.StartEvent);
            SendEventIfExists(client, qst.EndEvent);
            foreach (var tsk in qst.Tasks)
            {
                SendEventIfExists(client, tsk.CompletionEvent);
            }
        }

        //GameObjectPacket
        public static void SendEventIfExists(Client client, EventBase evt)
        {
            if (evt != null && evt.Id != Guid.Empty)
            {
                SendGameObject(client, evt, false, false);
            }
        }

        //GameObjectPacket
        public static void SendGameObjectToAll(IDatabaseObject obj, bool deleted = false, bool another = false)
        {
            foreach (var client in Globals.Clients)
            {
                SendGameObject(client, obj, deleted, another);
            }
        }

        //OpenEditorPacket
        public static void SendOpenEditor(Client client, GameObjectType type)
        {
            client.SendPacket(new OpenEditorPacket(type));
        }

        //EntityDashPacket
        public static void SendEntityDash(Entity en, Guid endMapId, byte endX, byte endY, int dashTime, sbyte direction)
        {
            SendDataToProximity(en.MapId, new EntityDashPacket(en.Id, endMapId, endX, endY, dashTime, direction));
        }

        //ActionMsgPacket
        public static void SendActionMsg(Entity en, string message, Color color)
        {
            SendDataToProximity(en.MapId, new ActionMsgPacket(en.MapId, en.X, en.Y, message, color));
        }

        public static void SendActionMsgPrivate(Player en, string message, Color color)
        {
            SendDataToProximityPrivate(en.MapId, new ActionMsgPacket(en.MapId, en.X, en.Y, message, color), en);
        }

        public static void SendCrit(Guid playerId)
        {
            Player player = Player.FindOnline(playerId);
            player.SendPacket(new CritPacket());
        }

        //ActionMsgPacket
        //public static void SendActionMsgSelf(Event ev, string message, Color color, bool self)
        //{
        //    SendDataToProximity(ev.MapId, new ActionMsgPacket(ev.MapId, ev.X, ev.Y, message, color));
        //}

        //ActionMsgPacketSelf
        public static void SendActionMsgSelf(
            Event ev,
            string message,
            Color color,
            byte x,
            byte y,
            Guid entityId,
            Guid mapId
        )
        {
            SendDataToProximity(ev.MapId, new ActionMsgPacket(ev.MapId, x, y, message, color));
        }

        //EnterMapPacket
        public static void SendEnterMap(Client client, Guid mapId)
        {
            client.SendPacket(new EnterMapPacket(mapId));
        }

        //TimeDataPacket
        public static void SendTimeBaseTo(Client client)
        {
            client.SendPacket(new TimeDataPacket(TimeBase.GetTimeBase().GetInstanceJson()));
        }

        //TimeDataPacket
        public static void SendTimeBaseToAllEditors()
        {
            SendDataToEditors(new TimeDataPacket(TimeBase.GetTimeBase().GetInstanceJson()));
        }

        //TimePacket
        public static void SendTimeToAll()
        {
            SendDataToAllPlayers(
                new TimePacket(
                    Time.GetTime(), TimeBase.GetTimeBase().SyncTime ? 1 : TimeBase.GetTimeBase().Rate,
                    Time.GetTimeColor()
                )
            );
        }

        //TimePacket
        public static void SendTimeTo(Client client)
        {
            client?.SendPacket(
                new TimePacket(
                    Time.GetTime(), TimeBase.GetTimeBase().SyncTime ? 1 : TimeBase.GetTimeBase().Rate,
                    Time.GetTimeColor()
                )
            );
        }

        //PartyPacket
        public static void SendParty(Player player)
        {
            var memberPackets = new PartyMemberPacket[player.Party.Count];
            for (var i = 0; i < player.Party.Count; i++)
            {
                var mem = player.Party[i];
                memberPackets[i] = new PartyMemberPacket(
                    mem.Id, mem.Name, mem.GetVitals(), mem.GetMaxVitals(), mem.Level
                );
            }

            player.SendPacket(new PartyPacket(memberPackets));
        }

        //PartyUpdatePacket
        public static void SendPartyUpdateTo(Player player, Player member)
        {
            var partyIndex = -1;
            for (var i = 0; i < player.Party.Count; i++)
            {
                if (player.Party[i] == member)
                {
                    partyIndex = i;
                }
            }

            if (partyIndex > -1)
            {
                player.SendPacket(
                    new PartyUpdatePacket(
                        partyIndex,
                        new PartyMemberPacket(
                            member.Id, member.Name, member.GetVitals(), member.GetMaxVitals(), member.Level
                        )
                    )
                );
            }
        }

        //PartyInvitePacket
        public static void SendPartyInvite(Player player, Player leader)
        {
            player.SendPacket(new PartyInvitePacket(leader.Name, leader.Id));
        }

        //ChatBubblePacket
        public static void SendChatBubble(Guid entityId, EntityTypes type, string text, Guid mapId)
        {
            SendDataToProximity(mapId, new ChatBubblePacket(entityId, type, mapId, text));
        }

        //QuestOfferPacket
        public static void SendQuestOffer(Player player, Guid questId)
        {
            player.SendPacket(new QuestOfferPacket(questId));
        }

        //QuestProgressPacket
        public static void SendQuestsProgress(Player player)
        {
            var dict = new Dictionary<Guid, string>();
            foreach (var quest in player.Quests)
            {
                dict.Add(quest.QuestId, quest.Data());
            }

            player.SendPacket(new QuestProgressPacket(dict));
        }

        //QuestProgressPacket
        public static void SendQuestProgress(Player player, Guid questId)
        {
            var dict = new Dictionary<Guid, string>();
            var questProgress = player.FindQuest(questId);
            if (questProgress != null)
            {
                dict.Add(questId, questProgress.Data());
            }
            else
            {
                dict.Add(questId, null);
            }

            player.SendPacket(new QuestProgressPacket(dict));
        }

        //TradePacket
        public static void StartTrade(Player player, Player target)
        {
            player.SendPacket(new TradePacket(target.Name));
        }

        //TradeUpdatePacket
        public static void SendTradeUpdate(Player player, Player trader, int slot)
        {
            if (trader.Trading.Offer[slot] != null &&
                trader.Trading.Offer[slot].ItemId != Guid.Empty &&
                trader.Trading.Offer[slot].Quantity > 0)
            {
                player.SendPacket(
                    new TradeUpdatePacket(
                        trader.Id, slot, trader.Trading.Offer[slot].ItemId, trader.Trading.Offer[slot].Quantity,
                        trader.Trading.Offer[slot].BagId, trader.Trading.Offer[slot].StatBuffs
                    )
                );
            }
            else
            {
                player.SendPacket(new TradeUpdatePacket(trader.Id, slot, Guid.Empty, 0, null, null));
            }
        }

        //TradePacket
        public static void SendTradeClose(Player player)
        {
            player.SendPacket(new TradePacket(null));
        }

        //TradeRequestPacket
        public static void SendTradeRequest(Player player, Player partner)
        {
            player.SendPacket(new TradeRequestPacket(partner.Id, partner.Name));
        }

        //PlayerDeathPacket
        public static void SendPlayerDeath(Player en)
        {
            SendDataToProximity(en.MapId, new PlayerDeathPacket(en.Id));
        }

        //EntityZDimensionPacket
        public static void UpdateEntityZDimension(Entity en, byte z)
        {
            SendDataToProximity(en.MapId, new EntityZDimensionPacket(en.Id, z));
        }

        //BagPacket
        public static void SendOpenBag(Player player, int slots, Bag bag)
        {
            player.SendPacket(new BagPacket(slots, false));
            for (var i = 0; i < slots; i++)
            {
                SendBagUpdate(player, i, bag.Slots[i]);
            }
        }

        //BagUpdatePacket
        public static void SendBagUpdate(Player player, int slot, Item item)
        {
            if (item != null && item.ItemId != Guid.Empty && item.Quantity > 0)
            {
                player.SendPacket(new BagUpdatePacket(slot, item.ItemId, item.Quantity, item.BagId, item.StatBuffs));
            }
            else
            {
                player.SendPacket(new BagUpdatePacket(slot, Guid.Empty, 0, null, null));
            }
        }

        //BagPacket
        public static void SendCloseBag(Player player)
        {
            player.SendPacket(new BagPacket(0, true));
        }

        //MoveRoutePacket
        public static void SendMoveRouteToggle(Player player, bool routeOn)
        {
            player.SendPacket(new MoveRoutePacket(routeOn));
        }

        //FriendsPacket
        public static void SendFriends(Player player)
        {
            if (player == null)
            {
                return;
            }

            var online = new Dictionary<string, string>();
            var offline = new List<string>();
            var found = false;

            foreach (var friend in player.Friends)
            {
                if (friend.Target == null)
                {
                    continue;
                }

                found = false;
                foreach (var c in Globals.Clients)
                {
                    if (c != null && c.Entity != null)
                    {
                        if (friend.Target?.Name.ToLower() == c.Entity?.Name.ToLower())
                        {
                            online.Add(friend.Target?.Name, MapList.List.FindMap(friend.Target.MapId)?.Name ?? "");
                            found = true;

                            break;
                        }
                    }
                }

                if (found == false)
                {
                    offline.Add(friend.Target.Name);
                }
            }

            player.SendPacket(new FriendsPacket(online, offline.ToArray()));
        }

        //FriendRequestPacket
        public static void SendFriendRequest(Player player, Player partner)
        {
            player.SendPacket(new FriendRequestPacket(partner.Id, partner.Name));
        }

        //PasswordResetResultPacket
        public static void SendPasswordResetResult(Client client, bool result)
        {
            client.SendPacket(new PasswordResetResultPacket(result));
        }

        //TargetOverridePacket
        public static void SetPlayerTarget(Player player, Guid targetId)
        {
            player.SendPacket(new TargetOverridePacket(targetId));
        }

        public static void SendDataToMap(Guid mapId, CerasPacket packet, Player except = null)
        {
            if (!MapInstance.Lookup.Keys.Contains(mapId))
            {
                return;
            }

            var players = MapInstance.Get(mapId).GetPlayersOnMap();
            foreach (var player in players)
            {
                if (player != null && player != except)
                {
                    player.SendPacket(packet);
                }
            }
        }

        public static void SendDataToMapPrivate(Guid mapId, CerasPacket packet, Player except = null)
        {
            if (!MapInstance.Lookup.Keys.Contains(mapId))
            {
                return;
            }

            var players = MapInstance.Get(mapId).GetPlayersOnMap();
            foreach (var player in players)
            {
                if (player != null && player == except)
                {
                    player.SendPacket(packet);
                }
            }
        }

        public static bool SendDataToProximity(Guid mapId, CerasPacket packet, Player except = null)
        {
            if (!MapInstance.Lookup.Keys.Contains(mapId))
            {
                return false;
            }

            SendDataToMap(mapId, packet, except);
            for (var i = 0; i < MapInstance.Get(mapId).SurroundingMaps.Count; i++)
            {
                SendDataToMap(MapInstance.Get(mapId).SurroundingMaps[i], packet, except);
            }

            return true;
        }

        public static bool SendDataToProximityPrivate(Guid mapId, CerasPacket packet, Player except = null)
        {
            if (!MapInstance.Lookup.Keys.Contains(mapId))
            {
                return false;
            }

            SendDataToMapPrivate(mapId, packet, except);
            for (var i = 0; i < MapInstance.Get(mapId).SurroundingMaps.Count; i++)
            {
                SendDataToMapPrivate(MapInstance.Get(mapId).SurroundingMaps[i], packet, except);
            }

            return true;
        }

        public static void SendDataToEditors(CerasPacket packet)
        {
            lock (Globals.ClientLock)
            {
                foreach (var client in Globals.Clients)
                {
                    if (client.IsEditor)
                    {
                        client.SendPacket(packet);
                    }
                }
            }
        }

        public static void SendDataToAllPlayers(CerasPacket packet)
        {
            lock (Globals.ClientLock)
            {
                foreach (var client in Globals.Clients)
                {
                    if (client?.Entity != null)
                    {
                        client.SendPacket(packet);
                    }
                }
            }
        }

        public static void SendDataToAll(CerasPacket packet)
        {
            lock (Globals.ClientLock)
            {
                foreach (var client in Globals.Clients)
                {
                    if ((client?.IsEditor ?? false) || client?.Entity != null)
                    {
                        client.SendPacket(packet);
                    }
                }
            }
        }

    }

}
