using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Specials;
using Hextasy.CardWars.Cards.Traits;
using Hextasy.Framework;

namespace Hextasy.CardWars.Logic
{
    public class CardWarsTile : HexagonTile
    {
        #region Fields

        private readonly CardWarsGameLogic _gameLogic;

        private MonsterCard _card;
        private bool _isSelected;

        #endregion Fields

        #region Constructors

        public CardWarsTile(CardWarsGameLogic gameLogic, Guid id)
        {
            Id = id;
            _gameLogic = gameLogic;
        }

        #endregion Constructors

        #region Events

        public event EventHandler<CardDiedEventArgs> CardDied;

        #endregion Events

        #region Public Properties

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

        public Guid Id
        {
            get;
            private set;
        }

        public bool IsDefender
        {
            get { return Card != null && Card.HasTrait<DefenderTrait>(); }
        }

        public bool IsFixed { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                if (_isSelected) WasPreviouslySelectedThisTurn = true;
            }
        }

        public bool IsValidSpellTarget
        {
            get { return Card != null && !(Card is KingCard); }
        }

        public bool IsValidTarget
        {
            get;
            set;
        }

        public Owner Owner
        {
            get { return Card != null ? Card.Owner : Owner.None; }
        }

        public IEnumerable<ITrait> Traits
        {
            get { return Card != null ? Card.Traits : Enumerable.Empty<ITrait>(); }
        }

        public bool WasPreviouslySelectedThisTurn
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Public Methods

        public void AddDebuff(Debuff debuff)
        {
            if (Card != null) Card.AddDebuff(debuff);
        }

        public void AssignCard(MonsterCard card)
        {
            Card = card;
            IsFixed = true;
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

        public CardWarsTile DeepCopy(CardWarsGameLogic cardWarsGameLogic, Player player1, Player player2)
        {
            var tile = new CardWarsTile(cardWarsGameLogic, Id);
            if (Card != null)
            {
                if (Card is KingCard) tile.Card = Owner == Owner.Player1 ? player1.KingCard : player2.KingCard;
                else tile.Card = (MonsterCard)Card.DeepCopy(Owner == Owner.Player1 ? player1 : player2);
            }

            tile.IsFixed = IsFixed;
            tile.IsSelected = IsSelected;
            tile.WasPreviouslySelectedThisTurn = WasPreviouslySelectedThisTurn;
            tile.IsValidTarget = IsValidTarget;
            return tile;
        }

        public void PrepareTurn()
        {
            Card.IsExhausted = false;
            WasPreviouslySelectedThisTurn = false;
        }

        #endregion Public Methods

        #region Private Methods

        private void CardPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var card = sender as MonsterCard;
            if (card == null) return;
            if (e.PropertyName == card.GetPropertyName(p => p.Health))
            {
                if (card.Health <= 0 && !card.IsKilled) Die();
            }
        }

        private void Die()
        {
            Card.IsKilled = true;
            Card.Traits.OfType<IActivateTraitOnDeath>().Apply(p => p.Activate(_gameLogic, this));
            Card.Traits.Apply(p => p.Deactivate(_gameLogic));
            Card = null;
            IsFixed = false;
            IsValidTarget = false;
            RaiseCardDied();
        }

        private void RaiseCardDied()
        {
            var handler = CardDied;
            if (handler != null) handler(this, new CardDiedEventArgs(this));
        }

        #endregion Private Methods
    }
}