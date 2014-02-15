using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(CardWarsGameViewModel))]
    public class CardWarsGameViewModel : GameViewModel<CardWarsGameLogic, CardWarsSettings, CardWarsTile>
    {
        private Card _selectedCard;

        [ImportingConstructor]
        public CardWarsGameViewModel(CardWarsGameLogic game, IEventAggregator eventAggregator)
            : base(game, eventAggregator)
        {
        }

        public ObservableCollection<Card> CurrentCards
        {
            get { return Game.CurrentCards; }
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


        public bool IsInCardPlacementMode
        {
            get { return SelectedCard != null; }
        }

        public bool IsInTargetMode
        {
            get { return Game.SelectedTile != null; }
        }

        public Player CurrentPlayer
        {
            get { return Game.CurrentPlayer; }
        }

        public Player Player1
        {
            get { return Game.Player1; }
        }

        public Player Player2
        {
            get { return Game.Player2; }
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
            else
            {
                Game.SelectTile(tile);
            }

            NotifyOfPropertyChange(() => IsInTargetMode);
        }

        public void OnTileEnter(CardWarsTile tile)
        {
            if (SelectedCard is MonsterCard)
            {
                Game.PreviewAssignCard(tile, SelectedCard as MonsterCard);
            }
        }

        public void OnTileLeave(CardWarsTile tile)
        {
            if (SelectedCard is MonsterCard)
            {
                Game.PreviewRemoveCard(tile, SelectedCard as MonsterCard);
            }
        }

        public void EndTurn()
        {
            Game.EndTurn();
            NotifyOfPropertyChange(() => CurrentPlayer);
            NotifyOfPropertyChange(() => CurrentCards);
        }

        public void PreviewKeyUp(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    if (SelectedCard != null) SelectedCard = null;
                    else Game.UnselectTile();
                    break;
                case Key.Enter:
                    EndTurn();
                    break;
            }
        }
    }
}