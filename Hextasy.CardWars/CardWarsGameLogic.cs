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
            Player1 = new Player(Settings.Player1, Owner.Player1,
                Tiles.Select(p => p.Card).OfType<RedKingCard>().Single());
            Player2 = new Player(Settings.Player2, Owner.Player2,
                Tiles.Select(p => p.Card).OfType<BlueKingCard>().Single());
            CurrentPlayer = Player1;
            RefreshHand();
        }

        public ObservableCollection<Card> CurrentCards { get; private set; }

        protected override CardWarsTile CreateTile(int column, int row)
        {
            if (column == 0 && row == 0)
            {
                var tile = new CardWarsTile();
                tile.AssignCard(new RedKingCard());
                return tile;
            }
            if (column == Settings.Columns - 1 && row == Settings.Rows - 1)
            {
                var tile = new CardWarsTile();
                tile.AssignCard(new BlueKingCard());
                return tile;
            }
            return new CardWarsTile();
        }

        public void SelectTile(CardWarsTile tile)
        {
            if (tile.Card == null || tile.Card.IsExhausted) return;
            tile.IsSelected = true;
            Tiles.Where(p => p.Card != null).Apply(p => p.IsValidTarget = true);
            tile.IsValidTarget = false;
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
            tile.AssignCard(selectedCard);
            CurrentPlayer.RemainingResources -= selectedCard.Cost;
            CurrentCards.Remove(selectedCard);
            UpdatePlayabeCards();
        }

        public void AttackCard(CardWarsTile tile)
        {
            if (tile.Card == null || SelectedTile == null || SelectedTile.Card == null) return;
            if (tile == SelectedTile)
            {
                UnselectTile();
                return;
            }

            SelectedTile.Attack(tile);
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
            CurrentCards.Add(new FallenAngelCard { Owner = CurrentPlayer.Owner });
            CurrentCards.Add(new FallenAngelCard { Owner = CurrentPlayer.Owner });
            CurrentCards.Add(new FallenAngelCard { Owner = CurrentPlayer.Owner });
            CurrentCards.Add(new FallenAngelCard { Owner = CurrentPlayer.Owner });
            CurrentCards.Add(new FallenAngelCard { Owner = CurrentPlayer.Owner });
            UpdatePlayabeCards();
        }

        private void UpdatePlayabeCards()
        {
            CurrentCards.Apply(p => p.CanBePlayed = p.Cost <= CurrentPlayer.RemainingResources);
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