using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanPopeCard : MonsterCard
    {
        public HumanPopeCard()
        {
        }

        public override string Name
        {
            get { return "Pope"; }
        }

        public override string Description
        {
            get { return "Initiative: Gives all friendly monsters +1 attack and heals 2 damage."; }
        }

        protected override string ImageFilename
        {
            get { return @"HumanPriest31B.PNG"; }
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