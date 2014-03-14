namespace Hextasy.CardWars.Logic
{
    public class CardDiedEventArgs
    {
        #region Constructors

        public CardDiedEventArgs(CardWarsTile tileOnWhichTheCardDied)
        {
            TileOnWhichTheCardDied = tileOnWhichTheCardDied;
        }

        #endregion Constructors

        #region Public Properties

        public CardWarsTile TileOnWhichTheCardDied
        {
            get;
            set;
        }

        #endregion Public Properties
    }
}