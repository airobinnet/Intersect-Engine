namespace Intersect.Network.Packets.Server
{

    public class ShopPacket : CerasPacket
    {

        public ShopPacket(string shopData, bool close, string reqcheck)
        {
            ShopData = shopData;
            Close = close;
            ReqCheck = reqcheck;
        }

        public string ShopData { get; set; }

        public bool Close { get; set; }

        public string ReqCheck { get; set; }

    }

}
