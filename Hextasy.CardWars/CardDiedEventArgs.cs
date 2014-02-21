namespace Hextasy.CardWars
{
    public class CardDiedEventArgs
    {
        public CardWarsTile TileOnWhichTheCardDied { get; set; }

        public CardDiedEventArgs(CardWarsTile tileOnWhichTheCardDied)
        {
            TileOnWhichTheCardDied = tileOnWhichTheCardDied;
        }
    }
}