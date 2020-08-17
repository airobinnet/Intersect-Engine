namespace Intersect.Network.Packets.Client
{

    public class LoginCheckPacket : CerasPacket
    {

        public LoginCheckPacket(string username)
        {
            Username = username;
        }

        public string Username { get; set; }

    }

}
