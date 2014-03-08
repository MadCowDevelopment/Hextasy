namespace Hextasy.CardWars.Cards.Traits
{
    public class HasteTrait : Trait, IActivateTraitOnCardPlayed
    {
        #region Constructors

        public HasteTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Haste"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/haste.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            CardThatHasTrait.IsExhausted = false;
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new HasteTrait(monsterCard);
        }

        #endregion Public Methods
    }
}