using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class LesserFireballCard : SpellCard
    {
        public override string Name
        {
            get { return "Lesser Fireball"; }
        }

        public override string Description
        {
            get { return "Burns the target monster for 2 damage."; }
        }

        public override int Cost
        {
            get { return 1; }
        }

        protected override string ImageFilename
        {
            get { return "fireball-red-1.png"; }
        }

        protected override Card CreateInstance()
        {
            return new LesserFireballCard();
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.TakeFireDamage(2);
        }
    }
}