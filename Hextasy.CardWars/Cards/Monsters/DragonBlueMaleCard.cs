using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonBlueMaleCard : DragonMaleCard
    {
        public override string Name
        {
            get { return "Squlor"; }
        }

        public override string Description
        {
            get { return ""; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        protected override string ImageFilename
        {
            get { return "DragonAncientBlue.png"; }
        }

        public override int BaseAttack
        {
            get { return 7; }
        }

        public override int BaseHealth
        {
            get { return 7; }
        }

        public override DragonFlight DragonFlight
        {
            get { return DragonFlight.Blue; }
        }
    }
}