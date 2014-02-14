using Caliburn.Micro;
using Hextasy.CardWars.Cards;
using Hextasy.Framework;

namespace Hextasy.CardWars
{
    public class Player : PropertyChangedBase
    {
        private KingCard KingCard { get; set; }

        public string Name { get; private set; }
        public Owner Owner { get; private set; }
        public int RemainingLife { get { return KingCard.Health; } }
        public int MaximumResources { get; set; }
        public int RemainingResources { get; set; }
        public bool IsActive { get; set; }

        public Player(string name, Owner owner, KingCard kingCard)
        {
            Name = name;
            Owner = owner;
            KingCard = kingCard;
            MaximumResources = 5;
            RemainingResources = 5;
        }

        public void PrepareTurn()
        {
            if (MaximumResources < 12) MaximumResources++;
            RemainingResources = MaximumResources;
        }
    }
}