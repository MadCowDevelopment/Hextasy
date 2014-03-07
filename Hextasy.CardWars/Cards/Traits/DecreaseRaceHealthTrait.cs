using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DecreaseRaceHealthTrait : Trait, IActivateTraitOnDeath
    {
        private int Amount { get; set; }
        private Race Race { get; set; }

        public DecreaseRaceHealthTrait(MonsterCard cardThatHasTrait, int amount, Race race)
            : base(cardThatHasTrait)
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
                cardWarsGameLogic.AllCards.Where(
                    p => p.Player.Owner == targetTile.Owner && p != targetTile.Card && p.Race == Race);
            beastCardsToDebuff.Apply(p => p.HealthBonus -= Amount);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new DecreaseRaceHealthTrait(monsterCard, Amount, Race);
        }
    }
}