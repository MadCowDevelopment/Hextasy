using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class Deck
    {
        private readonly List<Card> _cards;
        private Queue<Card> _cardQueue;

        private readonly List<Card> _discardPile;

        public Deck(string name, IEnumerable<Card> cards)
        {
            Name = name;
            _cards = cards.ToList();
            _cardQueue = new Queue<Card>(_cards.Shuffle());
            _discardPile = new List<Card>();
        }

        public Card TakeCard()
        {
            if (_cardQueue.Count == 0)
            {
                _cardQueue = new Queue<Card>(_discardPile.Shuffle());
                _discardPile.Clear();
            }

            return _cardQueue.Count > 0 ? _cardQueue.Dequeue() : null;
        }

        public string Name { get; private set; }
        public IEnumerable<Card> Cards { get { return _cards; } }

        public void DiscardCards(IEnumerable<Card> cards)
        {
            cards.Apply(_discardPile.Add);
        }
    }
}