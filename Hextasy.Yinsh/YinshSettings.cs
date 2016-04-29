using Hextasy.Framework;
using Hextasy.Yinsh.AI;

namespace Hextasy.Yinsh
{
    public class YinshSettings : Settings
    {
        public YinshSettings(int rows, int columns) : base(rows, columns)
        {
            Player1 = new Player();
            Player2 = new CpuPlayer();
        }

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
    }
}