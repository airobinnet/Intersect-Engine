﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Intersect.Enums;
using Intersect.GameObjects;
using Intersect.GameObjects.Events;
using Intersect.GameObjects.Events.Commands;
using Intersect.GameObjects.Switches_and_Variables;
using Intersect.Server.Database;
using Intersect.Server.Database.PlayerData.Players;
using Intersect.Server.Database.PlayerData.Security;
using Intersect.Server.General;
using Intersect.Server.Localization;
using Intersect.Server.Maps;
using Intersect.Server.Networking;
using Intersect.Utilities;

namespace Intersect.Server.Entities.Events
{

    public static class CommandProcessing
    {

        public static void ProcessCommand(EventCommand command, Player player, Event instance)
        {
            var stackInfo = instance.CallStack.Peek();
            stackInfo.WaitingForResponse = CommandInstance.EventResponse.None;
            stackInfo.WaitingOnCommand = null;
            stackInfo.BranchIds = null;

            ProcessCommand((dynamic) command, player, instance, instance.CallStack.Peek(), instance.CallStack);

            stackInfo.CommandIndex++;
        }

        //Show Text Command
        private static void ProcessCommand(
            ShowTextCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            PacketSender.SendEventDialog(
                player, ParseEventText(command.Text, player, instance), command.Face, instance.PageInstance.Id, command.Dialogue, false
            );

            stackInfo.WaitingForResponse = CommandInstance.EventResponse.Dialogue;
        }

        //Show Options Command
        private static void ProcessCommand(
            ShowOptionsCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var txt = ParseEventText(command.Text, player, instance);
            var opt1 = ParseEventText(command.Options[0], player, instance);
            var opt2 = ParseEventText(command.Options[1], player, instance);
            var opt3 = ParseEventText(command.Options[2], player, instance);
            var opt4 = ParseEventText(command.Options[3], player, instance);
            PacketSender.SendEventDialog(player, txt, opt1, opt2, opt3, opt4, command.Face, instance.PageInstance.Id, false, command.fishScreen);
            stackInfo.WaitingForResponse = CommandInstance.EventResponse.Dialogue;
            stackInfo.WaitingOnCommand = command;
            stackInfo.BranchIds = command.BranchIds;
        }

        //ClassChangeWindowCommand Command
        private static void ProcessCommand(
            ClassChangeWindowCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var opt1 = ParseEventText(command.Options[0], player, instance);
            var opt2 = ParseEventText(command.Options[1], player, instance);
            var opt3 = ParseEventText(command.Options[2], player, instance);
            var opt4 = ParseEventText(command.Options[3], player, instance);
            PacketSender.SendClassChangeDialog(player, opt1, opt2, opt3, opt4, instance.PageInstance.Id);
            stackInfo.WaitingForResponse = CommandInstance.EventResponse.ClassChange;
            stackInfo.WaitingOnCommand = command;
            stackInfo.BranchIds = command.BranchIds;
        }

        //ItemChoiceWindowCommand
        private static void ProcessCommand(
            ItemChoiceWindowCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var opt1 = ParseEventText(command.Options[0], player, instance);
            var opt2 = ParseEventText(command.Options[1], player, instance);
            var opt3 = ParseEventText(command.Options[2], player, instance);
            var opt4 = ParseEventText(command.Options[3], player, instance);
            PacketSender.SendItemChoiceWindow(player, opt1, opt2, opt3, opt4, instance.PageInstance.Id);
            stackInfo.WaitingForResponse = CommandInstance.EventResponse.ItemChoice;
            stackInfo.WaitingOnCommand = command;
            stackInfo.BranchIds = command.BranchIds;
        }

        //Input Variable Command
        private static void ProcessCommand(
            InputVariableCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var title = ParseEventText(command.Title, player, instance);
            var txt = ParseEventText(command.Text, player, instance);
            var type = VariableDataTypes.Integer;

            if (command.VariableType == VariableTypes.PlayerVariable)
            {
                var variable = PlayerVariableBase.Get(command.VariableId);
                type = variable.Type;
            }
            else
            {
                var variable = ServerVariableBase.Get(command.VariableId);
                type = variable.Type;
            }

            PacketSender.SendInputVariableDialog(player, title, txt, type, instance.PageInstance.Id);
            stackInfo.WaitingForResponse = CommandInstance.EventResponse.Dialogue;
            stackInfo.WaitingOnCommand = command;
            stackInfo.BranchIds = command.BranchIds;
        }

        //Show Add Chatbox Text Command
        private static void ProcessCommand(
            AddChatboxTextCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var txt = ParseEventText(command.Text, player, instance);
            var color = Color.FromName(command.Color, Strings.Colors.presets);
            switch (command.Channel)
            {
                case ChatboxChannel.Player:
                    PacketSender.SendChatMsg(player, txt, color);

                    break;
                case ChatboxChannel.Local:
                    PacketSender.SendProximityMsg(txt, player.MapId, color);

                    break;
                case ChatboxChannel.Global:
                    PacketSender.SendGlobalMsg(txt, color);

                    break;
            }
        }

        //Show Add Combat Text Command
        private static void ProcessCommand(
            AddCombatTextCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var txt = ParseEventText(command.Text, player, instance);
            var color = Color.FromName(command.Color, Strings.Colors.presets);
            bool self = command.self;
            var mapId = instance.MapId;
            var tileX = instance.PageInstance.X;
            var tileY = instance.PageInstance.Y;
            var targetEntity = (Entity)player;
            //Next part could probably be rewritten completely by just sending PageInstance.X and PageInstance.Y... but i'm lazy!
            if (self)
            {
                if (mapId != Guid.Empty)
                {
                    tileX = instance.PageInstance.X;
                    tileY = instance.PageInstance.Y;
                }
                else
                {
                    if (instance.Id != Guid.Empty)
                    {
                        foreach (var evt in player.EventLookup)
                        {
                            if (evt.Value.MapId != instance.MapId)
                            {
                                continue;
                            }

                            if (evt.Value.BaseEvent.Id == instance.Id)
                            {
                                targetEntity = evt.Value.PageInstance;

                                break;
                            }
                        }
                    }

                    if (targetEntity != null)
                    {
                        if (instance.X == 0 && instance.Y == 0)
                        {
                            //Attach to entity instead of playing on tile
                            PacketSender.SendActionMsgSelf(
                                instance, txt, color, 0, 0, targetEntity.Id,
                                targetEntity.MapId
                            );

                            return;
                        }

                        int xDiff = instance.X;
                        int yDiff = instance.Y;

                        mapId = targetEntity.MapId;
                        tileX = targetEntity.X + xDiff;
                        tileY = targetEntity.Y + yDiff;
                    }
                    else
                    {
                        return;
                    }
                }

                var tile = new TileHelper(mapId, tileX, tileY);
                if (tile.TryFix())
                {
                    PacketSender.SendActionMsgSelf(instance, txt, color, tile.GetX(), tile.GetY(), targetEntity.Id,
                                targetEntity.MapId);
                }
            }
            else
            {
                PacketSender.SendActionMsg(player, txt, color);
            }
        }

        //Set Variable Commands
        private static void ProcessCommand(
            SetVariableCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            ProcessVariableModification(command, (dynamic) command.Modification, player, instance);
        }

        //Set Self Switch Command
        private static void ProcessCommand(
            SetSelfSwitchCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            if (instance.Global)
            {
                var evts = MapInstance.Get(instance.MapId).GlobalEventInstances.Values.ToList();
                for (var i = 0; i < evts.Count; i++)
                {
                    if (evts[i] != null && evts[i].BaseEvent == instance.BaseEvent)
                    {
                        evts[i].SelfSwitch[command.SwitchId] = command.Value;
                    }
                }
            }
            else
            {
                instance.SelfSwitch[command.SwitchId] = command.Value;
            }
        }

        //Conditional Branch Command
        private static void ProcessCommand(
            ConditionalBranchCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var success = Conditions.MeetsCondition((dynamic) command.Condition, player, instance, null);
            if (command.Condition.Negated)
            {
                success = !success;
            }

            List<EventCommand> newCommandList = null;
            if (success && stackInfo.Page.CommandLists.ContainsKey(command.BranchIds[0]))
            {
                newCommandList = stackInfo.Page.CommandLists[command.BranchIds[0]];
            }

            if (!success && stackInfo.Page.CommandLists.ContainsKey(command.BranchIds[1]))
            {
                newCommandList = stackInfo.Page.CommandLists[command.BranchIds[1]];
            }

            var tmpStack = new CommandInstance(stackInfo.Page)
            {
                CommandList = newCommandList,
                CommandIndex = 0,
            };

            callStack.Push(tmpStack);
        }

        //Exit Event Process Command
        private static void ProcessCommand(
            ExitEventProcessingCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            callStack.Clear();
        }

        //Label Command
        private static void ProcessCommand(
            LabelCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            return; //Do Nothing.. just a label
        }

        //Go To Label Command
        private static void ProcessCommand(
            GoToLabelCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            //Recursively search through commands for the label, and create a brand new call stack based on where that label is located.
            var newCallStack = LoadLabelCallstack(command.Label, stackInfo.Page);
            if (newCallStack != null)
            {
                newCallStack.Reverse();
                while (callStack.Peek().CommandListId != Guid.Empty)
                {
                    callStack.Pop();
                }

                //also pop the current event
                callStack.Pop();
                foreach (var itm in newCallStack)
                {
                    callStack.Push(itm);
                }
            }
        }

        //Start Common Event Command
        private static void ProcessCommand(
            StartCommmonEventCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var commonEvent = EventBase.Get(command.EventId);
            if (commonEvent != null)
            {
                for (var i = 0; i < commonEvent.Pages.Count; i++)
                {
                    if (Conditions.CanSpawnPage(commonEvent.Pages[i], player, instance))
                    {
                        var commonEventStack = new CommandInstance(commonEvent.Pages[i]);
                        callStack.Push(commonEventStack);
                    }
                }
            }
        }

        //Restore Hp Command
        private static void ProcessCommand(
            RestoreHpCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            if (command.Amount > 0)
            {
                player.AddVital(Vitals.Health, command.Amount);
            }
            else if (command.Amount < 0)
            {
                player.SubVital(Vitals.Health, -command.Amount);
                player.CombatTimer = Globals.Timing.TimeMs + Options.CombatTime;
                if (player.GetVital(Vitals.Health) <= 0)
                {
                    player.Die(Options.ItemDropChance);
                }
            }
            else
            {
                player.RestoreVital(Vitals.Health);
            }
        }

        //Restore Mp Command
        private static void ProcessCommand(
            RestoreMpCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            if (command.Amount > 0)
            {
                player.AddVital(Vitals.Mana, command.Amount);
            }
            else if (command.Amount < 0)
            {
                player.SubVital(Vitals.Mana, -command.Amount);
                player.CombatTimer = Globals.Timing.TimeMs + Options.CombatTime;
            }
            else
            {
                player.RestoreVital(Vitals.Mana);
            }
        }

        //Level Up Command
        private static void ProcessCommand(
            LevelUpCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.LevelUp();
        }

        //Give Experience Command
        private static void ProcessCommand(
            GiveExperienceCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.GiveExperience(command.Exp);
        }

        //Give Tradeskill Experience Command
        private static void ProcessCommand(
            GiveTradeSkillExperienceCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.GiveTradeSkillExperience(command.TradeskillId, command.Exp);
        }

        //Give Guild Experience Command
        private static void ProcessCommand(
            GiveGuildExperienceCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.Guild?.GiveExperience(command.Exp);
        }

        //Change Level Command
        private static void ProcessCommand(
            ChangeLevelCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.SetLevel(command.Level, true);
        }

        //Change Spells Command
        private static void ProcessCommand(
            ChangeSpellsCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            //0 is add, 1 is remove
            var success = false;
            if (command.Add) //Try to add a spell
            {
                success = player.TryTeachSpell(new Spell(command.SpellId));
            }
            else
            {
                if (player.FindSpell(command.SpellId) > -1 && command.SpellId != Guid.Empty)
                {
                    player.ForgetSpell(player.FindSpell(command.SpellId));
                    success = true;
                }
            }

            List<EventCommand> newCommandList = null;
            if (success && stackInfo.Page.CommandLists.ContainsKey(command.BranchIds[0]))
            {
                newCommandList = stackInfo.Page.CommandLists[command.BranchIds[0]];
            }

            if (!success && stackInfo.Page.CommandLists.ContainsKey(command.BranchIds[1]))
            {
                newCommandList = stackInfo.Page.CommandLists[command.BranchIds[1]];
            }

            var tmpStack = new CommandInstance(stackInfo.Page)
            {
                CommandList = newCommandList,
                CommandIndex = 0,
            };

            callStack.Push(tmpStack);
        }

        //Friendly Spells Command
        private static void ProcessCommand(
            FriendlySpellsCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var spell = SpellBase.Get(command.spell);

            if (spell == null)
            {
                return;
            }

            player.CastSpell(command.spell,-1,-2);
        }

        //Change Items Command
        private static void ProcessCommand(
            ChangeItemsCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var success = false;

            if (command.Add)
            {
                Item item = new Item(command.ItemId, command.Quantity, true);
                for (var j = 0; j < (int)Stats.StatCount; j++)
                {
                    item.StatBuffs[j] = Randomization.Next(ItemBase.Get(item.ItemId).StatsGiven[j], ItemBase.Get(item.ItemId).StatGrowths[j] + 1);
                }

                success = player.TryGiveItem(item, command.ItemHandling);
            }
            else
            {
                success = player.TryTakeItem(command.ItemId, command.Quantity, command.ItemHandling);
            }

            List<EventCommand> newCommandList = null;
            if (success && stackInfo.Page.CommandLists.ContainsKey(command.BranchIds[0]))
            {
                newCommandList = stackInfo.Page.CommandLists[command.BranchIds[0]];
            }

            if (!success && stackInfo.Page.CommandLists.ContainsKey(command.BranchIds[1]))
            {
                newCommandList = stackInfo.Page.CommandLists[command.BranchIds[1]];
            }

            var tmpStack = new CommandInstance(stackInfo.Page)
            {
                CommandList = newCommandList,
                CommandIndex = 0,
            };

            callStack.Push(tmpStack);
        }


        //Change Items Command
        private static void ProcessCommand(
            ChangeTradeSkillCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            if (command.Add)
            {
                player.TryGiveTradeSkill(command.TradeSkillId);
            }
            else
            {
                player.TryTakeTradeSkill(command.TradeSkillId);
            }
        }

        //Create Guild Command
        private static void ProcessCommand(
            CreateGuildCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.OpenGuildCreate(command.ItemId);
            player.CreateGuildItem = command.ItemId;
        }


        //Remove Status Command
        private static void ProcessCommand(
            RemoveStatusCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.RemoveStatus(command.SpellId);
        }

        //Take Items By tag Command
        private static void ProcessCommand(
            ChangeItemsByTag command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var success = false;

            // Retrieve all items that have the tag we're looking for so we can use this list to check against their inventory, or pick a random item!.
            var potentialItems = new List<Guid>();
            foreach (var dbObject in ItemBase.Lookup.Values)
            {
                var item = (ItemBase)dbObject;
                if (item.Tags.Contains(command.Tag))
                {
                    potentialItems.Add(item.Id);
                }
            }

            // Create a backup of our inventory in case we end up not being able to remove all required items and want to revert.
            var invBackup = player.Items.Select(item => item?.Clone()).ToList();

            // Going to use this to keep track of how many items we have to change.
            var changed = 0;

            // Go through each inventory slot we've retrieved before and attempt to remove as many items as we need.
            //Check if we're going to be giving or taking items.
            if (command.Add) // Add Items to the inventory!
            {
                // Go through the amout of items we have to give, and pick a random item from our list of potential items to attempt to give to our player.
                var randomizer = new Random();
                for (var attempt = 0; attempt < command.Quantity; attempt++)
                {
                    if (player.TryGiveItem(potentialItems[randomizer.Next(potentialItems.Count)], 1, ItemHandling.Normal, false, false))
                    {
                        changed += 1;
                    }
                }
            }
            else // Remove Items from the inventory!
            {
                // Find all inventory slots that has the items we've looked up above.
                var inventorySlots = new List<InventorySlot>();
                for (var slot = 0; slot < Options.MaxInvItems; slot++)
                {
                    if (potentialItems.Contains(player.Items[slot].ItemId))
                    {
                        inventorySlots.Add(player.Items[slot]);
                    }
                }

                // Go through each inventory slot we've retrieved before and attempt to remove as many items as we need.
                foreach (var slot in inventorySlots)
                {
                    // No point looping further if we are at the correct quantity!
                    if (changed == command.Quantity) break;
                
                    for (var attempt = 0; attempt < command.Quantity; attempt++)
                    {
                        if (player.TryTakeItem(slot, 1, ItemHandling.Normal, false))
                        {
                            changed += 1;
                        }
                    }
                }
            }

            // Do we still have items left to change or did we finish?
            if ((command.Quantity - changed) == 0)
            {
                // We've succeeded! Let's update the inventory.
                success = true;
                PacketSender.SendInventory(player);
            }
            else
            {
                // We've failed to take all the required items. Time to restore our inventory!
                for (var i = 0; i < invBackup.Count; i++)
                {
                    player.Items[i].Set(invBackup[i]);
                }

                PacketSender.SendInventory(player);
            }

            // Process other events.
            List<EventCommand> newCommandList = null;
            if (success && stackInfo.Page.CommandLists.ContainsKey(command.BranchIds[0]))
            {
                newCommandList = stackInfo.Page.CommandLists[command.BranchIds[0]];
            }

            if (!success && stackInfo.Page.CommandLists.ContainsKey(command.BranchIds[1]))
            {
                newCommandList = stackInfo.Page.CommandLists[command.BranchIds[1]];
            }

            var tmpStack = new CommandInstance(stackInfo.Page) {
                CommandList = newCommandList,
                CommandIndex = 0,
            };

            callStack.Push(tmpStack);
        }

        //Equip Items Command
        private static void ProcessCommand(
            EquipItemCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var itm = ItemBase.Get(command.ItemId);

            if (itm == null)
            {
                return;
            }

            player.EquipItem(ItemBase.Get(command.ItemId));
        }

        //UnEquip Items Command
        private static void ProcessCommand(
            UnEquipItemCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var slot = Options.EquipmentSlots[command.Slot];

            if (slot == null)
            {
                return;
            }

            player.UnequipItem(command.Slot);
        }

        //Change Sprite Command
        private static void ProcessCommand(
            ChangeSpriteCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.Sprite = command.Sprite;
            PacketSender.SendEntityDataToProximity(player);
        }

        //Change Face Command
        private static void ProcessCommand(
            ChangeFaceCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.Face = command.Face;
            PacketSender.SendEntityDataToProximity(player);
        }

        //Change Hair Command
        private static void ProcessCommand(
            ChangeHairCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.CustomSpriteLayers[(int)Enums.CustomSpriteLayers.Hair] = command.Hair;
            PacketSender.SendCustomSpriteLayersToProximity(player);
        }

        //Change Gender Command
        private static void ProcessCommand(
            ChangeGenderCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.Gender = command.Gender;
            PacketSender.SendEntityDataToProximity(player);
        }

        //Change Name Color Command
        private static void ProcessCommand(
            ChangeNameColorCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            if (command.Remove)
            {
                player.NameColor = null;
                PacketSender.SendEntityDataToProximity(player);

                return;
            }

            //Don't set the name color if it doesn't override admin name colors.
            if (player.Power != UserRights.None && !command.Override)
            {
                return;
            }

            player.NameColor = command.Color;
            PacketSender.SendEntityDataToProximity(player);
        }

        //Change Player Label Command
        private static void ProcessCommand(
            ChangePlayerLabelCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var label = ParseEventText(command.Value, player, instance);

            var color = command.Color;
            if (command.MatchNameColor)
            {
                color = Color.Transparent;
            }

            if (command.Position == 0) // Header
            {
                player.HeaderLabel = new Label(label, color);
            }
            else if (command.Position == 1) // Footer
            {
                player.FooterLabel = new Label(label, color);
            }

            PacketSender.SendEntityDataToProximity(player);
        }

        //Set Access Command (wtf why would we even allow this? lol)
        private static void ProcessCommand(
            SetAccessCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            if (player.Client == null)
            {
                return;
            }

            switch (command.Access)
            {
                case Access.Moderator:
                    player.Client.Power = UserRights.Moderation;

                    break;
                case Access.Admin:
                    player.Client.Power = UserRights.Admin;

                    break;
                default:
                    player.Client.Power = UserRights.None;

                    break;
            }

            PacketSender.SendEntityDataToProximity(player);
            PacketSender.SendChatMsg(player, Strings.Player.powerchanged, Color.Red);
        }

        //Warp Player Command
        private static void ProcessCommand(
            WarpCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.Warp(
                command.MapId, command.X, command.Y,
                command.Direction == WarpDirection.Retain ? (byte) player.Dir : (byte) (command.Direction - 1)
            );
        }

        //Set Move Route Command
        private static void ProcessCommand(
            SetMoveRouteCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            if (command.Route.Target == Guid.Empty)
            {
                player.MoveRoute = new EventMoveRoute();
                player.MoveRouteSetter = instance.PageInstance;
                player.MoveRoute.CopyFrom(command.Route);
                PacketSender.SendMoveRouteToggle(player, true);
            }
            else
            {
                foreach (var evt in player.EventLookup)
                {
                    if (evt.Value.BaseEvent.Id == command.Route.Target)
                    {
                        if (evt.Value.PageInstance != null)
                        {
                            evt.Value.PageInstance.MoveRoute.CopyFrom(command.Route);
                            evt.Value.PageInstance.MovementType = EventMovementType.MoveRoute;
                            if (evt.Value.PageInstance.GlobalClone != null)
                            {
                                evt.Value.PageInstance.GlobalClone.MovementType = EventMovementType.MoveRoute;
                            }
                        }
                    }
                }
            }
        }

        //Wait for Route Completion Command
        private static void ProcessCommand(
            WaitForRouteCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            if (command.TargetId == Guid.Empty)
            {
                stackInfo.WaitingForRoute = player.Id;
                stackInfo.WaitingForRouteMap = player.MapId;
            }
            else
            {
                foreach (var evt in player.EventLookup)
                {
                    if (evt.Value.BaseEvent.Id == command.TargetId)
                    {
                        stackInfo.WaitingForRoute = evt.Value.BaseEvent.Id;
                        stackInfo.WaitingForRouteMap = evt.Value.MapId;

                        break;
                    }
                }
            }
        }

        //Spawn Npc Command
        private static void ProcessCommand(
            SpawnNpcCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var npcId = command.NpcId;
            var mapId = command.MapId;
            var tileX = 0;
            var tileY = 0;
            var direction = (byte) Directions.Up;
            var targetEntity = (Entity) player;
            if (mapId != Guid.Empty)
            {
                tileX = command.X;
                tileY = command.Y;
                direction = command.Dir;
            }
            else
            {
                if (command.EntityId != Guid.Empty)
                {
                    foreach (var evt in player.EventLookup)
                    {
                        if (evt.Value.MapId != instance.MapId)
                        {
                            continue;
                        }

                        if (evt.Value.BaseEvent.Id == command.EntityId)
                        {
                            targetEntity = evt.Value.PageInstance;

                            break;
                        }
                    }
                }

                if (targetEntity != null)
                {
                    int xDiff = command.X;
                    int yDiff = command.Y;
                    if (command.Dir == 1)
                    {
                        var tmp = 0;
                        switch (targetEntity.Dir)
                        {
                            case (int) Directions.Down:
                                yDiff *= -1;
                                xDiff *= -1;

                                break;
                            case (int) Directions.Left:
                                tmp = yDiff;
                                yDiff = xDiff;
                                xDiff = tmp;

                                break;
                            case (int) Directions.Right:
                                tmp = yDiff;
                                yDiff = xDiff;
                                xDiff = -tmp;

                                break;
                        }

                        direction = (byte) targetEntity.Dir;
                    }

                    mapId = targetEntity.MapId;
                    tileX = (byte) (targetEntity.X + xDiff);
                    tileY = (byte) (targetEntity.Y + yDiff);
                }
                else
                {
                    return;
                }
            }

            var tile = new TileHelper(mapId, tileX, tileY);
            if (tile.TryFix())
            {
                var npc = MapInstance.Get(mapId).SpawnNpc((byte) tileX, (byte) tileY, direction, npcId, true);
                player.SpawnedNpcs.Add((Npc) npc);
            }
        }

        //Despawn Npcs Command
        private static void ProcessCommand(
            DespawnNpcCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var entities = player.SpawnedNpcs.ToArray();
            for (var i = 0; i < entities.Length; i++)
            {
                if (entities[i] != null && entities[i].GetType() == typeof(Npc))
                {
                    if (((Npc) entities[i]).Despawnable == true)
                    {
                        ((Npc) entities[i]).Die(100);
                    }
                }
            }

            player.SpawnedNpcs.Clear();
        }

        //Spawn Pet Command
        private static void ProcessCommand(
            SpawnPetCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var petId = command.PetId;
            var mapId = command.MapId;
            var tileX = 0;
            var tileY = 0;
            var direction = (byte)Directions.Up;
            var targetEntity = (Entity)player;
            if (mapId != Guid.Empty)
            {
                tileX = command.X;
                tileY = command.Y;
                direction = command.Dir;
            }
            else
            {
                if (command.EntityId != Guid.Empty)
                {
                    foreach (var evt in player.EventLookup)
                    {
                        if (evt.Value.MapId != instance.MapId)
                        {
                            continue;
                        }

                        if (evt.Value.BaseEvent.Id == command.EntityId)
                        {
                            targetEntity = evt.Value.PageInstance;

                            break;
                        }
                    }
                }

                if (targetEntity != null)
                {
                    int xDiff = command.X;
                    int yDiff = command.Y;
                    if (command.Dir == 1)
                    {
                        var tmp = 0;
                        switch (targetEntity.Dir)
                        {
                            case (int)Directions.Down:
                                yDiff *= -1;
                                xDiff *= -1;

                                break;
                            case (int)Directions.Left:
                                tmp = yDiff;
                                yDiff = xDiff;
                                xDiff = tmp;

                                break;
                            case (int)Directions.Right:
                                tmp = yDiff;
                                yDiff = xDiff;
                                xDiff = -tmp;

                                break;
                        }

                        direction = (byte)targetEntity.Dir;
                    }

                    mapId = targetEntity.MapId;
                    tileX = (byte)(targetEntity.X + xDiff);
                    tileY = (byte)(targetEntity.Y + yDiff);
                }
                else
                {
                    return;
                }
            }
            if (player.SpawnedPets.ToArray() == null || player.SpawnedPets.ToArray().Length == 0)
            {
                var tile = new TileHelper(mapId, tileX, tileY);
                if (tile.TryFix())
                {
                    var pet = MapInstance.Get(mapId).SpawnPet((byte)tileX, (byte)tileY, direction, petId, player, true);
                    player.SpawnedPets.Add((Pet)pet);
                }
            } else
            {
                var entities = player.SpawnedPets.ToArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    if (entities[i] != null && entities[i].GetType() == typeof(Pet))
                    {
                        if (entities[i].Name == PetBase.Get(petId).Name)
                        {
                            //if (((Pet)entities[i]).Despawnable == true)
                            //{
                            ((Pet)entities[i]).Die(100);
                            player.SpawnedPets.Clear();
                            //}
                        } else
                        {

                            ((Pet)entities[i]).Die(100);
                            player.SpawnedPets.Clear();
                            var pet = MapInstance.Get(mapId).SpawnPet((byte)tileX, (byte)tileY, direction, petId, player, true);
                            player.SpawnedPets.Add((Pet)pet);
                        }
                    }
                }
            }
        }

        //Despawn Pet Command
        private static void ProcessCommand(
            DespawnPetCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var entities = player.SpawnedPets.ToArray();
            for (var i = 0; i < entities.Length; i++)
            {
                if (entities[i] != null && entities[i].GetType() == typeof(Pet))
                {
                    if (((Pet)entities[i]).Despawnable == true)
                    {
                        ((Pet)entities[i]).Die(100);
                    }
                }
            }

            player.SpawnedPets.Clear();
        }

        //Play Animation Command
        private static void ProcessCommand(
            PlayAnimationCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            //Playing an animations requires a target type/target or just a tile.
            //We need an animation number and whether or not it should rotate (and the direction I guess)
            var animId = command.AnimationId;
            var mapId = command.MapId;
            var tileX = 0;
            var tileY = 0;
            var direction = (byte) Directions.Up;
            var targetEntity = (Entity) player;
            if (mapId != Guid.Empty)
            {
                tileX = command.X;
                tileY = command.Y;
                direction = command.Dir;
            }
            else
            {
                if (command.EntityId != Guid.Empty)
                {
                    foreach (var evt in player.EventLookup)
                    {
                        if (evt.Value.MapId != instance.MapId)
                        {
                            continue;
                        }

                        if (evt.Value.BaseEvent.Id == command.EntityId)
                        {
                            targetEntity = evt.Value.PageInstance;

                            break;
                        }
                    }
                }

                if (targetEntity != null)
                {
                    if (command.X == 0 && command.Y == 0 && command.Dir == 0)
                    {
                        //Attach to entity instead of playing on tile
                        PacketSender.SendAnimationToProximity(
                            animId, targetEntity.GetEntityType() == EntityTypes.Event ? 2 : 1, targetEntity.Id,
                            targetEntity.MapId, 0, 0, 0
                        );

                        return;
                    }

                    int xDiff = command.X;
                    int yDiff = command.Y;
                    if (command.Dir == 1)
                    {
                        var tmp = 0;
                        switch (targetEntity.Dir)
                        {
                            case (int) Directions.Down:
                                yDiff *= -1;
                                xDiff *= -1;

                                break;
                            case (int) Directions.Left:
                                tmp = yDiff;
                                yDiff = xDiff;
                                xDiff = tmp;

                                break;
                            case (int) Directions.Right:
                                tmp = yDiff;
                                yDiff = xDiff;
                                xDiff = -tmp;

                                break;
                        }

                        direction = (byte) targetEntity.Dir;
                    }

                    mapId = targetEntity.MapId;
                    tileX = targetEntity.X + xDiff;
                    tileY = targetEntity.Y + yDiff;
                }
                else
                {
                    return;
                }
            }

            var tile = new TileHelper(mapId, tileX, tileY);
            if (tile.TryFix())
            {
                PacketSender.SendAnimationToProximity(
                    animId, -1, Guid.Empty, tile.GetMapId(), tile.GetX(), tile.GetY(), (sbyte) direction
                );
            }
        }

        //Hold Player Command
        private static void ProcessCommand(
            HoldPlayerCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            instance.HoldingPlayer = true;
            PacketSender.SendHoldPlayer(player, instance.BaseEvent.Id, instance.BaseEvent.MapId);
        }

        //Release Player Command
        private static void ProcessCommand(
            ReleasePlayerCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            instance.HoldingPlayer = false;
            PacketSender.SendReleasePlayer(player, instance.BaseEvent.Id);
        }

        //Hide Player Command
        private static void ProcessCommand(
            HidePlayerCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.HideEntity = true;
            player.HideName = true;
            PacketSender.SendEntityDataToProximity(player);
        }

        //Show Player Command
        private static void ProcessCommand(
            ShowPlayerCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.HideEntity = false;
            player.HideName = false;
            PacketSender.SendEntityDataToProximity(player);
        }

        //Play Bgm Command
        private static void ProcessCommand(
            PlayBgmCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            PacketSender.SendPlayMusic(player, command.File);
        }

        //Fadeout Bgm Command
        private static void ProcessCommand(
            FadeoutBgmCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            PacketSender.SendFadeMusic(player);
        }

        //Play Sound Command
        private static void ProcessCommand(
            PlaySoundCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            PacketSender.SendPlaySound(player, command.File);
        }

        //Stop Sounds Command
        private static void ProcessCommand(
            StopSoundsCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            PacketSender.SendStopSounds(player);
        }

        //Show Picture Command
        private static void ProcessCommand(
            ShowPictureCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            PacketSender.SendShowPicture(player, command.File, command.Size, command.Clickable);
        }

        //Hide Picture Command
        private static void ProcessCommand(
            HidePictureCommmand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            PacketSender.SendHidePicture(player);
        }

        //Wait Command
        private static void ProcessCommand(
            WaitCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            instance.WaitTimer = Globals.Timing.TimeMs + command.Time;
            callStack.Peek().WaitingForResponse = CommandInstance.EventResponse.Timer;
        }

        //Open Bank Command
        private static void ProcessCommand(
            OpenBankCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.OpenBank();
            callStack.Peek().WaitingForResponse = CommandInstance.EventResponse.Bank;
        }

        //Open GuildBank Command
        private static void ProcessCommand(
            OpenGuildBankCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.OpenGuildBank();
            callStack.Peek().WaitingForResponse = CommandInstance.EventResponse.GuildBank;
        }

        //Open Shop Command
        private static void ProcessCommand(
            OpenShopCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.OpenShop(ShopBase.Get(command.ShopId));
            callStack.Peek().WaitingForResponse = CommandInstance.EventResponse.Shop;
        }

        //Open Crafting Table Command
        private static void ProcessCommand(
            OpenCraftingTableCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.OpenCraftingTable(CraftingTableBase.Get(command.CraftingTableId));
            callStack.Peek().WaitingForResponse = CommandInstance.EventResponse.Crafting;
        }

        //Set Class Command
        private static void ProcessCommand(
            SetClassCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            if (ClassBase.Get(command.ClassId) != null)
            {
                player.ClassId = command.ClassId;
                player.RecalculateStatsAndPoints();
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

            PacketSender.SendEntityDataToProximity(player);
        }

        private static void ProcessCommand(
            OpenMailBoxCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.OpenMailBox();
        }

        private static void ProcessCommand(
            SendMailBoxCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.SendMail();
        }

        private static void ProcessCommand(
            DropChanceItemCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.DropChanceItem(ItemBase.Get(command.ItemId), Randomization.Next(command.Min, command.Max + 1), command.DropChance);
        }

        private static void ProcessCommand(
            HDVCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.OpenHDV(command.HDVid);
        }

        //Start Quest Command
        private static void ProcessCommand(
            StartQuestCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            var success = false;
            var quest = QuestBase.Get(command.QuestId);
            if (quest != null)
            {
                if (player.CanStartQuest(quest))
                {
                    if (command.Offer)
                    {
                        player.OfferQuest(quest);
                        stackInfo.WaitingForResponse = CommandInstance.EventResponse.Quest;
                        stackInfo.BranchIds = command.BranchIds;
                        stackInfo.WaitingOnCommand = command;

                        return;
                    }
                    else
                    {
                        player.StartQuest(quest);
                        success = true;
                    }
                }
            }

            List<EventCommand> newCommandList = null;
            if (success && stackInfo.Page.CommandLists.ContainsKey(command.BranchIds[0]))
            {
                newCommandList = stackInfo.Page.CommandLists[command.BranchIds[0]];
            }

            if (!success && stackInfo.Page.CommandLists.ContainsKey(command.BranchIds[1]))
            {
                newCommandList = stackInfo.Page.CommandLists[command.BranchIds[1]];
            }

            var tmpStack = new CommandInstance(stackInfo.Page)
            {
                CommandList = newCommandList,
                CommandIndex = 0,
            };

            callStack.Push(tmpStack);
        }

        //Complete Quest Task Command
        private static void ProcessCommand(
            CompleteQuestTaskCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.CompleteQuestTask(command.QuestId, command.TaskId);
        }

        //End Quest Command
        private static void ProcessCommand(
            EndQuestCommand command,
            Player player,
            Event instance,
            CommandInstance stackInfo,
            Stack<CommandInstance> callStack
        )
        {
            player.CompleteQuest(command.QuestId, command.SkipCompletionEvent);
        }

        private static Stack<CommandInstance> LoadLabelCallstack(string label, EventPage currentPage)
        {
            var newStack = new Stack<CommandInstance>();
            newStack.Push(new CommandInstance(currentPage)); //Start from the top
            if (FindLabelResursive(newStack, currentPage, newStack.Peek().CommandList, label))
            {
                return newStack;
            }

            return null;
        }

        private static bool FindLabelResursive(
            Stack<CommandInstance> stack,
            EventPage page,
            List<EventCommand> commandList,
            string label
        )
        {
            if (page.CommandLists.ContainsValue(commandList))
            {
                while (stack.Peek().CommandIndex < commandList.Count)
                {
                    var command = commandList[stack.Peek().CommandIndex];
                    var branchIds = new List<Guid>();
                    switch (command.Type)
                    {
                        case EventCommandType.ShowOptions:
                            branchIds.AddRange(((ShowOptionsCommand) command).BranchIds);

                            break;
                        case EventCommandType.InputVariable:
                            branchIds.AddRange(((InputVariableCommand) command).BranchIds);

                            break;
                        case EventCommandType.ConditionalBranch:
                            branchIds.AddRange(((ConditionalBranchCommand) command).BranchIds);

                            break;
                        case EventCommandType.ChangeSpells:
                            branchIds.AddRange(((ChangeSpellsCommand) command).BranchIds);

                            break;
                        case EventCommandType.ChangeItems:
                            branchIds.AddRange(((ChangeItemsCommand) command).BranchIds);

                            break;
                        case EventCommandType.StartQuest:
                            branchIds.AddRange(((StartQuestCommand) command).BranchIds);

                            break;
                        case EventCommandType.ClassChangeWindow:
                            branchIds.AddRange(((ClassChangeWindowCommand)command).BranchIds);

                            break;
                        case EventCommandType.ItemChoiceWindow:
                            branchIds.AddRange(((ItemChoiceWindowCommand)command).BranchIds);

                            break;
                        case EventCommandType.Label:
                            //See if we found the label!
                            if (((LabelCommand) command).Label == label)
                            {
                                return true;
                            }

                            break;
                    }

                    //Test each branch
                    foreach (var branch in branchIds)
                    {
                        if (page.CommandLists.ContainsKey(branch))
                        {
                            var tmpStack = new CommandInstance(page)
                            {
                                CommandList = page.CommandLists[branch],
                                CommandIndex = 0,
                            };

                            stack.Peek().CommandIndex++;
                            stack.Push(tmpStack);
                            if (FindLabelResursive(stack, page, tmpStack.CommandList, label))
                            {
                                return true;
                            }

                            stack.Peek().CommandIndex--;
                        }
                    }

                    stack.Peek().CommandIndex++;
                }

                stack.Pop(); //We made it through a list
            }

            return false;
        }

        public static string ParseEventText(string input, Player player, Event instance)
        {
            if (input == null)
            {
                input = "";
            }

            if (player != null)
            {
                input = input.Replace(Strings.Events.playernamecommand, player.Name);
                if (instance != null)
                {
                    if (instance.PageInstance != null)
                    {
                        input = input.Replace(Strings.Events.eventnamecommand, instance.PageInstance.Name);
                        input = input.Replace(Strings.Events.commandparameter, instance.PageInstance.Param);
                    }

                    input = input.Replace(Strings.Events.eventparams, instance.FormatParameters(player));
                }

                if (input.Contains(Strings.Events.onlinelistcommand) ||
                    input.Contains(Strings.Events.onlinecountcommand))
                {
                    var onlineList = Globals.OnlineList;
                    input = input.Replace(Strings.Events.onlinecountcommand, onlineList.Count.ToString());
                    var sb = new StringBuilder();
                    for (var i = 0; i < onlineList.Count; i++)
                    {
                        sb.Append(onlineList[i].Name + (i != onlineList.Count - 1 ? ", " : ""));
                    }

                    input = input.Replace(Strings.Events.onlinelistcommand, sb.ToString());
                }

                //Time Stuff
                input = input.Replace(Strings.Events.timehour, Time.GetTime().ToString("%h"));
                input = input.Replace(Strings.Events.militaryhour, Time.GetTime().ToString("HH"));
                input = input.Replace(Strings.Events.timeminute, Time.GetTime().ToString("mm"));
                input = input.Replace(Strings.Events.timesecond, Time.GetTime().ToString("ss"));
                if (Time.GetTime().Hour >= 12)
                {
                    input = input.Replace(Strings.Events.timeperiod, Strings.Events.periodevening);
                }
                else
                {
                    input = input.Replace(Strings.Events.timeperiod, Strings.Events.periodmorning);
                }

                //Have to accept a numeric parameter after each of the following (player switch/var and server switch/var)
                var matches = Regex.Matches(input, Regex.Escape(Strings.Events.playervar) + @"{([^}]*)}");
                foreach (Match m in matches)
                {
                    if (m.Success)
                    {
                        var id = m.Groups[1].Value;
                        foreach (var var in PlayerVariableBase.Lookup.Values)
                        {
                            if (id == ((PlayerVariableBase) var).TextId)
                            {
                                input = input.Replace(
                                    Strings.Events.playervar + "{" + m.Groups[1].Value + "}",
                                    player.GetVariableValue(var.Id).ToString(((PlayerVariableBase) var).Type)
                                );
                            }
                        }
                    }
                }

                matches = Regex.Matches(input, Regex.Escape(Strings.Events.playerswitch) + @"{([^}]*)}");
                foreach (Match m in matches)
                {
                    if (m.Success)
                    {
                        var id = m.Groups[1].Value;
                        foreach (var var in PlayerVariableBase.Lookup.Values)
                        {
                            if (id == ((PlayerVariableBase) var).TextId)
                            {
                                input = input.Replace(
                                    Strings.Events.playerswitch + "{" + m.Groups[1].Value + "}",
                                    player.GetVariableValue(var.Id).ToString(((PlayerVariableBase) var).Type)
                                );
                            }
                        }
                    }
                }

                matches = Regex.Matches(input, Regex.Escape(Strings.Events.globalvar) + @"{([^}]*)}");
                foreach (Match m in matches)
                {
                    if (m.Success)
                    {
                        var id = m.Groups[1].Value;
                        foreach (var var in ServerVariableBase.Lookup.Values)
                        {
                            if (id == ((ServerVariableBase) var).TextId)
                            {
                                input = input.Replace(
                                    Strings.Events.globalvar + "{" + m.Groups[1].Value + "}",
                                    ((ServerVariableBase) var).Value.ToString(((ServerVariableBase) var).Type)
                                );
                            }
                        }
                    }
                }

                matches = Regex.Matches(input, Regex.Escape(Strings.Events.globalswitch) + @"{([^}]*)}");
                foreach (Match m in matches)
                {
                    if (m.Success)
                    {
                        var id = m.Groups[1].Value;
                        foreach (var var in ServerVariableBase.Lookup.Values)
                        {
                            if (id == ((ServerVariableBase) var).TextId)
                            {
                                input = input.Replace(
                                    Strings.Events.globalswitch + "{" + m.Groups[1].Value + "}",
                                    ((ServerVariableBase) var).Value.ToString(((ServerVariableBase) var).Type)
                                );
                            }
                        }
                    }
                }

                //Event Params
                matches = Regex.Matches(input, Regex.Escape(Strings.Events.eventparam) + @"{([^}]*)}");
                if (instance != null)
                {
                    foreach (Match m in matches)
                    {
                        if (m.Success)
                        {
                            var id = m.Groups[1].Value;
                            input = input.Replace(
                                Strings.Events.eventparam + "{" + m.Groups[1].Value + "}",
                                instance.GetParam(player, id.ToLower())
                            );
                        }
                    }
                }
            }

            return input;
        }

        private static void ProcessVariableModification(
            SetVariableCommand command,
            VariableMod mod,
            Player player,
            Event instance
        )
        {
        }

        private static void ProcessVariableModification(
            SetVariableCommand command,
            BooleanVariableMod mod,
            Player player,
            Event instance
        )
        {
            VariableValue value = null;
            if (command.VariableType == VariableTypes.PlayerVariable)
            {
                value = player.GetVariableValue(command.VariableId);
            }
            else if (command.VariableType == VariableTypes.ServerVariable)
            {
                value = ServerVariableBase.Get(command.VariableId)?.Value;
            }

            if (value == null)
            {
                value = new VariableValue();
            }

            if (mod.DuplicateVariableId != Guid.Empty)
            {
                if (mod.DupVariableType == VariableTypes.PlayerVariable)
                {
                    value.Boolean = player.GetVariableValue(mod.DuplicateVariableId).Boolean;
                }
                else if (mod.DupVariableType == VariableTypes.ServerVariable)
                {
                    var variable = ServerVariableBase.Get(mod.DuplicateVariableId);
                    if (variable != null)
                    {
                        value.Boolean = ServerVariableBase.Get(mod.DuplicateVariableId).Value.Boolean;
                    }
                }
            }
            else
            {
                value.Boolean = mod.Value;
            }

            if (command.VariableType == VariableTypes.PlayerVariable)
            {
                // Set the party member switches too if Sync Party enabled!
                if (command.SyncParty)
                {
                    foreach (var partyMember in player.Party)
                    {
                        if (partyMember != player)
                        {
                            partyMember.SetSwitchValue(command.VariableId, mod.Value);
                        }
                    }
                }
            }
        }

        private static void ProcessVariableModification(
            SetVariableCommand command,
            IntegerVariableMod mod,
            Player player,
            Event instance
        )
        {
            VariableValue value = null;
            if (command.VariableType == VariableTypes.PlayerVariable)
            {
                value = player.GetVariableValue(command.VariableId);
            }
            else if (command.VariableType == VariableTypes.ServerVariable)
            {
                value = ServerVariableBase.Get(command.VariableId)?.Value;
            }

            if (value == null)
            {
                value = new VariableValue();
            }

            switch (mod.ModType)
            {
                case Enums.VariableMods.Set:
                    value.Integer = mod.Value;

                    break;
                case Enums.VariableMods.Add:
                    value.Integer += mod.Value;

                    break;
                case Enums.VariableMods.Subtract:
                    value.Integer -= mod.Value;

                    break;
                case Enums.VariableMods.Multiply:
                    value.Integer *= mod.Value;

                    break;
                case Enums.VariableMods.Divide:
                    if (mod.Value != 0)  //Idiot proofing divide by 0 LOL
                    {
                        value.Integer /= mod.Value;
                    }

                    break;
                case Enums.VariableMods.LeftShift:
                    value.Integer = value.Integer << (int)mod.Value;

                    break;
                case Enums.VariableMods.RightShift:
                    value.Integer = value.Integer >> (int)mod.Value;

                    break;
                case Enums.VariableMods.Random:
                    //TODO: Fix - Random doesnt work with longs lolz
                    value.Integer = Randomization.Next((int) mod.Value, (int) mod.HighValue + 1);

                    break;
                case Enums.VariableMods.SystemTime:
                    var ms = (long) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                        .TotalMilliseconds;

                    value.Integer = ms;

                    break;
                case Enums.VariableMods.DupPlayerVar:
                    value.Integer = player.GetVariableValue(mod.DuplicateVariableId).Integer;

                    break;
                case Enums.VariableMods.DupGlobalVar:
                    var dupServerVariable = ServerVariableBase.Get(mod.DuplicateVariableId);
                    if (dupServerVariable != null)
                    {
                        value.Integer = dupServerVariable.Value.Integer;
                    }

                    break;
                case Enums.VariableMods.AddPlayerVar:
                    value.Integer += player.GetVariableValue(mod.DuplicateVariableId).Integer;

                    break;
                case Enums.VariableMods.AddGlobalVar:
                    var asv = ServerVariableBase.Get(mod.DuplicateVariableId);
                    if (asv != null)
                    {
                        value.Integer += asv.Value.Integer;
                    }

                    break;
                case Enums.VariableMods.SubtractPlayerVar:
                    value.Integer -= player.GetVariableValue(mod.DuplicateVariableId).Integer;

                    break;
                case Enums.VariableMods.SubtractGlobalVar:
                    var ssv = ServerVariableBase.Get(mod.DuplicateVariableId);
                    if (ssv != null)
                    {
                        value.Integer -= ssv.Value.Integer;
                    }

                    break;
                case Enums.VariableMods.MultiplyPlayerVar:
                    value.Integer *= player.GetVariableValue(mod.DuplicateVariableId).Integer;

                    break;
                case Enums.VariableMods.MultiplyGlobalVar:
                    var msv = ServerVariableBase.Get(mod.DuplicateVariableId);
                    if (msv != null)
                    {
                        value.Integer *= msv.Value.Integer;
                    }

                    break;
                case Enums.VariableMods.DividePlayerVar:
                    if (player.GetVariableValue(mod.DuplicateVariableId).Integer != 0) //Idiot proofing divide by 0 LOL
                    {
                        value.Integer /= player.GetVariableValue(mod.DuplicateVariableId).Integer;
                    }

                    break;
                case Enums.VariableMods.DivideGlobalVar:
                    var dsv = ServerVariableBase.Get(mod.DuplicateVariableId);
                    if (dsv != null)
                    {
                        if (dsv.Value != 0) //Idiot proofing divide by 0 LOL
                        {
                            value.Integer /= dsv.Value.Integer;
                        }
                    }

                    break;
                case Enums.VariableMods.LeftShiftPlayerVar:
                    value.Integer = value.Integer << (int)player.GetVariableValue(mod.DuplicateVariableId).Integer;

                    break;
                case Enums.VariableMods.LeftShiftGlobalVar:
                    var lhsv = ServerVariableBase.Get(mod.DuplicateVariableId);
                    if (lhsv != null)
                    {
                        value.Integer = value.Integer << (int)lhsv.Value.Integer;
                    }

                    break;
                case Enums.VariableMods.RightShiftPlayerVar:
                    value.Integer = value.Integer >> (int)player.GetVariableValue(mod.DuplicateVariableId).Integer;

                    break;
                case Enums.VariableMods.RightShiftGlobalVar:
                    var rhsv = ServerVariableBase.Get(mod.DuplicateVariableId);
                    if (rhsv != null)
                    {
                        value.Integer = value.Integer >> (int)rhsv.Value.Integer;
                    }

                    break;
            }

            if (command.VariableType == VariableTypes.PlayerVariable)
            {
                // Set the party member switches too if Sync Party enabled!
                if (command.SyncParty)
                {
                    foreach (var partyMember in player.Party)
                    {
                        if (partyMember != player)
                        {
                            partyMember.SetVariableValue(command.VariableId, value.Integer);
                        }
                    }
                }
            }
        }

        private static void ProcessVariableModification(
            SetVariableCommand command,
            StringVariableMod mod,
            Player player,
            Event instance
        )
        {
            VariableValue value = null;
            if (command.VariableType == VariableTypes.PlayerVariable)
            {
                value = player.GetVariableValue(command.VariableId);
            }
            else if (command.VariableType == VariableTypes.ServerVariable)
            {
                value = ServerVariableBase.Get(command.VariableId)?.Value;
            }

            if (value == null)
            {
                value = new VariableValue();
            }

            switch (mod.ModType)
            {
                case Enums.VariableMods.Set:
                    value.String = ParseEventText(mod.Value, player, instance);

                    break;
                case Enums.VariableMods.Replace:
                    var find = ParseEventText(mod.Value, player, instance);
                    var replace = ParseEventText(mod.Replace, player, instance);
                    value.String = value.String.Replace(find, replace);

                    break;
            }

            if (command.VariableType == VariableTypes.PlayerVariable)
            {
                // Set the party member switches too if Sync Party enabled!
                if (command.SyncParty)
                {
                    foreach (var partyMember in player.Party)
                    {
                        if (partyMember != player)
                        {
                            partyMember.SetVariableValue(command.VariableId, value.String);
                        }
                    }
                }
            }
        }

    }

}
