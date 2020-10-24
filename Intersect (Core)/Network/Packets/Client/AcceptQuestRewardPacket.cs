using System;

namespace Intersect.Network.Packets.Client
{

    public class AcceptQuestRewardPacket : CerasPacket
    {

        public AcceptQuestRewardPacket(Guid questId, Guid taskId, int choice)
        {
            QuestId = questId;
            Choice = choice;
            TaskId = taskId;
        }

        public Guid QuestId { get; set; }

        public Guid TaskId { get; set; }

        public int Choice { get; set; }

    }

}
