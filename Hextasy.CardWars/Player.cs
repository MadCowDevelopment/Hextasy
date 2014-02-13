using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class Player : PropertyChangedBase
    {
        public string Name { get; private set; }
        public Owner Owner { get; private set; }
        public int RemainingLife { get; private set; }
        public int MaximumResources { get; set; }
        public int RemainingResources { get; set; }
        public bool IsActive { get; set; }

        public Player(string name, Owner owner)
        {
            Name = name;
            Owner = owner;
            RemainingLife = 30;
            MaximumResources = 10;
            RemainingResources = 8;
        }

        public void PrepareTurn()
        {
            if (MaximumResources < 12) MaximumResources++;
            RemainingResources = MaximumResources;
        }
    }
}