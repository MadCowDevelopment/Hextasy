using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class AdjacentMonsterLoseHasteTrait : Trait, IActivateTraitOnDeath
    {
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
            var allAdjacentTilesWithoutHaste =
    cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile)
        .Where(p => p.Card.Player == targetTile.Card.Player && !p.Card.Traits.OfType<HasteTrait>().Any());
            allAdjacentTilesWithoutHaste.Apply(p => p.Card.RemoveTrait<HasteTrait>());
        }
    }
}
