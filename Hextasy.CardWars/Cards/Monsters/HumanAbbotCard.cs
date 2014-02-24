using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanAbbotCard : MonsterCard
    {
        public HumanAbbotCard()
        {
        }

        public override string Name
        {
            get { return "Abbot"; }
        }

        public override string Description
        {
            get { return "50% chance to subdue a random enemy or kill an undead at the start of your turn."; }
        }

        protected override string ImageFilename
        {
            get { return @"HumanPriest04.PNG"; }
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