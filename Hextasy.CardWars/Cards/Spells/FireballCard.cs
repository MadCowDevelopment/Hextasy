using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class FireballCard : SpellCard
    {
        public override string Name
        {
            get { return "Fireball"; }
        }

        public override string Description
        {
            get { return "Scorges the target monster for 4 damage and all adjacent monsters for 2 damage."; }
        }

        public override int Cost
        {
            get { return 7; }
        }

        protected override string ImageFilename
        {
            get { return "fireball-red-3.png"; }
        }
    }
}
