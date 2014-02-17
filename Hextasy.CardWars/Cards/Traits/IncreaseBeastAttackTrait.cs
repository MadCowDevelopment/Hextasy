using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class IncreaseBeastAttackTrait : Trait, IActivateTraitOnAnyCardPlayed
    {
        private int Amount { get; set; }

        private List<MonsterCard> _buffedCards;

        public IncreaseBeastAttackTrait(int amount)
        {
            Amount = amount;
        }

        public override string Name
        {
            get { return "Increase Beast attack"; }
        }

        public override string ImageFilename
        {
            get { return @"Images\Cards\Traits\enchant-magenta-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var allBeastCardsOfCurrentPlayer =
                cardWarsGameLogic.AllCards.Where(p => p.Player.Owner == targetTile.Owner && p.Race == Race.Beast);
            if (_buffedCards == null) _buffedCards = new List<MonsterCard>();
            var beastsToBuff = allBeastCardsOfCurrentPlayer.Except(_buffedCards).ToList();
            beastsToBuff.Apply(p => p.AttackBonus += Amount);
            _buffedCards.AddRange(beastsToBuff);
        }
    }
}
