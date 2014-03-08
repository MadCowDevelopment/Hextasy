namespace Hextasy.CardWars.Cards.Traits
{
    public class DrawCardTrait : Trait, IActivateTraitOnCardPlayed
    {
        #region Constructors

        public DrawCardTrait(MonsterCard cardThatHasTrait, int amount)
            : base(cardThatHasTrait)
        {
            Amount = amount;
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return string.Format("Draw {0} card(s)", Amount); }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Traits/drawcard.png"; }
        }

        #endregion Protected Properties

        #region Private Properties

        private int Amount
        {
            get; set;
        }

        #endregion Private Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            for (var i = 0; i < Amount; i++)
            {
                cardWarsGameLogic.CurrentPlayer.DrawCard();
            }
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new DrawCardTrait(monsterCard, Amount);
        }

        #endregion Public Methods
    }
}