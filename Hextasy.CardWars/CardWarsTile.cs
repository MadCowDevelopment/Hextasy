using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class CardWarsTile : HexagonTile
    {
        public Owner Owner { get; set; }
        public Card Card { get; set; }
        public bool IsSelected { get; set; }
        public bool IsFixed { get; set; }
        public bool IsValidTarget { get; set; }
    }
}