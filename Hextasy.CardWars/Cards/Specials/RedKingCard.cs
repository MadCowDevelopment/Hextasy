namespace Hextasy.CardWars.Cards.Specials
{
    public class RedKingCard : KingCard
    {
        #region Public Properties

        public override Race Race
        {
            get { return Race.Special; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"crown-red.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new RedKingCard();
        }

        #endregion Protected Methods
    }
}