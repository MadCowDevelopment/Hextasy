using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    public class YinshStatistics : GameStatistics
    {
        public Player Winner { get; private set; }

        public YinshStatistics(Player currentPlayer)
        {
            Winner = currentPlayer;
        }
    }
}