using System;
using System.Linq;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Specials;
using Hextasy.Framework;
using Hextasy.Framework.Utils;

namespace Hextasy.CardWars
{
    public class Player : PropertyChangedBase
    {
        private int _numberOfDrawsWithoutCardLeft;
        private const int MaximumNumberOfCardsInHand = 10;
        public KingCard KingCard { get; private set; }

        public string Name { get; private set; }
        public Owner Owner { get; private set; }

        public int RemainingLife { get { return KingCard.Health; } }
        public int MaximumResources { get; set; }
        public int RemainingResources { get; set; }
        public bool IsActive { get; set; }
        public Deck Deck { get; private set; }

        public void Initialize(string name, Owner owner, Deck deck)
        {
            Name = name;
            Owner = owner;
            Deck = deck;
            MaximumResources = 0;
            RemainingResources = 1;
            deck.Cards.Apply(p => p.Player = this);
            Hand = new DispatcherObservableCollection<Card>(Deck.TakeHand());
        }

        public void Initialize(KingCard kingCard)
        {
            KingCard = kingCard;
            KingCard.Player = this;
            KingCard.PropertyChanged += KingCardPropertyChanged;
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

        public DispatcherObservableCollection<Card> Hand { get; private set; }

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
            Hand = new DispatcherObservableCollection<Card>(Deck.Mulligan());
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
            var drawnCard = Deck.TakeCard();
            if (drawnCard == null)
            {
                _numberOfDrawsWithoutCardLeft++;
                KingCard.TakeDamage(_numberOfDrawsWithoutCardLeft);
            }
            else
            {
                if (Hand.Count <= MaximumNumberOfCardsInHand)
                {
                    Hand.AddNotNull(drawnCard);
                }
            }
        }

        public Player DeepCopy()
        {
            var player = (Player)Activator.CreateInstance(GetType());
            player.Initialize((KingCard)KingCard.DeepCopy(player));
            player.Deck = Deck.DeepCopy(player);
            player.DidMulligan = DidMulligan;
            player.Hand = new DispatcherObservableCollection<Card>(Hand.Select(p => p.DeepCopy(player)));
            player.IsActive = IsActive;
            player.MaximumResources = MaximumResources;
            player.Name = Name;
            player.Owner = Owner;
            player.RemainingResources = RemainingResources;
            return player;
        }
    }
}