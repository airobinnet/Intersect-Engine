using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

using Intersect.Client.Framework.File_Management;
using Intersect.Client.Framework.Graphics;
using Intersect.Client.General;
using Intersect.Client.Localization;
using Intersect.Client.Maps;
using Intersect.Client.Networking;
using Intersect.Configuration;
using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.GameObjects.Maps;

using DiscordRPC.Message;
using DiscordRPC;
using System.Text;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;

using System.Diagnostics;
using System.ComponentModel;

using Steamworks;

// ReSharper disable All

namespace Intersect.Client.Core
{

    public static class Main
    {

        private static long _animTimer;

        private static bool _createdMapTextures;

        private static bool _loadedTilesets;

        private static int _ExpiredTicks;

        /// <summary>
        /// The level of logging to use.
        /// </summary>
        private static DiscordRPC.Logging.LogLevel logLevel = DiscordRPC.Logging.LogLevel.Trace;

        /// <summary>
        /// The pipe to connect too.
        /// </summary>
        private static int discordPipe = -1;

        /// <summary>
        /// The current presence to send to discord.
        /// </summary>
        private static RichPresence presence = new RichPresence();

        /// <summary>
        /// The discord client
        /// </summary>
        private static DiscordRpcClient client;

        /// <summary>
        /// Is the main loop currently running?
        /// </summary>
        private static bool isRunning = true;

        /// <summary>
        /// The string builder for the command
        /// </summary>
        private static StringBuilder word = new StringBuilder();

        private static Timestamps menuTime = Timestamps.Now;

        private static Timestamps gameTime = Timestamps.Now;


        public static void Start()
        {
            //Load Graphics
            Graphics.InitGraphics();

            //Load Sounds
            Audio.Init();
            Audio.PlayMusic(ClientConfiguration.Instance.MenuMusic, 3, 3, true);

            //Init Network
            Networking.Network.InitNetwork();
            Fade.FadeIn();

            //Make Json.Net Familiar with Our Object Types
            var id = Guid.NewGuid();
            foreach (var val in Enum.GetValues(typeof(GameObjectType)))
            {
                var type = ((GameObjectType) val);
                if (type != GameObjectType.Event && type != GameObjectType.Time)
                {
                    var lookup = type.GetLookup();
                    var item = lookup.AddNew(type.GetObjectType(), id);
                    item.Load(item.JsonData);
                    lookup.Delete(item);
                }
            }

            // == Create the client
            client = new DiscordRpcClient("725494946081013832", pipe: discordPipe)
            {
                Logger = new DiscordRPC.Logging.ConsoleLogger(logLevel, true)
            };

            // == Subscribe to some events
            client.OnReady += (sender, msg) =>
            {
                //Create some events so we know things are happening
                //Console.WriteLine("Connected to discord with user {0}", msg.User.Username);
            };

            client.OnPresenceUpdate += (sender, msg) =>
            {
                //The presence has updated
                //Console.WriteLine("Presence has been updated! ");
            };
            client.OnConnectionEstablished += OnConnectionEstablished;      //Called when a pipe connection is made, but not ready
            client.OnConnectionFailed += OnConnectionFailed;                //Called when a pipe connection failed.
            client.OnReady += OnReady;                                      //Called when the client is ready to send presences
            client.OnClose += OnClose;                                      //Called when connection to discord is lost
            client.OnError += OnError;                                      //Called when discord has a error
            // == Initialize
            client.Initialize();

            // == Set the presence
            client.SetPresence(new RichPresence()
            {
                Details = "Chilling...",
                State = "In Menu",
                Timestamps = menuTime,
                Assets = new Assets()
                {
                    LargeImageKey = "discordlogo",
                    SmallImageKey = "logov2"
                }

            });

            _ExpiredTicks = 0;

            try
            {
                SteamClient.Init(1280220);
                Globals.IsSteamRunning = true;
                SteamUtils.OverlayNotificationPosition = NotificationPosition.BottomLeft;
                SteamUser.OnMicroTxnAuthorizationResponse += SteamUser_OnMicroTxnAuthorizationResponse;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.ToString());
                Globals.IsSteamRunning = false;
            }

            // == Do the rest of your program.
            //Simulated by a Console.ReadKey
            // etc...
            //Console.ReadKey();

            // == At the very end we need to dispose of it
            //client.Dispose();
        }
        
        private static void SteamUser_OnMicroTxnAuthorizationResponse(AppId appid, ulong orderid, bool authorized)
        {
            if (authorized)
            {
                PacketSender.SendSteamMTxnAuthorized(appid, orderid, authorized);
            } else
            {
                Interface.Interface.MsgboxErrors.Add(
                    new KeyValuePair<string, string>("", "Could not authorize your payment (orderid: "  + orderid + ") to steam, please try again!")
                );
                //SteamFriends.OpenWebOverlay("https://floor100.com/steamshoperror.php?orderid=" + orderid);
            }
        }

        public static void DestroyGame()
        {
            //Destroy Game
            //TODO - Destroy Graphics and Networking peacefully
            //Network.Close();
            if (Globals.IsSteamRunning) SteamClient.Shutdown();
            client.Dispose();
            Interface.Interface.DestroyGwen();
            Graphics.Renderer.Close();
        }

        #region Pipe Connection Events
        private static void OnConnectionEstablished(object sender, ConnectionEstablishedMessage args)
        {
            //This is called when a pipe connection is established. The connection is not ready yet, but we have at least found a valid pipe.
            //Console.WriteLine("Pipe Connection Established. Valid on pipe #{0}", args.ConnectedPipe);
        }
        private static void OnConnectionFailed(object sender, ConnectionFailedMessage args)
        {
            //This is called when the client fails to establish a connection to discord. 
            // It can be assumed that Discord is unavailable on the supplied pipe.
            //Console.WriteLine("Pipe Connection Failed. Could not connect to pipe #{0}", args.FailedPipe);
            if (discordPipe < 5)
            {
                discordPipe++;
            } else
            {
                discordPipe = -1;
            }
            isRunning = false;
        }
        #endregion

        #region State Events
        private static void OnReady(object sender, ReadyMessage args)
        {
            //This is called when we are all ready to start receiving and sending discord events. 
            // It will give us some basic information about discord to use in the future.

            //DEBUG: Update the presence timestamp
            presence.Timestamps = Timestamps.Now;

            //It can be a good idea to send a inital presence update on this event too, just to setup the inital game state.
            //Console.WriteLine("On Ready. RPC Version: {0}", args.Version);

        }
        private static void OnClose(object sender, CloseMessage args)
        {
            //This is called when our client has closed. The client can no longer send or receive events after this message.
            // Connection will automatically try to re-establish and another OnReady will be called (unless it was disposed).
            //Console.WriteLine("Lost Connection with client because of '{0}'", args.Reason);
        }
        private static void OnError(object sender, ErrorMessage args)
        {
            //Some error has occured from one of our messages. Could be a malformed presence for example.
            // Discord will give us one of these events and its upto us to handle it
            //Console.WriteLine("Error occured within discord. ({1}) {0}", args.Message, args.Code);
        }
        #endregion

        public static void Update()
        {
            if (Globals.IsSteamRunning) SteamClient.RunCallbacks();

            if (_ExpiredTicks == 600) {
                if (client != null)
                {
                    if (Globals.Me?.MapInstance != null)
                    {
                        var maptag = MapBase.Get(Globals.Me.CurrentMap).Tags;
                        var firsttag = "unknown";
                        if (maptag.Count > 0)
                        {
                            firsttag = maptag[0];
                        }
                        client.SetPresence(new RichPresence()
                        {
                            Details = Globals.Me?.Name + " lvl " + Globals.Me?.Level + " " + ClassBase.GetName(Globals.Me.Class),
                            State = "On map: " + firsttag,
                            Timestamps = menuTime,
                            Assets = new Assets()
                            {
                                LargeImageKey = "discordlogo",
                                SmallImageKey = "logov2"
                            }
                        });
                    }
                    else
                    {
                        client.SetPresence(new RichPresence()
                        {
                            Details = "Chilling...",
                            State = "In Menu",
                            Timestamps = gameTime,
                            Assets = new Assets()
                            {
                                LargeImageKey = "discordlogo",
                                SmallImageKey = "logov2"
                            }
                        });
                    }
                    client.Invoke();
                    _ExpiredTicks = 0;
                }
            } else
            {
                _ExpiredTicks++;
            }

            lock (Globals.GameLock)
            {
                Networking.Network.Update();
                Globals.System.Update();
                Fade.Update();
                Interface.Interface.ToggleInput(Globals.GameState != GameStates.Intro);

                switch (Globals.GameState)
                {
                    case GameStates.Intro:
                        ProcessIntro();

                        break;

                    case GameStates.Menu:
                        ProcessMenu();

                        break;

                    case GameStates.Loading:
                        ProcessLoading();

                        break;

                    case GameStates.InGame:
                        ProcessGame();

                        break;

                    case GameStates.Error:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(Globals.GameState), $"Value {Globals.GameState} out of range."
                        );
                }

                Globals.InputManager.Update();
                Audio.Update();
            }
        }

        private static void ProcessIntro()
        {
            if (ClientConfiguration.Instance.IntroImages.Count > 0)
            {
                GameTexture imageTex = Globals.ContentManager.GetTexture(
                    GameContentManager.TextureType.Image, ClientConfiguration.Instance.IntroImages[Globals.IntroIndex]
                );

                if (imageTex != null)
                {
                    if (Globals.IntroStartTime == -1)
                    {
                        if (Fade.DoneFading())
                        {
                            if (Globals.IntroComing)
                            {
                                Globals.IntroStartTime = Globals.System.GetTimeMs();
                            }
                            else
                            {
                                Globals.IntroIndex++;
                                Fade.FadeIn();
                                Globals.IntroComing = true;
                            }
                        }
                    }
                    else
                    {
                        if (Globals.System.GetTimeMs() > Globals.IntroStartTime + Globals.IntroDelay)
                        {
                            //If we have shown an image long enough, fade to black -- keep track that the image is going
                            Fade.FadeOut();
                            Globals.IntroStartTime = -1;
                            Globals.IntroComing = false;
                        }
                    }
                }
                else
                {
                    Globals.IntroIndex++;
                }

                if (Globals.IntroIndex >= ClientConfiguration.Instance.IntroImages.Count)
                {
                    Globals.GameState = GameStates.Menu;
                }
            }
            else
            {
                Globals.GameState = GameStates.Menu;
            }
        }

        private static void ProcessMenu()
        {
            if (!Globals.JoiningGame)
                return;

            //if (GameGraphics.FadeAmt != 255f) return;
            //Check if maps are loaded and ready
            Globals.GameState = GameStates.Loading;
            Interface.Interface.DestroyGwen();
        }

        private static void ProcessLoading()
        {
            if (Globals.Me == null || Globals.Me.MapInstance == null)
                return;

            if (!_loadedTilesets && Globals.HasGameData)
            {
                Globals.ContentManager.LoadTilesets(TilesetBase.GetNameList());
                _loadedTilesets = true;
            }

            Audio.PlayMusic(MapInstance.Get(Globals.Me.CurrentMap).Music, 3, 3, true);
            Globals.GameState = GameStates.InGame;
            Fade.FadeIn();
        }

        private static void ProcessGame()
        {
            if (Globals.ConnectionLost)
            {
                Main.Logout(false);
                Interface.Interface.MsgboxErrors.Add(
                    new KeyValuePair<string, string>("", Strings.Errors.lostconnection)
                );

                Globals.ConnectionLost = false;

                return;
            }

            //If we are waiting on maps, lets see if we have them
            if (Globals.NeedsMaps)
            {
                bool canShowWorld = true;
                if (MapInstance.Get(Globals.Me.CurrentMap) != null)
                {
                    var gridX = MapInstance.Get(Globals.Me.CurrentMap).MapGridX;
                    var gridY = MapInstance.Get(Globals.Me.CurrentMap).MapGridY;
                    for (int x = gridX - 1; x <= gridX + 1; x++)
                    {
                        for (int y = gridY - 1; y <= gridY + 1; y++)
                        {
                            if (x >= 0 &&
                                x < Globals.MapGridWidth &&
                                y >= 0 &&
                                y < Globals.MapGridHeight &&
                                Globals.MapGrid[x, y] != Guid.Empty)
                            {
                                var map = MapInstance.Get(Globals.MapGrid[x, y]);
                                if (map != null)
                                {
                                    if (map.MapLoaded == false)
                                    {
                                        canShowWorld = false;
                                    }
                                }
                                else
                                {
                                    canShowWorld = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    canShowWorld = false;
                }

                canShowWorld = true;
                if (canShowWorld)
                    Globals.NeedsMaps = false;
            }
            else
            {
                if (MapInstance.Get(Globals.Me.CurrentMap) != null)
                {
                    var gridX = MapInstance.Get(Globals.Me.CurrentMap).MapGridX;
                    var gridY = MapInstance.Get(Globals.Me.CurrentMap).MapGridY;
                    for (int x = gridX - 1; x <= gridX + 1; x++)
                    {
                        for (int y = gridY - 1; y <= gridY + 1; y++)
                        {
                            if (x >= 0 &&
                                x < Globals.MapGridWidth &&
                                y >= 0 &&
                                y < Globals.MapGridHeight &&
                                Globals.MapGrid[x, y] != Guid.Empty)
                            {
                                var map = MapInstance.Get(Globals.MapGrid[x, y]);
                                if (map == null &&
                                    (!MapInstance.MapRequests.ContainsKey(Globals.MapGrid[x, y]) ||
                                     MapInstance.MapRequests[Globals.MapGrid[x, y]] < Globals.System.GetTimeMs()))
                                {
                                    //Send for the map
                                    PacketSender.SendNeedMap(Globals.MapGrid[x, y]);
                                }
                            }
                        }
                    }
                }
            }

            if (!Globals.NeedsMaps)
            {
                //Update All Entities
                foreach (var en in Globals.Entities)
                {
                    if (en.Value == null)
                        continue;

                    en.Value.Update();
                }

                for (int i = 0; i < Globals.EntitiesToDispose.Count; i++)
                {
                    if (Globals.Entities.ContainsKey(Globals.EntitiesToDispose[i]))
                    {
                        if (Globals.EntitiesToDispose[i] == Globals.Me.Id)
                            continue;

                        Globals.Entities[Globals.EntitiesToDispose[i]].Dispose();
                        Globals.Entities.Remove(Globals.EntitiesToDispose[i]);
                    }
                }

                Globals.EntitiesToDispose.Clear();

                //Update Maps
                var maps = MapInstance.Lookup.Values.ToArray();
                foreach (MapInstance map in maps)
                {
                    if (map == null)
                        continue;

                    map.Update(map.InView());
                }
            }

            //Update Game Animations
            if (_animTimer < Globals.System.GetTimeMs())
            {
                Globals.AnimFrame++;
                if (Globals.AnimFrame == 3)
                {
                    Globals.AnimFrame = 0;
                }

                _animTimer = Globals.System.GetTimeMs() + 500;
            }

            //Remove Event Holds If Invalid
            var removeHolds = new List<Guid>();
            foreach (var hold in Globals.EventHolds)
            {
                //If hold.value is empty its a common event, ignore. Otherwise make sure we have the map else the hold doesnt matter
                if (hold.Value != Guid.Empty && MapInstance.Get(hold.Value) == null)
                {
                    removeHolds.Add(hold.Key);
                }
            }

            foreach (var hold in removeHolds)
            {
                Globals.EventHolds.Remove(hold);
            }

            Graphics.UpdatePlayerLight();
            Time.Update();
        }

        public static void JoinGame()
        {
            Globals.LoggedIn = true;
            Audio.StopMusic(3f);
        }

        public static void Logout(bool characterSelect)
        {
            Audio.PlayMusic(ClientConfiguration.Instance.MenuMusic, 3, 3, true);
            Fade.FadeOut();
            PacketSender.SendLogout(characterSelect);
            Globals.LoggedIn = false;
            Globals.WaitingOnServer = false;
            Globals.GameState = GameStates.Menu;
            Globals.JoiningGame = false;
            Globals.NeedsMaps = true;
            Globals.Picture = null;
            Interface.Interface.HideUi = false;

            //Dump Game Objects
            Globals.Me = null;
            Globals.HasGameData = false;
            foreach (var map in MapInstance.Lookup)
            {
                var mp = (MapInstance) map.Value;
                mp.Dispose(false, true);
            }

            foreach (var en in Globals.Entities.ToArray())
            {
                en.Value.Dispose();
            }

            MapBase.Lookup.Clear();
            MapInstance.Lookup.Clear();

            Globals.Entities.Clear();
            Globals.MapGrid = null;
            Globals.GridMaps.Clear();
            Globals.EventDialogs.Clear();
            Globals.EventHolds.Clear();
            Globals.PendingEvents.Clear();

            Interface.Interface.InitGwen();
            Fade.FadeIn();
        }

    }

}
