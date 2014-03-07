using Caliburn.Micro;
using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HungryDragonBlueTrait : HungryDragonTrait
    {
        public HungryDragonBlueTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        protected override void ActivateStarvingEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var enemyMonsters = cardWarsGameLogic.OpponentCards;
            enemyMonsters.Apply(p => p.AddDebuff(new FrozenDebuff()));
        }

        protected override void ActivateSaturatedEffect(
            CardWarsGameLogic cardWarsGameLogic,
            CardWarsTile targetTile,
            MonsterCard eatenMonster)
        {
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new HungryDragonBlueTrait(monsterCard);
        }
    }
}
