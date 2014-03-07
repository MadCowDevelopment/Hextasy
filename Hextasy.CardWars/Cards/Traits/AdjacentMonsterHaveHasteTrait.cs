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
            get { return "Friendly monsters played adjacent to this get 'Haste'."; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Traits/haste_add.png"; }
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

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new AdjacentMonsterHaveHasteTrait(monsterCard);
        }
    }
}
