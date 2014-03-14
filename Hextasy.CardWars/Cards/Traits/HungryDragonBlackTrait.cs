using System.Collections.Generic;
using System.Linq;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HungryDragonBlackTrait : HungryDragonTrait
    {
        #region Constructors

        public HungryDragonBlackTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Methods

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new HungryDragonBlackTrait(monsterCard);
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
            var enemyMonsters = cardWarsGameLogic.OpponentCardsExceptKing.Where(p => p.Attack <= 3 && !(p is DragonCard));
            KillEnemyMonster(enemyMonsters);
            KillEnemyMonster(enemyMonsters);
        }

        #endregion Protected Methods

        #region Private Methods

        private void KillEnemyMonster(IEnumerable<MonsterCard> enemyMonsters)
        {
            var randomMonster = enemyMonsters.RandomOrDefault();
            if (randomMonster != null) randomMonster.Kill();
        }

        #endregion Private Methods
    }
}