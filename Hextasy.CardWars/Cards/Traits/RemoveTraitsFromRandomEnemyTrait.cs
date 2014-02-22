using System.Linq;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class RemoveTraitsFromRandomEnemyTrait : Trait, IActivateTraitOnEndTurn
    {
        public RemoveTraitsFromRandomEnemyTrait(MonsterCard cardThatHasTrait) : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Remove Traits"; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var enemyCardWithTraits = cardWarsGameLogic.OpponentCards.Where(p => p.Traits.Count > 0).RandomOrDefault();
            if (enemyCardWithTraits == null) return;
            enemyCardWithTraits.ClearTraits();
        }
    }
}
