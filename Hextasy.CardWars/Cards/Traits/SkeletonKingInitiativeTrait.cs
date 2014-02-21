using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class SkeletonKingInitiativeTrait : Trait, IActivateTraitOnCardPlayed
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
            var neighbours = cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).ToList();
            neighbours.Where(p => p.Owner != targetTile.Owner).Apply(p => p.Card.AttackBonus -= 2);
            neighbours.Where(p => p.Card.Race == Race.Undead).Apply(p => p.Card.AttackBonus += 3);
        }
    }
}
