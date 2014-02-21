using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Specials;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(CardWarsGameLogic))]
    public class CardWarsGameLogic : GameLogic<CardWarsSettings, CardWarsTile>
    {
        private Player _currentPlayer;
        private int _turns = 1;

        protected override void OnSettingsInitialized()
        {
            base.OnSettingsInitialized();
            Player1 = new Player(Settings.Player1, Owner.Player1,
                Tiles.Select(p => p.Card).OfType<RedKingCard>().Single(),
                Settings.Player1Deck);
            Player2 = new Player(Settings.Player2, Owner.Player2,
                Tiles.Select(p => p.Card).OfType<BlueKingCard>().Single(),
                Settings.Player2Deck);

            Player1.Died += (sender, args) => RaiseFinished(new GameFinishedEventArgs());
            Player2.Died += (sender, args) => RaiseFinished(new GameFinishedEventArgs());

            Tiles.Apply(p => p.CardDied += OnCardDied);

            CurrentPlayer = Player1;
            CurrentPlayer.PrepareTurn();
        }

        private void OnCardDied(object sender, CardDiedEventArgs e)
        {
            AllCards.SelectMany(p => p.Traits)
                .OfType<IActivateTraitOnAnyCardDied>()
                .ToList()
                .Apply(p => p.Activate(this, e.TileOnWhichTheCardDied));
        }

        public ObservableCollection<Card> CurrentCards
        {
            get
            {
                return CurrentPlayer != null ? CurrentPlayer.Hand : null;
            }
        }

        public void Mulligan()
        {
            if (CanMulligan) CurrentPlayer.Mulligan();
        }

        private int Turn { get { return (int)Math.Ceiling(_turns / 2.0); } }

        protected override CardWarsTile CreateTile(int column, int row)
        {
            if (column == 0 && row == 0)
            {
                var tile = new CardWarsTile(this);
                tile.AssignCard(new RedKingCard());
                return tile;
            }

            if (column == Settings.Columns - 1 && row == Settings.Rows - 1)
            {
                var tile = new CardWarsTile(this);
                tile.AssignCard(new BlueKingCard());
                return tile;
            }

            return new CardWarsTile(this);
        }

        public void SelectTile(CardWarsTile tile)
        {
            if (tile.Card == null || tile.Card.IsExhausted) return;
            tile.IsSelected = true;
            Tiles.Apply(p => p.IsValidTarget = false);
            if (OpponentTiles.Any(p => p.IsDefender)) Tiles.Where(p => p.IsDefender).Apply(p => p.IsValidTarget = true);
            else Tiles.Where(p => p.Card != null).Apply(p => p.IsValidTarget = true);
            tile.IsValidTarget = false;
        }

        public Player Player1 { get; private set; }

        public Player Player2 { get; private set; }

        private IEnumerable<CardWarsTile> CurrentPlayerTiles
        {
            get { return Tiles.Where(p => p.Owner == CurrentPlayer.Owner); }
        }

        private IEnumerable<CardWarsTile> OpponentTiles
        {
            get
            {
                var owner = CurrentPlayer.Owner == Owner.Player1 ? Owner.Player2 : Owner.Player1;
                return Tiles.Where(p => p.Owner == owner);
            }
        }

        internal IEnumerable<MonsterCard> CurrentPlayerCards
        {
            get { return CurrentPlayerTiles.Where(p => p.Card != null).Select(p => p.Card); }
        }

        internal IEnumerable<MonsterCard> OpponentCards
        {
            get { return OpponentTiles.Where(p => p.Card != null).Select(p => p.Card); }
        }

        internal IEnumerable<MonsterCard> OpponentCardsExceptKing
        {
            get { return OpponentCards.Where(p => !(p is KingCard)); }
        }

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

        public IEnumerable<MonsterCard> AllCards
        {
            get { return Tiles.Where(p => p.Card != null).Select(p => p.Card); }
        }

        public IEnumerable<MonsterCard> AllCardsExceptKing
        {
            get { return AllCards.Where(p => !(p is KingCard)); }
        }

        public bool CanMulligan { get { return Turn == 1 && !CardPlayedThisTurn; } }
        private bool CardPlayedThisTurn { get; set; }

        public void PlayMonsterCard(CardWarsTile tile, MonsterCard selectedCard)
        {
            if (tile.IsFixed) return;
            CardPlayedThisTurn = true;
            tile.AssignCard(selectedCard);
            CurrentPlayer.RemainingResources -= selectedCard.Cost;
            CurrentCards.Remove(selectedCard);
            selectedCard.Traits.OfType<IActivateTraitOnCardPlayed>().Apply(trait => trait.Activate(this, tile));
            ActivateTraits<IActivateTraitOnAnyCardPlayed>(Tiles, tile);
        }

        public void PlaySpellCard(CardWarsTile tile, SpellCard selectedCard)
        {
            if (!tile.IsValidSpellTarget) return;
            CardPlayedThisTurn = true;
            CurrentPlayer.RemainingResources -= selectedCard.Cost;
            CurrentCards.Remove(selectedCard);
            selectedCard.Activate(this, tile);
        }

        public void AttackCard(CardWarsTile tile)
        {
            if (tile.Card == null || SelectedTile == null || SelectedTile.Card == null) return;

            if (tile == SelectedTile)
            {
                UnselectTile();
                return;
            }

            if (!tile.IsValidTarget) return;

            SelectedTile.Attack(this, tile);
            UnselectTile();
        }

        public void UnselectTile()
        {
            if (SelectedTile == null) return;
            SelectedTile.IsSelected = false;
            NotifyOfPropertyChange(() => SelectedTile);
        }

        public void PreviewAssignCard(CardWarsTile tile, MonsterCard selectedCard)
        {
            if (selectedCard == null) return;
            if (tile.Card != null) return;
            tile.Card = selectedCard;
        }

        public void PreviewRemoveCard(CardWarsTile tile, MonsterCard selectedCard)
        {
            if (selectedCard == null) return;
            if (tile.Card == null || tile.Card != selectedCard) return;
            tile.Card = null;
        }

        public void EndTurn()
        {
            UnselectTile();
            ResolveEndTurnEffects();
            ExhaustCards();
            CleanupDebuffs();
            _turns++;
            CardPlayedThisTurn = false;
            SwitchCurrentPlayer();
            ReadyCards();
            ResolveStartTurnEffects();
        }

        public IEnumerable<CardWarsTile> GetAdjacentMonsterTiles(CardWarsTile tile)
        {
            return HexMap.GetNeighbours(tile).Where(p => p.Card != null);
        }

        public IEnumerable<CardWarsTile> GetAdjacentFreeTiles(CardWarsTile tile)
        {
            return HexMap.GetNeighbours(tile).Where(p => p.Card == null);
        }

        private void CleanupDebuffs()
        {
            CurrentPlayerTiles.Apply(p => p.Card.CleanupDebuffs());
        }

        private void ResolveStartTurnEffects()
        {
            ActivateTraits<IActivateTraitOnStartTurn>(CurrentPlayerTiles);
            ActivateDebuffs<IActivateDebuffOnStartTurn>(CurrentPlayerTiles);
        }

        private void ActivateTraits<T>(IEnumerable<CardWarsTile> tiles, CardWarsTile targetTile) where T : ITrait
        {
            tiles.Where(p => p.Card != null && p.Card.Traits.OfType<T>().Any()).ToList().Apply(
                tile => tile.Card.Traits.OfType<T>().ToList().Apply(trait => trait.Activate(this, targetTile)));
        }

        private void ActivateTraits<T>(IEnumerable<CardWarsTile> tiles) where T : ITrait
        {
            tiles.Where(p => p.Card != null && p.Card.Traits.OfType<T>().Any()).ToList().Apply(
                tile => tile.Card.Traits.OfType<T>().ToList().Apply(trait => trait.Activate(this, tile)));
        }

        private void ActivateDebuffs<T>(IEnumerable<CardWarsTile> tiles) where T : IDebuff
        {
            tiles.Where(p => p.Card != null && p.Card.Debuffs.OfType<T>().Any()).ToList().Select(p => p.Card).Apply(
                card => card.Debuffs.OfType<T>().ToList().Apply(debuff => debuff.Activate(card)));
        }

        private void ResolveEndTurnEffects()
        {
            ActivateTraits<IActivateTraitOnEndTurn>(CurrentPlayerTiles);
            ActivateDebuffs<IActivateDebuffOnEndTurn>(CurrentPlayerTiles);
        }

        private void ExhaustCards()
        {
            CurrentPlayerTiles.Apply(p => p.Card.IsExhausted = true);
        }

        private void ReadyCards()
        {
            CurrentPlayerTiles.Apply(p => p.Card.IsExhausted = false);
        }

        private void SwitchCurrentPlayer()
        {
            CurrentPlayer.EndTurn();
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            CurrentPlayer.PrepareTurn();
        }
    }
}