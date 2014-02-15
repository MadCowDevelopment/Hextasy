using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards
{
    [Export(typeof(Card))]
    public class BarbarianWarlordCard : MonsterCard
    {
        public override string Name
        {
            get { return "Barbarian Warlord"; }
        }

        public override string Description
        {
            get { return "SMASH!"; }
        }

        protected override string ImageFilename
        {
            get { return @"BarbarianFighter2.png"; }
        }

        public override int BaseAttack
        {
            get { return 4; }
        }

        public override int BaseHealth
        {
            get { return 6; }
        }

        public override int Cost
        {
            get { return 5; }
        }
    }
}
