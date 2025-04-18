﻿using System;
using System.Collections.Generic;

using Intersect.Client.Entities;
using Intersect.Client.Entities.Events;
using Intersect.Client.Framework.Database;
using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Input;
using Intersect.Client.Framework.Sys;
using Intersect.Client.Items;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.Network.Packets.Server;

using JetBrains.Annotations;

namespace Intersect.Client.General
{

    public static class Globals
    {

        //Only need 1 table, and that is the one we see at a given moment in time.
        public static CraftingTableBase ActiveCraftingTable;

        //ReqCheck
        public static List<Guid> ActiveCraftingTableReqs;

        //Shop req check
        public static List<Guid> ShopReqs;

        //Craftcheck
        public static bool canCraftrq = false;
        public static Guid canCraftitem = Guid.Empty;

        public static int AnimFrame = 0;

        //Bag
        public static Item[] Bag = null;

        //Bank
        public static Item[] Bank;

        //GuildBank
        public static Item[] GuildBank;

        //GuildCreateItem
        public static Guid GuildCreateItem;

        public static List<PvpPlayer> PvpList;

        public static bool ConnectionLost;

        // Mail
        public static List<Mail> Mails = new List<Mail>();

        //Game Systems
        public static GameContentManager ContentManager;

        public static int CurrentMap = -1;

        [NotNull] public static GameDatabase Database;

        //Entities and stuff
        //public static List<Entity> Entities = new List<Entity>();
        public static Dictionary<Guid, Entity> Entities = new Dictionary<Guid, Entity>();

        public static List<Guid> EntitiesToDispose = new List<Guid>();

        //Control Objects
        public static List<Dialog> EventDialogs = new List<Dialog>();

        //Class Change
        public static List<ClassChange> ClassChange = new List<ClassChange>();

        //Item Choice
        public static List<ItemChoice> ItemChoice = new List<ItemChoice>();

        public static Dictionary<Guid, Guid> EventHolds = new Dictionary<Guid, Guid>();

        //Game Lock
        public static object GameLock = new object();

        //Game Shop
        //Only need 1 shop, and that is the one we see at a given moment in time.
        public static ShopBase GameShop;

        //Crucial game variables
        public static GameStates GameState = GameStates.Intro; //0 for Intro, 1 to Menu, 2 for in game

        public static List<Guid> GridMaps = new List<Guid>();

        public static bool HasGameData = false;

        public static bool InBag = false;

        public static bool InBank = false;

        public static bool InGuildBank = false;

        public static bool InGuildCreate = false;

        //Crafting station
        public static bool InCraft = false;

        [NotNull] public static GameInput InputManager;

        public static bool InTrade = false;

        public static bool IntroComing = true;

        public static long IntroDelay = 2000;

        //Engine Progression
        public static int IntroIndex = 0;

        public static long IntroStartTime = -1;

        public static bool IsRunning = true;

        public static bool JoiningGame = false;

        public static bool LoggedIn = false;

        //Map/Chunk Array
        public static Guid[,] MapGrid;

        public static long MapGridHeight;

        public static long MapGridWidth;

        //Local player information
        public static Player Me;

        public static bool MoveRouteActive = false;

        public static int MyX = 0;

        public static int MyY = 0;

        public static bool NeedsMaps = true;

        public static bool HasAccount = false;

        //Event Guid and the Map its associated with
        public static Dictionary<Guid, Dictionary<Guid, EventEntityPacket>> PendingEvents =
            new Dictionary<Guid, Dictionary<Guid, EventEntityPacket>>();

        //Event Show Pictures
        public static string Picture;

        public static bool PictureClickable;

        public static int PictureSize;

        public static List<Guid> QuestOffers = new List<Guid>();

        public static Random Random = new Random();

        [NotNull] public static GameSystem System;

        //Trading (Only 2 people can trade at once)
        public static Item[,] Trade;

        //Scene management
        public static bool WaitingOnServer = false;

        public static bool InMailBox = false;

        public static bool InSendMailBox = false;

        public static Guid HdvID = Guid.Empty;
        public static HDVBase HDV { get => HDVBase.Get(HdvID); }
        public static List<HDV> HDVObjet = new List<HDV>();

        public static bool InHDV = false;

        public static bool IsSteamRunning = false;

        public static Entity GetEntity(Guid id, EntityTypes type)
        {
            if (Entities.ContainsKey(id))
            {
                if (Entities[id].GetEntityType() == type)
                {
                    EntitiesToDispose.Remove(Entities[id].Id);

                    return Entities[id];
                }

                Entities[id].Dispose();
                Entities.Remove(id);
            }

            return null;
        }


        public class PvpPlayer
        {
            public Guid playerId;

            public string Name;

            public int Level;

        }

    }

}
