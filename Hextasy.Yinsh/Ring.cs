using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    public class Ring : ObservableObject
    {
        public PlayerColor Color { get; private set; }

        public Ring(PlayerColor color)
        {
            Color = color;
        }
    }
}