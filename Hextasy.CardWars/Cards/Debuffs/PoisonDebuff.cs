namespace Hextasy.CardWars.Cards.Debuffs
{
    public class PoisonDebuff : Debuff, IActivateDebuffOnEndTurn
    {
        private int Amount { get; set; }
        private int Duration { get; set; }

        public PoisonDebuff(int amount, int duration)
        {
            Amount = amount;
            Duration = duration;
        }

        public override string Name
        {
            get { return "Poisoned"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Debuffs/fog-acid-3.png"; }
        }

        public override void Activate(MonsterCard affectedCard)
        {
            affectedCard.TakePoisonDamage(Amount);
            Duration--;
            if (Duration == 0) IsExpired = true;
        }

        public override IDebuff DeepCopy()
        {
            return new PoisonDebuff(Amount, Duration);
        }
    }
}
