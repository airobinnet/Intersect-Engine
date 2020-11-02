using System;
using System.Collections.Generic;

namespace Intersect.Network.Packets.Server
{

    public class CraftingTablePacket : CerasPacket
    {

        public CraftingTablePacket(string tableData, bool close, List<Guid> reqcheck)
        {
            TableData = tableData;
            Close = close;
            ReqCheck = reqcheck;
        }

        public string TableData { get; set; }

        public bool Close { get; set; }

        public List<Guid> ReqCheck { get; set; }

    }

}
