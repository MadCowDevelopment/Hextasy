using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class IncreaseBeastAttackTrait : Trait, IActivateTraitOnPlay
    {
        private int Amount { get; set; }

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
            cardWarsGameLogic.CurrentPlayerCards.Where(p => p.Race == Race.Beast).Apply(p => p.AttackBonus += Amount);
        }
    }
}
