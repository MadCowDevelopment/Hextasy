using System.Linq;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class AdjacentMonsterHaveHasteTrait : Trait, IActivateTraitOnAnyCardPlayed
    {
        #region Constructors

        public AdjacentMonsterHaveHasteTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Friendly monsters played adjacent to this get 'Haste'."; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Traits/haste_add.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

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

        #endregion Public Methods
    }
}