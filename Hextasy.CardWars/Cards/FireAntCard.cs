using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards
{
    [Export(typeof(Card))]
    public class FireAntCard : MonsterCard
    {
        public override string Name
        {
            get { return "Fire Ant"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 1; }
        }

        public override int Cost
        {
            get { return 1; }
        }

        protected override string ImageFilename
        {
            get { return "AntRed2.png"; }
        }
    }
}
