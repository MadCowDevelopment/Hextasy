using System.Linq;

namespace Hextasy.CardWars.Cards.Traits
{
    public class AdjacentMonsterHaveHasteTrait : Trait, IActivateTraitOnAnyCardPlayed
    {
        public AdjacentMonsterHaveHasteTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Adjacent monsters have 'Haste'."; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            if (targetTile.Card == null) return;

            var tileWithTrait = cardWarsGameLogic.Tiles.SingleOrDefault(p => p.Card == CardThatHasTrait);
            var allAdjacentTilesWithoutHaste =
                cardWarsGameLogic.GetAdjacentMonsterTiles(tileWithTrait)
                    .Where(p => p.Card.Player == CardThatHasTrait.Player && !p.Card.Traits.OfType<HasteTrait>().Any());

            if (allAdjacentTilesWithoutHaste.Contains(targetTile))
            {
                targetTile.Card.AddTrait(new HasteTrait(targetTile.Card));
                targetTile.Card.IsExhausted = false;
            }
        }
    }
}
