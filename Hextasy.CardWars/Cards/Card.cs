using System.ComponentModel;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards
{
    public abstract class Card : PropertyChangedBase
    {
        private Player _player;

        protected Card()
        {
            IsExhausted = true;
        }

        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract int BaseAttack { get; }
        public abstract int BaseHealth { get; }
        public abstract int Cost { get; }

        public string ImageSource { get { return ImageFolder + ImageFilename; } }

        public int Attack { get { return BaseAttack + AttackBonus; } }
        public int AttackBonus { get; set; }

        public int Health { get { return BaseHealth + HealthBonus; } }
        public int HealthBonus { get; set; }

        public bool IsKilled { get; set; }
        public bool IsExhausted { get; protected internal set; }

        public bool CanBePlayed { get { return Player.RemainingResources >= Cost; } }

        public bool HasIncreasedAttack
        {
            get { return Attack > BaseAttack; }
        }

        public bool HasDecreasedAttack
        {
            get { return Attack < BaseAttack; }
        }

        public bool HasIncreasedHealth
        {
            get { return Health > BaseHealth; }
        }

        public bool HasDecreasedHealth
        {
            get { return Health < BaseHealth; }
        }

        public Owner Owner { get { return Player.Owner; } }

        public Player Player
        {
            get { return _player; }
            set
            {
                if (_player != null) Player.PropertyChanged -= OnPlayerPropertyChanged;
                _player = value;
                if (_player != null) Player.PropertyChanged += OnPlayerPropertyChanged;
            }
        }

        private void OnPlayerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var player = sender as Player;
            if (e.PropertyName == player.GetPropertyName(p => p.RemainingResources))
            {
                NotifyOfPropertyChange(() => CanBePlayed);
            }
        }

        public void TakeDamage(int attackValue)
        {
            HealthBonus -= attackValue;
        }

        protected abstract string ImageFilename { get; }
        protected abstract string ImageFolder { get; }
    }
}
