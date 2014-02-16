using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class WormCard : MonsterCard
    {
        public override string Name
        {
            get { return "Worm"; }
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
            get { return 2; }
        }

        public override int Cost
        {
            get { return 1; }
        }

        protected override string ImageFilename
        {
            get { return "WormGreen.png"; }
        }
    }
}