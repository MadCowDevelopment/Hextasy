using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(CardWarsGameLogic))]
    public class CardWarsGameLogic : GameLogic<CardWarsSettings, CardWarsTile>
    {
        private Player _currentPlayer;

        public CardWarsGameLogic()
        {
            CurrentCards = new ObservableCollection<Card>();
        }

        protected override void OnSettingsInitialized()
        {
            base.OnSettingsInitialized();
            Player1 = new Player(Settings.Player1, Owner.Player1);
            Player2 = new Player(Settings.Player2, Owner.Player2);
            CurrentPlayer = Player1;
            RefreshHand();
        }

        public ObservableCollection<Card> CurrentCards { get; private set; }

        protected override CardWarsTile CreateTile(int column, int row)
        {
            return new CardWarsTile();
        }

        public void SelectTile(CardWarsTile tile)
        {
            if (tile.Card == null || tile.Card.IsExhausted) return;
            tile.IsSelected = true;
            Tiles.Where(p => p.Card != null && p.Card != tile.Card).Apply(p => p.IsValidTarget = true);
        }

        public Player Player1 { get; private set; }

        public Player Player2 { get; private set; }

        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            private set
            {
                if (_currentPlayer != null) _currentPlayer.IsActive = false;
                _currentPlayer = value;
                _currentPlayer.IsActive = true;
            }
        }

        public CardWarsTile SelectedTile
        {
            get { return Tiles.SingleOrDefault(p => p.IsSelected); }
        }

        public void PlayCard(CardWarsTile tile, Card selectedCard)
        {
            if (tile.IsFixed) return;
            tile.Card = selectedCard;
            tile.IsFixed = true;
            tile.Owner = CurrentPlayer.Owner;
            CurrentPlayer.RemainingResources -= selectedCard.Cost;
            CurrentCards.Remove(selectedCard);
            UpdateBuyableCards();
        }

        public void AttackCard(CardWarsTile tile)
        {
            if (tile.Card == null || SelectedTile == null || SelectedTile.Card == null) return;
            if (tile == SelectedTile)
            {
                UnselectTile();
                return;
            }

            var attacker = SelectedTile.Card;
            var defender = tile.Card;

            defender.TakeDamage(attacker.Attack);
            attacker.TakeDamage(defender.Attack);

            attacker.IsExhausted = true;

            if (attacker.Health <= 0)
            {
                attacker.Die();
                SelectedTile.Card = null;
                SelectedTile.Owner = Owner.None;
            }

            if (defender.Health <= 0)
            {
                defender.Die();
                tile.Card = null;
                tile.Owner = Owner.None;
            }

            UnselectTile();
        }

        public void UnselectTile()
        {
            if (SelectedTile == null) return;
            SelectedTile.IsSelected = false;
        }

        public void PreviewAssignCard(CardWarsTile tile, Card selectedCard)
        {
            if (selectedCard == null) return;
            if (tile.Card != null) return;
            tile.Card = selectedCard;
        }

        public void PreviewRemoveCard(CardWarsTile tile, Card selectedCard)
        {
            if (selectedCard == null) return;
            if (tile.Card != selectedCard) return;
            tile.Card = null;
        }

        public void EndTurn()
        {
            ResolveEndTurnEffects();
            ExhaustCards();
            SwitchCurrentPlayer();
            ResolveStartTurnEffects();
            CheckWinCondition();
            RefreshCards();
            RefreshHand();
        }

        private void RefreshHand()
        {
            CurrentCards.Clear();
            // TODO: Get the real cards from the player's deck.
            CurrentCards.Add(new FallenAngelCard());
            CurrentCards.Add(new FallenAngelCard());
            CurrentCards.Add(new FallenAngelCard());
            CurrentCards.Add(new FallenAngelCard());
            CurrentCards.Add(new FallenAngelCard());
            UpdateBuyableCards();
        }

        private void UpdateBuyableCards()
        {
            CurrentCards.Apply(p => p.CanBeBought = p.Cost < CurrentPlayer.RemainingResources);
        }

        private void ResolveStartTurnEffects()
        {
            // TODO
        }

        private void CheckWinCondition()
        {
            if (Player1.RemainingLife <= 0 || Player2.RemainingLife <= 0)
                RaiseFinished(new GameFinishedEventArgs());
        }

        private void ResolveEndTurnEffects()
        {
            // TODO
        }

        private void ExhaustCards()
        {
            Tiles.Where(p => p.Owner == CurrentPlayer.Owner).Apply(p => p.Card.IsExhausted = true);
        }

        private void RefreshCards()
        {
            Tiles.Where(p => p.Owner == CurrentPlayer.Owner).Apply(p => p.Card.IsExhausted = false);
        }

        private void SwitchCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            CurrentPlayer.PrepareTurn();
        }
    }
}