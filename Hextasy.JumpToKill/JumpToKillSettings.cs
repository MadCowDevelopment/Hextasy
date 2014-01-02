using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    public class JumpToKillSettings : Settings
    {
        public string Player1 { get; private set; }
        public string Player2 { get; private set; }

        public JumpToKillSettings(int rows, int columns, string player1, string player2) : base(rows, columns)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}