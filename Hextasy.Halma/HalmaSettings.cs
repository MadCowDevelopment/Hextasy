using Hextasy.Framework;

namespace Hextasy.Halma
{
    public class HalmaSettings : Settings
    {
        public string Player1 { get; private set; }
        public string Player2 { get; private set; }

        public HalmaSettings(string player1, string player2) : base(9, 17)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}