namespace Hextasy.CardWars.Cards
{
    public abstract class SpellCard : Card
    {
        #region Public Properties

        public override CardType Type
        {
            get { return CardType.Spell; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFolder
        {
            get { return @"pack://application:,,,/Hextasy.CardWars;component/Images/Cards/Spells/"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public abstract void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);

        #endregion Public Methods
    }
}