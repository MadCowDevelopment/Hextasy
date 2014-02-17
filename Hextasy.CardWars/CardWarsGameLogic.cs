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

            CurrentPlayer = Player1;
            CurrentPlayer.PrepareTurn();
        }

        public ObservableCollection<Card> CurrentCards
        {
            get
            {
                return CurrentPlayer != null ? CurrentPlayer.Hand : null;
            }
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
            get { return Tiles.Where(p => p.Card != null).Select(p=>p.Card); }
        }

        public IEnumerable<MonsterCard> AllCardsExceptKing
        {
            get { return AllCards.Where(p => !(p is KingCard)); }
        }

        public void PlayMonsterCard(CardWarsTile tile, MonsterCard selectedCard)
        {
            if (tile.IsFixed) return;
            tile.AssignCard(selectedCard);
            CurrentPlayer.RemainingResources -= selectedCard.Cost;
            CurrentCards.Remove(selectedCard);
            if(selectedCard.HasTrait<IActivateTraitOnPlay>())
                selectedCard.Traits.OfType<IActivateTraitOnPlay>().Apply(trait => trait.Activate(this, tile));

            ActivateTraits<IActivateTraitOnAnyCardPlayed>(Tiles);
        }

        public void PlaySpellCard(CardWarsTile tile, SpellCard selectedCard)
        {
            if (!tile.IsValidSpellTarget) return;
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
            if (tile.Card != selectedCard) return;
            tile.Card = null;
        }

        public void EndTurn()
        {
            UnselectTile();
            ResolveEndTurnEffects();
            ExhaustCards();
            CleanupDebuffs();
            SwitchCurrentPlayer();
            ReadyCards();
            ResolveStartTurnEffects();

            NotifyOfPropertyChange(() => CurrentCards);
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

        private void ActivateTraits<T>(IEnumerable<CardWarsTile> tiles) where T : ITrait
        {
            tiles.Where(p => p.Card != null && p.Card.Traits.OfType<T>().Any()).Apply(
                tile => tile.Card.Traits.OfType<T>().Apply(trait => trait.Activate(this, tile)));
        }

        private void ActivateDebuffs<T>(IEnumerable<CardWarsTile> tiles) where T : IDebuff
        {
            tiles.Where(p => p.Card != null && p.Card.Debuffs.OfType<T>().Any()).Select(p => p.Card).Apply(
                card => card.Debuffs.OfType<T>().Apply(debuff => debuff.Activate(card)));
        }

        private void ResolveEndTurnEffects()
        {
            // TODO
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