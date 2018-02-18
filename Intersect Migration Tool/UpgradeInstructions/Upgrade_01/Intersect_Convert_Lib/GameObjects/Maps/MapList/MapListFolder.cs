﻿using System.Collections.Generic;

namespace Intersect.Migration.UpgradeInstructions.Upgrade_1.Intersect_Convert_Lib.GameObjects.Maps.MapList
{
    public class MapListFolder : MapListItem
    {
        public MapList Children = new MapList();
        public int FolderId = -1;

        public MapListFolder()
            : base()
        {
            Name = "New Folder";
            Type = 0;
        }

        public void GetData(Upgrade_10.Intersect_Convert_Lib.ByteBuffer myBuffer, Dictionary<int, MapBase> gameMaps)
        {
            base.GetData(myBuffer);
            myBuffer.WriteInteger(FolderId);
            myBuffer.WriteBytes(Children.Data(gameMaps));
        }

        public bool Load(Upgrade_10.Intersect_Convert_Lib.ByteBuffer myBuffer, Dictionary<int, MapBase> gameMaps, bool isServer = true)
        {
            Children.Items.Clear();
            base.Load(myBuffer);
            FolderId = myBuffer.ReadInteger();
            return Children.Load(myBuffer, gameMaps, isServer, false);
        }
    }
}