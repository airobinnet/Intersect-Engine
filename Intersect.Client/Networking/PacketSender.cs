﻿using System;

using Intersect.Admin.Actions;
using Intersect.Client.Entities.Events;
using Intersect.Client.General;
using Intersect.Client.Interface.Game;
using Intersect.Client.Maps;
using Intersect.Network.Packets.Client;
using Steamworks;

namespace Intersect.Client.Networking
{

    public static class PacketSender
    {

        public static void SendPing()
        {
            Network.SendPacket(new PingPacket());
        }

        public static void SendLogin(string username, string password)
        {
            Network.SendPacket(new LoginPacket(username, password));
        }

        public static void SendLoginCheck(string username)
        {
            Network.SendPacket(new LoginCheckPacket(username));
        }

        public static void SendLogout(bool characterSelect = false)
        {
            Network.SendPacket(new LogoutPacket(characterSelect));
        }

        public static void SendNeedMap(Guid mapId)
        {
            Network.SendPacket(new NeedMapPacket(mapId));
            if (MapInstance.MapRequests.ContainsKey(mapId))
            {
                MapInstance.MapRequests[mapId] = Globals.System.GetTimeMs() + 3000;
            }
            else
            {
                MapInstance.MapRequests.Add(mapId, Globals.System.GetTimeMs() + 3000);
            }
        }

        public static void SendSteamAuth(SteamId steamId, AuthTicket authTicket)
        {
            Network.SendPacket(new SendSteamAuthPacket(steamId, authTicket));
        }

        public static void SendSteamMTxnAuthorized(AppId appid, ulong orderid, bool authorized)
        {
            Network.SendPacket(new SendSteamMTxnAuthorizedPacket(appid,orderid,authorized));
        }

        public static void OpenCashShop(Guid shopid)
        {
            Network.SendPacket(new OpenCashShopPacket(shopid));
        }

        public static void SendCreateGuild(string name, string tag)
        {
            Network.SendPacket(new SendCreateGuildPacket(name, tag));
        }


        public static void SendMove()
        {
            Network.SendPacket(new MovePacket(Globals.Me.CurrentMap, Globals.Me.X, Globals.Me.Y, Globals.Me.Dir));
        }

        public static void SendChatMsg(string msg, byte channel)
        {
            Network.SendPacket(new ChatMsgPacket(msg, channel));
        }

        public static void SendAttack(Guid targetId, bool targetOnFocus)
        {
            Network.SendPacket(new AttackPacket(targetId, targetOnFocus));
        }

        public static void SendBlock(bool blocking)
        {
            Network.SendPacket(new BlockPacket(blocking));
        }

        public static void SendDirection(byte dir)
        {
            Network.SendPacket(new DirectionPacket(dir));
        }

        public static void SendEnterGame()
        {
            Network.SendPacket(new EnterGamePacket());
        }

        public static void SendActivateEvent(Guid eventId)
        {
            Network.SendPacket(new ActivateEventPacket(eventId));
        }

        public static void SendEventResponse(byte response, Dialog ed)
        {
            Globals.EventDialogs.Remove(ed);
            Network.SendPacket(new EventResponsePacket(ed.EventId, response));
        }

        public static void SendClassChangeResponse(byte response, ClassChange cc)
        {
            Globals.ClassChange.Remove(cc);
            Network.SendPacket(new ClassChangeResponsePacket(cc.EventId, response));
        }

        public static void SendItemChoiceResponse(int response, ItemChoice ic)
        {
            Globals.ItemChoice.Remove(ic);
            Network.SendPacket(new ItemChoiceResponsePacket(ic.EventId, response));
        }

        public static void SendEventInputVariable(object sender, EventArgs e)
        {
            Network.SendPacket(
                new EventInputVariablePacket(
                    (Guid) ((InputBox) sender).UserData, (int) ((InputBox) sender).Value, ((InputBox) sender).TextValue
                )
            );
        }

        public static void SendEventInputVariableCancel(object sender, EventArgs e)
        {
            Network.SendPacket(
                new EventInputVariablePacket(
                    (Guid) ((InputBox) sender).UserData, (int) ((InputBox) sender).Value, ((InputBox) sender).TextValue,
                    true
                )
            );
        }

        public static void SendCreateAccount(string username, string password, string email)
        {
            Network.SendPacket(new CreateAccountPacket(username.Trim(), password.Trim(), email.Trim()));
        }

        public static void SendCreateCharacter(string name, Guid classId, int sprite, int[] customSpriteLayers)
        {
            Network.SendPacket(new CreateCharacterPacket(name, classId, sprite, customSpriteLayers));
        }

        public static void SendPickupItem(int index)
        {
            Network.SendPacket(new PickupItemPacket(index));
        }

        public static void SendSwapInvItems(int item1, int item2)
        {
            Network.SendPacket(new SwapInvItemsPacket(item1, item2));
        }

        public static void SendDropItem(int slot, int amount)
        {
            Network.SendPacket(new DropItemPacket(slot, amount));
        }

        public static void SendUseItem(int slot, Guid targetId)
        {
            Network.SendPacket(new UseItemPacket(slot, targetId));
        }

        public static void checkGuildId(Guid player)
        {
            Network.SendPacket(new checkGuildIdPacket(player));
        }

        public static void SendSwapSpells(int spell1, int spell2)
        {
            Network.SendPacket(new SwapSpellsPacket(spell1, spell2));
        }

        public static void SendForgetSpell(int slot)
        {
            Network.SendPacket(new ForgetSpellPacket(slot));
        }

        public static void SendUseSpell(int slot, Guid targetId)
        {
            Network.SendPacket(new UseSpellPacket(slot, targetId));
        }

        public static void SendUnequipItem(int slot)
        {
            Network.SendPacket(new UnequipItemPacket(slot));
        }

        public static void SendUpgradeStat(byte stat)
        {
            Network.SendPacket(new UpgradeStatPacket(stat));
        }

        public static void SendHotbarUpdate(byte hotbarSlot, sbyte type, int itemIndex)
        {
            Network.SendPacket(new HotbarUpdatePacket(hotbarSlot, type, itemIndex));
        }

        public static void SendHotbarSwap(byte index, byte swapIndex)
        {
            Network.SendPacket(new HotbarSwapPacket(index, swapIndex));
        }

        public static void SendOpenAdminWindow()
        {
            Network.SendPacket(new OpenAdminWindowPacket());
        }

        //Admin Action Packet Should be Here

        public static void SendSellItem(int slot, int amount)
        {
            Network.SendPacket(new SellItemPacket(slot, amount));
        }

        public static void SendBuyItem(int slot, int amount)
        {
            Network.SendPacket(new BuyItemPacket(slot, amount));
        }

        public static void SendCloseShop()
        {
            Network.SendPacket(new CloseShopPacket());
        }

        public static void SendDepositItem(int slot, int amount)
        {
            Network.SendPacket(new DepositItemPacket(slot, amount));
        }

        public static void SendWithdrawItem(int slot, int amount)
        {
            Network.SendPacket(new WithdrawItemPacket(slot, amount));
        }


        public static void SendDepositGuildItem(int slot, int amount)
        {
            Network.SendPacket(new DepositGuildItemPacket(slot, amount));
        }

        public static void SendWithdrawGuildItem(int slot, int amount)
        {
            Network.SendPacket(new WithdrawGuildItemPacket(slot, amount));
        }

        public static void SendCloseTradeSkillInfo()
        {
            Network.SendPacket(new CloseTradeSkillInfoPacket());
        }

        public static void SendCloseBank()
        {
            Network.SendPacket(new CloseBankPacket());
        }

        public static void SendCloseGuildCreate()
        {
            Network.SendPacket(new CloseGuildCreatePacket());
        }

        public static void SendCloseGuildBank()
        {
            Network.SendPacket(new CloseGuildBankPacket());
        }

        public static void SendCloseCrafting()
        {
            Network.SendPacket(new CloseCraftingPacket());
        }

        public static void SendMoveBankItems(int slot1, int slot2)
        {
            Network.SendPacket(new SwapBankItemsPacket(slot1, slot2));
        }

        public static void SendMoveGuildBankItems(int slot1, int slot2)
        {
            Network.SendPacket(new SwapGuildBankItemsPacket(slot1, slot2));
        }

        public static void SendCraftItem(Guid id)
        {
            Network.SendPacket(new CraftItemPacket(id));
        }

        public static void SendCraftRequest(Guid id)
        {
            Network.SendPacket(new CraftRequestPacket(id));
        }

        public static void SendPartyInvite(Guid targetId)
        {
            Network.SendPacket(new PartyInvitePacket(targetId));
        }

        public static void SendPartyKick(Guid targetId)
        {
            Network.SendPacket(new PartyKickPacket(targetId));
        }

        public static void SendPartyLeave()
        {
            Network.SendPacket(new PartyLeavePacket());
        }

        public static void SendGuildLeave()
        {
            Network.SendPacket(new GuildLeavePacket());
        }

        public static void SendRequestGuildInfo()
        {
            Network.SendPacket(new RequestGuildInfoPacket());
        }

        public static void SendPartyAccept(object sender, EventArgs e)
        {
            Network.SendPacket(new PartyInviteResponsePacket((Guid) ((InputBox) sender).UserData, true));
        }

        public static void SendPartyDecline(object sender, EventArgs e)
        {
            Network.SendPacket(new PartyInviteResponsePacket((Guid) ((InputBox) sender).UserData, false));
        }

        public static void SendAcceptQuest(Guid questId)
        {
            Network.SendPacket(new QuestResponsePacket(questId, true));
        }

        public static void SendQuestTaskKeyPressed(int key)
        {
            Network.SendPacket(new QuestTaskKeyPressed(key));
        }

        public static void SendDeclineQuest(Guid questId)
        {
            Network.SendPacket(new QuestResponsePacket(questId, false));
        }

        public static void SendAbandonQuest(Guid questId)
        {
            Network.SendPacket(new AbandonQuestPacket(questId));
        }

        public static void SendAcceptQuestReward(Guid questId, Guid taskId, int choice)
        {
            Network.SendPacket(new AcceptQuestRewardPacket(questId, taskId, choice));
        }

        public static void SendAcceptQuestReward(Guid questId, Guid taskId)
        {
            Network.SendPacket(new AcceptQuestRewardPacket(questId, taskId, -1));
        }

        public static void SendTradeRequest(Guid targetId)
        {
            Network.SendPacket(new TradeRequestPacket(targetId));
        }

        public static void SendOfferTradeItem(int slot, int amount)
        {
            Network.SendPacket(new OfferTradeItemPacket(slot, amount));
        }

        public static void SendRevokeTradeItem(int slot, int amount)
        {
            Network.SendPacket(new RevokeTradeItemPacket(slot, amount));
        }

        public static void SendAcceptTrade()
        {
            Network.SendPacket(new AcceptTradePacket());
        }

        public static void SendDeclineTrade()
        {
            Network.SendPacket(new DeclineTradePacket());
        }

        public static void SendTradeRequestAccept(object sender, EventArgs e)
        {
            Network.SendPacket(new TradeRequestResponsePacket((Guid) ((InputBox) sender).UserData, true));
        }

        public static void SendTradeRequestDecline(object sender, EventArgs e)
        {
            Network.SendPacket(new TradeRequestResponsePacket((Guid) ((InputBox) sender).UserData, false));
        }

        public static void SendStoreBagItem(int slot, int amount)
        {
            Network.SendPacket(new StoreBagItemPacket(slot, amount));
        }

        public static void SendRetrieveBagItem(int slot, int amount)
        {
            Network.SendPacket(new RetrieveBagItemPacket(slot, amount));
        }

        public static void SendCloseBag()
        {
            Network.SendPacket(new CloseBagPacket());
        }

        public static void SendMoveBagItems(int slot1, int slot2)
        {
            Network.SendPacket(new SwapBagItemsPacket(slot1, slot2));
        }

        public static void SendRequestFriends()
        {
            Network.SendPacket(new RequestFriendsPacket());
        }

        public static void SendAddFriend(string name)
        {
            Network.SendPacket(new UpdateFriendsPacket(name, true));
        }

        public static void SendRemoveFriend(string name)
        {
            Network.SendPacket(new UpdateFriendsPacket(name, false));
        }

        public static void SendFriendRequestAccept(Object sender, EventArgs e)
        {
            Network.SendPacket(new FriendRequestResponsePacket((Guid) ((InputBox) sender).UserData, true));
        }

        public static void SendFriendRequestDecline(Object sender, EventArgs e)
        {
            Network.SendPacket(new FriendRequestResponsePacket((Guid) ((InputBox) sender).UserData, false));
        }

        public static void SendSelectCharacter(Guid charId)
        {
            Network.SendPacket(new SelectCharacterPacket(charId));
        }

        public static void SendDeleteCharacter(Guid charId)
        {
            Network.SendPacket(new DeleteCharacterPacket(charId));
        }

        public static void SendNewCharacter()
        {
            Network.SendPacket(new NewCharacterPacket());
        }

        public static void SendRequestPasswordReset(string nameEmail)
        {
            Network.SendPacket(new RequestPasswordResetPacket(nameEmail));
        }

        public static void SendResetPassword(string nameEmail, string code, string hashedPass)
        {
            Network.SendPacket(new ResetPasswordPacket(nameEmail, code, hashedPass));
        }

        public static void SendAdminAction(AdminAction action)
        {
            Network.SendPacket(new AdminActionPacket(action));
        }

        public static void SendBumpEvent(Guid mapId, Guid eventId)
        {
            Network.SendPacket(new BumpPacket(mapId, eventId));
        }

        public static void SendMail(string to, string title, string message, int slotID, int quantity)
        {
            if (slotID != -1)
            {
                Network.SendPacket(new MailBoxSendPacket(to, title, message, slotID, quantity, Globals.Me.Inventory[slotID].StatBuffs));
            } else
            {
                Network.SendPacket(new MailBoxSendPacket(to, title, message, slotID, quantity, new int[(int)Enums.Stats.StatCount]));
            }
        }

        public static void SendCloseMail()
        {
            Network.SendPacket(new MailBoxClosePacket());
        }

        public static void SendTakeMail(Guid mailID)
        {
            if (mailID == Guid.Empty)
            {
                return;
            }
            Network.SendPacket(new TakeMailPacket(mailID));
        }

        public static void SendCloseHDV()
        {
            Network.SendPacket(new CloseHDVPacket());
        }

        public static void SendAddToHDV(int slot, int quantity, int price, double expires)
        {
            Network.SendPacket(new AddHDVPacket(slot, Globals.Me.Inventory[slot].StatBuffs, quantity, price , expires));
        }

        public static void SendActionHDV(Guid hdvItemID, int action)
        {
            Network.SendPacket(new ActionHDVPacket(hdvItemID, action));
        }

    }

}
