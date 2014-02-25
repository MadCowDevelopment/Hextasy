using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class CardWarsSettings : Settings
    {
        public CardWarsSettings(
            int rows,
            int columns,
            string player1,
            string player2,
            Deck player1Deck,
            Deck player2Deck,
            bool player1Human,
            bool player2Human)
            : base(rows, columns)
        {
            Player1 = player1;
            Player2 = player2;
            Player1Deck = player1Deck;
            Player2Deck = player2Deck;
            Player1Human = player1Human;
            Player2Human = player2Human;
        }

        public string Player1 { get; private set; }
        public string Player2 { get; private set; }
        public Deck Player1Deck { get; private set; }
        public Deck Player2Deck { get; private set; }
        public bool Player1Human { get; private set; }
        public bool Player2Human { get; private set; }
    }
}