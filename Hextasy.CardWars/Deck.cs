using System.Collections.Generic;
using System.Linq;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class Deck
    {
        private const int NumberCardsInHandWhenStarting = 4;

        private List<Card> _cards;
        private Queue<Card> _cardQueue;

        public Deck(string name, IEnumerable<Card> cards)
        {
            Name = name;
            _cards = cards.ToList();
            InitializeDeck();
        }

        private Deck() { }

        private void InitializeDeck()
        {
            _cardQueue = new Queue<Card>(_cards.Shuffle());
        }

        public Card TakeCard()
        {
            return _cardQueue.Count > 0 ? _cardQueue.Dequeue() : null;
        }

        public IEnumerable<Card> TakeHand()
        {
            return Enumerable.Repeat(1, NumberCardsInHandWhenStarting).Select(p => TakeCard()).Where(p => p != null);
        }

        public string Name { get; private set; }

        public IEnumerable<Card> Cards { get { return _cards; } }

        public IEnumerable<Card> Mulligan()
        {
            InitializeDeck();
            var hand = TakeHand().ToList();
            hand.AddNotNull(TakeCard());
            return hand;
        }

        public Deck DeepCopy(Player player)
        {
            var deck = new Deck();
            deck._cardQueue = new Queue<Card>(_cardQueue.Select(p => p.DeepCopy(player)));
            deck._cards = new List<Card>(_cards.Select(p => p.DeepCopy(player)));
            return deck;
        }
    }
}