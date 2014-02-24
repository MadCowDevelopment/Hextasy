using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanInquisitorFemaleCard : MonsterCard
    {
        public HumanInquisitorFemaleCard()
        {
            Traits.Add(new InquisitorTrait(this));
        }

        public override string Name
        {
            get { return "Female Inquisitor"; }
        }

        public override string Description
        {
            get { return "33% chance to subdue a random enemy or kill an undead at the start of your turn."; }
        }

        protected override string ImageFilename
        {
            get { return @"FemalePriest02.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 2; }
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