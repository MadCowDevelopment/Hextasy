using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    public class Player : ObservableObject
    {
        public Player()
        {
            Name = "Player 1";
            UnplacedRings = 1;
            Color = PlayerColor.White;
        }
        
        public string Name { get; protected set; }

        public bool IsActive { get; set; }

        public PlayerColor Color { get; protected set; }

        public int UnplacedRings { get; set; }
    }
}