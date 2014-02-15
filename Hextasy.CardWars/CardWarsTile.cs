using System.ComponentModel;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class CardWarsTile : HexagonTile
    {
        private MonsterCard _card;
        public Owner Owner { get { return Card != null ? Card.Owner : Owner.None; } }

        public MonsterCard Card
        {
            get { return _card; }
            set
            {
                if (_card != null) _card.PropertyChanged -= CardPropertyChanged;
                _card = value;
                if (_card != null) _card.PropertyChanged += CardPropertyChanged;
            }
        }

        private void CardPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var card = sender as MonsterCard;
            if (card == null) return;
            if (e.PropertyName == card.GetPropertyName(p => p.Health))
            {
                if (card.Health < 0) Die();
            }
        }

        public bool IsSelected { get; set; }

        public bool IsFixed { get; set; }

        public bool IsValidTarget { get; set; }

        public bool IsValidSpellTarget { get { return Card != null; } }

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
        }

        public void AssignCard(MonsterCard card)
        {
            Card = card;
            IsFixed = true;
        }
    }
}