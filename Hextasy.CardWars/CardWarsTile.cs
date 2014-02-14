using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class CardWarsTile : HexagonTile
    {
        public Owner Owner { get; set; }
        public Card Card { get; set; }
        public bool IsSelected { get; set; }
        public bool IsFixed { get; set; }
        public bool IsValidTarget { get; set; }

        private void Die()
        {
            Card.IsKilled = true;
            Card = null;
            Owner = Owner.None;
            IsFixed = false;
            IsValidTarget = false;
        }

        public void Attack(CardWarsTile target)
        {
            var attacker = Card;
            var defender = target.Card;

            defender.TakeDamage(attacker.Attack);
            attacker.TakeDamage(defender.Attack);

            attacker.IsExhausted = true;

            if (attacker.Health <= 0)
            {
                Die();
            }

            if (defender.Health <= 0)
            {
                target.Die();
            }
        }
    }
}