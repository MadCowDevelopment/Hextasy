﻿using System.ComponentModel;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards
{
    public abstract class Card : PropertyChangedBase
    {
        private Player _player;

        public abstract string Name { get; }
        public abstract string Description { get; }

        public abstract int Cost { get; }

        public string ImageSource { get { return ImageFolder + ImageFilename; } }

        public bool CanBePlayed { get { return Player.RemainingResources >= Cost; } }

        public Owner Owner { get { return Player.Owner; } }

        public abstract CardType Type { get; }

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

        protected abstract string ImageFilename { get; }
        protected abstract string ImageFolder { get; }
    }
}
