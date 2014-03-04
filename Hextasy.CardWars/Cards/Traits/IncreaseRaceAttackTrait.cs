using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class IncreaseRaceAttackTrait : Trait, IActivateTraitOnAnyCardPlayed
    {
        private int Amount { get; set; }
        private Race Race { get; set; }

        private List<MonsterCard> _buffedCards;

        public IncreaseRaceAttackTrait(MonsterCard cardThatHasTrait, int amount, Race race)
            : base(cardThatHasTrait)
        {
            Amount = amount;
            Race = race;
        }

        public override string Name
        {
            get { return "Increase Attack"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/enchant-magenta-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var allCardsOfCurrentPlayerWithRace =
                cardWarsGameLogic.AllCards.Where(
                    p => p.Player.Owner == targetTile.Owner && p != CardThatHasTrait && p.Race == Race);
            if (_buffedCards == null) _buffedCards = new List<MonsterCard>();
            var beastsToBuff = allCardsOfCurrentPlayerWithRace.Except(_buffedCards).ToList();
            beastsToBuff.Apply(p => p.AttackBonus += Amount);
            _buffedCards.AddRange(beastsToBuff);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return (IncreaseRaceAttackTrait) Activator.CreateInstance(GetType(), CardThatHasTrait, Amount, Race);
        }
    }
}
