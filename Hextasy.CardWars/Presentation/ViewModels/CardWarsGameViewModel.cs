using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows.Input;

using Caliburn.Micro;

using Hextasy.CardWars.AI;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;
using Hextasy.Framework.Utils;

namespace Hextasy.CardWars.Presentation.ViewModels
{
    [Export(typeof(CardWarsGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CardWarsGameViewModel : GameViewModel<CardWarsGameLogic, CardWarsSettings, CardWarsTile, CardWarsStatistics>
    {
        #region Fields

        private CardWarsTile _mouseOverTile;
        private Card _selectedCard;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public CardWarsGameViewModel(CardWarsGameLogic game, IEventAggregator eventAggregator)
            : base(game, eventAggregator)
        {
            Game.PropertyChanged += GamePropertyChanged;
        }

        #endregion Constructors

        #region Public Properties

        public DispatcherObservableCollection<PlayerAction> Actions
        {
            get { return Game.TakenActions; }
        }

        public bool CanMulligan
        {
            get { return Game.CanMulligan && !CurrentPlayer.DidMulligan; }
        }

        public DispatcherObservableCollection<Card> CurrentCards
        {
            get { return Game.CurrentPlayerHand; }
        }

        public Player CurrentPlayer
        {
            get { return Game.CurrentPlayer; }
        }

        public bool IsInCardPlacementMode
        {
            get { return SelectedCard is MonsterCard; }
        }

        public bool IsInSpellTargetMode
        {
            get { return SelectedCard is SpellCard; }
        }

        public bool IsInTargetMode
        {
            get { return Game.SelectedTile != null; }
        }

        public bool IsPlayerTurn
        {
            get { return !(CurrentPlayer is CpuPlayer); }
        }

        public Player Player1
        {
            get { return Game.Player1; }
        }

        public Player Player2
        {
            get { return Game.Player2; }
        }

        public Card SelectedCard
        {
            get
            {
                return _selectedCard;
            }

            set
            {
                _selectedCard = value;
                Game.UnselectTile();
                NotifyOfPropertyChange(() => IsInTargetMode);
            }
        }

        #endregion Public Properties

        #region Public Methods

        public void EndTurn()
        {
            Game.EndTurn();
            NotifyOfPropertyChange(() => CurrentPlayer);
            NotifyOfPropertyChange(() => CurrentCards);
            NotifyOfPropertyChange(() => CanMulligan);
        }

        public void Mulligan()
        {
            Game.Mulligan();
            NotifyOfPropertyChange(() => CanMulligan);
            NotifyOfPropertyChange(() => CurrentCards);
        }

        public void OnTileClick(CardWarsTile tile)
        {
            if (IsInCardPlacementMode)
            {
                Game.PlayMonsterCard(tile, SelectedCard as MonsterCard);
            }
            else if (IsInTargetMode)
            {
                Game.AttackCard(tile);
            }
            else if (IsInSpellTargetMode)
            {
                Game.PlaySpellCard(tile, SelectedCard as SpellCard);
            }
            else
            {
                Game.SelectTile(tile);
            }

            NotifyOfPropertyChange(() => CanMulligan);
            NotifyOfPropertyChange(() => IsInTargetMode);
        }

        public void OnTileEnter(CardWarsTile tile)
        {
            _mouseOverTile = tile;
            if (SelectedCard is MonsterCard)
            {
                Game.PreviewAssignCard(tile, SelectedCard as MonsterCard);
            }
        }

        public void OnTileLeave(CardWarsTile tile)
        {
            _mouseOverTile = null;
            if (SelectedCard is MonsterCard)
            {
                Game.PreviewRemoveCard(tile, SelectedCard as MonsterCard);
            }
        }

        public void PreviewKeyUp(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    if (SelectedCard != null)
                    {
                        OnTileLeave(_mouseOverTile);
                        SelectedCard = null;
                    }
                    else Game.UnselectTile();
                    break;
                case Key.Enter:
                    EndTurn();
                    break;
            }

            e.Handled = true;
        }

        #endregion Public Methods

        #region Private Methods

        private void GamePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Game.GetPropertyName(p => p.SelectedTile))
            {
                NotifyOfPropertyChange(() => SelectedCard);
                NotifyOfPropertyChange(() => IsInTargetMode);
            }
            else if (e.PropertyName == Game.GetPropertyName(p => p.CurrentPlayer))
            {
                OnPropertyChanged(new PropertyChangedEventArgs(string.Empty));
            }
        }

        #endregion Private Methods
    }
}