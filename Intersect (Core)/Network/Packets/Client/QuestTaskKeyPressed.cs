using System;

namespace Intersect.Network.Packets.Client
{

    public class QuestTaskKeyPressed : CerasPacket
    {

        public QuestTaskKeyPressed(int key)
        {
            Key = key;
        }

        public int Key { get; set; }

    }

}
