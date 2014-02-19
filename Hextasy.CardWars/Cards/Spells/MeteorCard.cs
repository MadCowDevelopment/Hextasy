using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class MeteorCard : SpellCard
    {
        public override string Name
        {
            get { return "Meteor"; }
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

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.TakeDamage(4);
            cardWarsGameLogic.HexMap.GetNeighbours(targetTile)
                .Where(p => p.Card != null)
                .Apply(p => p.Card.TakeDamage(2));
        }
    }
}
