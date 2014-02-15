using System.Collections.Generic;
using System.Linq;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class Deck
    {
        private readonly List<Card> _cards;
        private readonly Queue<Card> _cardQueue;

        public Deck(string name, IEnumerable<Card> cards)
        {
            Name = name;
            _cards = cards.ToList();
            _cardQueue = new Queue<Card>(_cards.Shuffle());
        }

        public Card TakeCard()
        {
            return _cardQueue.Count > 0 ? _cardQueue.Dequeue() : null;
        }

        public string Name { get; private set; }
        public IEnumerable<Card> Cards { get { return _cards; } }
    }
}