using System.Linq;

using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class AdjacentMonsterLoseHasteTrait : Trait, IActivateTraitOnDeath
    {
        #region Constructors

        public AdjacentMonsterLoseHasteTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return string.Empty; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var allAdjacentTilesWitHaste =
                cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile)
                    .Where(p => p.Card.Player == CardThatHasTrait.Player && p.Card.Traits.OfType<HasteTrait>().Any());
            allAdjacentTilesWitHaste.Apply(p => p.Card.RemoveTrait<HasteTrait>());
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new AdjacentMonsterLoseHasteTrait(monsterCard);
        }

        #endregion Public Methods
    }
}