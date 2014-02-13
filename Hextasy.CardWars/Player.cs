using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class Player : PropertyChangedBase
    {
        public string Name { get; private set; }
        public Owner Owner { get; private set; }
        public int RemainingLife { get; private set; }
        public int Resources { get; set; }
        public bool IsActive { get; set; }

        public Player(string name, Owner owner)
        {
            Name = name;
            Owner = owner;
            RemainingLife = 30;
            Resources = 20;
        }
    }
}