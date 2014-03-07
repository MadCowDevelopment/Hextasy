using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class RemoveDefenderTraitFromEnemiesTrait : Trait, IActivateTraitOnAnyCardPlayed
    {
        public RemoveDefenderTraitFromEnemiesTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Remove Defender Trait"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Traits/ShieldCrestedCrownBroken.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var enemyCardsWithDefenderTrait =
                cardWarsGameLogic.OpponentCards.Where(p => p.HasTrait<DefenderTrait>());
            enemyCardsWithDefenderTrait.Apply(p => p.RemoveTrait<DefenderTrait>());
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new RemoveDefenderTraitFromEnemiesTrait(monsterCard);
        }
    }
}
