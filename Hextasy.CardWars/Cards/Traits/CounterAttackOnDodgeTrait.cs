using System.Linq;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class CounterAttackOnDodgeTrait : Trait
    {
        public CounterAttackOnDodgeTrait(MonsterCard cardThatHasTrait) : base(cardThatHasTrait)
        {
        }

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
                cardWarsGameLogic.AllCards.Where(p => p.Player != CardThatHasTrait.Player).RandomOrDefault();
            if (randomOpponent == null) return;
            randomOpponent.TakeDamage(CardThatHasTrait.Attack);
        }
    }
}
