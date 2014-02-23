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
            get { return "Burns the target monster for 5 damage."; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        protected override string ImageFilename
        {
            get { return "fireball-red-2.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.TakeFireDamage(5);
        }
    }
}