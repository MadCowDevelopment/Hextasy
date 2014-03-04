using System;
using System.Collections.Generic;
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
        private readonly CardWarsGameLogic _gameLogic;
        private MonsterCard _card;

        public CardWarsTile(CardWarsGameLogic gameLogic)
        {
            _gameLogic = gameLogic;
        }

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

        public event EventHandler<CardDiedEventArgs> CardDied;

        public IEnumerable<ITrait> Traits { get { return Card != null ? Card.Traits : Enumerable.Empty<ITrait>(); } }

        private void RaiseCardDied()
        {
            var handler = CardDied;
            if (handler != null) handler(this, new CardDiedEventArgs(this));
        }

        private void CardPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var card = sender as MonsterCard;
            if (card == null) return;
            if (e.PropertyName == card.GetPropertyName(p => p.Health))
            {
                if (card.Health <= 0 && !card.IsKilled) Die();
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
            Card.Traits.OfType<IActivateTraitOnDeath>().Apply(p => p.Activate(_gameLogic, this));
            Card = null;
            IsFixed = false;
            IsValidTarget = false;
            RaiseCardDied();
        }

        public void Attack(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var attacker = Card;
            var defender = targetTile.Card;

            defender.Traits.OfType<IActivateTraitOnDefense>().Apply(p => p.Activate(cardWarsGameLogic, this));
            defender.TakeDamage(attacker.Attack);

            attacker.Traits.OfType<IActivateTraitOnAttack>().Apply(p => p.Activate(cardWarsGameLogic, targetTile));
            attacker.TakeDamage(defender.Attack);

            attacker.IsExhausted = true;
        }

        public void AssignCard(MonsterCard card)
        {
            Card = card;
            IsFixed = true;
        }

        public void AddDebuff(Debuff debuff)
        {
            if (Card != null) Card.AddDebuff(debuff);
        }

        public CardWarsTile DeepCopy(CardWarsGameLogic cardWarsGameLogic, Player player1, Player player2)
        {
            var tile = new CardWarsTile(cardWarsGameLogic);
            if (Card != null) tile.Card = (MonsterCard)Card.DeepCopy(Owner == Owner.Player1 ? player1 : player2);
            tile.IsFixed = IsFixed;
            tile.IsSelected = IsSelected;
            tile.IsValidTarget = IsValidTarget;
            return tile;
        }
    }
}