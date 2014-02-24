using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanDruidFemaleCard : MonsterCard
    {
        public HumanDruidFemaleCard()
        {
            Traits.Add(new ShapeshifterTrait(this));
        }

        public override string Name
        {
            get { return "Shapeshifter"; }
        }

        public override string Description
        {
            get { return "Transform into a random beast at the start of your turn."; }
        }

        protected override string ImageFilename
        {
            get { return @"FemaleDruid01.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 0; }
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