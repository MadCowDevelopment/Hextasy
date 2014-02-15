namespace Hextasy.CardWars.Cards
{
    public abstract class MonsterCard : Card
    {
        public MonsterCard()
        {
            IsExhausted = true;
        }

        public abstract int BaseAttack { get; }
        public abstract int BaseHealth { get; }
        public int Attack { get { return BaseAttack + AttackBonus; } }
        public int AttackBonus { get; set; }

        public int Health { get { return BaseHealth + HealthBonus; } }
        public int HealthBonus { get; set; }

        public bool IsKilled { get; set; }
        public bool IsExhausted { get; protected internal set; }

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

        public void TakeDamage(int attackValue)
        {
            HealthBonus -= attackValue;
        }

        protected override string ImageFolder
        {
            get { return @"Images\Cards\Monsters\"; }
        }

        public override CardType Type
        {
            get { return CardType.Monster; }
        }
    }
}
