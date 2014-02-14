using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class CardWarsTile : HexagonTile
    {
        public Owner Owner { get { return Card != null ? Card.Owner : Owner.None; } }
        public Card Card { get; set; }
        public bool IsSelected { get; set; }

        public bool IsFixed { get; set; }

        public bool IsValidTarget { get; set; }

        private void Die()
        {
            Card.IsKilled = true;
            Card = null;
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

        public void AssignCard(Card card)
        {
            Card = card;
            IsFixed = true;
        }
    }
}