namespace Hextasy.CardWars.Cards.Traits
{
    public class ImmunityFireTrait : Trait
    {
        #region Constructors

        public ImmunityFireTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Immunity: Fire"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Spells/protect-red-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new ImmunityFireTrait(monsterCard);
        }

        #endregion Public Methods
    }
}