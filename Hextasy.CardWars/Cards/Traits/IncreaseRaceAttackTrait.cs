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

        public IncreaseRaceAttackTrait(int amount, Race race)
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
            var allBeastCardsOfCurrentPlayer =
                cardWarsGameLogic.AllCards.Where(p => p.Player.Owner == targetTile.Owner && p.Race == Race);
            if (_buffedCards == null) _buffedCards = new List<MonsterCard>();
            var beastsToBuff = allBeastCardsOfCurrentPlayer.Except(_buffedCards).ToList();
            beastsToBuff.Apply(p => p.AttackBonus += Amount);
            _buffedCards.AddRange(beastsToBuff);
        }
    }
}
