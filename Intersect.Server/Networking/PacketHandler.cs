using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

using Intersect.Enums;
using Intersect.ErrorHandling;
using Intersect.GameObjects;
using Intersect.GameObjects.Crafting;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Maps;
using Intersect.GameObjects.Maps.MapList;
using Intersect.Logging;
using Intersect.Models;
using Intersect.Network;
using Intersect.Network.Packets.Client;
using Intersect.Server.Admin.Actions;
using Intersect.Server.Core;
using Intersect.Server.Database;
using Intersect.Server.Database.PlayerData;
using Intersect.Server.Database.PlayerData.Players;
using Intersect.Server.Database.PlayerData.Security;
using Intersect.Server.Entities;
using Intersect.Server.Entities.Guilds;
using Intersect.Server.General;
using Intersect.Server.Localization;
using Intersect.Server.Maps;
using Intersect.Server.Notifications;
using Intersect.Utilities;

using JetBrains.Annotations;

using RestSharp;
using Newtonsoft.Json;

using Steamworks;

namespace Intersect.Server.Networking
{

    public class PacketHandler
    {

        public bool PreProcessPacket(IConnection connection, long pSize)
        {
            var client = Client.FindBeta4Client(connection);
            if (client == null)
            {
                return false;
            }

            if (client.Banned || client.FloodKicked)
            {
                return false;
            }

            var packetOptions = Options.Instance.SecurityOpts?.PacketOpts;
            var thresholds = packetOptions?.Threshholds;
            if (client.IsEditor)
            {
                //Is Editor
                thresholds = packetOptions?.EditorThreshholds;
            }
            else if (client.User != null)
            {
                //Logged In
                thresholds = packetOptions?.PlayerThreshholds;
            }

            if (pSize > thresholds.MaxPacketSize)
            {
                Log.Error(
                    Strings.Errors.floodsize.ToString(
                        pSize, client?.User?.Name ?? "", client?.Entity?.Name ?? "", client.GetIp()
                    )
                );

                client.FloodKicked = true;
                client.Disconnect("Flooding detected.");

                return false;
            }

            if (client.PacketTimer > Globals.Timing.TimeMs)
            {
                client.PacketCount++;
                if (client.PacketCount > thresholds.MaxPacketPerSec)
                {
                    Log.Error(
                        Strings.Errors.floodburst.ToString(
                            client.PacketCount, client?.User?.Name ?? "", client?.Entity?.Name ?? "", client.GetIp()
                        )
                    );

                    client.FloodKicked = true;
                    client.Disconnect("Flooding detected.");

                    return false;
                }
                else if (client.PacketCount > thresholds.KickAvgPacketPerSec && !client.PacketFloodDetect)
                {
                    client.FloodDetects++;
                    client.TotalFloodDetects++;
                    client.PacketFloodDetect = true;

                    if (client.FloodDetects > 3)
                    {
                        Log.Error(
                            Strings.Errors.floodaverage.ToString(
                                client.TotalFloodDetects, client?.User?.Name ?? "", client?.Entity?.Name ?? "",
                                client.GetIp()
                            )
                        );

                        client.FloodKicked = true;
                        client.Disconnect("Flooding detected.");

                        return false;
                    }

                    //TODO: Make this check a rolling average somehow to prevent constant flooding right below the threshholds.
                    if (client.TotalFloodDetects > 10)
                    {
                        //Log.Error(string.Format("[Flood]: Total Detections: {00} [User: {01} | Player: {02} | IP {03}]", client.TotalFloodDetects, client?.User?.Name ?? "", client?.Entity?.Name ?? "", client.GetIp()));
                        //client.Disconnect("Flooding detected.");
                        //return false;
                    }
                }
                else if (client.PacketCount < thresholds.KickAvgPacketPerSec / 2)
                {
                    if (client.FloodDetects > 1)
                    {
                        client.FloodDetects--;
                    }
                }
            }
            else
            {
                if (client.PacketFloodDetect)
                {
                    //Log.Error(string.Format("Possible Flood Detected: Packets in last second {00} [User: {01} | Player: {02} | IP {03}]", client.PacketCount, client?.User?.Name ?? "", client?.Entity?.Name ?? "", client.GetIp()));
                }

                client.PacketCount = 0;
                client.PacketTimer = Globals.Timing.TimeMs + 1000;
                client.PacketFloodDetect = false;
            }

            return true;
        }

        public bool HandlePacket(IConnection connection, IPacket packet)
        {
            var client = Client.FindBeta4Client(connection);
            if (client == null)
            {
                throw new Exception("Client is null!");
            }

            if (client.Banned)
            {
                return false;
            }

            switch (packet)
            {
                case Network.Packets.EditorPacket _ when !client.IsEditor:
                    return false;

                case null:
                    Log.Error($@"Received null packet from {client.Id} ({client.Name}).");
                    client.Disconnect("Error processing packet.");

                    return true;
            }

            if (!packet.IsValid)
            {
                return false;
            }

            try
            {
                var sanitizedFields = packet.Sanitize();
                if (sanitizedFields != null)
                {
                    var sanitizationBuilder = new StringBuilder(256, 8192);
                    sanitizationBuilder.Append("Received out-of-bounds values in '");
                    sanitizationBuilder.Append(packet.GetType().Name);
                    sanitizationBuilder.Append("' packet from '");
                    sanitizationBuilder.Append(client.GetIp());
                    sanitizationBuilder.Append("', '");
                    sanitizationBuilder.Append(client.Name);
                    sanitizationBuilder.AppendLine("': ");

                    foreach (var field in sanitizedFields)
                    {
                        sanitizationBuilder.Append(field.Key);
                        sanitizationBuilder.Append(" = ");
                        sanitizationBuilder.Append(field.Value.Before);
                        sanitizationBuilder.Append(" => ");
                        sanitizationBuilder.Append(field.Value.After);
                        sanitizationBuilder.AppendLine();
                    }

                    Log.Warn(sanitizationBuilder.ToString());
                }
            }
            catch (Exception exception)
            {
                Log.Error(
                    $"Client Packet Error! [Packet: {packet.GetType().Name} | User: {client.Name ?? ""} | Player: {client.Entity?.Name ?? ""} | IP {client.GetIp()}]"
                );

                Log.Error(exception);
                client.Disconnect("Error processing packet.");

                return false;
            }

            try
            {
                HandlePacket(client, client.Entity, (dynamic) packet);
            }
            catch (Exception exception)
            {
                var packetType = packet.GetType().Name;
                var packetMessage =
                    $"Client Packet Error! [Packet: {packetType} | User: {client.Name ?? ""} | Player: {client.Entity?.Name ?? ""} | IP {client.GetIp()}]";

                // TODO: Re-combine these once we figure out how to prevent the OutOfMemoryException that happens occasionally
                Log.Error(packetMessage);
                Log.Error(new ExceptionInfo(exception));
                if (exception.InnerException != null)
                {
                    Log.Error(new ExceptionInfo(exception.InnerException));
                }

                // Make the call that triggered the OOME in the first place so that we know when it stops happening
                Log.Error(exception, packetMessage);

#if DIAGNOSTIC
                client.Disconnect($"Error processing packet type '{packetType}'.");
#else
                client.Disconnect($"Error processing packet.");
#endif
                return false;
            }

            return true;
        }

        #region "Client Packets"
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class CashItem
        {
            [JsonProperty("itemid")]
            public int Itemid { get; set; }

            [JsonProperty("qty")]
            public int Qty { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("vat")]
            public int Vat { get; set; }

            [JsonProperty("itemstatus")]
            public string Itemstatus { get; set; }
        }

        public class CashParams
        {
            [JsonProperty("orderid")]
            public string Orderid { get; set; }

            [JsonProperty("transid")]
            public string Transid { get; set; }

            [JsonProperty("steamid")]
            public string Steamid { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("time")]
            public DateTime Time { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("usstate")]
            public string Usstate { get; set; }

            [JsonProperty("timecreated")]
            public DateTime Timecreated { get; set; }

            [JsonProperty("items")]
            public List<CashItem> Items { get; set; }
        }

        public class CashResponse
        {
            [JsonProperty("result")]
            public string Result { get; set; }

            [JsonProperty("params")]
            public CashParams Params { get; set; }
        }

        public class CashRoot
        {
            [JsonProperty("response")]
            public CashResponse Response { get; set; }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class CashFParams
        {
            [JsonProperty("orderid")]
            public string Orderid { get; set; }

            [JsonProperty("transid")]
            public string Transid { get; set; }
        }

        public class CashFResponse
        {
            [JsonProperty("result")]
            public string Result { get; set; }

            [JsonProperty("params")]
            public CashFParams Params { get; set; }
        }

        public class CashFRoot
        {
            [JsonProperty("response")]
            public CashFResponse Response { get; set; }
        }

        // AuthRoot myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class AuthParams
        {
            [JsonProperty("result")]
            public string Result { get; set; }

            [JsonProperty("steamid")]
            public string Steamid { get; set; }

            [JsonProperty("ownersteamid")]
            public string Ownersteamid { get; set; }

            [JsonProperty("vacbanned")]
            public bool Vacbanned { get; set; }

            [JsonProperty("publisherbanned")]
            public bool Publisherbanned { get; set; }
        }

        public class AuthResponse
        {
            [JsonProperty("params")]
            public AuthParams Params { get; set; }
        }

        public class AuthRoot
        {
            [JsonProperty("response")]
            public AuthResponse Response { get; set; }
        }


        //PingPacket
        public void HandlePacket(Client client, Player player, PingPacket packet)
        {
            client.Pinged();
            PacketSender.SendPing(client, false);
        }

        //LoginPacket
        public void HandlePacket(Client client, Player player, LoginPacket packet)
        {
            if (client.AccountAttempts > 3 && client.TimeoutMs > Globals.Timing.TimeMs)
            {
                PacketSender.SendError(client, Strings.Errors.errortimeout);
                client.ResetTimeout();

                return;
            }

            client.ResetTimeout();

            /*if (!DbInterface.CheckPassword(packet.Username, packet.Password))
            {
                client.FailedAttempt();
                PacketSender.SendError(client, Strings.Account.badlogin);

                return;
            }*/

            lock (Globals.ClientLock)
            {
                Globals.Clients.ForEach(
                    user =>
                    {
                        if (user == client)
                        {
                            return;
                        }

                        if (user?.IsEditor ?? false)
                        {
                            return;
                        }

                        if (!string.Equals(user?.Name, packet.Username, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return;
                        }

                        user?.Disconnect();
                    }
                );
            }

            var sw = new Stopwatch();
            sw.Start();
            if (!DbInterface.LoadUser(client, packet.Username))
            {
                PacketSender.SendError(client, Strings.Account.loadfail);

                return;
            }

            sw.Stop();
            Log.Debug("Took " + sw.ElapsedMilliseconds + "ms to load user and characters from db!");

            //Check for ban
            var isBanned = Ban.CheckBan(client.User, client.GetIp());
            if (isBanned != null)
            {
                client.SetUser(null);
                client.Banned = true;
                PacketSender.SendError(client, isBanned);

                return;
            }

            //Check that server is in admin only mode
            if (Options.AdminOnly)
            {
                if (client.Power == UserRights.None)
                {
                    PacketSender.SendError(client, Strings.Account.adminonly);

                    return;
                }
            }

            //Check Mute Status and Load into user property
            Mute.FindMuteReason(client.User, client.GetIp());

            PacketSender.SendServerConfig(client);

            //Character selection if more than one.
            if (Options.MaxCharacters > 1)
            {
                PacketSender.SendPlayerCharacters(client);
            }
            else if (client.Characters?.Count > 0)
            {
                client.LoadCharacter(client.Characters.First());
                client.Entity.SetOnline();
                PacketSender.SendJoinGame(client);
            }
            else
            {
                PacketSender.SendGameObjects(client, GameObjectType.Class);
                PacketSender.SendCreateCharacter(client);
            }
        }

        //LoginCheckPacket
        public void HandlePacket(Client client, Player player, LoginCheckPacket packet)
        {

            if (DbInterface.AccountExists(packet.Username))
            {
                PacketSender.SendHasAccount(client, true);

                return;
            }
            else
            {
                PacketSender.SendHasAccount(client, false);
            }
        }

        public void HandlePacket(Client client, Player player, OpenCashShopPacket packet)
        {
            player.OpenShop(ShopBase.Get(packet.ShopId));
        }

        public static Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }

        //SendSteamAuthPacket
        public async void HandlePacket(Client client, Player player, SendSteamAuthPacket packet)
        {
            string result = BitConverter.ToString(packet.Ticket.Data).Replace("-", "");
            var rclient = new RestClient("https://partner.steam-api.com/ISteamUserAuth/AuthenticateUserTicket/v1/?key=3640925ABA2FA8E6E238A31B0C7E289A&appid=1280220&ticket=" + result);
            //Console.WriteLine(result);
            Log.Debug("authenticating user with steam...\r\n");
            rclient.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "", ParameterType.RequestBody);
            var cancellationTokenSource3 = new CancellationTokenSource();

            var response =
                await rclient.ExecuteAsync(request, cancellationTokenSource3.Token);
            //IRestResponse response = rclient.Execute(request);
            //Console.WriteLine(response.Content);
            AuthRoot myDeserializedClass = JsonConvert.DeserializeObject<AuthRoot>(response.Content);
            if (myDeserializedClass.Response.Params.Result == "OK" && myDeserializedClass.Response.Params.Publisherbanned == false && myDeserializedClass.Response.Params.Vacbanned == false)
            {
                //check if account exists, if so: login, else register
                if (DbInterface.AccountExists(myDeserializedClass.Response.Params.Steamid))
                {
                    //player authorized by steam, let them login without password
                    if (client.AccountAttempts > 3 && client.TimeoutMs > Globals.Timing.TimeMs)
                    {
                        PacketSender.SendError(client, Strings.Errors.errortimeout);
                        client.ResetTimeout();

                        return;
                    }

                    client.ResetTimeout();

                    lock (Globals.ClientLock)
                    {
                        Globals.Clients.ForEach(
                            user =>
                            {
                                if (user == client)
                                {
                                    return;
                                }

                                if (user?.IsEditor ?? false)
                                {
                                    return;
                                }

                                if (!string.Equals(user?.Name, myDeserializedClass.Response.Params.Steamid, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    return;
                                }

                                user?.Disconnect();
                            }
                        );
                    }

                    var sw = new Stopwatch();
                    sw.Start();
                    if (!DbInterface.LoadUser(client, myDeserializedClass.Response.Params.Steamid))
                    {
                        PacketSender.SendError(client, Strings.Account.loadfail);

                        return;
                    }

                    sw.Stop();
                    Log.Debug("Took " + sw.ElapsedMilliseconds + "ms to load user and characters from db!");

                    //Check for ban
                    var isBanned = Ban.CheckBan(client.User, client.GetIp());
                    if (isBanned != null)
                    {
                        client.SetUser(null);
                        client.Banned = true;
                        PacketSender.SendError(client, isBanned);

                        return;
                    }

                    //Check that server is in admin only mode
                    if (Options.AdminOnly)
                    {
                        if (client.Power == UserRights.None)
                        {
                            PacketSender.SendError(client, Strings.Account.adminonly);

                            return;
                        }
                    }

                    //Check Mute Status and Load into user property
                    Mute.FindMuteReason(client.User, client.GetIp());

                    PacketSender.SendServerConfig(client);

                    //Character selection if more than one.
                    if (Options.MaxCharacters > 1)
                    {
                        PacketSender.SendPlayerCharacters(client);
                    }
                    else if (client.Characters?.Count > 0)
                    {
                        client.LoadCharacter(client.Characters.First());
                        client.Entity.SetOnline();
                        PacketSender.SendJoinGame(client);
                    }
                    else
                    {
                        PacketSender.SendGameObjects(client, GameObjectType.Class);
                        PacketSender.SendCreateCharacter(client);
                    }
                }

                //Account not registered yet, make an account
                else
                {
                    if (client.TimeoutMs > Globals.Timing.TimeMs)
                    {
                        PacketSender.SendError(client, Strings.Errors.errortimeout);
                        client.ResetTimeout();

                        return;
                    }

                    client.ResetTimeout();

                    if (Options.BlockClientRegistrations)
                    {
                        PacketSender.SendError(client, Strings.Account.registrationsblocked);

                        return;
                    }

                    //Check for ban
                    var isBanned = Ban.CheckBan(client.GetIp());
                    if (isBanned != null)
                    {
                        PacketSender.SendError(client, isBanned);

                        return;
                    }

                    if (!FieldChecking.IsValidUsername(myDeserializedClass.Response.Params.Steamid, Strings.Regex.username))
                    {
                        PacketSender.SendError(client, Strings.Account.invalidname);

                        return;
                    }

                    if (DbInterface.AccountExists(myDeserializedClass.Response.Params.Steamid))
                    {
                        PacketSender.SendError(client, Strings.Account.exists);
                    }
                    else
                    {

                        DbInterface.CreateAccount(client, myDeserializedClass.Response.Params.Steamid, "steamuser", "steamuser@floor100.com");
                        PacketSender.SendServerConfig(client);

                        //Check that server is in admin only mode
                        if (Options.AdminOnly)
                        {
                            if (client.Power == UserRights.None)
                            {
                                PacketSender.SendError(client, Strings.Account.adminonly);

                                return;
                            }
                        }

                        //Character selection if more than one.
                        if (Options.MaxCharacters > 1)
                        {
                            PacketSender.SendPlayerCharacters(client);
                        }
                        else
                        {
                            PacketSender.SendGameObjects(client, GameObjectType.Class);
                            PacketSender.SendCreateCharacter(client);
                        }

                    }
                }
            }
            else
            {
                PacketSender.SendError(client, "You accound seems to be banned or you are doing nasty things!");
            }   
        }

        //SendSteamMTxnAuthorizedPacket
        public async void HandlePacket(Client client, Player player, SendSteamMTxnAuthorizedPacket packet)
        {
            //Check the steam API with RESTSharp
            var sw1 = new Stopwatch();
            sw1.Start();
            var rclient = new RestClient("https://partner.steam-api.com/ISteamMicroTxnSandbox/QueryTxn/v2/?key=3640925ABA2FA8E6E238A31B0C7E289A&appid=1280220&orderid=" + packet.OrderId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "", ParameterType.RequestBody);
            var cancellationTokenSource = new CancellationTokenSource();

            var restResponse =
                await rclient.ExecuteAsync(request, cancellationTokenSource.Token);
            Log.Debug("received an order, checking if authorized...\r\n");
            //Deserialize the json response with a prebuilt class CashRoot
            CashRoot myDeserializedClass = JsonConvert.DeserializeObject<CashRoot>(restResponse.Content);
            sw1.Stop();
            Log.Debug("Took " + sw1.ElapsedMilliseconds + "ms to authorize!");
            //If the transaction result is OK AND the Status is Approved, continue
            if (myDeserializedClass.Response.Result == "OK" && myDeserializedClass.Response.Params.Status == "Approved")
            {
                //Finalize the order through the Steam API again
                var sw2 = new Stopwatch();
                sw2.Start();
                Log.Debug("Order has been approved, finalizing the order\r\n");
                var fclient = new RestClient("https://partner.steam-api.com/ISteamMicroTxnSandbox/FinalizeTxn/v2/");
                fclient.Timeout = -1;
                var frequest = new RestRequest(Method.POST);
                frequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                frequest.AddParameter("key", "3640925ABA2FA8E6E238A31B0C7E289A");
                frequest.AddParameter("appid", "1280220");
                frequest.AddParameter("orderid", packet.OrderId);
                var cancellationTokenSource2 = new CancellationTokenSource();

                var fresponse =
                    await rclient.ExecuteAsync(request, cancellationTokenSource2.Token);
                CashFRoot myDeserializedClassF = JsonConvert.DeserializeObject<CashFRoot>(fresponse.Content);
                sw2.Stop();
                Log.Debug("Took " + sw2.ElapsedMilliseconds + "ms to finalize!");
                if (myDeserializedClassF.Response.Result == "OK")
                {

                    if (myDeserializedClass.Response.Params.Items[0].Itemid != null)
                    {
                        if (myDeserializedClass.Response.Params.Items[0].Itemid == 1)
                        {
                            //give 1$ pack
                            if (ItemBase.Get(Options.CashShopOptions.ShopItem1Guid) != null)
                            {
                                var tempItem = ItemBase.Get(Options.CashShopOptions.ShopItem1Guid);

                                Log.Debug("Order has been processed, sending item " + tempItem.Name + " x" + myDeserializedClass.Response.Params.Items[0].Qty + " \r\n");

                                player.TryGiveItem(tempItem.Id, myDeserializedClass.Response.Params.Items[0].Qty);
                                PacketSender.SendChatMsg(player, "Thank you for your purchase, you can find the item(s) in your inventory or bank");
                            }
                        }
                        else if (myDeserializedClass.Response.Params.Items[0].Itemid == 2)
                        {
                            //give 5$ pack
                            if (ItemBase.Get(Options.CashShopOptions.ShopItem2Guid) != null)
                            {
                                var tempItem = ItemBase.Get(Options.CashShopOptions.ShopItem2Guid);

                                Log.Debug("Order has been processed, sending item " + tempItem.Name + " x" + myDeserializedClass.Response.Params.Items[0].Qty + " \r\n");

                                player.TryGiveItem(tempItem.Id, myDeserializedClass.Response.Params.Items[0].Qty);
                                PacketSender.SendChatMsg(player, "Thank you for your purchase, you can find the item(s) in your inventory or bank");
                            }
                        }
                        else if (myDeserializedClass.Response.Params.Items[0].Itemid == 3)
                        {
                            //give 10$ pack
                            if (ItemBase.Get(Options.CashShopOptions.ShopItem3Guid) != null)
                            {
                                var tempItem = ItemBase.Get(Options.CashShopOptions.ShopItem3Guid);

                                Log.Debug("Order has been processed, sending item " + tempItem.Name + " x" + myDeserializedClass.Response.Params.Items[0].Qty + " \r\n");

                                player.TryGiveItem(tempItem.Id, myDeserializedClass.Response.Params.Items[0].Qty);
                                PacketSender.SendChatMsg(player, "Thank you for your purchase, you can find the item(s) in your inventory or bank");
                            }
                        }
                        else if (myDeserializedClass.Response.Params.Items[0].Itemid == 4)
                        {
                            //give 20$ pack
                            if (ItemBase.Get(Options.CashShopOptions.ShopItem4Guid) != null)
                            {
                                var tempItem = ItemBase.Get(Options.CashShopOptions.ShopItem4Guid);

                                Log.Debug("Order has been processed, sending item " + tempItem.Name + " x" + myDeserializedClass.Response.Params.Items[0].Qty + " \r\n");

                                player.TryGiveItem(tempItem.Id, myDeserializedClass.Response.Params.Items[0].Qty);
                                PacketSender.SendChatMsg(player, "Thank you for your purchase, you can find the item(s) in your inventory or bank");
                            }
                        }
                        else if (myDeserializedClass.Response.Params.Items[0].Itemid == 5)
                        {
                            //give 50$ pack
                            if (ItemBase.Get(Options.CashShopOptions.ShopItem5Guid) != null)
                            {
                                var tempItem = ItemBase.Get(Options.CashShopOptions.ShopItem5Guid);

                                Log.Debug("Order has been processed, sending item " + tempItem.Name + " x" + myDeserializedClass.Response.Params.Items[0].Qty + " \r\n");

                                player.TryGiveItem(tempItem.Id, myDeserializedClass.Response.Params.Items[0].Qty);
                                PacketSender.SendChatMsg(player, "Thank you for your purchase, you can find the item(s) in your inventory or bank");
                            }
                        }
                        else if (myDeserializedClass.Response.Params.Items[0].Itemid == 6)
                        {
                            //give 100$ pack
                            if (ItemBase.Get(Options.CashShopOptions.ShopItem6Guid) != null)
                            {
                                var tempItem = ItemBase.Get(Options.CashShopOptions.ShopItem6Guid);

                                Log.Debug("Order has been processed, sending item " + tempItem.Name + " x" + myDeserializedClass.Response.Params.Items[0].Qty + " \r\n");

                                player.TryGiveItem(tempItem.Id, myDeserializedClass.Response.Params.Items[0].Qty);
                                PacketSender.SendChatMsg(player, "Thank you for your purchase, you can find the item(s) in your inventory or bank");
                            }
                        }
                    }
                }
            }
        }

        //LogoutPacket
        public void HandlePacket(Client client, Player player, LogoutPacket packet)
        {
            client?.Logout();
            if (Options.MaxCharacters > 1 && packet.ReturningToCharSelect)
            {
                PacketSender.SendPlayerCharacters(client);
            }
        }

        //NeedMapPacket
        public void HandlePacket(Client client, Player player, NeedMapPacket packet)
        {
            var map = MapInstance.Get(packet.MapId);
            if (map != null)
            {
                PacketSender.SendMap(client, packet.MapId);
                if (player != null && packet.MapId == player.MapId)
                {
                    PacketSender.SendMapGrid(client, map.MapGrid);
                }
            }
        }

        //MovePacket
        public void HandlePacket(Client client, Player player, MovePacket packet)
        {
            if (player == null)
            {
                return;
            }

            //check if player is stunned or snared, if so don't let them move.
            var statuses = client.Entity.Statuses.Values.ToArray();
            foreach (var status in statuses)
            {
                if (status.Type == StatusTypes.Stun ||
                    status.Type == StatusTypes.Snare ||
                    status.Type == StatusTypes.Sleep || 
                    status.Type == StatusTypes.Fear)
                {
                    return;
                }
            }

            if (!TileHelper.IsTileValid(packet.MapId, packet.X, packet.Y))
            {
                //POSSIBLE HACKING ATTEMPT!
                PacketSender.SendEntityPositionTo(client, client.Entity);

                return;
            }

            var canMove = player.CanMove(packet.Dir);
            if ((canMove == -1 || canMove == -4) && client.Entity.MoveRoute == null)
            {
                player.Move(packet.Dir, player, false);
                if (player.MoveTimer > Globals.Timing.TimeMs)
                {
                    //TODO: Make this based moreso on the players current ping instead of a flat value that can be abused
                    player.MoveTimer = Globals.Timing.TimeMs + (long) (player.GetMovementTime() * .75f);
                }
            }
            else
            {
                PacketSender.SendEntityPositionTo(client, client.Entity);

                return;
            }

            if (packet.MapId != client.Entity.MapId || packet.X != client.Entity.X || packet.Y != client.Entity.Y)
            {
                PacketSender.SendEntityPositionTo(client, client.Entity);
            }
        }

        //ChatMsgPacket
        public void HandlePacket(Client client, Player player, ChatMsgPacket packet)
        {
            if (player == null)
            {
                return;
            }

            var msg = packet.Message;
            var channel = packet.Channel;
            if (client?.User.IsMuted ?? false) //Don't let the toungless toxic kids speak.
            {
                PacketSender.SendChatMsg(player, client?.User?.Mute?.Reason);

                return;
            }

            if (player.LastChatTime > Globals.Timing.RealTimeMs)
            {
                PacketSender.SendChatMsg(player, Strings.Chat.toofast);
                player.LastChatTime = Globals.Timing.RealTimeMs + Options.MinChatInterval;

                return;
            }

            if (packet.Message.Length > Options.MaxChatLength)
            {
                return;
            }

            //If no /command, then use the designated channel.
            var cmd = "";
            if (!msg.StartsWith("/"))
            {
                switch (channel)
                {
                    case 0: //local
                        cmd = Strings.Chat.localcmd;

                        break;
                    case 1: //global
                        cmd = Strings.Chat.allcmd;

                        break;
                    case 2: //party
                        cmd = Strings.Chat.partycmd;

                        break;
                    case 3: //admin
                        cmd = Strings.Chat.admincmd;

                        break;
                    case 4: // guild
                        cmd = Strings.Chat.GuildCmd;

                        break;
                }
            }
            else
            {
                cmd = msg.Split()[0].ToLower();
                msg = msg.Remove(0, cmd.Length);
            }

            var msgSplit = msg.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (cmd == Strings.Chat.localcmd)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                if (client?.Power.IsAdmin ?? false)
                {
                    PacketSender.SendProximityMsg(
                        Strings.Chat.local.ToString(player.Name, msg), player.MapId, CustomColors.Chat.AdminLocalChat,
                        player.Name
                    );
                }
                else if (client?.Power.IsModerator ?? false)
                {
                    PacketSender.SendProximityMsg(
                        Strings.Chat.local.ToString(player.Name, msg), player.MapId, CustomColors.Chat.ModLocalChat,
                        player.Name
                    );
                }
                else
                {
                    PacketSender.SendProximityMsg(
                        Strings.Chat.local.ToString(player.Name, msg), player.MapId, CustomColors.Chat.LocalChat,
                        player.Name
                    );
                }

                PacketSender.SendChatBubble(player.Id, (int) EntityTypes.GlobalEntity, msg, player.MapId);
            }
            else if (cmd == Strings.Chat.allcmd || cmd == Strings.Chat.globalcmd)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                if (client?.Power.IsAdmin ?? false)
                {
                    PacketSender.SendGlobalMsg(
                        Strings.Chat.Global.ToString(player.Name, msg), CustomColors.Chat.AdminGlobalChat, player.Name
                    );
                }
                else if (client?.Power.IsModerator ?? false)
                {
                    PacketSender.SendGlobalMsg(
                        Strings.Chat.Global.ToString(player.Name, msg), CustomColors.Chat.ModGlobalChat, player.Name
                    );
                }
                else
                {
                    PacketSender.SendGlobalMsg(
                        Strings.Chat.Global.ToString(player.Name, msg), CustomColors.Chat.GlobalChat, player.Name
                    );
                }
            }
            else if (cmd == Strings.Chat.partycmd)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                if (player.InParty(player))
                {
                    PacketSender.SendPartyMsg(
                        player, Strings.Chat.party.ToString(player.Name, msg), CustomColors.Chat.PartyChat, player.Name
                    );
                }
                else
                {
                    PacketSender.SendChatMsg(player, Strings.Parties.notinparty, CustomColors.Alerts.Error);
                }
            }
            else if (cmd == Strings.Chat.GuildCmd)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                // Is the player in a guild?
                if (player.Guild == null)
                {
                    PacketSender.SendChatMsg(player, Strings.Guilds.NotInGuild, CustomColors.Alerts.Error);
                }

                PacketSender.SendGuildMsg(
                        player.Guild, Strings.Chat.Guild.ToString(player.Name, msg), CustomColors.Chat.GuildChat, player.Name
                    );
            }
            else if (cmd == Strings.Chat.admincmd)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                if (client?.Power.IsModerator ?? false)
                {
                    PacketSender.SendAdminMsg(
                        Strings.Chat.admin.ToString(player.Name, msg), CustomColors.Chat.AdminChat, player.Name
                    );
                }
            }
            else if (cmd == Strings.Chat.announcementcmd)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                if (client?.Power.IsModerator ?? false)
                {
                    PacketSender.SendGlobalMsg(
                        Strings.Chat.announcement.ToString(player.Name, msg), CustomColors.Chat.AnnouncementChat,
                        player.Name
                    );
                }
            }
            else if (cmd == Strings.Chat.pmcmd || cmd == Strings.Chat.messagecmd)
            {
                if (msgSplit.Length < 2)
                {
                    return;
                }

                msg = msg.Remove(0, msgSplit[0].Length + 1); //Chop off the player name parameter

                if (msg.Trim().Length == 0)
                {
                    return;
                }

                for (var i = 0; i < Globals.Clients.Count; i++)
                {
                    if (Globals.Clients[i] != null && Globals.Clients[i].Entity != null)
                    {
                        if (msgSplit[0].ToLower() == Globals.Clients[i].Entity.Name.ToLower())
                        {
                            PacketSender.SendChatMsg(
                                player, Strings.Chat.Private.ToString(player.Name, msg), CustomColors.Chat.PrivateChat,
                                player.Name
                            );

                            PacketSender.SendChatMsg(
                                Globals.Clients[i].Entity, Strings.Chat.Private.ToString(player.Name, msg),
                                CustomColors.Chat.PrivateChat, player.Name
                            );

                            Globals.Clients[i].Entity.ChatTarget = player;
                            player.ChatTarget = Globals.Clients[i].Entity;

                            return;
                        }
                    }
                }

                PacketSender.SendChatMsg(player, Strings.Player.offline, CustomColors.Alerts.Error);
            }
            else if (cmd == Strings.Chat.replycmd || cmd == Strings.Chat.rcmd)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                if (player.ChatTarget != null)
                {
                    PacketSender.SendChatMsg(
                        player, Strings.Chat.Private.ToString(player.Name, msg), CustomColors.Chat.PrivateChat,
                        player.Name
                    );

                    PacketSender.SendChatMsg(
                        player.ChatTarget, Strings.Chat.Private.ToString(player.Name, msg),
                        CustomColors.Chat.PrivateChat, player.Name
                    );

                    player.ChatTarget.ChatTarget = player;
                }
                else
                {
                    PacketSender.SendChatMsg(player, Strings.Player.offline, CustomColors.Alerts.Error);
                }
            }
            /*else if (cmd == Strings.Chat.GuildCreate)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                var arg = msg.Split(';');
                if (arg.Length != 2)
                {
                    return;
                }
                var name = arg[0];
                var tag = arg[1];

                Guild.Create(player, name, tag);
            }*/
            else if (cmd == Strings.Chat.GuildInvite)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                // Are we even in a guild?
                if (player.Guild != null)
                {
                    // Is our rank allowed to invite players?
                    var rank = player.Guild.GetRank(player);
                    if (rank != null)
                    {
                        if (rank.Permissions.ContainsKey(GuildPermissions.InvitePlayers)) {
                            // Attempt to invite this player to our guild.
                            var invitePlayer = Player.FindOnline(msg.Trim());
                            if (invitePlayer == null)
                            {
                                invitePlayer = Player.Find(msg.Trim());
                            }
                            invitePlayer?.InviteToGuild(player.Guild, player);
                        }
                        else
                        {
                            // This player is not allowed to do this cuz no rank matches this one
                            PacketSender.SendChatMsg(player, Strings.Guilds.NoPermission, CustomColors.Alerts.Error);
                        }
                    }
                    else
                    {
                        // This player is not allowed to do this!
                        PacketSender.SendChatMsg(player, Strings.Guilds.NoPermission, CustomColors.Alerts.Error);
                    }
                }
                else
                {
                    // They're not even in a guild!
                    PacketSender.SendChatMsg(player, Strings.Guilds.NotInGuild, CustomColors.Alerts.Error);
                } 
            }
            else if (cmd == Strings.Chat.GuildPromote)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                // Are we even in a guild?
                if (player.Guild != null)
                {
                    // Is our rank allowed to promote players?
                    var rank = player.Guild.GetRank(player);
                    if (rank != null)
                    {
                        if (rank.Permissions.ContainsKey(GuildPermissions.KickPlayers))
                        {
                            var toPromotePlayer = Player.Find(msg.Trim());
                            // Attempt to promote this player
                            var RankInfo = player.Guild.Ranks;
                            for (var i = 0; i < RankInfo.Count()-1; i++)
                            {
                                var currentRank = RankInfo.FirstOrDefault(n => n.Id == toPromotePlayer.Guild.GetRank(toPromotePlayer).Id);
                                if (RankInfo[i].Id == currentRank.Id)
                                {
                                    if (RankInfo.IndexOf(rank) > RankInfo.IndexOf(currentRank) && RankInfo.IndexOf(rank) > RankInfo.IndexOf(currentRank)+1)
                                    {
                                        if (i < RankInfo.Count() - 1)
                                        {
                                            player.Guild.ChangeRank(toPromotePlayer.Id, RankInfo[i + 1].Id);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // This player is not allowed to do this cuz no rank matches this one
                            PacketSender.SendChatMsg(player, Strings.Guilds.NoPermission, CustomColors.Alerts.Error);
                        }
                    }
                    else
                    {
                        // This player is not allowed to do this!
                        PacketSender.SendChatMsg(player, Strings.Guilds.NoPermission, CustomColors.Alerts.Error);
                    }
                }
                else
                {
                    // They're not even in a guild!
                    PacketSender.SendChatMsg(player, Strings.Guilds.NotInGuild, CustomColors.Alerts.Error);
                }
            }
            else if (cmd == Strings.Chat.GuildDemote)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                // Are we even in a guild?
                if (player.Guild != null)
                {
                    // Is our rank allowed to demote players?
                    var rank = player.Guild.GetRank(player);
                    if (rank != null)
                    {
                        if (rank.Permissions.ContainsKey(GuildPermissions.KickPlayers))
                        {
                            var toPromotePlayer = Player.Find(msg.Trim());
                            // Attempt to demote this player
                            var RankInfo = player.Guild.Ranks;
                            for (var i = 0; i < RankInfo.Count(); i++)
                            {
                                var currentRank = RankInfo.FirstOrDefault(n => n.Id == toPromotePlayer.Guild.GetRank(toPromotePlayer).Id);
                                if (RankInfo[i].Id == currentRank.Id)
                                {
                                    if (RankInfo.IndexOf(rank) > RankInfo.IndexOf(currentRank) || RankInfo.IndexOf(rank) == RankInfo.Count())
                                    {
                                        if (i > 0)
                                        {
                                            player.Guild.ChangeRank(toPromotePlayer.Id, RankInfo[i - 1].Id);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // This player is not allowed to do this cuz no rank matches this one
                            PacketSender.SendChatMsg(player, Strings.Guilds.NoPermission, CustomColors.Alerts.Error);
                        }
                    }
                    else
                    {
                        // This player is not allowed to do this!
                        PacketSender.SendChatMsg(player, Strings.Guilds.NoPermission, CustomColors.Alerts.Error);
                    }
                }
                else
                {
                    // They're not even in a guild!
                    PacketSender.SendChatMsg(player, Strings.Guilds.NotInGuild, CustomColors.Alerts.Error);
                }
            }
            else if (cmd == Strings.Chat.GuildInviteAccept)
            {
                // Accept our guild invite.
                player.HandleGuildInvite(true);
            }
            else if (cmd == Strings.Chat.GuildInviteDecline)
            {
                // Decline our guild invite.
                player.HandleGuildInvite(false);
            }
            else if (cmd == Strings.Chat.GuildLeave)
            {
                // Decline our guild invite.
                player.Guild.Leave(player);
            }
            else if (cmd == Strings.Chat.GuildKick)
            {
                if (msg.Trim().Length == 0)
                {
                    return;
                }

                // Are we even in a guild?
                if (player.Guild != null)
                {
                    // Is our rank allowed to invite players?
                    var rank = player.Guild.GetRank(player);
                    if (rank != null)
                    {
                        if (rank.Permissions.ContainsKey(GuildPermissions.KickPlayers))
                        {
                            var toKickPlayer = Player.Find(msg.Trim());
                            player.Guild.Kick(toKickPlayer);
                        }
                        else
                        {
                            // This player is not allowed to do this cuz no rank matches this one
                            PacketSender.SendChatMsg(player, Strings.Guilds.NoPermission, CustomColors.Alerts.Error);
                        }
                    }
                    else
                    {
                        // This player is not allowed to do this!
                        PacketSender.SendChatMsg(player, Strings.Guilds.NoPermission, CustomColors.Alerts.Error);
                    }
                }
                else
                {
                    // They're not even in a guild!
                    PacketSender.SendChatMsg(player, Strings.Guilds.NotInGuild, CustomColors.Alerts.Error);
                }
            }
            else
            {
                //Search for command activated events and run them
                foreach (var evt in EventBase.Lookup)
                {
                    if ((EventBase) evt.Value != null)
                    {
                        if (client.Entity.StartCommonEvent(
                                (EventBase) evt.Value, CommonEventTrigger.SlashCommand, cmd.TrimStart('/'), msg
                            ) ==
                            true)
                        {
                            return; //Found our /command, exit now :)
                        }
                    }
                }

                //No common event /command, invalid command.
                PacketSender.SendChatMsg(player, Strings.Commands.invalid, CustomColors.Alerts.Error);
            }
        }

        //BlockPacket
        public void HandlePacket(Client client, Player player, BlockPacket packet)
        {
            if (player == null)
            {
                return;
            }

            //check if player is blinded or stunned
            var statuses = client.Entity.Statuses.Values.ToArray();
            foreach (var status in statuses)
            {
                if (status.Type == StatusTypes.Stun)
                {
                    PacketSender.SendChatMsg(player, Strings.Combat.stunblocking);

                    return;
                }

                if (status.Type == StatusTypes.Sleep)
                {
                    PacketSender.SendChatMsg(player, Strings.Combat.sleepblocking);

                    return;
                }

                if (status.Type == StatusTypes.Fear)
                {
                    PacketSender.SendChatMsg(player, Strings.Combat.fearblocking);

                    return;
                }
            }

            client.Entity.TryBlock(packet.Blocking);
        }

        //BumpPacket
        public void HandlePacket(Client client, Player player, BumpPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.TryBumpEvent(packet.MapId, packet.EventId);
        }

        //AttackPacket
        public void HandlePacket(Client client, Player player, AttackPacket packet)
        {
            if (player == null)
            {
                return;
            }

            var unequippedAttack = false;
            var target = packet.Target;
            bool targetOnFocus = packet.TargetOnFocus;

            if (player.CastTime >= Globals.Timing.TimeMs)
            {
                PacketSender.SendChatMsg(player, Strings.Combat.channelingnoattack);

                return;
            }

            //check if player is blinded or stunned
            var statuses = player.Statuses.Values.ToArray();
            foreach (var status in statuses)
            {
                if (status.Type == StatusTypes.Stun)
                {
                    PacketSender.SendChatMsg(player, Strings.Combat.stunattacking);

                    return;
                }

                if (status.Type == StatusTypes.Sleep)
                {
                    PacketSender.SendChatMsg(player, Strings.Combat.sleepattacking);

                    return;
                }

                if (status.Type == StatusTypes.Blind)
                {
                    PacketSender.SendActionMsg(player, Strings.Combat.miss, CustomColors.Combat.Missed);

                    return;
                }

                if (status.Type == StatusTypes.Fear)
                {
                    PacketSender.SendChatMsg(player, Strings.Combat.fearattacking);

                    return;
                }
            }

            var attackingTile = new TileHelper(player.MapId, player.X, player.Y);
            switch (player.Dir)
            {
                case 0:
                    attackingTile.Translate(0, -1);

                    break;
                case 1:
                    attackingTile.Translate(0, 1);

                    break;
                case 2:
                    attackingTile.Translate(-1, 0);

                    break;
                case 3:
                    attackingTile.Translate(1, 0);

                    break;
                case 4:
                    attackingTile.Translate(-1, -1); // UpLeft

                    break;
                case 5:
                    attackingTile.Translate(1, -1); // UpRight

                    break;
                case 6:
                    attackingTile.Translate(-1, 1); // DownLeft

                    break;
                case 7:
                    attackingTile.Translate(1, 1); // DownRight

                    break;
            }

            PacketSender.SendEntityAttack(player, player.CalculateAttackTime());

            //Fire projectile instead if weapon has it
            if (Options.WeaponIndex > -1)
            {
                if (player.Equipment[Options.WeaponIndex] >= 0 &&
                    ItemBase.Get(player.Items[player.Equipment[Options.WeaponIndex]].ItemId) != null)
                {
                    var weaponItem = ItemBase.Get(
                        player.Items[player.Equipment[Options.WeaponIndex]].ItemId
                    );

                    //Check for animation
                    var attackAnim = ItemBase
                        .Get(player.Items[player.Equipment[Options.WeaponIndex]].ItemId)
                        .AttackAnimation;

                    if (attackAnim != null && attackingTile.TryFix())
                    {
                        PacketSender.SendAnimationToProximity(
                            attackAnim.Id, -1, Guid.Empty, attackingTile.GetMapId(), attackingTile.GetX(),
                            attackingTile.GetY(), (sbyte)player.Dir
                        );
                    }

                    var weaponInvSlot = player.Equipment[Options.WeaponIndex];
                    var invItem = player.Items[weaponInvSlot];
                    var weapon = ItemBase.Get(invItem?.ItemId ?? Guid.Empty);
                    var projectileBase = ProjectileBase.Get(weapon?.ProjectileId ?? Guid.Empty);

                    if (projectileBase != null)
                    {
                        if (projectileBase.AmmoItemId != Guid.Empty)
                        {
                            var itemSlot = player.FindInventoryItemSlot(
                                projectileBase.AmmoItemId, projectileBase.AmmoRequired
                            );

                            if (itemSlot == null)
                            {
                                PacketSender.SendChatMsg(
                                    player,
                                    Strings.Items.notenough.ToString(ItemBase.GetName(projectileBase.AmmoItemId)),
                                    CustomColors.Combat.NoAmmo
                                );

                                return;
                            }
#if INTERSECT_DIAGNOSTIC
                                PacketSender.SendPlayerMsg(client,
                                    Strings.Get("items", "notenough", $"REGISTERED_AMMO ({projectileBase.Ammo}:'{ItemBase.GetName(projectileBase.Ammo)}':{projectileBase.AmmoRequired})"),
                                    CustomColors.NoAmmo);
#endif
                            if (!player.TryTakeItem(projectileBase.AmmoItemId, projectileBase.AmmoRequired))
                            {
#if INTERSECT_DIAGNOSTIC
                                    PacketSender.SendPlayerMsg(client,
                                        Strings.Get("items", "notenough", "FAILED_TO_DEDUCT_AMMO"),
                                        CustomColors.NoAmmo);
                                    PacketSender.SendPlayerMsg(client,
                                        Strings.Get("items", "notenough", $"FAILED_TO_DEDUCT_AMMO {client.Entity.CountItems(projectileBase.Ammo)}"),
                                        CustomColors.NoAmmo);
#endif
                            }
                        }
#if INTERSECT_DIAGNOSTIC
                            else
                            {
                                PacketSender.SendPlayerMsg(client,
                                    Strings.Get("items", "notenough", "NO_REGISTERED_AMMO"),
                                    CustomColors.NoAmmo);
                            }
#endif
                        MapInstance.Get(player.MapId)
                            .SpawnMapProjectile(
                                player, projectileBase, null, weaponItem, player.MapId,
                                (byte)player.X, (byte)player.Y, (byte)player.Z,
                                (byte)player.Dir, null
                            );

                        return;
                    }
#if INTERSECT_DIAGNOSTIC
                        else
                        {
                            PacketSender.SendPlayerMsg(client,
                                Strings.Get("items", "notenough", "NONPROJECTILE"),
                                CustomColors.NoAmmo);
                            return;
                        }
#endif
                }
                else
                {
                    unequippedAttack = true;
#if INTERSECT_DIAGNOSTIC
                        PacketSender.SendPlayerMsg(client,
                            Strings.Get("items", "notenough", "NO_WEAPON"),
                            CustomColors.NoAmmo);
#endif
                }
            }
            else
            {
                unequippedAttack = true;
            }

            if (unequippedAttack)
            {
                var classBase = ClassBase.Get(player.ClassId);
                if (classBase != null)
                {
                    //Check for animation
                    if (classBase.AttackAnimation != null)
                    {
                        PacketSender.SendAnimationToProximity(
                            classBase.AttackAnimationId, -1, Guid.Empty, attackingTile.GetMapId(), attackingTile.GetX(),
                            attackingTile.GetY(), (sbyte)player.Dir
                        );
                    }
                }
            }

            foreach (var map in player.Map.GetSurroundingMaps(true))
            {
                foreach (var entity in map.GetEntities())
                {
                    if (entity.Id == target)
                    {
                        player.TryAttack(entity, targetOnFocus);

                        break;
                    }
                }
            }
        }

        //DirectionPacket
        public void HandlePacket(Client client, Player player, DirectionPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.ChangeDir(packet.Direction);
        }

        //EnterGamePacket
        public void HandlePacket(Client client, Player player, EnterGamePacket packet)
        {
        }

        //ActivateEventPacket
        public void HandlePacket(Client client, Player player, ActivateEventPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.TryActivateEvent(packet.EventId);
        }

        //EventResponsePacket
        public void HandlePacket(Client client, Player player, EventResponsePacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.RespondToEvent(packet.EventId, packet.Response);
        }

        //ItemChoiceResponsePacket
        public void HandlePacket(Client client, Player player, ItemChoiceResponsePacket packet)
        {
            if (player == null)
            {
                return;
            }
            player.ItemChoice(packet.EventId, packet.Response);
        }

        //ClassChangeResponsePacket
        public void HandlePacket(Client client, Player player, ClassChangeResponsePacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.ClassChange(packet.EventId, packet.Response);
        }

        //EventInputVariablePacket
        public void HandlePacket(Client client, Player player, EventInputVariablePacket packet)
        {
            ((Player) client.Entity).RespondToEventInput(
                packet.EventId, packet.Value, packet.StringValue, packet.Canceled
            );
        }

        //CreateAccountPacket
        public void HandlePacket(Client client, Player player, CreateAccountPacket packet)
        {
            if (client.TimeoutMs > Globals.Timing.TimeMs)
            {
                PacketSender.SendError(client, Strings.Errors.errortimeout);
                client.ResetTimeout();

                return;
            }

            client.ResetTimeout();

            if (Options.BlockClientRegistrations)
            {
                PacketSender.SendError(client, Strings.Account.registrationsblocked);

                return;
            }

            //Check for ban
            var isBanned = Ban.CheckBan(client.GetIp());
            if (isBanned != null)
            {
                PacketSender.SendError(client, isBanned);

                return;
            }

            if (!FieldChecking.IsValidUsername(packet.Username, Strings.Regex.username))
            {
                PacketSender.SendError(client, Strings.Account.invalidname);

                return;
            }

            if (!FieldChecking.IsWellformedEmailAddress(packet.Email, Strings.Regex.email))
            {
                PacketSender.SendError(client, Strings.Account.invalidemail);

                return;
            }

            if (DbInterface.AccountExists(packet.Username))
            {
                PacketSender.SendError(client, Strings.Account.exists);
            }
            else
            {
                if (DbInterface.EmailInUse(packet.Email))
                {
                    PacketSender.SendError(client, Strings.Account.emailexists);
                }
                else
                {
                    DbInterface.CreateAccount(client, packet.Username, packet.Password, packet.Email);
                    PacketSender.SendServerConfig(client);

                    //Check that server is in admin only mode
                    if (Options.AdminOnly)
                    {
                        if (client.Power == UserRights.None)
                        {
                            PacketSender.SendError(client, Strings.Account.adminonly);

                            return;
                        }
                    }

                    //Character selection if more than one.
                    if (Options.MaxCharacters > 1)
                    {
                        PacketSender.SendPlayerCharacters(client);
                    }
                    else
                    {
                        PacketSender.SendGameObjects(client, GameObjectType.Class);
                        PacketSender.SendCreateCharacter(client);
                    }
                }
            }
        }

        //CreateCharacterPacket
        public void HandlePacket(Client client, Player player, CreateCharacterPacket packet)
        {
            if (client.User == null)
            {
                return;
            }

            if (!FieldChecking.IsValidUsername(packet.Name, Strings.Regex.username))
            {
                PacketSender.SendError(client, Strings.Account.invalidname);

                return;
            }

            var index = client.Id;
            var classBase = ClassBase.Get(packet.ClassId);
            if (classBase == null || classBase.Locked)
            {
                PacketSender.SendError(client, Strings.Account.invalidclass);

                return;
            }

            if (DbInterface.CharacterNameInUse(packet.Name))
            {
                PacketSender.SendError(client, Strings.Account.characterexists);
            }
            else
            {
                var newChar = new Player();
                newChar.Id = Guid.NewGuid();
                DbInterface.AddCharacter(client.User, newChar);
                newChar.ValidateLists();
                for (var i = 0; i < Options.EquipmentSlots.Count; i++)
                {
                    newChar.Equipment[i] = -1;
                }

                newChar.Name = packet.Name;
                newChar.ClassId = packet.ClassId;
                newChar.Level = 1;

                if (classBase.Sprites.Count > 0)
                {
                    var spriteIndex = Math.Max(0, Math.Min(classBase.Sprites.Count, packet.Sprite));
                    newChar.Sprite = classBase.Sprites[spriteIndex].Sprite;
                    newChar.Face = classBase.Sprites[spriteIndex].Face;
                    newChar.Gender = classBase.Sprites[spriteIndex].Gender;
                }

                // Get our custom layers from the packet.
                for (var i = 0; i < (int)Enums.CustomSpriteLayers.CustomCount; i++)
                {
                    newChar.CustomSpriteLayers[i] = packet.CustomSpriteLayers[i] != -1 ? classBase.CustomSpriteLayers[(Enums.CustomSpriteLayers)i][packet.CustomSpriteLayers[i]].Texture : String.Empty;
                }
                
                client.LoadCharacter(newChar);

                newChar.SetVital(Vitals.Health, classBase.BaseVital[(int) Vitals.Health]);
                newChar.SetVital(Vitals.Mana, classBase.BaseVital[(int) Vitals.Mana]);

                for (var i = 0; i < (int) Stats.StatCount; i++)
                {
                    newChar.Stat[i].BaseStat = 0;
                }

                newChar.StatPoints = classBase.BasePoints;

                for (var i = 0; i < classBase.Spells.Count; i++)
                {
                    if (classBase.Spells[i].Level <= 1)
                    {
                        var tempSpell = new Spell(classBase.Spells[i].Id);
                        newChar.TryTeachSpell(tempSpell, false);
                    }
                }

                foreach (var item in classBase.Items)
                {
                    if (ItemBase.Get(item.Id) != null)
                    {
                        var tempItem = new Item(item.Id, item.Quantity);
                        newChar.TryGiveItem(tempItem, ItemHandling.Normal, false, false);
                    }
                }

                PacketSender.SendJoinGame(client);
                newChar.SetOnline();

                DbInterface.SavePlayerDatabaseAsync();
            }
        }

        //PickupItemPacket
        public void HandlePacket(Client client, Player player, PickupItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            if (packet.MapItemIndex < MapInstance.Get(player.MapId).MapItems.Count &&
                MapInstance.Get(player.MapId).MapItems[packet.MapItemIndex] != null)
            {
                var mapItem = MapInstance.Get(player.MapId).MapItems[packet.MapItemIndex];
                if (mapItem.X == player.X &&
                    mapItem.Y == player.Y)
                {
                    var canTake = false;
                    // Can we actually take this item?
                    if (mapItem.Owner == Guid.Empty || Globals.Timing.TimeMs > mapItem.OwnershipTime)
                    {
                        // The ownership time has run out, or there's no owner!
                        canTake = true;
                    }
                    else if (mapItem.Owner == player.Id || player.Party.Any(p => p.Id == mapItem.Owner))
                    {
                        // The current player is the owner, or one of their party members is.
                        canTake = true;
                    } 

                    if (canTake)
                    {
                        // Try to give the item to our player.
                        if (player.TryGiveItem(mapItem))
                        {
                            // Remove Item From Map
                            MapInstance.Get(player.MapId).RemoveItem(packet.MapItemIndex);
                        } 
                        else 
                        {
                            // We couldn't give the player their item, notify them.
                            PacketSender.SendChatMsg(player, Strings.Items.InventoryNoSpace, CustomColors.Alerts.Error);
                        }
                    } 
                    else
                    {
                        // Item does not belong to them.
                        PacketSender.SendChatMsg(player, Strings.Items.NotYours, CustomColors.Alerts.Error);
                    }
                    
                }
            }
        }

        //SwapInvItemsPacket
        public void HandlePacket(Client client, Player player, SwapInvItemsPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.SwapItems(packet.Slot1, packet.Slot2);
        }

        //DropItemPacket
        public void HandlePacket(Client client, Player player, DropItemPacket packet)
        {
            if (packet == null)
            {
                return;
            }

            player?.DropItems(packet.Slot, packet.Quantity);
        }

        //UseItemPacket
        public void HandlePacket(Client client, Player player, UseItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            Entity target = null;
            if (packet.TargetId != Guid.Empty)
            {
                foreach (var map in player.Map.GetSurroundingMaps(true))
                {
                    foreach (var en in map.GetEntities())
                    {
                        if (en.Id == packet.TargetId)
                        {
                            target = en;

                            break;
                        }
                    }
                }
            }

            player.UseItem(packet.Slot, target);
        }

        //checkGuildIdPacket
        public void checkGuildIdPacket(Player player)
        {
            if (player == null)
            {
                return;
            }

            PacketSender.updateGuild(player);
        }

        //SwapSpellsPacket
        public void HandlePacket(Client client, Player player, SwapSpellsPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.SwapSpells(packet.Slot1, packet.Slot2);
        }

        //ForgetSpellPacket
        public void HandlePacket(Client client, Player player, ForgetSpellPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.ForgetSpell(packet.Slot);
        }

        //UseSpellPacket
        public void HandlePacket(Client client, Player player, UseSpellPacket packet)
        {
            if (player == null)
            {
                return;
            }

            var casted = false;

            if (packet.TargetId != Guid.Empty)
            {
                foreach (var map in player.Map.GetSurroundingMaps(true))
                {
                    foreach (var en in map.GetEntities())
                    {
                        if (en.Id == packet.TargetId)
                        {
                            player.UseSpell(packet.Slot, en);
                            casted = true;

                            break;
                        }
                    }
                }
            }

            if (!casted)
            {
                player.UseSpell(packet.Slot, null);
            }
        }

        //UnequipItemPacket
        public void HandlePacket(Client client, Player player, UnequipItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.UnequipItem(packet.Slot);
        }

        //UpgradeStatPacket
        public void HandlePacket(Client client, Player player, UpgradeStatPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.UpgradeStat(packet.Stat);
        }

        //HotbarUpdatePacket
        public void HandlePacket(Client client, Player player, HotbarUpdatePacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.HotbarChange(packet.HotbarSlot, packet.Type, packet.Index);
        }

        //HotbarSwapPacket
        public void HandlePacket(Client client, Player player, HotbarSwapPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.HotbarSwap(packet.Slot1, packet.Slot2);
        }

        //OpenAdminWindowPacket
        public void HandlePacket(Client client, Player player, OpenAdminWindowPacket packet)
        {
            if (client.Power.IsModerator)
            {
                PacketSender.SendMapList(client);
                PacketSender.SendOpenAdminWindow(client);
            }
        }

        //AdminActionPacket
        public void HandlePacket(Client client, Player player, AdminActionPacket packet)
        {
            if (!client.Power.Editor && !client.Power.IsModerator)
            {
                return;
            }

            ActionProcessing.ProcessAction(client, player, (dynamic) packet.Action);
        }

        //BuyItemPacket
        public void HandlePacket(Client client, Player player, BuyItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.BuyItem(packet.Slot, packet.Quantity);
        }

        //SellItemPacket
        public void HandlePacket(Client client, Player player, SellItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.SellItem(packet.Slot, packet.Quantity);
        }

        //CloseShopPacket
        public void HandlePacket(Client client, Player player, CloseShopPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.CloseShop();
        }

        //CloseCraftingPacket
        public void HandlePacket(Client client, Player player, CloseCraftingPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.CloseCraftingTable();
        }

        //CraftItemPacket
        public void HandlePacket(Client client, Player player, CraftItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.CraftId = packet.CraftId;
            player.CraftTimer = Globals.Timing.TimeMs;
        }

        //CraftRequestPacket
        public void HandlePacket(Client client, Player player, CraftRequestPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.CraftRequestId = packet.CraftId;
        }

        //CloseBankPacket
        public void HandlePacket(Client client, Player player, CloseBankPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.CloseBank();
        }

        //CloseBankPacket
        public void HandlePacket(Client client, Player player, CloseTradeSkillInfoPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.CloseTradeSkillInfo();
        }

        //ClosGuildCreatePacket
        public void HandlePacket(Client client, Player player, CloseGuildCreatePacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.CloseGuildCreate();
        }

        //CloseGuildBankPacket
        public void HandlePacket(Client client, Player player, CloseGuildBankPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.CloseGuildBank();
        }

        //DepositItemPacket
        public void HandlePacket(Client client, Player player, DepositItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.TryDepositItem(packet.Slot, packet.Quantity);
        }

        //WithdrawItemPacket
        public void HandlePacket(Client client, Player player, WithdrawItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.WithdrawItem(packet.Slot, packet.Quantity);
        }

        //DepositGuildItemPacket
        public void HandlePacket(Client client, Player player, DepositGuildItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.TryDepositGuildItem(packet.Slot, packet.Quantity);
        }

        //WithdrawGuildItemPacket
        public void HandlePacket(Client client, Player player, WithdrawGuildItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.WithdrawGuildItem(packet.Slot, packet.Quantity);
        }

        //MoveBankItemPacket
        public void HandlePacket(Client client, Player player, SwapBankItemsPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.SwapBankItems(packet.Slot1, packet.Slot2);
        }

        //MoveGuildBankItemPacket
        public void HandlePacket(Client client, Player player, SwapGuildBankItemsPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.SwapGuildBankItems(packet.Slot1, packet.Slot2);
        }

        //PartyInvitePacket
        public void HandlePacket(Client client, Player player, PartyInvitePacket packet)
        {
            if (player == null)
            {
                return;
            }

            var target = Player.FindOnline(packet.TargetId);

            if (target != null && target.Id != player.Id && player.InRangeOf(target, Options.Party.InviteRange))
            {
                target.InviteToParty(player);

                return;
            }

            PacketSender.SendChatMsg(player, Strings.Parties.outofrange, CustomColors.Combat.NoTarget);
        }

        // Mail Box
        public void HandlePacket(Client client, Player player, MailBoxClosePacket packet)
        {
            if (player == null)
            {
                return;
            }
            player.CloseMailBox();
        }

        public void HandlePacket(Client client, Player player, MailBoxSendPacket packet)
        {
            if (player == null)
            {
                return;
            }

            var character = DbInterface.GetPlayer(packet.To);
            if (character != null)
            {
                int slotID = packet.SlotID;
                if (slotID >= player.Items.Count)
                {
                    player.CloseMailBox();
                    return;
                }
                int quantity = 0;
                int[] statBuffs = new int[(int)Enums.Stats.StatCount];
                Guid itemID = Guid.Empty;
                if (slotID >= 0)
                {
                    InventorySlot slot = player.Items[slotID];
                    itemID = slot.ItemId;
                    if (itemID != Guid.Empty)
                    {
                        if (slot.Descriptor.Bound)
                        {
                            PacketSender.SendChatMsg(player, $"Can't send bound items!", CustomColors.Alerts.Declined);
                            return;
                        }
                        quantity = packet.Quantity;
                        //statBuffs = slot.StatBuffs;
                        statBuffs = packet.StatBuffs;

                        if (player.TryTakeItem(slot, quantity) == false)
                        {
                            itemID = Guid.Empty;
                            quantity = 0;
                            statBuffs = new int[(int)Enums.Stats.StatCount];
                        }

                    }
                }

                character.MailBoxs.Add(new MailBox(player, character, packet.Title, packet.Message, itemID, quantity, statBuffs));
                if (Globals.OnlineList.Select(p => p.Id == character.Id) != null)
                {
                    PacketSender.SendChatMsg(character, $"You received a mail", CustomColors.Alerts.Accepted);
                }

            }
            else
            {
                PacketSender.SendChatMsg(player, $"{Strings.Mails.playernotfound} ({packet.To})", CustomColors.Alerts.Info);
            }
            player.CloseMailBox();
            DbInterface.SavePlayerDatabaseAsync();
        }

        public void HandlePacket(Client client, Player player, TakeMailPacket packet)
        {
            if (player == null)
            {
                return;
            }

            MailBox mail = null;
            foreach (MailBox mailbox in player.MailBoxs)
            {
                if (mailbox.Id == packet.MailID)
                {
                    mail = mailbox;
                    break;
                }
            }
            if (mail == null)
            {
                return;
            }
            if (mail.ItemId == Guid.Empty || mail.Quantity < 1)
            {
                player.MailBoxs.Remove(mail);
                DbInterface.GetPlayerContext().Player_MailBox.Remove(mail);
                PacketSender.SendOpenMailBox(player);
                DbInterface.SavePlayerDatabaseAsync();
                player.CloseMailBox();
                return;
            }
            Item item = new Item(mail.ItemId, mail.Quantity, false);
            item.StatBuffs = mail.StatBuffs;
            if (player.TryGiveItem(item))
            {
                var it = ItemBase.Get(mail.ItemId);
                player.MailBoxs.Remove(mail);
                DbInterface.GetPlayerContext().Player_MailBox.Remove(mail);
                PacketSender.SendChatMsg(player, $"{Strings.Mails.receiveitem} ({it?.Name})!", CustomColors.Chat.PartyChat);
                PacketSender.SendOpenMailBox(player);
                DbInterface.SavePlayerDatabaseAsync();
                player.CloseMailBox();
            }
            else
            {
                PacketSender.SendChatMsg(player, Strings.Mails.inventoryfull, CustomColors.Alerts.Declined);
            }

        }

        // HDV
        public void HandlePacket(Client client, Player player, CloseHDVPacket packet)
        {
            if (player == null)
            {
                return;
            }
            if (player.InHDV)
            {
                player.InHDV = false;
                player.HdvID = Guid.Empty;
            }
        }
        public void HandlePacket(Client client, Player player, ActionHDVPacket packet)
        {
            if (player == null || player.HdvID == Guid.Empty || !player.InHDV)
            {
                return;
            }
            HDVBase hdbBase = HDVBase.Get(player.HdvID);
            if (hdbBase == null)
            {
                PacketSender.SendChatMsg(player, "Can't find Auction House!", CustomColors.Alerts.Declined);
                return;
            }
            HDV hdvItem = HDV.Get(packet.HdvItemId);
            if (hdvItem != null)
            {
                Guid id = hdvItem.Id;
                switch (packet.Action)
                {
                    case -1:
                        if (hdvItem.SellerId == player.Id)
                        {
                            Item nItem = new Item(hdvItem.ItemId, hdvItem.Quantity, false);
                            nItem.StatBuffs = hdvItem.StatBuffs;

                            if (player.TryGiveItem(nItem))
                            {
                                HDV.Remove(hdvItem);
                                PacketSender.SendChatMsg(player, "You have received your item(s)", CustomColors.Alerts.Accepted);
                                PacketSender.SendRemoveHDVItem(player, id);
                                DbInterface.SavePlayerDatabaseAsync();
                            }
                            else
                            {
                                PacketSender.SendChatMsg(player, "Not enough room to receive item(s)", CustomColors.Alerts.Declined);
                            }
                        }
                        return;
                    case 0:
                    case 1:
                        int price = hdvItem.Price;

                        //int currencySlot = player.FindItem(hdbBase.Currency.Id, hdvItem.Quantity);
                        //if (currencySlot > -1 && player.TakeItemsBySlot(currencySlot, hdvItem.Quantity))
                        var currencySlot = ItemBase.Get(hdbBase.Currency.Id);
                        var itemSlot = player.FindInventoryItemSlot(currencySlot.Id);
                        if (itemSlot != null && player.TryTakeItem(itemSlot, hdvItem.Price))
                        {
                            var seller = DbInterface.GetPlayer(hdvItem.SellerId);

                            player.MailBoxs.Add(new MailBox(seller, player, hdbBase.Name, "Auction House item bought: ", hdvItem.ItemId, hdvItem.Quantity, hdvItem.StatBuffs));

                            seller.MailBoxs.Add(new MailBox(player, seller, hdbBase.Name, "Auction House item sold: ", hdbBase.Currency.Id, price,
                                new int[(int)Enums.Stats.StatCount]));

                            ItemBase item = ItemBase.Get(hdvItem.ItemId);

                            PacketSender.SendChatMsg(player, "Your purchase has been mailed to you", CustomColors.Alerts.Accepted);

                            if (Globals.OnlineList.Select(p => p.Id == seller.Id) != null)
                            {
                                PacketSender.SendChatMsg(seller, $"You sold {item.Name}", CustomColors.Alerts.Accepted);
                            }

                            PacketSender.SendRemoveHDVItem(player, id);
                            HDV.Remove(hdvItem);
                            DbInterface.SavePlayerDatabaseAsync();
                        }
                        else
                        {
                            PacketSender.SendChatMsg(player, $"You don't have enough {hdbBase.Currency.Name} to buy this item.", CustomColors.Alerts.Declined);
                        }
                        return;
                }
            }

        }
        public void HandlePacket(Client client, Player player, AddHDVPacket packet)
        {
            if (player == null || player.HdvID == Guid.Empty || !player.InHDV)
            {
                return;
            }
            int slotID = packet.Slot;
            if (slotID >= player.Items.Count)
            {
                return;
            }
            HDVBase hdbBase = HDVBase.Get(player.HdvID);
            if (hdbBase == null)
            {
                PacketSender.SendChatMsg(player, "Can't find Auction House!", CustomColors.Alerts.Declined);
                return;
            }
            var totalAHitems = HDV.List(player.HdvID).ToArray<HDV>();
            if (totalAHitems.Length >= 255)
            {
                PacketSender.SendChatMsg(player, "The Auction House reached the maximum amount of items!", CustomColors.Alerts.Declined);
                return;
            }

            if (slotID >= 0)
            {
                InventorySlot slot = player.Items[slotID];
                if (slot.ItemId != Guid.Empty)
                {
                    if (slot.Descriptor.Bound)
                    {
                        PacketSender.SendChatMsg(player, $"Can't sell bound items!", CustomColors.Alerts.Declined);
                        return;
                    }
                    if (hdbBase.isWhiteList)
                    {
                        if (hdbBase.ItemListed.Contains(slot.ItemId) == false)
                        {
                            PacketSender.SendChatMsg(player, $"The Auction House does not accept this item!", CustomColors.Alerts.Declined);
                            return;
                        }
                    }
                    else
                    {
                        if (hdbBase.ItemListed.Contains(slot.ItemId))
                        {
                            PacketSender.SendChatMsg(player, $"The Auction House does not accept this item!", CustomColors.Alerts.Declined);
                            return;
                        }
                    }


                    if (packet.Price <= 0)
                    {
                        // Erreur de prix
                        PacketSender.SendChatMsg(player, "Invalid Price!", CustomColors.Alerts.Declined);
                        return;
                    }
                    Guid itemID = slot.ItemId;

                    if (itemID == hdbBase.CurrencyId)
                    {
                        PacketSender.SendChatMsg(player, $"The Auction House does not accept this item!", CustomColors.Alerts.Declined);
                        return;
                    }

                    int[] statBuffs = packet.StatBuffs;
                    double expireTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    if (player.TryTakeItem(slot, packet.Quantity))
                    {
                        if (packet.Expires == 0)
                        {
                            expireTime = expireTime + 21600000;
                        }
                        if (packet.Expires == 1)
                        {
                            expireTime = expireTime + 43200000;
                        }
                        if (packet.Expires == 2)
                        {
                            expireTime = expireTime + 86400000;
                        }
                        HDV nHDV = new HDV(player.HdvID, player.Id, itemID, packet.Quantity, statBuffs, packet.Price, expireTime);
                        DbInterface.GetPlayerContext().HDV.Add(nHDV);
                        PacketSender.SendChatMsg(player, "Your item is succesfully listed", CustomColors.Alerts.Accepted);
                        PacketSender.SendAddHDVItem(player, player.HdvID, nHDV);
                        PacketSender.SendInventory(player);
                        DbInterface.SavePlayerDatabaseAsync();
                    }
                    else
                    {
                        PacketSender.SendChatMsg(player, "Can't sell this item!", CustomColors.Alerts.Declined);
                    }
                }
                else
                {
                    PacketSender.SendChatMsg(player, "Can't find item!", CustomColors.Alerts.Declined);
                }
            }
            else
            {
                PacketSender.SendChatMsg(player, "Can't find item in your inventory!", CustomColors.Alerts.Declined);
            }
        }

        //SendCreateGuildPacket
        public void HandlePacket(Client client, Player player, SendCreateGuildPacket packet)
        {
            var GuildName = DbInterface.CheckGuildName(packet.Name);
            var GuildTag = DbInterface.CheckGuildTag(packet.Tag);

            if (packet.Name.Trim().Length < 4 || packet.Name.Trim().Length > 20)
            {
                PacketSender.SendChatMsg(player, "Guildname has to be between 4 and 20 characters!", CustomColors.Alerts.Declined);
                return;
            }

            if (packet.Tag.Trim().Length < 3 || packet.Tag.Trim().Length > 4)
            {
                PacketSender.SendChatMsg(player, "Guildname has to be between 3 and 4 characters!", CustomColors.Alerts.Declined);
                return;
            }

            if (!GuildName)
            {
                PacketSender.SendChatMsg(player, "Guildname is already taken, try again!", CustomColors.Alerts.Declined);
                player.CloseGuildCreate();
                return;
            }
            if (!GuildTag)
            {
                PacketSender.SendChatMsg(player, "Guildtag is already taken, try again!", CustomColors.Alerts.Declined);
                player.CloseGuildCreate();
                return;
            }
            var GuildCreateItem = ItemBase.Get(player.CreateGuildItem);
            var itemSlot = player.FindInventoryItemSlot(GuildCreateItem.Id);
            if (itemSlot != null && player.TryTakeItem(itemSlot, 1))
            {
                DbInterface.CreateGuild(player, packet.Name, packet.Tag);
                player.CloseGuildCreate();
            }

        }

        //PartyInviteResponsePacket
        public void HandlePacket(Client client, Player player, PartyInviteResponsePacket packet)
        {
            if (player == null)
            {
                return;
            }

            var leader = packet.PartyId;
            if (player.PartyRequester != null && player.PartyRequester.Id == leader)
            {
                if (packet.AcceptingInvite)
                {
                    if (player.PartyRequester.IsValidPlayer)
                    {
                        player.PartyRequester.AddParty(player);
                    }
                }
                else
                {
                    PacketSender.SendChatMsg(
                        player.PartyRequester, Strings.Parties.declined.ToString(client.Entity.Name),
                        CustomColors.Alerts.Declined
                    );

                    if (player.PartyRequests.ContainsKey(player.PartyRequester))
                    {
                        player.PartyRequests[player.PartyRequester] = Globals.Timing.TimeMs + Options.RequestTimeout;
                    }
                    else
                    {
                        player.PartyRequests.Add(player.PartyRequester, Globals.Timing.TimeMs + Options.RequestTimeout);
                    }
                }

                player.PartyRequester = null;
            }
        }

        //PartyKickPacket
        public void HandlePacket(Client client, Player player, PartyKickPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.KickParty(packet.TargetId);
        }

        //PartyLeavePacket
        public void HandlePacket(Client client, Player player, PartyLeavePacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.LeaveParty();
        }

        //GuildLeavePacket
        public void HandlePacket(Client client, Player player, GuildLeavePacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.Guild.Leave(player);
        }

        //RequestGuildInfoPacket
        public void HandlePacket(Client client, Player player, RequestGuildInfoPacket packet)
        {
            if (player == null)
            {
                return;
            }

            PacketSender.SendGuildData(player);
        }

        //QuestResponsePacket
        public void HandlePacket(Client client, Player player, QuestResponsePacket packet)
        {
            if (player == null)
            {
                return;
            }

            if (packet.AcceptingQuest)
            {
                player.AcceptQuest(packet.QuestId);
            }
            else
            {
                player.DeclineQuest(packet.QuestId);
            }
        }

        //QuestTaskKeyPressed
        public void HandlePacket(Client client, Player player, QuestTaskKeyPressed packet)
        {
            if (player == null)
            {
                return;
            }

            foreach (var questProgress in player.Quests)
            {
                var questId = questProgress.QuestId;
                var quest = QuestBase.Get(questId);
                if (quest != null)
                {
                    if (questProgress.TaskId != Guid.Empty)
                    {
                        //Assume this quest is in progress. See if we can find the task in the quest
                        var questTask = quest.FindTask(questProgress.TaskId);
                        if (questTask != null)
                        {
                            if (questTask.Objective == QuestObjective.PressKey)
                            {
                                if (questTask.KeyPressed  == packet.Key)
                                {
                                    player.CompleteQuestTask(questId, questProgress.TaskId);
                                }
                            }
                        }
                    }
                }
            }
        }

        //AbandonQuestPacket
        public void HandlePacket(Client client, Player player, AbandonQuestPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player.CancelQuest(packet.QuestId);
        }

        //AcceptQuestRewardPacket
        public void HandlePacket(Client client, Player player, AcceptQuestRewardPacket packet)
        {
            if (player == null)
            {
                return;
            }


            var quest = QuestBase.Get(packet.QuestId);
            var questTask = quest.FindTask(packet.TaskId);

            foreach (var questProgress in player.Quests)
            {
                if (questProgress.QuestId == packet.QuestId)
                {
                    if (questTask.HasChoice)
                    {
                        if (packet.Choice <= questTask.mTargets.Count)
                        {
                            if (player.TryGiveItem(questTask.mTargets[packet.Choice], questTask.mTargetsQuantity[packet.Choice]))
                            {
                                if (questTask.Experience > 0)
                                {
                                    player.GiveExperience(questTask.Experience);
                                }
                                if (questTask.TradeskillAmount > 0)
                                {
                                    player.GiveTradeSkillExperience(questTask.Tradeskill, questTask.TradeskillAmount);
                                }
                                player.CompleteQuestTask(packet.QuestId, packet.TaskId);
                            }
                        }
                    }
                    else
                    {
                        for (var i = 0; i < questTask.mTargets.Count; i++)
                        {
                            player.TryGiveItem(questTask.mTargets[i], questTask.mTargetsQuantity[i], ItemHandling.Overflow);
                            if (i == questTask.mTargets.Count - 1)
                            {
                                if (questTask.Experience > 0)
                                {
                                    player.GiveExperience(questTask.Experience);
                                }
                                if (questTask.TradeskillAmount > 0)
                                {
                                    player.GiveTradeSkillExperience(questTask.Tradeskill, questTask.TradeskillAmount);
                                }
                                player.CompleteQuestTask(packet.QuestId, packet.TaskId);
                            }
                        }
                    }
                }
            }
        }

        //TradeRequestPacket
        public void HandlePacket(Client client, Player player, TradeRequestPacket packet)
        {
            if (player == null)
            {
                return;
            }

            var target = Player.FindOnline(packet.TargetId);

            if (target != null && target.Id != player.Id && player.InRangeOf(target, Options.TradeRange))
            {
                if (player.InRangeOf(target, Options.TradeRange))
                {
                    target.InviteToTrade(player);

                    return;
                }
            }

            //Player Out of Range Or Offline
            PacketSender.SendChatMsg(player, Strings.Trading.outofrange.ToString(), CustomColors.Combat.NoTarget);
        }

        //TradeRequestResponsePacket
        public void HandlePacket(Client client, Player player, TradeRequestResponsePacket packet)
        {
            if (player == null)
            {
                return;
            }

            var target = packet.TradeId;
            if (player.Trading.Requester != null && player.Trading.Requester.Id == target)
            {
                if (player.Trading.Requester.IsValidPlayer)
                {
                    if (packet.AcceptingInvite)
                    {
                        if (player.Trading.Requester.Trading.Counterparty == null
                        ) //They could have accepted another trade since.
                        {
                            if (player.InRangeOf(player.Trading.Requester, Options.TradeRange))
                            {
                                //Check if still in range lolz
                                player.Trading.Requester.StartTrade(player);
                            }
                            else
                            {
                                PacketSender.SendChatMsg(
                                    player, Strings.Trading.outofrange.ToString(), CustomColors.Combat.NoTarget
                                );
                            }
                        }
                        else
                        {
                            PacketSender.SendChatMsg(
                                player, Strings.Trading.busy.ToString(player.Trading.Requester.Name), Color.Red
                            );
                        }
                    }
                    else
                    {
                        PacketSender.SendChatMsg(
                            player.Trading.Requester, Strings.Trading.declined.ToString(player.Name),
                            CustomColors.Alerts.Declined
                        );

                        if (player.Trading.Requests.ContainsKey(player.Trading.Requester))
                        {
                            player.Trading.Requests[player.Trading.Requester] =
                                Globals.Timing.TimeMs + Options.RequestTimeout;
                        }
                        else
                        {
                            player.Trading.Requests.Add(
                                player.Trading.Requester, Globals.Timing.TimeMs + Options.RequestTimeout
                            );
                        }
                    }
                }
            }

            player.Trading.Requester = null;
        }

        //OfferTradeItemPacket
        public void HandlePacket(Client client, Player player, [NotNull] OfferTradeItemPacket packet)
        {
            player?.OfferItem(packet.Slot, packet.Quantity);
        }

        //RevokeTradeItemPacket
        public void HandlePacket(Client client, Player player, [NotNull] RevokeTradeItemPacket packet)
        {
            player?.RevokeItem(packet.Slot, packet.Quantity);
        }

        //AcceptTradePacket
        public void HandlePacket(Client client, Player player, AcceptTradePacket packet)
        {
            if (player == null || player.Trading.Counterparty == null)
            {
                return;
            }

            player.Trading.Accepted = true;
            if (player.Trading.Counterparty.Trading.Accepted)
            {
                var t = new Item[Options.MaxInvItems];

                //Swap the trade boxes over, then return the trade boxes to their new owners!
                t = player.Trading.Offer;
                player.Trading.Offer = player.Trading.Counterparty.Trading.Offer;
                player.Trading.Counterparty.Trading.Offer = t;
                player.Trading.Counterparty.ReturnTradeItems();
                player.ReturnTradeItems();

                PacketSender.SendChatMsg(player, Strings.Trading.accepted, CustomColors.Alerts.Accepted);
                PacketSender.SendChatMsg(
                    player.Trading.Counterparty, Strings.Trading.accepted, CustomColors.Alerts.Accepted
                );

                PacketSender.SendTradeClose(player.Trading.Counterparty);
                PacketSender.SendTradeClose(player);
                player.Trading.Counterparty.Trading.Counterparty = null;
                player.Trading.Counterparty = null;
            }
        }

        //DeclineTradePacket
        public void HandlePacket(Client client, Player player, DeclineTradePacket packet)
        {
            if (player == null)
            {
                return;
            }

            player?.CancelTrade();
        }

        //CloseBagPacket
        public void HandlePacket(Client client, Player player, CloseBagPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player?.CloseBag();
        }

        //StoreBagItemPacket
        public void HandlePacket(Client client, Player player, StoreBagItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player?.StoreBagItem(packet.Slot, packet.Quantity);
        }

        //RetrieveBagItemPacket
        public void HandlePacket(Client client, Player player, RetrieveBagItemPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player?.RetrieveBagItem(packet.Slot, packet.Quantity);
        }

        //SwapBagItemPacket
        public void HandlePacket(Client client, Player player, SwapBagItemsPacket packet)
        {
            if (player == null)
            {
                return;
            }

            player?.SwapBagItems(packet.Slot1, packet.Slot2);
        }

        //RequestFriendsPacket
        public void HandlePacket(Client client, Player player, RequestFriendsPacket packet)
        {
            if (player == null)
            {
                return;
            }

            PacketSender.SendFriends(player);
        }

        //UpdateFriendsPacket
        public void HandlePacket(Client client, Player player, UpdateFriendsPacket packet)
        {
            if (player == null)
            {
                return;
            }

            if (packet.Adding)
            {
                //Don't add yourself!
                if (packet.Name.ToLower() == client.Entity.Name.ToLower())
                {
                    return;
                }

                var character = DbInterface.GetPlayer(packet.Name);
                if (character != null)
                {
                    if (!client.Entity.HasFriend(character))
                    {
                        var target = Player.FindOnline(packet.Name);
                        if (target != null)
                        {
                            target.FriendRequest(client.Entity);
                        }
                        else
                        {
                            PacketSender.SendChatMsg(player, Strings.Player.offline, CustomColors.Alerts.Error);
                        }
                    }
                    else
                    {
                        PacketSender.SendChatMsg(
                            player, Strings.Friends.alreadyfriends.ToString(packet.Name), CustomColors.Alerts.Info
                        );
                    }
                }
            }
            else
            {
                var charId = DbInterface.GetCharacterId(packet.Name);

                if (charId != null)
                {
                    var character = DbInterface.GetPlayer((Guid) charId);
                    if (character != null && client.Entity.HasFriend(character))
                    {
                        player.RemoveFriend(character);
                        character.RemoveFriend(player);
                        PacketSender.SendChatMsg(player, Strings.Friends.remove, CustomColors.Alerts.Declined);
                        PacketSender.SendFriends(player);
                        if (character.Client != null)
                        {
                            PacketSender.SendFriends(character);
                        }
                    }
                }
            }
        }

        //FriendRequestResponsePacket
        public void HandlePacket(Client client, Player player, FriendRequestResponsePacket packet)
        {
            if (player == null)
            {
                return;
            }

            var target = Player.FindOnline(packet.FriendId);

            if (target == null || target.Id == player.Id)
            {
                return;
            }

            if (packet.AcceptingRequest)
            {
                if (!player.HasFriend(target)) // Incase one user deleted friend then re-requested
                {
                    player.AddFriend(target);
                    PacketSender.SendChatMsg(
                        player, Strings.Friends.notification.ToString(target.Name), CustomColors.Alerts.Accepted
                    );

                    PacketSender.SendFriends(player);
                }

                if (!target.HasFriend(player)) // Incase one user deleted friend then re-requested
                {
                    target.AddFriend(player);
                    PacketSender.SendChatMsg(
                        target, Strings.Friends.accept.ToString(player.Name), CustomColors.Alerts.Accepted
                    );

                    PacketSender.SendFriends(target);
                }
            }
            else
            {
                if (player.FriendRequester == target)
                {
                    if (player.FriendRequester.IsValidPlayer)
                    {
                        if (player.FriendRequests.ContainsKey(player.FriendRequester))
                        {
                            player.FriendRequests[player.FriendRequester] =
                                Globals.Timing.TimeMs + Options.RequestTimeout;
                        }
                        else
                        {
                            player.FriendRequests.Add(
                                client.Entity.FriendRequester, Globals.Timing.TimeMs + Options.RequestTimeout
                            );
                        }
                    }

                    player.FriendRequester = null;
                }
            }
        }

        //SelectCharacterPacket
        public void HandlePacket(Client client, Player player, SelectCharacterPacket packet)
        {
            if (client.User == null) return;
            var character = DbInterface.GetUserCharacter(client.User, packet.CharacterId);
            if (character != null)
            {
                client.LoadCharacter(character);
                try
                {
                    client.Entity?.SetOnline();
                    PacketSender.SendJoinGame(client);
                }
                catch (Exception exception)
                {
                    Log.Warn(exception);
                    PacketSender.SendError(client, Strings.Account.loadfail);
                    client.Logout();
                }
            }
        }

        //DeleteCharacterPacket
        public void HandlePacket(Client client, Player player, DeleteCharacterPacket packet)
        {
            if (client.User == null) return;
            var character = DbInterface.GetUserCharacter(client.User, packet.CharacterId);
            if (character != null)
            {
                foreach (var chr in client.Characters.ToArray())
                {
                    if (chr.Id == packet.CharacterId)
                    {
                        DbInterface.DeleteCharacter(client.User, chr);
                    }
                }
            }

            PacketSender.SendError(client, Strings.Account.deletechar, Strings.Account.deleted);
            PacketSender.SendPlayerCharacters(client);
        }

        //NewCharacterPacket
        public void HandlePacket(Client client, Player player, NewCharacterPacket packet)
        {
            if (client?.Characters?.Count < Options.MaxCharacters)
            {
                PacketSender.SendGameObjects(client, GameObjectType.Class);
                PacketSender.SendCreateCharacter(client);
            }
            else
            {
                PacketSender.SendError(client, Strings.Account.maxchars);
            }
        }

        //RequestPasswordResetPacket
        public void HandlePacket(Client client, Player player, RequestPasswordResetPacket packet)
        {
            if (client.TimeoutMs > Globals.Timing.TimeMs)
            {
                PacketSender.SendError(client, Strings.Errors.errortimeout);
                client.ResetTimeout();

                return;
            }

            if (Options.Instance.SmtpValid)
            {
                //Find account with that name or email
                var userName = DbInterface.UsernameFromEmail(packet.NameOrEmail);
                if (string.IsNullOrEmpty(userName))
                {
                    userName = packet.NameOrEmail;
                }

                if (DbInterface.AccountExists(userName))
                {
                    //Send reset email
                    var user = DbInterface.GetUser(userName);
                    var email = new PasswordResetEmail(user);
                    email.Send();
                }
                else
                {
                    client.FailedAttempt();
                }
            }
            else
            {
                client.FailedAttempt();
            }
        }

        //ResetPasswordPacket
        public void HandlePacket(Client client, Player player, ResetPasswordPacket packet)
        {
            //Find account with that name or email
            var success = false;
            var userName = DbInterface.UsernameFromEmail(packet.NameOrEmail);
            if (string.IsNullOrEmpty(userName))
            {
                userName = packet.NameOrEmail;
            }

            if (DbInterface.AccountExists(userName))
            {
                //Reset Password
                var user = DbInterface.GetUser(userName);
                if (user.PasswordResetCode.ToLower().Trim() == packet.ResetCode.ToLower().Trim() &&
                    user.PasswordResetTime > DateTime.UtcNow)
                {
                    user.PasswordResetCode = "";
                    user.PasswordResetTime = DateTime.MinValue;
                    DbInterface.ResetPass(user, packet.NewPassword);
                    success = true;
                }
            }

            PacketSender.SendPasswordResetResult(client, success);
        }

        #endregion

        #region "Editor Packets"

        //PingPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.PingPacket packet)
        {
        }

        //LoginPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.LoginPacket packet)
        {
            if (client.AccountAttempts > 3 && client.TimeoutMs > Globals.Timing.TimeMs)
            {
                PacketSender.SendError(client, Strings.Errors.errortimeout);
                client.ResetTimeout();

                return;
            }

            client.ResetTimeout();

            if (!DbInterface.AccountExists(packet.Username))
            {
                client.FailedAttempt();
                PacketSender.SendError(client, Strings.Account.badlogin);

                return;
            }

            if (!DbInterface.CheckPassword(packet.Username, packet.Password))
            {
                client.FailedAttempt();
                PacketSender.SendError(client, Strings.Account.badlogin);

                return;
            }

            if (!DbInterface.CheckAccess(packet.Username).Editor)
            {
                client.FailedAttempt();
                PacketSender.SendError(client, Strings.Account.badaccess);

                return;
            }

            client.IsEditor = true;
            var sw = new Stopwatch();
            sw.Start();
            DbInterface.LoadUser(client, packet.Username);
            sw.Stop();
            Log.Debug("Took " + sw.ElapsedMilliseconds + "ms to load player from db!");
            lock (Globals.ClientLock)
            {
                var clients = Globals.Clients.ToArray();
                foreach (var user in clients)
                {
                    if (user.Name != null &&
                        user.Name.ToLower() == packet.Username.ToLower() &&
                        user != client &&
                        user.IsEditor)
                    {
                        user.Disconnect();
                    }
                }
            }

            PacketSender.SendServerConfig(client);
            PacketSender.SendJoinGame(client);
            PacketSender.SendTimeBaseTo(client);
            PacketSender.SendMapList(client);
        }

        //MapPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.MapUpdatePacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            var map = MapInstance.Get(packet.MapId);

            if (map == null)
            {
                return;
            }

            map.Load(packet.JsonData, MapInstance.Get(packet.MapId).Revision + 1);
            MapList.List.UpdateMap(packet.MapId);

            //Event Fixing
            var removedEvents = new List<Guid>();
            foreach (var id in map.EventIds)
            {
                if (!map.LocalEvents.ContainsKey(id))
                {
                    var evt = EventBase.Get(id);
                    if (evt != null)
                    {
                        DbInterface.DeleteGameObject(evt);
                    }

                    removedEvents.Add(id);
                }
            }

            foreach (var id in removedEvents)
            {
                map.EventIds.Remove(id);
            }

            foreach (var evt in map.LocalEvents)
            {
                var dbObj = EventBase.Get(evt.Key);
                if (dbObj == null)
                {
                    dbObj = (EventBase) DbInterface.AddGameObject(GameObjectType.Event, evt.Key);
                }

                dbObj.Load(evt.Value.JsonData);
                if (!map.EventIds.Contains(evt.Key))
                {
                    map.EventIds.Add(evt.Key);
                }
            }

            map.LocalEvents.Clear();

            if (packet.TileData != null && map.TileData != null)
            {
                map.TileData = packet.TileData;
            }

            map.AttributeData = packet.AttributeData;

            DbInterface.SaveGameDatabase();
            map.Initialize();
            var players = new List<Player>();
            foreach (var surrMap in map.GetSurroundingMaps(true))
            {
                players.AddRange(surrMap.GetPlayersOnMap().ToArray());
            }

            foreach (var plyr in players)
            {
                plyr.Warp(plyr.MapId, (byte) plyr.X, (byte) plyr.Y, (byte) plyr.Dir, false, (byte) plyr.Z, true);
                PacketSender.SendMap(plyr.Client, packet.MapId);
            }

            PacketSender.SendMap(client, packet.MapId, true); //Sends map to everyone/everything in proximity
            PacketSender.SendMapListToAll();
        }

        //CreateMapPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.CreateMapPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            lock (ServerLoop.Lock)
            {
                var newMap = Guid.Empty;
                var tmpMap = new MapInstance(true);
                if (!packet.AttachedToMap)
                {
                    var destType = (int) packet.MapListParentType;
                    newMap = DbInterface.AddGameObject(GameObjectType.Map).Id;
                    tmpMap = MapInstance.Get(newMap);
                    DbInterface.GenerateMapGrids();
                    PacketSender.SendMap(client, newMap, true);
                    PacketSender.SendMapGridToAll(tmpMap.MapGrid);

                    //FolderDirectory parent = null;
                    destType = -1;
                    if (destType == -1)
                    {
                        MapList.List.AddMap(newMap, tmpMap.TimeCreated, MapBase.Lookup);
                    }

                    DbInterface.SaveGameDatabase();
                    PacketSender.SendMapListToAll();
                    /*else if (destType == 0)
                    {
                        parent = Database.MapStructure.FindDir(bf.ReadInteger());
                        if (parent == null)
                        {
                            Database.MapStructure.AddMap(newMap);
                        }
                        else
                        {
                            parent.Children.AddMap(newMap);
                        }
                    }
                    else if (destType == 1)
                    {
                        var mapNum = bf.ReadInteger();
                        parent = Database.MapStructure.FindMapParent(mapNum, null);
                        if (parent == null)
                        {
                            Database.MapStructure.AddMap(newMap);
                        }
                        else
                        {
                            parent.Children.AddMap(newMap);
                        }
                    }*/
                }
                else
                {
                    var relativeMap = packet.MapId;
                    switch (packet.AttachDir)
                    {
                        case 0:
                            if (MapInstance.Get(MapInstance.Get(relativeMap).Up) == null)
                            {
                                newMap = DbInterface.AddGameObject(GameObjectType.Map).Id;
                                tmpMap = MapInstance.Get(newMap);
                                tmpMap.MapGrid = MapInstance.Get(relativeMap).MapGrid;
                                tmpMap.MapGridX = MapInstance.Get(relativeMap).MapGridX;
                                tmpMap.MapGridY = MapInstance.Get(relativeMap).MapGridY - 1;
                                MapInstance.Get(relativeMap).Up = newMap;
                            }

                            break;

                        case 1:
                            if (MapInstance.Get(MapInstance.Get(relativeMap).Down) == null)
                            {
                                newMap = DbInterface.AddGameObject(GameObjectType.Map).Id;
                                tmpMap = MapInstance.Get(newMap);
                                tmpMap.MapGrid = MapInstance.Get(relativeMap).MapGrid;
                                tmpMap.MapGridX = MapInstance.Get(relativeMap).MapGridX;
                                tmpMap.MapGridY = MapInstance.Get(relativeMap).MapGridY + 1;
                                MapInstance.Get(relativeMap).Down = newMap;
                            }

                            break;

                        case 2:
                            if (MapInstance.Get(MapInstance.Get(relativeMap).Left) == null)
                            {
                                newMap = DbInterface.AddGameObject(GameObjectType.Map).Id;
                                tmpMap = MapInstance.Get(newMap);
                                tmpMap.MapGrid = MapInstance.Get(relativeMap).MapGrid;
                                tmpMap.MapGridX = MapInstance.Get(relativeMap).MapGridX - 1;
                                tmpMap.MapGridY = MapInstance.Get(relativeMap).MapGridY;
                                MapInstance.Get(relativeMap).Left = newMap;
                            }

                            break;

                        case 3:
                            if (MapInstance.Get(MapInstance.Get(relativeMap).Right) == null)
                            {
                                newMap = DbInterface.AddGameObject(GameObjectType.Map).Id;
                                tmpMap = MapInstance.Get(newMap);
                                tmpMap.MapGrid = MapInstance.Get(relativeMap).MapGrid;
                                tmpMap.MapGridX = MapInstance.Get(relativeMap).MapGridX + 1;
                                tmpMap.MapGridY = MapInstance.Get(relativeMap).MapGridY;
                                MapInstance.Get(relativeMap).Right = newMap;
                            }

                            break;
                    }

                    if (newMap != Guid.Empty)
                    {
                        var grid = DbInterface.GetGrid(tmpMap.MapGrid);
                        if (tmpMap.MapGridX >= 0 && tmpMap.MapGridX < grid.Width)
                        {
                            if (tmpMap.MapGridY + 1 < grid.Height)
                            {
                                tmpMap.Down = grid.MyGrid[tmpMap.MapGridX, tmpMap.MapGridY + 1];

                                if (tmpMap.Down != Guid.Empty)
                                {
                                    MapInstance.Get(tmpMap.Down).Up = newMap;
                                }
                            }

                            if (tmpMap.MapGridY - 1 >= 0)
                            {
                                tmpMap.Up = grid.MyGrid[tmpMap.MapGridX, tmpMap.MapGridY - 1];

                                if (tmpMap.Up != Guid.Empty)
                                {
                                    MapInstance.Get(tmpMap.Up).Down = newMap;
                                }
                            }
                        }

                        if (tmpMap.MapGridY >= 0 && tmpMap.MapGridY < grid.Height)
                        {
                            if (tmpMap.MapGridX - 1 >= 0)
                            {
                                tmpMap.Left = grid.MyGrid[tmpMap.MapGridX - 1, tmpMap.MapGridY];

                                if (tmpMap.Left != Guid.Empty)
                                {
                                    MapInstance.Get(tmpMap.Left).Right = newMap;
                                }
                            }

                            if (tmpMap.MapGridX + 1 < grid.Width)
                            {
                                tmpMap.Right = grid.MyGrid[tmpMap.MapGridX + 1, tmpMap.MapGridY];

                                if (tmpMap.Right != Guid.Empty)
                                {
                                    MapInstance.Get(tmpMap.Right).Left = newMap;
                                }
                            }
                        }

                        DbInterface.SaveGameDatabase();
                        DbInterface.GenerateMapGrids();
                        PacketSender.SendMap(client, newMap, true);
                        PacketSender.SendMapGridToAll(MapInstance.Get(newMap).MapGrid);
                        PacketSender.SendEnterMap(client, newMap);
                        var folderDir = MapList.List.FindMapParent(relativeMap, null);
                        if (folderDir != null)
                        {
                            folderDir.Children.AddMap(newMap, MapInstance.Get(newMap).TimeCreated, MapBase.Lookup);
                        }
                        else
                        {
                            MapList.List.AddMap(newMap, MapInstance.Get(newMap).TimeCreated, MapBase.Lookup);
                        }

                        DbInterface.SaveGameDatabase();
                        PacketSender.SendMapListToAll();
                    }
                }
            }
        }

        //MapListUpdatePacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.MapListUpdatePacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            MapListFolder parent = null;
            var mapId = Guid.Empty;
            switch (packet.UpdateType)
            {
                case MapListUpdates.MoveItem:
                    MapList.List.HandleMove(packet.TargetType, packet.TargetId, packet.ParentType, packet.ParentId);

                    break;
                case MapListUpdates.AddFolder:
                    if (packet.ParentId == Guid.Empty)
                    {
                        MapList.List.AddFolder(Strings.Mapping.newfolder);
                    }
                    else if (packet.ParentType == 0)
                    {
                        parent = MapList.List.FindDir(packet.ParentId);
                        if (parent == null)
                        {
                            MapList.List.AddFolder(Strings.Mapping.newfolder);
                        }
                        else
                        {
                            parent.Children.AddFolder(Strings.Mapping.newfolder);
                        }
                    }
                    else if (packet.ParentType == 1)
                    {
                        mapId = packet.ParentId;
                        parent = MapList.List.FindMapParent(mapId, null);
                        if (parent == null)
                        {
                            MapList.List.AddFolder(Strings.Mapping.newfolder);
                        }
                        else
                        {
                            parent.Children.AddFolder(Strings.Mapping.newfolder);
                        }
                    }

                    break;
                case MapListUpdates.Rename:
                    if (packet.TargetType == 0)
                    {
                        parent = MapList.List.FindDir(packet.TargetId);
                        parent.Name = packet.Name;
                        PacketSender.SendMapListToAll();
                    }
                    else if (packet.TargetType == 1)
                    {
                        var mapListMap = MapList.List.FindMap(packet.TargetId);
                        mapListMap.Name = packet.Name;
                        MapInstance.Get(packet.TargetId).Name = packet.Name;
                        DbInterface.SaveGameDatabase();
                        PacketSender.SendMapListToAll();
                    }

                    break;
                case MapListUpdates.Delete:
                    if (packet.TargetType == 0)
                    {
                        MapList.List.DeleteFolder(packet.TargetId);
                        PacketSender.SendMapListToAll();
                    }
                    else if (packet.TargetType == 1)
                    {
                        if (MapInstance.Lookup.Count == 1)
                        {
                            PacketSender.SendError(client, Strings.Mapping.lastmaperror, Strings.Mapping.lastmap);

                            return;
                        }

                        lock (ServerLoop.Lock)
                        {
                            mapId = packet.TargetId;
                            var players = MapInstance.Get(mapId).GetPlayersOnMap();
                            MapList.List.DeleteMap(mapId);
                            DbInterface.DeleteGameObject(MapInstance.Get(mapId));
                            DbInterface.SaveGameDatabase();
                            DbInterface.GenerateMapGrids();
                            PacketSender.SendMapListToAll();
                            foreach (var plyr in players)
                            {
                                plyr.WarpToSpawn();
                            }
                        }

                        PacketSender.SendMapToEditors(mapId);
                    }

                    break;
            }

            PacketSender.SendMapListToAll();
            DbInterface.SaveGameDatabase();
        }

        //UnlinkMapPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.UnlinkMapPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            var mapId = packet.MapId;
            var curMapId = packet.CurrentMapId;
            var mapGrid = 0;
            if (MapInstance.Lookup.Keys.Contains(mapId))
            {
                if (client.IsEditor)
                {
                    lock (ServerLoop.Lock)
                    {
                        var map = MapInstance.Get(mapId);
                        if (map != null)
                        {
                            map.ClearConnections();

                            var grid = DbInterface.GetGrid(map.MapGrid);
                            var gridX = map.MapGridX;
                            var gridY = map.MapGridY;

                            //Up
                            if (gridY - 1 >= 0 && grid.MyGrid[gridX, gridY - 1] != Guid.Empty)
                            {
                                MapInstance.Get(grid.MyGrid[gridX, gridY - 1])?.ClearConnections((int) Directions.Down);
                            }

                            //Down
                            if (gridY + 1 < grid.Height && grid.MyGrid[gridX, gridY + 1] != Guid.Empty)
                            {
                                MapInstance.Get(grid.MyGrid[gridX, gridY + 1])?.ClearConnections((int) Directions.Up);
                            }

                            //Left
                            if (gridX - 1 >= 0 && grid.MyGrid[gridX - 1, gridY] != Guid.Empty)
                            {
                                MapInstance.Get(grid.MyGrid[gridX - 1, gridY])
                                    ?.ClearConnections((int) Directions.Right);
                            }

                            //Right
                            if (gridX + 1 < grid.Width && grid.MyGrid[gridX + 1, gridY] != Guid.Empty)
                            {
                                MapInstance.Get(grid.MyGrid[gridX + 1, gridY]).ClearConnections((int) Directions.Left);
                            }

                            DbInterface.GenerateMapGrids();
                            if (MapInstance.Lookup.Keys.Contains(curMapId))
                            {
                                mapGrid = MapInstance.Get(curMapId).MapGrid;
                            }
                        }

                        PacketSender.SendMapGridToAll(mapGrid);
                    }
                }
            }
        }

        //LinkMapPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.LinkMapPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            var adjacentMapId = packet.AdjacentMapId;
            var linkMapId = packet.LinkMapId;
            var adjacentMap = MapInstance.Get(packet.AdjacentMapId);
            var linkMap = MapInstance.Get(packet.LinkMapId);
            long gridX = packet.GridX;
            long gridY = packet.GridY;
            var canLink = true;

            lock (ServerLoop.Lock) 
            { 
                if (adjacentMap != null && linkMap != null)
                {
                    //Clear to test if we can link.
                    var linkGrid = DbInterface.GetGrid(linkMap.MapGrid);
                    var adjacentGrid = DbInterface.GetGrid(adjacentMap.MapGrid);
                    if (linkGrid != adjacentGrid && linkGrid != null && adjacentGrid != null)
                    {
                        var xOffset = linkMap.MapGridX - gridX;
                        var yOffset = linkMap.MapGridY - gridY;
                        for (var x = 0; x < adjacentGrid.Width; x++)
                        {
                            for (var y = 0; y < adjacentGrid.Height; y++)
                            {
                                if (x + xOffset >= 0 &&
                                    x + xOffset < linkGrid.Width &&
                                    y + yOffset >= 0 &&
                                    y + yOffset < linkGrid.Height)
                                {
                                    if (adjacentGrid.MyGrid[x, y] != Guid.Empty &&
                                        linkGrid.MyGrid[x + xOffset, y + yOffset] != Guid.Empty)
                                    {
                                        //Incompatible Link!
                                        PacketSender.SendError(client,
                                            Strings.Mapping.linkfailerror.ToString(
                                                MapBase.GetName(linkMapId), MapBase.GetName(adjacentMapId),
                                                MapBase.GetName(adjacentGrid.MyGrid[x, y]),
                                                MapBase.GetName(linkGrid.MyGrid[x + xOffset, y + yOffset])
                                            ), Strings.Mapping.linkfail
                                        );

                                        return;
                                    }
                                }
                            }
                        }

                        if (canLink)
                        {
                            for (var x = -1; x < adjacentGrid.Width + 1; x++)
                            {
                                for (var y = -1; y < adjacentGrid.Height + 1; y++)
                                {
                                    if (x + xOffset >= 0 &&
                                        x + xOffset < linkGrid.Width &&
                                        y + yOffset >= 0 &&
                                        y + yOffset < linkGrid.Height)
                                    {
                                        if (linkGrid.MyGrid[x + xOffset, y + yOffset] != Guid.Empty)
                                        {
                                            var inXBounds = x > -1 && x < adjacentGrid.Width;
                                            var inYBounds = y > -1 && y < adjacentGrid.Height;
                                            if (inXBounds && inYBounds)
                                            {
                                                adjacentGrid.MyGrid[x, y] = linkGrid.MyGrid[x + xOffset, y + yOffset];
                                            }

                                            if (inXBounds && y - 1 >= 0 && adjacentGrid.MyGrid[x, y - 1] != Guid.Empty)
                                            {
                                                MapInstance.Get(linkGrid.MyGrid[x + xOffset, y + yOffset]).Up = adjacentGrid.MyGrid[x, y - 1];

                                                MapInstance.Get(adjacentGrid.MyGrid[x, y - 1]).Down = linkGrid.MyGrid[x + xOffset, y + yOffset];
                                            }

                                            if (inXBounds && y + 1 < adjacentGrid.Height && adjacentGrid.MyGrid[x, y + 1] != Guid.Empty)
                                            {
                                                MapInstance.Get(linkGrid.MyGrid[x + xOffset, y + yOffset]).Down = adjacentGrid.MyGrid[x, y + 1];

                                                MapInstance.Get(adjacentGrid.MyGrid[x, y + 1]).Up = linkGrid.MyGrid[x + xOffset, y + yOffset];
                                            }

                                            if (inYBounds && x - 1 >= 0 && adjacentGrid.MyGrid[x - 1, y] != Guid.Empty)
                                            {
                                                MapInstance.Get(linkGrid.MyGrid[x + xOffset, y + yOffset]).Left = adjacentGrid.MyGrid[x - 1, y];

                                                MapInstance.Get(adjacentGrid.MyGrid[x - 1, y]).Right = linkGrid.MyGrid[x + xOffset, y + yOffset];
                                            }

                                            if (inYBounds && x + 1 < adjacentGrid.Width && adjacentGrid.MyGrid[x + 1, y] != Guid.Empty)
                                            {
                                                MapInstance.Get(linkGrid.MyGrid[x + xOffset, y + yOffset]).Right = adjacentGrid.MyGrid[x + 1, y];

                                                MapInstance.Get(adjacentGrid.MyGrid[x + 1, y]).Left = linkGrid.MyGrid[x + xOffset, y + yOffset];
                                            }
                                        }
                                    }
                                }
                            }

                            DbInterface.SaveGameDatabase();
                            DbInterface.GenerateMapGrids();
                            PacketSender.SendMapGridToAll(adjacentMap.MapGrid);
                        }
                    }
                }
            }
        }

        //CreateGameObjectPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.CreateGameObjectPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            var type = packet.Type;
            var obj = DbInterface.AddGameObject(type);
            if (type == GameObjectType.Event)
            {
                ((EventBase) obj).CommonEvent = true;
                DbInterface.SaveGameDatabase();
            }

            PacketSender.CacheGameDataPacket();
            PacketSender.SendGameObjectToAll(obj);
        }

        //RequestOpenEditorPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.RequestOpenEditorPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            var type = packet.Type;
            PacketSender.SendGameObjects(client, type);
            PacketSender.SendOpenEditor(client, type);
        }

        //DeleteGameObjectPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.DeleteGameObjectPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            var type = packet.Type;
            var id = packet.Id;

            // TODO: YO COME DO THIS
            IDatabaseObject obj = null;
            switch (type)
            {
                case GameObjectType.Animation:
                    obj = AnimationBase.Get(id);

                    break;
                case GameObjectType.Class:
                    if (ClassBase.Lookup.Count == 1)
                    {
                        PacketSender.SendError(client, Strings.Classes.lastclasserror, Strings.Classes.lastclass);

                        return;
                    }

                    obj = DatabaseObject<ClassBase>.Lookup.Get(id);

                    break;
                case GameObjectType.Item:
                    obj = ItemBase.Get(id);

                    break;
                case GameObjectType.Npc:
                    obj = NpcBase.Get(id);

                    break;
                case GameObjectType.Pet:
                    obj = PetBase.Get(id);

                    break;
                case GameObjectType.Projectile:
                    obj = ProjectileBase.Get(id);

                    break;
                case GameObjectType.Quest:
                    obj = QuestBase.Get(id);

                    break;
                case GameObjectType.Resource:
                    obj = ResourceBase.Get(id);

                    break;
                case GameObjectType.Shop:
                    obj = ShopBase.Get(id);

                    break;
                case GameObjectType.Spell:
                    obj = SpellBase.Get(id);

                    break;
                case GameObjectType.CraftTables:
                    obj = DatabaseObject<CraftingTableBase>.Lookup.Get(id);

                    break;
                case GameObjectType.Crafts:
                    obj = DatabaseObject<CraftBase>.Lookup.Get(id);

                    break;
                case GameObjectType.Map:
                    break;
                case GameObjectType.Event:
                    obj = EventBase.Get(id);

                    break;
                case GameObjectType.PlayerVariable:
                    obj = PlayerVariableBase.Get(id);

                    break;
                case GameObjectType.ServerVariable:
                    obj = ServerVariableBase.Get(id);

                    break;
                case GameObjectType.Tileset:
                    break;
                case GameObjectType.Time:
                    break;
                case GameObjectType.HDVs:
                    obj = HDVBase.Get(id);

                    break;
                case GameObjectType.DropPool:
                    obj = DropPoolBase.Get(id);

                    break;
                case GameObjectType.Tradeskill:
                    obj = TradeSkillBase.Get(id);

                    break;
                case GameObjectType.Behavior:
                    obj = BehaviorBase.Get(id);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (obj != null)
            {
                //if Item or Resource, kill all global entities of that kind
                if (type == GameObjectType.Item)
                {
                    Globals.KillItemsOf((ItemBase) obj);
                }
                else if (type == GameObjectType.Resource)
                {
                    Globals.KillResourcesOf((ResourceBase) obj);
                }
                else if (type == GameObjectType.Npc)
                {
                    Globals.KillNpcsOf((NpcBase)obj);
                }
                else if (type == GameObjectType.Pet)
                {
                    Globals.KillPetsOf((PetBase)obj);
                }

                DbInterface.DeleteGameObject(obj);
                DbInterface.SaveGameDatabase();
                PacketSender.CacheGameDataPacket();
                PacketSender.SendGameObjectToAll(obj, true);
            }
        }

        //SaveGameObjectPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.SaveGameObjectPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            var type = packet.Type;
            var id = packet.Id;
            IDatabaseObject obj = null;
            switch (type)
            {
                case GameObjectType.Animation:
                    obj = AnimationBase.Get(id);

                    break;
                case GameObjectType.Class:
                    obj = DatabaseObject<ClassBase>.Lookup.Get(id);

                    break;
                case GameObjectType.Item:
                    obj = ItemBase.Get(id);

                    break;
                case GameObjectType.Npc:
                    obj = NpcBase.Get(id);

                    break;
                case GameObjectType.Pet:
                    obj = PetBase.Get(id);

                    break;
                case GameObjectType.Projectile:
                    obj = ProjectileBase.Get(id);

                    break;
                case GameObjectType.Quest:
                    obj = QuestBase.Get(id);

                    break;
                case GameObjectType.Resource:
                    obj = ResourceBase.Get(id);

                    break;
                case GameObjectType.Shop:
                    obj = ShopBase.Get(id);

                    break;
                case GameObjectType.Spell:
                    obj = SpellBase.Get(id);

                    break;
                case GameObjectType.CraftTables:
                    obj = DatabaseObject<CraftingTableBase>.Lookup.Get(id);

                    break;
                case GameObjectType.Crafts:
                    obj = DatabaseObject<CraftBase>.Lookup.Get(id);

                    break;
                case GameObjectType.Map:
                    break;
                case GameObjectType.Event:
                    obj = EventBase.Get(id);

                    break;
                case GameObjectType.PlayerVariable:
                    obj = PlayerVariableBase.Get(id);

                    break;
                case GameObjectType.ServerVariable:
                    obj = ServerVariableBase.Get(id);

                    break;
                case GameObjectType.Tileset:
                    break;
                case GameObjectType.Time:
                    break;
                case GameObjectType.HDVs:
                    obj = HDVBase.Get(id);
                    break;
                case GameObjectType.DropPool:
                    obj = DropPoolBase.Get(id);
                    break;
                case GameObjectType.Tradeskill:
                    obj = TradeSkillBase.Get(id);
                    break;
                case GameObjectType.Behavior:
                    obj = BehaviorBase.Get(id);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (obj != null)
            {
                lock (ServerLoop.Lock)
                {
                    //if Item or Resource, kill all global entities of that kind
                    if (type == GameObjectType.Item)
                    {
                        Globals.KillItemsOf((ItemBase)obj);
                    }
                    else if (type == GameObjectType.Npc)
                    {
                        Globals.KillNpcsOf((NpcBase)obj);
                    }
                    else if (type == GameObjectType.Pet)
                    {
                        Globals.KillPetsOf((PetBase)obj);
                    }
                    else if (type == GameObjectType.Projectile)
                    {
                        Globals.KillProjectilesOf((ProjectileBase)obj);
                    }

                    obj.Load(packet.Data);

                    if (type == GameObjectType.Quest)
                    {
                        var qst = (QuestBase)obj;
                        foreach (var evt in qst.RemoveEvents)
                        {
                            var evtb = EventBase.Get(evt);
                            if (evtb != null)
                            {
                                DbInterface.DeleteGameObject(evtb);
                            }
                        }

                        foreach (var evt in qst.AddEvents)
                        {
                            var evtb = (EventBase)DbInterface.AddGameObject(GameObjectType.Event, evt.Key);
                            evtb.CommonEvent = false;
                            foreach (var tsk in qst.Tasks)
                            {
                                if (tsk.Id == evt.Key)
                                {
                                    tsk.CompletionEvent = evtb;
                                }
                            }

                            evtb.Load(evt.Value.JsonData);
                        }

                        qst.AddEvents.Clear();
                        qst.RemoveEvents.Clear();
                    }

                    PacketSender.CacheGameDataPacket();
                    PacketSender.SendGameObjectToAll(obj, false);
                }
                DbInterface.SaveGameDatabase();
            }
        }

        //SaveTimeDataPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.SaveTimeDataPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            TimeBase.GetTimeBase().LoadFromJson(packet.TimeJson);
            DbInterface.SaveGameDatabase();
            Time.Init();
            PacketSender.SendTimeBaseToAllEditors();
        }

        //AddTilesetsPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.AddTilesetsPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            foreach (var tileset in packet.Tilesets)
            {
                var value = tileset.Trim().ToLower();
                var found = false;
                foreach (var tset in TilesetBase.Lookup)
                {
                    if (tset.Value.Name.Trim().ToLower() == value)
                    {
                        found = true;
                    }
                }

                if (!found)
                {
                    var obj = DbInterface.AddGameObject(GameObjectType.Tileset);
                    ((TilesetBase) obj).Name = value;
                    DbInterface.SaveGameDatabase();
                    PacketSender.CacheGameDataPacket();
                    PacketSender.SendGameObjectToAll(obj);
                }
            }
        }

        //RequestGridPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.RequestGridPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            if (MapInstance.Lookup.Keys.Contains(packet.MapId))
            {
                if (client.IsEditor)
                {
                    PacketSender.SendMapGrid(client, MapInstance.Get(packet.MapId).MapGrid);
                }
            }
        }

        //OpenMapPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.EnterMapPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            client.EditorMap = packet.MapId;
        }

        //NeedMapPacket
        public void HandlePacket(Client client, Player player, Network.Packets.Editor.NeedMapPacket packet)
        {
            if (!client.IsEditor)
            {
                return;
            }

            var map = MapInstance.Get(packet.MapId);
            if (map != null)
            {
                PacketSender.SendMap(client, packet.MapId);
            }
        }

        #endregion

    }

}
