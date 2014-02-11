using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(CardWarsGameLogic))]
    public class CardWarsGameLogic : GameLogic<CardWarsSettings, CardWarsTile>
    {
        private Player _currentPlayer;

        protected override void OnSettingsInitialized()
        {
            base.OnSettingsInitialized();
            Player1 = new Player(Settings.Player1, Owner.Player1);
            Player2 = new Player(Settings.Player2, Owner.Player2);
            CurrentPlayer = Player1;
            CurrentCards = new ObservableCollection<Card>
            {
                new FallenAngelCard(),
                new FallenAngelCard(),
                new FallenAngelCard(),
                new FallenAngelCard(),
                new FallenAngelCard()
            };
        }

        public ObservableCollection<Card> CurrentCards { get; private set; }

        protected override CardWarsTile CreateTile(int column, int row)
        {
            if (RNG.Next(0, 1) == 1)
            {
                return new CardWarsTile();
            }

            var owner = RNG.Next(0, 1) == 1 ? Owner.Player1 : Owner.Player2;
            var isExhausted = RNG.Next(0, 1) == 1;
            var attackBonus = RNG.Next(0, 2) - 1;
            var healthBonus = RNG.Next(0, 2) - 1;

            return new CardWarsTile
            {
                Card =
                    new FallenAngelCard
                    {
                        IsExhausted = isExhausted,
                        AttackBonus = attackBonus,
                        HealthBonus = healthBonus
                    },
                Owner = owner
            };
        }

        public void SelectTile(CardWarsTile tile)
        {
            tile.IsSelected = true;
        }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            private set { _currentPlayer = value; RaiseCurrentPlayerChanged(new CurrentPlayerChangedEventArgs()); }
        }

        public event EventHandler<CurrentPlayerChangedEventArgs> CurrentPlayerChanged;

        private void RaiseCurrentPlayerChanged(CurrentPlayerChangedEventArgs e)
        {
            EventHandler<CurrentPlayerChangedEventArgs> handler = CurrentPlayerChanged;
            if (handler != null) handler(this, e);
        }
    }

    public class CurrentPlayerChangedEventArgs : EventArgs
    {
    }
}