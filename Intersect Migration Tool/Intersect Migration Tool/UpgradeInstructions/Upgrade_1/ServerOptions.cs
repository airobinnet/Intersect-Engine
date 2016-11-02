﻿using System;
using System.IO;
using System.Xml;
using Intersect_Migration_Tool.UpgradeInstructions.Upgrade_1.Intersect_Convert_Lib;

namespace Intersect_Migration_Tool.UpgradeInstructions.Upgrade_1
{
    public static class ServerOptions
    {
        //Config XML String
        public static string ConfigXml = "";
        private static bool ConfigFailed = false;

        //Misc
        public static int ItemDespawnTime = 15000; //15 seconds
        public static int ItemRespawnTime = 15000; //15 seconds

        //Combat
        public static int RegenTime = 3000; //3 seconds

        //Options File
        public static bool LoadOptions()
        {

            if (!File.Exists("resources/config.xml"))
            {
                var settings = new XmlWriterSettings { Indent = true };
                var writer = XmlWriter.Create("resources/config.xml", settings);
                writer.WriteStartDocument();
                writer.WriteComment("Config.xml generated automatically by Intersect Server.");
                writer.WriteStartElement("Config");
                writer.WriteElementString("GameName", "Intersect");
                writer.WriteElementString("MOTD", "Welcome to Intersect!");
                writer.WriteElementString("ServerPort", "4500");

                writer.WriteStartElement("GameObjects");
                writer.WriteComment("You can increase these if you want, but you shouldn't unless you need to.");
                writer.WriteElementString("MaxNpcDrops", "10");
                writer.WriteEndElement();

                writer.WriteStartElement("Player");
                writer.WriteElementString("MaxStat", "255");
                writer.WriteElementString("MaxLevel", "100");
                writer.WriteElementString("MaxInventory", "35");
                writer.WriteElementString("MaxSpells", "35");
                writer.WriteElementString("MaxBank", "100");
                writer.WriteEndElement();

                writer.WriteStartElement("Equipment");
                writer.WriteElementString("WeaponSlot", "2");
                writer.WriteElementString("ShieldSlot", "3");
                writer.WriteElementString("Slot0", "Helmet");
                writer.WriteElementString("Slot1", "Armor");
                writer.WriteElementString("Slot2", "Weapon");
                writer.WriteElementString("Slot3", "Shield");
                writer.WriteElementString("Slot4", "Boots");
                writer.WriteEndElement();

                writer.WriteStartElement("Paperdoll");
                writer.WriteComment("Paperdoll is rendered in the following order. If you want to change when each piece of equipment gets rendered simply swap the equipment names.");
                writer.WriteElementString("Slot0", "Helmet");
                writer.WriteElementString("Slot1", "Armor");
                writer.WriteElementString("Slot2", "Weapon");
                writer.WriteElementString("Slot3", "Shield");
                writer.WriteElementString("Slot4", "Boots");
                writer.WriteEndElement();

                writer.WriteStartElement("ToolTypes");
                writer.WriteElementString("Slot0", "Axe");
                writer.WriteElementString("Slot1", "Pickaxe");
                writer.WriteElementString("Slot2", "Shovel");
                writer.WriteElementString("Slot3", "Fishing Rod");
                writer.WriteEndElement();

                writer.WriteStartElement("Misc");
                writer.WriteElementString("ItemDespawnTime", "15000");
                writer.WriteElementString("ItemSpawnTime", "15000");
                writer.WriteEndElement();

                writer.WriteStartElement("Combat");
                writer.WriteElementString("RegenTime", "3000");
                writer.WriteElementString("MinAttackRate", "1000");
                writer.WriteElementString("MaxAttackRate", "400");
                writer.WriteElementString("BlockingSlow", "30");
                writer.WriteElementString("CritChance", "20");
                writer.WriteElementString("CritMultiplier", "150");
                writer.WriteElementString("MaxDashSpeed", "200");
                writer.WriteEndElement();

                writer.WriteStartElement("Map");
                writer.WriteComment("MapBorder Override. 0 for seamless with scrolling that stops on world edges. 1 for non-seamless, and 2 for seamless where the camera knows no boundaries. (Black borders where the world ends)");
                writer.WriteElementString("BorderStyle", "0");
                writer.WriteComment("DO NOT TOUCH! These values will resize the maps in the engine and will CORRUPT existing maps. In MOST cases this value should not be changed. It would be wise to consult us before doing so!");
                writer.WriteElementString("MapWidth", "32");
                writer.WriteElementString("MapHeight", "26");
                writer.WriteElementString("TileWidth", "32");
                writer.WriteElementString("TileHeight", "32");
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
                ConfigXml = File.ReadAllText("resources/config.xml");
                Console.WriteLine("Configuration file was missing and regenerated by the server! Reloading Options Now.");
                return LoadOptions();
            }
            else
            {
                var options = new XmlDocument();
                ConfigXml = File.ReadAllText("resources/config.xml");
                try
                {
                    options.LoadXml(ConfigXml);

                    //General Options
                    Options.GameName = GetXmlStr(options, "//Config/GameName", false);
                    Options.MOTD = GetXmlStr(options, "//Config/MOTD", false);
                    Options.ServerPort = GetXmlInt(options, "//Config/ServerPort");

                    //Game Objects
                    Options.MaxNpcDrops = GetXmlInt(options, "//Config/GameObjects/MaxNpcDrops");

                    //Player Options
                    Options.MaxStatValue = GetXmlInt(options, "//Config/Player/MaxStat");
                    Options.MaxLevel = GetXmlInt(options, "//Config/Player/MaxLevel");
                    Options.MaxInvItems = GetXmlInt(options, "//Config/Player/MaxInventory");
                    Options.MaxPlayerSkills = GetXmlInt(options, "//Config/Player/MaxSpells");
                    Options.MaxBankSlots = GetXmlInt(options, "//Config/Player/MaxBank");

                    //Equipment
                    int slot = 0;
                    while (!string.IsNullOrEmpty(GetXmlStr(options, "//Config/Equipment/Slot" + slot, false)))
                    {
                        if (Options.EquipmentSlots.IndexOf(GetXmlStr(options, "//Config/Equipment/Slot" + slot, false)) > -1)
                        {
                            Console.WriteLine("Tried to add the same piece of equipment twice, this is not permitted.  (Path: " + "//Config/Equipment/Slot" + slot + ")");
                            return false;
                        }
                        else
                        {
                            Options.EquipmentSlots.Add(GetXmlStr(options, "//Config/Equipment/Slot" + slot, false));
                        }
                        slot++;
                    }
                    Options.WeaponIndex = GetXmlInt(options, "//Config/Equipment/WeaponSlot");
                    if (Options.WeaponIndex < -1 || Options.WeaponIndex > Options.EquipmentSlots.Count - 1)
                    {
                        Console.WriteLine("Weapon Slot is out of bounds! Make sure the slot exists and you are counting starting from zero! Use -1 if you do not wish to have equipable weapons in-game!  (Path: " + "//Config/Equipment/WeaponSlot)");
                    }
                    Options.ShieldIndex = GetXmlInt(options, "//Config/Equipment/ShieldSlot");
                    if (Options.ShieldIndex < -1 || Options.ShieldIndex > Options.EquipmentSlots.Count - 1)
                    {
                        Console.WriteLine("Shield Slot is out of bounds! Make sure the slot exists and you are counting starting from zero! Use -1 if you do not wish to have equipable shields in-game!  (Path: " + "//Config/Equipment/ShieldSlot)");
                    }

                    //Paperdoll
                    slot = 0;
                    while (!string.IsNullOrEmpty(GetXmlStr(options, "//Config/Paperdoll/Slot" + slot, false)))
                    {
                        if (Options.EquipmentSlots.IndexOf(GetXmlStr(options, "//Config/Paperdoll/Slot" + slot, false)) > -1)
                        {
                            if (Options.PaperdollOrder.IndexOf(GetXmlStr(options, "//Config/Paperdoll/Slot" + slot, false)) > -1)
                            {
                                Console.WriteLine("Tried to add the same piece of equipment to the paperdoll render order twice, this is not permitted.  (Path: " + "//Config/Paperdoll/Slot" + slot + ")");
                                return false;
                            }
                            else
                            {
                                Options.PaperdollOrder.Add(GetXmlStr(options, "//Config/Paperdoll/Slot" + slot, false));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tried to add a paperdoll for a piece of equipment that does not exist!  (Path: " + "//Config/Paperdoll/Slot" + slot + ")");
                            return false;
                        }
                        slot++;
                    }

                    //Tool Types
                    slot = 0;
                    while (!string.IsNullOrEmpty(GetXmlStr(options, "//Config/ToolTypes/Slot" + slot, false)))
                    {
                        if (Options.ToolTypes.IndexOf(GetXmlStr(options, "//Config/ToolTypes/Slot" + slot, false)) > -1)
                        {
                            Console.WriteLine("Tried to add the same type of tool twice, this is not permitted.  (Path: " + "//Config/ToolTypes/Slot" + slot + ")");
                            return false;
                        }
                        else
                        {
                            Options.ToolTypes.Add(GetXmlStr(options, "//Config/ToolTypes/Slot" + slot, false));
                        }
                        slot++;
                    }

                    //Misc
                    ItemDespawnTime = GetXmlInt(options, "//Config/Misc/ItemDespawnTime");
                    ItemRespawnTime = GetXmlInt(options, "//Config/Misc/ItemSpawnTime");

                    //Combat
                    RegenTime = GetXmlInt(options, "//Config/Combat/RegenTime");
                    Options.MinAttackRate = GetXmlInt(options, "//Config/Combat/MinAttackRate");
                    Options.MaxAttackRate = GetXmlInt(options, "//Config/Combat/MaxAttackRate");
                    Options.MaxAttackRate = GetXmlInt(options, "//Config/Combat/CritChance");
                    Options.MaxDashSpeed = GetXmlInt(options, "//Config/Combat/MaxDashSpeed");

                    //Map
                    Options.GameBorderStyle = GetXmlInt(options, "//Config/Map/BorderStyle");
                    Options.MapWidth = GetXmlInt(options, "//Config/Map/MapWidth");
                    Options.MapHeight = GetXmlInt(options, "//Config/Map/MapHeight");
                    if (Options.MapWidth < 10 || Options.MapWidth > 64 || Options.MapHeight < 10 || Options.MapHeight > 64)
                    {
                        Console.WriteLine("MapWidth and/or MapHeight are out of bounds. Must be between 10 and 64. The client loads 9 maps at a time, having large map sizes really hurts performance.");
                        ConfigFailed = true;
                    }
                    Options.TileWidth = GetXmlInt(options, "//Config/Map/TileWidth");
                    Options.TileHeight = GetXmlInt(options, "//Config/Map/TileHeight");

                    if (ConfigFailed)
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to load config.xml. Exception info: " + ex.ToString());
                    return false;
                }
            }
            return !ConfigFailed;
        }

        public static byte[] GetServerConfig()
        {
            ByteBuffer bf = new ByteBuffer();
            bf.WriteString(Options.GameName);

            //Game Objects
            bf.WriteInteger(Options.MaxNpcDrops);

            //Player Objects
            bf.WriteInteger(Options.MaxStatValue);
            bf.WriteInteger(Options.MaxLevel);
            bf.WriteInteger(Options.MaxHotbar);
            bf.WriteInteger(Options.MaxInvItems);
            bf.WriteInteger(Options.MaxPlayerSkills);
            bf.WriteInteger(Options.MaxBankSlots);

            //Equipment
            bf.WriteInteger(Options.EquipmentSlots.Count);
            for (int i = 0; i < Options.EquipmentSlots.Count; i++)
            {
                bf.WriteString(Options.EquipmentSlots[i]);
            }
            bf.WriteInteger(Options.WeaponIndex);
            bf.WriteInteger(Options.ShieldIndex);

            //Paperdoll
            bf.WriteInteger(Options.PaperdollOrder.Count);
            for (int i = 0; i < Options.PaperdollOrder.Count; i++)
            {
                bf.WriteString(Options.PaperdollOrder[i]);
            }

            //Tool Types
            bf.WriteInteger(Options.ToolTypes.Count);
            for (int i = 0; i < Options.ToolTypes.Count; i++)
            {
                bf.WriteString(Options.ToolTypes[i]);
            }

            //Combat
            bf.WriteInteger(Options.MinAttackRate);
            bf.WriteInteger(Options.MaxAttackRate);
            bf.WriteInteger(Options.MaxDashSpeed);

            //Map
            bf.WriteInteger(Options.GameBorderStyle);
            bf.WriteInteger(Options.MapWidth);
            bf.WriteInteger(Options.MapHeight);
            bf.WriteInteger(Options.TileWidth);
            bf.WriteInteger(Options.TileHeight);

            return bf.ToArray();
        }

        private static int GetXmlInt(XmlDocument xmlDoc, string xmlPath, bool required = true)
        {
            var selectSingleNode = xmlDoc.SelectSingleNode(xmlPath);
            int returnVal = 0;
            if (selectSingleNode == null)
            {
                if (required)
                {
                    Console.WriteLine("Path does not exist in config.xml  (Path: " + xmlPath + ")");
                    ConfigFailed = true;
                }
            }
            else if (!int.TryParse(selectSingleNode.InnerText, out returnVal))
            {
                if (required)
                {
                    Console.WriteLine("Failed to load value from config.xml  (Path: " + xmlPath + ")");
                    ConfigFailed = true;
                }
            }
            return returnVal;
        }

        private static string GetXmlStr(XmlDocument xmlDoc, string xmlPath, bool required = true)
        {
            var selectSingleNode = xmlDoc.SelectSingleNode(xmlPath);
            string returnVal = "";
            if (selectSingleNode == null)
            {
                if (required)
                {
                    Console.WriteLine("Path does not exist in config.xml  (Path: " + xmlPath + ")");
                    ConfigFailed = true;
                }
            }
            else
            {
                returnVal = selectSingleNode.InnerText;
            }
            return returnVal;
        }
    }
}