using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class CardWarsSettings : Settings
    {
        public CardWarsSettings(int rows, int columns, string player1, string player2, Deck player1Deck, Deck player2Deck)
            : base(rows, columns)
        {
            Player1 = player1;
            Player2 = player2;
            Player1Deck = player1Deck;
            Player2Deck = player2Deck;
        }

        public string Player1 { get; private set; }
        public string Player2 { get; private set; }
        public Deck Player1Deck { get; private set; }
        public Deck Player2Deck { get; private set; }
    }
}