using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HungryDragonGreenTrait : HungryDragonTrait
    {
        protected override void ActivateStarvingEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }

        protected override void ActivateSaturatedEffect(
            CardWarsGameLogic cardWarsGameLogic,
            CardWarsTile targetTile,
            MonsterCard eatenMonster)
        {
            var friendlyMonsters = cardWarsGameLogic.CurrentPlayerCards;
            friendlyMonsters.Apply(p => p.Heal(2));
        }
    }
}
