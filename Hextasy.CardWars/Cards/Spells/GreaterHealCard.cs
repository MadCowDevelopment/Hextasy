using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class GreaterHealCard : SpellCard
    {
        public override string Name
        {
            get { return "Greater Heal"; }
        }

        public override string Description
        {
            get { return "Restores 5 health to the target monster and 2 health to all adjacent monsters."; }
        }

        public override int Cost
        {
            get { return 6; }
        }

        protected override string ImageFilename
        {
            get { return "heal-jade-3.png"; }
        }
    }
}