using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class Player
    {
        public string Name { get; private set; }
        public Owner Owner { get; private set; }
        public int RemainingLife { get; private set; }

        public Player(string name, Owner owner)
        {
            Name = name;
            Owner = owner;
            RemainingLife = 30;
        }
    }
}