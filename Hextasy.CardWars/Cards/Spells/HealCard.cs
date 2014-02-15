using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class HealCard : SpellCard
    {
        public override string Name
        {
            get { return "Heal"; }
        }

        public override string Description
        {
            get { return "Restores 5 health to the target monster."; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        protected override string ImageFilename
        {
            get { return "heal-jade-2.png"; }
        }
    }
}