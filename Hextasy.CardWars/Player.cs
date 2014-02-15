using System;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Specials;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class Player : PropertyChangedBase
    {
        private KingCard KingCard { get; set; }

        public string Name { get; private set; }
        public Owner Owner { get; private set; }

        public int RemainingLife { get { return KingCard.Health; } }
        public int MaximumResources { get; set; }
        public int RemainingResources { get; set; }
        public bool IsActive { get; set; }

        public Player(string name, Owner owner, KingCard kingCard)
        {
            Name = name;
            Owner = owner;
            KingCard = kingCard;
            MaximumResources = 5;
            RemainingResources = 5;
            KingCard.Player = this;
            KingCard.PropertyChanged += KingCardPropertyChanged;
        }

        private void KingCardPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var card = sender as Card;
            if (e.PropertyName == card.GetPropertyName(p => p.Health))
            {
                NotifyOfPropertyChange(() => RemainingLife);
                if (RemainingLife < 0) RaiseDied();
            }
        }

        public void PrepareTurn()
        {
            if (MaximumResources < 12) MaximumResources++;
            RemainingResources = MaximumResources;
        }

        public event EventHandler<EventArgs> Died;

        private void RaiseDied()
        {
            var handler = Died;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}