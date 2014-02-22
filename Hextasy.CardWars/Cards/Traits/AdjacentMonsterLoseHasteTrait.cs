using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class AdjacentMonsterLoseHasteTrait : Trait, IActivateTraitOnDeath
    {
        public AdjacentMonsterLoseHasteTrait(MonsterCard cardThatHasTrait) : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return string.Empty; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var allAdjacentTilesWitHaste =
                cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile)
                    .Where(p => p.Card.Player == CardThatHasTrait.Player && p.Card.Traits.OfType<HasteTrait>().Any());
            allAdjacentTilesWitHaste.Apply(p => p.Card.RemoveTrait<HasteTrait>());
        }
    }
}
