using System;
using System.Collections.Generic;

using Intersect.Collections;
using Intersect.GameObjects;


namespace Intersect.Network.Packets.Client
{

    public class SendCreateGuildPacket : CerasPacket
    {

        public SendCreateGuildPacket(string name, string tag)
        {
            Name = name;
            Tag = tag;
        }
        

        public string Name { get; set; }

        public string Tag { get; set; }

    }

}
