using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Traits;
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
                if (card.Health <= 0) Die();
            }
        }

        public bool IsSelected { get; set; }

        public bool IsFixed { get; set; }

        public bool IsValidTarget { get; set; }

        public bool IsValidSpellTarget { get { return Card != null; } }

        public bool IsDefender { get { return Card != null && Card.HasTrait<DefenderTrait>(); } }

        private void Die()
        {
            Card.IsKilled = true;
            Card = null;
            IsFixed = false;
            IsValidTarget = false;
        }

        public void Attack(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var attacker = Card;
            var defender = targetTile.Card;

            defender.TakeDamage(attacker.Attack);
            attacker.TakeDamage(defender.Attack);

            attacker.Traits.OfType<IActivateTraitOnAttack>().Apply(p => p.Activate(cardWarsGameLogic, targetTile));

            attacker.IsExhausted = true;
        }

        public void AssignCard(MonsterCard card)
        {
            Card = card;
            IsFixed = true;
        }

        public void AddDebuff(Debuff debuff)
        {
            if(Card != null) Card.AddDebuff(debuff);
        }
    }
}