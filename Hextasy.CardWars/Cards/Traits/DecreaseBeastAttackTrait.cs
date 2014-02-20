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
            get { return string.Empty; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var beastCardsToDebuff =
            cardWarsGameLogic.AllCards.Where(p => p.Player.Owner == targetTile.Owner && p.Race == Race.Beast);
            beastCardsToDebuff.Apply(p => p.AttackBonus -= Amount);
        }
    }
}
