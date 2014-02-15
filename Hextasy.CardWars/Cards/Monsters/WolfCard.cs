using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class WolfCard : MonsterCard
    {
        public override string Name
        {
            get { return "Wolf"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int BaseAttack
        {
            get { return 3; }
        }

        public override int BaseHealth
        {
            get { return 1; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        protected override string ImageFilename
        {
            get { return "Wolf.png"; }
        }
    }
}