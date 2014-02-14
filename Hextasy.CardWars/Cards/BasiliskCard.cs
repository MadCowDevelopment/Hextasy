using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards
{
    [Export(typeof(Card))]
    public class BasiliskCard : Card
    {
        public override string Name
        {
            get { return "Basilisk"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        protected override string ImageFilename
        {
            get { return @"BasiliskBrown.png"; }
        }

        public override int BaseAttack
        {
            get { return 4; }
        }

        public override int BaseHealth
        {
            get { return 2; }
        }

        public override int Cost
        {
            get { return 3; }
        }
    }
}
