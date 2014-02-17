using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DecreaseBeastAttackTrait : Trait, IActivateTraitOnDeath
    {
        private int Amount { get; set; }

        public DecreaseBeastAttackTrait(int amount)
        {
            Amount = amount;
        }

        public override string Name
        {
            get { return "Remove Beast attack"; }
        }

        public override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.CurrentPlayerCards.Where(p => p.Race == Race.Beast).Apply(p => p.AttackBonus -= Amount);
        }
    }
}
