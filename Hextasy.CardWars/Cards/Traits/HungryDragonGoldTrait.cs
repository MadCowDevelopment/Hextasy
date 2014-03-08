using System.Linq;

using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HungryDragonGoldTrait : HungryDragonTrait
    {
        #region Constructors

        public HungryDragonGoldTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Methods

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new HungryDragonGoldTrait(monsterCard);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void ActivateSaturatedEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile, MonsterCard eatenMonster)
        {
            var numberOfCardsToTake = eatenMonster.Health / 2;
            Enumerable.Repeat(1, numberOfCardsToTake).Apply(p => cardWarsGameLogic.CurrentPlayer.DrawCard());
        }

        protected override void ActivateStarvingEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }

        #endregion Protected Methods
    }
}