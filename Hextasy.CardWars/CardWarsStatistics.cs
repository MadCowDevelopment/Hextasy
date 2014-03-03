using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class CardWarsStatistics : GameStatistics
    {
        public Owner Winner { get; set; }
        public int Player1Life { get; set; }
        public int Player2Life { get; set; }

        public CardWarsStatistics(Owner winner, int player1Life, int player2Life)
        {
            Winner = winner;
            Player1Life = player1Life;
            Player2Life = player2Life;
        }
    }
}