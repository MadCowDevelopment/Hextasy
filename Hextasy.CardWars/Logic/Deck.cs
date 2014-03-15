using System.Collections.Generic;
using System.Linq;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars.Logic
{
    public class Deck
    {
        #region Fields

        private const int NumberCardsInHandWhenStarting = 4;

        private Queue<Card> _cardQueue;
        private Dictionary<long, Card> _cards;

        #endregion Fields

        #region Constructors

        public Deck(string name, IEnumerable<Card> cards)
        {
            Name = name;
            _cards = cards.ToDictionary(p => p.Id, p => p);
            InitializeDeck();
        }

        private Deck()
        {
        }

        #endregion Constructors

        #region Public Properties

        public IEnumerable<Card> Cards
        {
            get { return _cards.Values; }
        }

        public string Name
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Public Methods

        public Deck DeepCopy(Player player)
        {
            var deck = new Deck();
            deck._cards = _cards.Values.ToDictionary(p => p.Id, p => p.DeepCopy(player));
            deck._cardQueue = new Queue<Card>();
            foreach (var card in _cardQueue)
            {
                deck._cardQueue.Enqueue(deck._cards[card.Id]);
            }

            return deck;
        }

        public IEnumerable<Card> Mulligan()
        {
            InitializeDeck();
            var hand = TakeHand().ToList();
            hand.AddNotNull(TakeCard());
            return hand;
        }

        public Card TakeCard()
        {
            return _cardQueue.Count > 0 ? _cardQueue.Dequeue() : null;
        }

        public IEnumerable<Card> TakeHand()
        {
            return Enumerable.Repeat(1, NumberCardsInHandWhenStarting).Select(p => TakeCard()).Where(p => p != null);
        }

        #endregion Public Methods

        #region Private Methods

        private void InitializeDeck()
        {
            _cardQueue = new Queue<Card>(_cards.Values.Shuffle());
        }

        #endregion Private Methods
    }
}