namespace Intersect.Network.Packets.Server
{

    public class HasAccountPacket : CerasPacket
    {

        public HasAccountPacket(bool hasaccount)
        {
            HasAccount = hasaccount;
        }

        public bool HasAccount { get; set; }

    }

}
