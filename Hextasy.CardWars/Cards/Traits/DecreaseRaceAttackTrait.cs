using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DecreaseRaceAttackTrait : Trait, IActivateTraitOnDeath
    {
        private int Amount { get; set; }
        private Race Race { get; set; }

        public DecreaseRaceAttackTrait(int amount, Race race)
        {
            Amount = amount;
            Race = race;
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
                cardWarsGameLogic.AllCards.Where(p => p.Player.Owner == targetTile.Owner && p.Race == Race);
            beastCardsToDebuff.Apply(p => p.AttackBonus -= Amount);
        }
    }

    public class DecreaseRaceHealthTrait : Trait, IActivateTraitOnDeath
    {
        private int Amount { get; set; }
        private Race Race { get; set; }

        public DecreaseRaceHealthTrait(int amount, Race race)
        {
            Amount = amount;
            Race = race;
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
                cardWarsGameLogic.AllCards.Where(p => p.Player.Owner == targetTile.Owner && p.Race == Race);
            beastCardsToDebuff.Apply(p => p.HealthBonus -= Amount);
        }
    }
}
