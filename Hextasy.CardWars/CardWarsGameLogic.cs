﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Hextasy.CardWars.AI;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Specials;
using Hextasy.Framework;
using Hextasy.Framework.Utils;

namespace Hextasy.CardWars
{
    [Export(typeof(CardWarsGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CardWarsGameLogic : GameLogic<CardWarsSettings, CardWarsTile, CardWarsStatistics>
    {
        private Player _currentPlayer;
        private int Turns { get; set; }
        private bool GameOver { get; set; }

        public DispatcherObservableCollection<Card> CurrentPlayerHand
        {
            get
            {
                return CurrentPlayer != null ? CurrentPlayer.Hand : null;
            }
        }

        private int Turn { get { return (int)Math.Ceiling(Turns / 2.0); } }

        public Player Player1 { get; private set; }

        public Player Player2 { get; private set; }

        public IEnumerable<CardWarsTile> CurrentPlayerTiles
        {
            get { return Tiles.Where(p => p.Owner == CurrentPlayer.Owner); }
        }

        public IEnumerable<CardWarsTile> OpponentTiles
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

        internal IEnumerable<MonsterCard> CurrentPlayerCardsExceptKing
        {
            get { return CurrentPlayerCards.Where(p => !(p is KingCard)); }
        }

        internal IEnumerable<MonsterCard> OpponentCards
        {
            get { return OpponentTiles.Where(p => p.Card != null).Select(p => p.Card); }
        }

        internal IEnumerable<MonsterCard> OpponentCardsExceptKing
        {
            get { return OpponentCards.Where(p => !(p is KingCard)); }
        }

        internal IEnumerable<MonsterCard> AllCards
        {
            get { return Tiles.Where(p => p.Card != null).Select(p => p.Card); }
        }

        internal IEnumerable<MonsterCard> AllCardsExceptKing
        {
            get { return AllCards.Where(p => !(p is KingCard)); }
        }

        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            private set
            {
                if (_currentPlayer == value) return;
                if (_currentPlayer != null)
                {
                    _currentPlayer.IsActive = false;
                    OpponentPlayer = _currentPlayer;
                }

                _currentPlayer = value;
                _currentPlayer.IsActive = true;
            }
        }

        public Player OpponentPlayer { get; private set; }

        public CardWarsTile SelectedTile
        {
            get { return Tiles.SingleOrDefault(p => p.IsSelected); }
        }

        public bool CanMulligan { get { return Turn == 1 && !CardPlayedThisTurn && !CurrentPlayer.DidMulligan; } }
        private bool CardPlayedThisTurn { get; set; }

        public IEnumerable<CardWarsTile> AllFreeTiles
        {
            get { return Tiles.Where(p => p.Card == null); }
        }

        protected override void OnSettingsInitialized()
        {
            base.OnSettingsInitialized();

            InitializePlayers();
            Tiles.Apply(p => p.CardDied += OnCardDied);
            CurrentPlayer = RNG.Chance(50) ? Player1 : Player2;
            StartTurn();
        }

        private void InitializePlayers()
        {
            Player1 = Settings.Player1;
            Player2 = Settings.Player2;

            Player1.Initialize(Tiles.Select(p => p.Card).OfType<RedKingCard>().Single());
            Player2.Initialize(Tiles.Select(p => p.Card).OfType<BlueKingCard>().Single());

            Player1.Died += (sender, args) =>
            {
                GameOver = true;
                RaiseFinished(
                    new GameFinishedEventArgs<CardWarsStatistics>(
                    new CardWarsStatistics(Owner.Player2, Player1.RemainingLife, Player2.RemainingLife)));
            };

            Player2.Died += (sender, args) =>
            {
                GameOver = true;
                RaiseFinished(
                    new GameFinishedEventArgs<CardWarsStatistics>(new CardWarsStatistics(Owner.Player1,
                        Player1.RemainingLife, Player2.RemainingLife)));
            };
        }

        private void OnCardDied(object sender, CardDiedEventArgs e)
        {
            AllCards.SelectMany(p => p.Traits)
                .OfType<IActivateTraitOnAnyCardDied>()
                .ToList()
                .Apply(p => p.Activate(this, e.TileOnWhichTheCardDied));
        }

        public void Mulligan()
        {
            if (CanMulligan) CurrentPlayer.Mulligan();
        }

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
            Tiles.Apply(p => p.IsSelected = false);
            tile.IsSelected = true;
            Tiles.Apply(p => p.IsValidTarget = false);
            if (OpponentTiles.Any(p => p.IsDefender))
                Tiles.Where(p => p.Owner == CurrentPlayer.Owner || (p.Owner == OpponentPlayer.Owner && p.IsDefender))
                    .Apply(p => p.IsValidTarget = true);
            else Tiles.Where(p => p.Card != null).Apply(p => p.IsValidTarget = true);
            tile.IsValidTarget = false;
        }

        public void PlayMonsterCard(CardWarsTile tile, MonsterCard selectedCard)
        {
            if (tile.IsFixed) return;
            CardPlayedThisTurn = true;
            tile.AssignCard(selectedCard);
            CurrentPlayer.RemainingResources -= selectedCard.Cost;
            CurrentPlayerHand.Remove(selectedCard);
            selectedCard.Traits.OfType<IActivateTraitOnCardPlayed>().Apply(trait => trait.Activate(this, tile));
            ActivateTraits<IActivateTraitOnAnyCardPlayed>(Tiles, tile);
        }

        public void PlaySpellCard(CardWarsTile tile, SpellCard selectedCard)
        {
            if (!tile.IsValidSpellTarget) return;
            CardPlayedThisTurn = true;
            CurrentPlayer.RemainingResources -= selectedCard.Cost;
            CurrentPlayerHand.Remove(selectedCard);
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
            if (tile == null || selectedCard == null) return;
            if (tile.Card == null || tile.Card != selectedCard) return;
            tile.Card = null;
        }

        public void EndTurn()
        {
            if (GameOver) return;
            UnselectTile();
            ResolveEndTurnEffects();
            ExhaustCards();
            CleanupDebuffs();
            StartTurn();
        }

        private void StartTurn()
        {
            Turns++;
            CardPlayedThisTurn = false;
            SwitchCurrentPlayer();
            ReadyCards();
            ResolveStartTurnEffects();
            StartCpuPlayerTurn();
        }

        private void StartCpuPlayerTurn()
        {
            var cpuPlayer = CurrentPlayer as CpuPlayer;
            if (cpuPlayer != null)
            {
                var task = new Task(() => cpuPlayer.TakeTurn(this));
                task.ContinueWith(p => EndTurn());
                task.Start();
            }
        }

        public IEnumerable<CardWarsTile> GetAdjacentMonsterTiles(CardWarsTile tile)
        {
            return HexMap.GetNeighbours(tile).Where(p => p.Card != null);
        }

        public IEnumerable<CardWarsTile> GetChainOfMonsterTiles(CardWarsTile tile, int distance)
        {
            return
                HexMap.GetNeighbours(tile, distance).Except(HexMap.GetNeighbours(tile, distance - 1)).Where(
                    p => p.Card != null);
        }

        public IEnumerable<CardWarsTile> GetAdjacentOpponentTiles(CardWarsTile tile)
        {
            return GetAdjacentMonsterTiles(tile).Where(p => p.Owner == OpponentPlayer.Owner);
        }

        public IEnumerable<CardWarsTile> GetAdjacentFriendlyTiles(CardWarsTile tile)
        {
            return GetAdjacentMonsterTiles(tile).Where(p => p.Owner == CurrentPlayer.Owner);
        }

        public IEnumerable<CardWarsTile> GetAdjacentFreeTiles(CardWarsTile tile)
        {
            return HexMap.GetNeighbours(tile).Where(p => p.Card == null);
        }

        internal void Heal(MonsterCard card, int amount)
        {
            card.Heal(amount);
            ActivateTraits<IActivateTraitOnHeal>(Tiles);
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
                tile => tile.Traits.OfType<T>().ToList().Apply(trait => trait.Activate(this, targetTile)));
        }

        private void ActivateTraits<T>(IEnumerable<CardWarsTile> tiles) where T : ITrait
        {
            tiles.Where(p => p.Card != null && p.Card.Traits.OfType<T>().Any()).ToList().Apply(
                tile => tile.Traits.OfType<T>().ToList().Apply(trait => trait.Activate(this, tile)));
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

        public IEnumerable<IEnumerable<CardWarsTile>> GetLinesOfTiles(CardWarsTile targetTile)
        {
            return HexMap.GetLines(targetTile);
        }

        public CardWarsGameLogic DeepCopy()
        {
            var gameLogic = new CardWarsGameLogic();
            gameLogic.Player1 = Player1.DeepCopy();
            gameLogic.Player2 = Player2.DeepCopy();
            gameLogic.CurrentPlayer = CurrentPlayer == Player1 ? gameLogic.Player1 : gameLogic.Player2;
            gameLogic.Settings = Settings;
            gameLogic.HexMap =
                new HexMap<CardWarsTile>(Tiles.Select(p => p.DeepCopy(gameLogic, gameLogic.Player1, gameLogic.Player2)),
                    Settings.Columns);
            gameLogic.Turns = Turns;
            gameLogic.GameOver = GameOver;
            return gameLogic;
        }
    }
}