using System.Linq;

namespace Hextasy.CardWars.Cards.Traits
{
    public class AdjacentMonsterHaveHasteTrait : Trait, IActivateTraitOnAnyCardPlayed
    {
        private MonsterCard CardWithTrait { get; set; }

        public AdjacentMonsterHaveHasteTrait(MonsterCard cardWithTrait)
        {
            CardWithTrait = cardWithTrait;
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

            var tileWithTrait = cardWarsGameLogic.Tiles.SingleOrDefault(p => p.Card == CardWithTrait);
            var allAdjacentTilesWithoutHaste =
                cardWarsGameLogic.GetAdjacentMonsterTiles(tileWithTrait)
                    .Where(p => p.Card.Player == CardWithTrait.Player && !p.Card.Traits.OfType<HasteTrait>().Any());

            if (allAdjacentTilesWithoutHaste.Contains(targetTile))
            {
                targetTile.Card.AddTrait(new HasteTrait());
                targetTile.Card.IsExhausted = false;
            }
        }
    }
}
