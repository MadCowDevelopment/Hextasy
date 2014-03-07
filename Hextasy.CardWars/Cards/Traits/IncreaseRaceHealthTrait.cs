using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class IncreaseRaceHealthTrait : Trait, IActivateTraitOnAnyCardPlayed
    {
        private int Amount { get; set; }
        private Race Race { get; set; }

        private List<MonsterCard> _buffedCards;

        public IncreaseRaceHealthTrait(MonsterCard cardThatHasTrait, int amount, Race race)
            : base(cardThatHasTrait)
        {
            Amount = amount;
            Race = race;
        }

        public override string Name
        {
            get { return "Increase Health"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/heal-sky-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var allBeastCardsOfCurrentPlayer =
                cardWarsGameLogic.AllCards.Where(
                    p => p.Player.Owner == CardThatHasTrait.Owner && p != CardThatHasTrait && p.Race == Race);
            if (_buffedCards == null) _buffedCards = new List<MonsterCard>();
            var beastsToBuff = allBeastCardsOfCurrentPlayer.Except(_buffedCards).ToList();
            beastsToBuff.Apply(p => p.HealthBonus += Amount);
            _buffedCards.AddRange(beastsToBuff);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new IncreaseRaceHealthTrait(monsterCard, Amount, Race);
        }
    }
}