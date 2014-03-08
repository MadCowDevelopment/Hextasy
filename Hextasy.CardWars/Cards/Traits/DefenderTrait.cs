namespace Hextasy.CardWars.Cards.Traits
{
    public class DefenderTrait : Trait
    {
        #region Constructors

        public DefenderTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Defender"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/protect-royal-2.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new DefenderTrait(monsterCard);
        }

        #endregion Public Methods
    }
}