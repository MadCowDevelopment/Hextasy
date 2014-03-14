using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class ImmunityFrostTrait : Trait
    {
        #region Constructors

        public ImmunityFrostTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Immunity: Frost"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Spells/protect-blue-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new ImmunityFrostTrait(monsterCard);
        }

        #endregion Public Methods
    }
}