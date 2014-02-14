using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards
{
    public abstract class Card : PropertyChangedBase
    {
        protected Card()
        {
            IsExhausted = true;
        }

        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string ImageSource { get; }

        public abstract int BaseAttack { get; }
        public abstract int BaseHealth { get; }
        public abstract int Cost { get; }

        public int Attack { get { return BaseAttack + AttackBonus; } }
        public int AttackBonus { get; set; }

        public int Health { get { return BaseHealth + HealthBonus; } }
        public int HealthBonus { get; set; }

        public bool IsKilled { get; set; }
        public bool IsExhausted { get; protected internal set; }

        public bool CanBePlayed { get; set; }

        public bool HasIncreasedAttack
        {
            get { return Attack > BaseAttack; }
        }

        public bool HasDecreasedAttack
        {
            get { return Attack < BaseAttack; }
        }

        public bool HasIncreasedHealth
        {
            get { return Health > BaseHealth; }
        }

        public bool HasDecreasedHealth
        {
            get { return Health < BaseHealth; }
        }

        public Owner Owner { get; set; }

        public void TakeDamage(int attackValue)
        {
            HealthBonus -= attackValue;
        }
    }
}
