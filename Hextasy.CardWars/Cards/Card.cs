using System;
using System.ComponentModel;

using Hextasy.Framework;

namespace Hextasy.CardWars.Cards
{
    public abstract class Card : ObservableObject
    {
        #region Fields

        private Guid? _id;
        private Player _player;

        #endregion Fields

        #region Public Properties

        public bool CanBePlayed
        {
            get { return Player != null && Player.RemainingResources >= Cost; }
        }

        public abstract int Cost
        {
            get;
        }

        public abstract string Description
        {
            get;
        }

        public Guid Id
        {
            get { return _id ?? (_id = Guid.NewGuid()).Value; }
        }

        public string ImageSource
        {
            get { return ImageFolder + ImageFilename; }
        }

        public bool IsSelected
        {
            get; set;
        }

        public abstract string Name
        {
            get;
        }

        public Owner Owner
        {
            get { return Player != null ? Player.Owner : Owner.None; }
        }

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

        public abstract CardType Type
        {
            get;
        }

        #endregion Public Properties

        #region Protected Properties

        protected abstract string ImageFilename
        {
            get;
        }

        protected abstract string ImageFolder
        {
            get;
        }

        #endregion Protected Properties

        #region Public Methods

        public Card DeepCopy(Player player)
        {
            var card = CreateInstance();
            card.Player = player;
            card._id = Id;
            OnDeepCopy(card);
            return card;
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract Card CreateInstance();

        protected virtual void OnDeepCopy(Card card)
        {
        }

        #endregion Protected Methods

        #region Private Methods

        private void OnPlayerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RemainingResources")
            {
                OnPropertyChanged("CanBePlayed");
            }
        }

        #endregion Private Methods
    }
}