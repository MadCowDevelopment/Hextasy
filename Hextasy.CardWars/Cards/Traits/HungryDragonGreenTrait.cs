using Caliburn.Micro;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HungryDragonGreenTrait : HungryDragonTrait
    {
        #region Constructors

        public HungryDragonGreenTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Methods

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new HungryDragonGreenTrait(monsterCard);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void ActivateSaturatedEffect(
            CardWarsGameLogic cardWarsGameLogic,
            CardWarsTile targetTile,
            MonsterCard eatenMonster)
        {
            var friendlyMonsters = cardWarsGameLogic.CurrentPlayerCards;
            friendlyMonsters.Apply(p => cardWarsGameLogic.Heal(p, 2));
        }

        protected override void ActivateStarvingEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }

        #endregion Protected Methods
    }
}