using System.Linq;

using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public abstract class HungryDragonTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Constructors

        protected HungryDragonTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Hungry Dragon"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/FoodShank.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var adjacentMonsters =
                cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Where(p => !(p.Card is DragonCard)).ToList();

            var randomMonster = adjacentMonsters.RandomOrDefault();
            if (randomMonster == null)
            {
                ActivateStarvingEffect(cardWarsGameLogic, targetTile);
            }
            else
            {
                ActivateSaturatedEffect(cardWarsGameLogic, targetTile, randomMonster.Card);
                randomMonster.Card.Kill();
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract void ActivateSaturatedEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile,
            MonsterCard eatenMonster);

        protected abstract void ActivateStarvingEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);

        #endregion Protected Methods
    }
}