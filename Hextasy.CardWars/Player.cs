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
        private const int MaxCardsPerHand = 5;
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
            MaximumResources = 5;
            RemainingResources = 5;
            KingCard.Player = this;
            KingCard.PropertyChanged += KingCardPropertyChanged;
            deck.Cards.Apply(p => p.Player = this);
            Hand = new ObservableCollection<Card>();
        }

        private void KingCardPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var card = sender as KingCard;
            if (e.PropertyName == card.GetPropertyName(p => p.Health))
            {
                NotifyOfPropertyChange(() => RemainingLife);
                if (RemainingLife < 0) RaiseDied();
            }
        }

        public ObservableCollection<Card> Hand { get; private set; }

        public event EventHandler<EventArgs> Died;

        public void PrepareTurn()
        {
            RefreshResources();
            DrawHand();
        }

        public void EndTurn()
        {
            Deck.DiscardCards(Hand);
            Hand.Clear();
        }

        private void RaiseDied()
        {
            var handler = Died;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void RefreshResources()
        {
            if (MaximumResources < 12) MaximumResources++;
            RemainingResources = MaximumResources;
        }

        private void DrawHand()
        {
            for (int i = 0; i < MaxCardsPerHand; i++)
            {
                Hand.AddNotNull(Deck.TakeCard());
            }
        }
    }
}