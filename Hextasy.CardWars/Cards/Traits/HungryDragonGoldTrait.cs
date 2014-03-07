﻿using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HungryDragonGoldTrait : HungryDragonTrait
    {
        public HungryDragonGoldTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        protected override void ActivateStarvingEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }

        protected override void ActivateSaturatedEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile, MonsterCard eatenMonster)
        {
            var numberOfCardsToTake = eatenMonster.Health / 2;
            Enumerable.Repeat(1, numberOfCardsToTake).Apply(p => cardWarsGameLogic.CurrentPlayer.DrawCard());
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new HungryDragonGoldTrait(monsterCard);
        }
    }
}
