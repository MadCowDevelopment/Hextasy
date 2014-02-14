using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards
{
    [Export(typeof(Card))]
    public class BarbarianPriestCard : Card
    {
        public override string Name
        {
            get { return "Barbarian Priest"; }
        }

        public override string Description
        {
            get { return "The lord is mighty but unforgiving."; }
        }

        public override string ImageSource
        {
            get { return @"Images\Cards\BarbarianPriest.png"; }
        }

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override int Cost
        {
            get { return 3; }
        }
    }
}
