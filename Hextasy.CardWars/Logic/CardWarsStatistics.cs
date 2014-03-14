using Hextasy.Framework;

namespace Hextasy.CardWars.Logic
{
    public class CardWarsStatistics : GameStatistics
    {
        #region Constructors

        public CardWarsStatistics(Owner winner, int player1Life, int player2Life)
        {
            Winner = winner;
            Player1Life = player1Life;
            Player2Life = player2Life;
        }

        #endregion Constructors

        #region Public Properties

        public int Player1Life
        {
            get;
            set;
        }

        public int Player2Life
        {
            get;
            set;
        }

        public Owner Winner
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}