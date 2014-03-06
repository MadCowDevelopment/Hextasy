using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class WarElephantCard : MonsterCard
    {
        public WarElephantCard()
        {
            Traits.Add(new IncreaseRaceAttackTrait(this, 1, Race.Beast));
            Traits.Add(new DecreaseRaceAttackTrait(this, 1, Race.Beast));
        }

        public override string Name
        {
            get { return "War Elephant"; }
        }

        public override string Description
        {
            get { return "Gives all friendly beasts +1 attack."; }
        }

        public override int BaseAttack
        {
            get { return 6; }
        }

        public override int BaseHealth
        {
            get { return 8; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        public override int Cost
        {
            get { return 9; }
        }

        protected override string ImageFilename
        {
            get { return "WarElephantGrey.png"; }
        }

        protected override Card CreateInstance()
        {
            return new WarElephantCard();
        }
    }
}