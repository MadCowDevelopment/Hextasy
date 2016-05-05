using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    public class Player : ObservableObject
    {
        public Player()
        {
            Name = "Player 1";
            UnplacedRings = 3;
            Color = PlayerColor.White;
            Score = 0;
        }
        
        public string Name { get; protected set; }

        public bool IsActive { get; set; }

        public PlayerColor Color { get; protected set; }

        public int UnplacedRings { get; set; }
        public int Score { get; set; }
    }
}