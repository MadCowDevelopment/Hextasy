using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonRedFemaleCard : DragonCard
    {
        public DragonRedFemaleCard()
        {
            Traits.Add(new DragonBabyTrait());
        }

        public override string Name
        {
            get { return "Zhixia"; }
        }

        public override string Description
        {
            get { return "Gives birth to a baby dragon at the start of your turn if there is a male dragon present."; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        protected override string ImageFilename
        {
            get { return "DragonAdultRed.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 3; }
        }

        public override int BaseHealth
        {
            get { return 7; }
        }

        public override DragonFlight DragonFlight
        {
            get { return DragonFlight.Red; }
        }

        public override Gender Gender
        {
            get { return Gender.Female; }
        }

        public override Race Race
        {
            get { return Race.Dragon; }
        }
    }
}
