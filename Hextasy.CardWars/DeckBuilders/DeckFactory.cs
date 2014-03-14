using System.Collections.Generic;
using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.DeckBuilders
{
    [InheritedExport(typeof(DeckFactory))]
    public abstract class DeckFactory
    {
        #region Protected Properties

        protected abstract List<Card> Cards
        {
            get;
        }

        protected abstract string Name
        {
            get;
        }

        #endregion Protected Properties

        #region Public Methods

        public Deck Create()
        {
            return CreateDeck(Name, Cards);
        }

        #endregion Public Methods

        #region Private Static Methods

        private static Deck CreateDeck(string name, List<Card> cards)
        {
            return new Deck(string.Format("{0} ({1} cards)", name, cards.Count), cards);
        }

        #endregion Private Static Methods
    }
}