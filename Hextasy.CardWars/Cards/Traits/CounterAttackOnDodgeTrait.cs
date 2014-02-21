using System.Linq;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class CounterAttackOnDodgeTrait : Trait
    {
        public override string Name
        {
            get { return "Counterattack"; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var randomOpponent =
                cardWarsGameLogic.AllCards.Where(p => p.Player != targetTile.Card.Player).RandomOrDefault();
            randomOpponent.TakeDamage(targetTile.Card.Attack);
        }
    }
}
