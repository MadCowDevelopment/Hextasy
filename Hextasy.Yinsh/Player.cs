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
            Score = 0;
        }
        
        public string Name { get; protected set; }

        public bool IsActive { get; set; }

        public PlayerColor Color { get; protected set; }

        public int UnplacedRings { get; set; }
        public int Score { get; set; }

        public Player DeepCopy()
        {
            var copy = new Player();
            copy.Color = Color;
            copy.Score = Score;
            copy.IsActive = IsActive;
            copy.Name = Name;
            copy.UnplacedRings = UnplacedRings;
            return copy;
        }
    }
}