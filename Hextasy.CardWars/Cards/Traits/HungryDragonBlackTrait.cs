using System.Collections.Generic;
using System.Linq;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HungryDragonBlackTrait : HungryDragonTrait
    {
        public HungryDragonBlackTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        protected override void ActivateStarvingEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var enemyMonsters = cardWarsGameLogic.OpponentCardsExceptKing.Where(p => p.Attack <= 3 && !(p is DragonCard));
            KillEnemyMonster(enemyMonsters);
            KillEnemyMonster(enemyMonsters);
        }

        protected override void ActivateSaturatedEffect(
            CardWarsGameLogic cardWarsGameLogic,
            CardWarsTile targetTile,
            MonsterCard eatenMonster)
        {
        }

        private void KillEnemyMonster(IEnumerable<MonsterCard> enemyMonsters)
        {
            var randomMonster = enemyMonsters.RandomOrDefault();
            if (randomMonster != null) randomMonster.Kill();
        }
    }
}
