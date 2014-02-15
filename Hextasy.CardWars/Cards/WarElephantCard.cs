using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards
{
    [Export(typeof(Card))]
    public class WarElephantCard : MonsterCard
    {
        public override string Name
        {
            get { return "War Elephant"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int BaseAttack
        {
            get { return 6; }
        }

        public override int BaseHealth
        {
            get { return 8; }
        }

        public override int Cost
        {
            get { return 7; }
        }

        protected override string ImageFilename
        {
            get { return "WarElephantGrey.png"; }
        }
    }
}