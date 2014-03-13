using System.Linq;

using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class RemoveDefenderTraitFromEnemiesTrait : Trait, IActivateTraitOnAnyCardPlayed
    {
        #region Constructors

        public RemoveDefenderTraitFromEnemiesTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Remove Defender Trait"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Traits/ShieldCrestedCrownBroken.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var enemyCardsWithDefenderTrait =
                cardWarsGameLogic.OpponentCards.Where(p => p.HasTrait<DefenderTrait>());
            enemyCardsWithDefenderTrait.Apply(p => p.RemoveTrait<DefenderTrait>(cardWarsGameLogic));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new RemoveDefenderTraitFromEnemiesTrait(monsterCard);
        }

        #endregion Public Methods
    }
}