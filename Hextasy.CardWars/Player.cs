using System;
using System.Collections.ObjectModel;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Specials;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class Player : PropertyChangedBase
    {
        private const int MaximumNumberOfCardsInHand = 10;
        private KingCard KingCard { get; set; }

        public string Name { get; private set; }
        public Owner Owner { get; private set; }

        public int RemainingLife { get { return KingCard.Health; } }
        public int MaximumResources { get; set; }
        public int RemainingResources { get; set; }
        public bool IsActive { get; set; }
        public Deck Deck { get; private set; }

        public Player(string name, Owner owner, KingCard kingCard, Deck deck)
        {
            Name = name;
            Owner = owner;
            KingCard = kingCard;
            Deck = deck;
            MaximumResources = 9;
            RemainingResources = 1;
            KingCard.Player = this;
            KingCard.PropertyChanged += KingCardPropertyChanged;
            deck.Cards.Apply(p => p.Player = this);
            Hand = new ObservableCollection<Card>(Deck.TakeHand());
        }

        private void KingCardPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var card = sender as KingCard;
            if (e.PropertyName == card.GetPropertyName(p => p.Health))
            {
                NotifyOfPropertyChange(() => RemainingLife);
                if (RemainingLife <= 0) RaiseDied();
            }
        }

        public ObservableCollection<Card> Hand { get; private set; }

        public bool DidMulligan { get; private set; }

        public event EventHandler<EventArgs> Died;

        public void PrepareTurn()
        {
            RefreshResources();
            DrawCard();
        }

        public void Mulligan()
        {
            DidMulligan = true;
            Hand = new ObservableCollection<Card>(Deck.Mulligan());
        }

        public void EndTurn()
        {
        }

        private void RaiseDied()
        {
            var handler = Died;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void RefreshResources()
        {
            if (MaximumResources < 10) MaximumResources++;
            RemainingResources = MaximumResources;
        }

        public void DrawCard()
        {
            if (Hand.Count < MaximumNumberOfCardsInHand) Hand.AddNotNull(Deck.TakeCard());
        }
    }
}