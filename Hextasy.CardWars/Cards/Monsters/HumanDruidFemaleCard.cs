using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanDruidFemaleCard : MonsterCard
    {
        public HumanDruidFemaleCard()
        {
        }

        public override string Name
        {
            get { return "Beastmistress"; }
        }

        public override string Description
        {
            get { return "50% chance to take control of a random enemy beast at the start of your turn."; }
        }

        protected override string ImageFilename
        {
            get { return @"FemaleDruid01.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 4; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        public override int Cost
        {
            get { return 3; }
        }
    }
}