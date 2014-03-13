using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class PopeTrait : Trait, IActivateTraitOnCardPlayed
    {
        #region Constructors

        public PopeTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Increase attack and heal"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/HumanPriest31B.PNG"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.CurrentPlayerCardsExceptKing.Apply(p => p.AttackBonus += 1);
            cardWarsGameLogic.CurrentPlayerCards.Apply(p => cardWarsGameLogic.Heal(p, 2));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new PopeTrait(monsterCard);
        }

        #endregion Public Methods
    }
}