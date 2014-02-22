using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class GreaterFireballCard : SpellCard
    {
        public override string Name
        {
            get { return "Greater Fireball"; }
        }

        public override string Description
        {
            get { return "Scorges the target monster for 5 damage and all adjacent monsters for 2 damage."; }
        }

        public override int Cost
        {
            get { return 7; }
        }

        protected override string ImageFilename
        {
            get { return "fireball-red-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.TakeFireDamage(5);
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.Card.TakeFireDamage(2));
        }
    }
}
