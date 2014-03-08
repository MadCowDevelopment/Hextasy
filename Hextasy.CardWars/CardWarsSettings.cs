using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class CardWarsSettings : Settings
    {
        #region Constructors

        public CardWarsSettings(
            int rows,
            int columns,
            Player player1,
            Player player2)
            : base(rows, columns)
        {
            Player1 = player1;
            Player2 = player2;
        }

        #endregion Constructors

        #region Public Properties

        public Player Player1
        {
            get; private set;
        }

        public Player Player2
        {
            get; private set;
        }

        #endregion Public Properties
    }
}