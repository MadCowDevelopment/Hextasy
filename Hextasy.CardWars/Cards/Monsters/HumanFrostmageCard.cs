using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanFrostmageCard : MonsterCard
    {
        public HumanFrostmageCard()
        {
        }

        public override string Name
        {
            get { return "Frostmage"; }
        }

        public override string Description
        {
            get { return "Initiative: Freezes all adjacent enemy minions."; }
        }

        protected override string ImageFilename
        {
            get { return @"HumanMage15.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 2; }
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