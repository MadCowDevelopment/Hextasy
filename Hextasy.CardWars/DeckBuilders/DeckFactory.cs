using System.Collections.Generic;
using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards;

namespace Hextasy.CardWars.DeckBuilders
{
    [InheritedExport(typeof(DeckFactory))]
    public abstract class DeckFactory
    {
        public Deck Create()
        {
            return CreateDeck(Name, Cards);
        }

        protected abstract string Name { get; }

        protected abstract List<Card> Cards { get; }

        private static Deck CreateDeck(string name, List<Card> cards)
        {
            return new Deck(string.Format("{0} ({1} cards)", name, cards.Count), cards);
        }
    }
}
