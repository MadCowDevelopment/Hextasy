using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    [Export(typeof(CardWarsGameViewModel))]
    public class CardWarsGameViewModel : GameViewModel<CardWarsGameLogic, CardWarsSettings, CardWarsTile>
    {
        [ImportingConstructor]
        public CardWarsGameViewModel(CardWarsGameLogic game, IEventAggregator eventAggregator)
            : base(game, eventAggregator)
        {

        }

        public ObservableCollection<Card> CurrentCards
        {
            get { return Game.CurrentCards; }
        }

        public Player Player1
        {
            get { return Game.Player1; }
        }

        public Player Player2
        {
            get { return Game.Player2; }
        }

        public void OnMouseClick(CardWarsTile tile)
        {
            Game.SelectTile(tile);
        }

        public void OnMouseEnter(CardWarsTile tile)
        {
        }

        public void OnMouseLeave(CardWarsTile tile)
        {
        }

        //public void OnMouseClick(Player player)
        //{
        //}

        //public void OnMouseEnter(Player player)
        //{
        //}

        //public void OnMouseLeave(Player player)
        //{
        //}
    }
}