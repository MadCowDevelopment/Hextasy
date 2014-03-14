using System.Linq;

using Caliburn.Micro;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HungryDragonRedTrait : HungryDragonTrait
    {
        #region Constructors

        public HungryDragonRedTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Methods

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new HungryDragonRedTrait(monsterCard);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void ActivateSaturatedEffect(
            CardWarsGameLogic cardWarsGameLogic,
            CardWarsTile targetTile,
            MonsterCard eatenMonster)
        {
        }

        protected override void ActivateStarvingEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var enemyMonsters = cardWarsGameLogic.AllCardsExceptKing.Where(p => p != targetTile.Card);
            enemyMonsters.Apply(p => p.TakeFireDamage(2));
        }

        #endregion Protected Methods
    }
}