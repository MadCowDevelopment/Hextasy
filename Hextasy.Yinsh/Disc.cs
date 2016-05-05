using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    public class Disc : ObservableObject
    {
        public PlayerColor Color { get; private set; }

        public bool IsSelected { get; set; }

        public Disc(PlayerColor color)
        {
            Color = color;
        }

        public void Flip()
        {
            Color = Color == PlayerColor.Black ? PlayerColor.White : PlayerColor.Black;
        }
    }
}