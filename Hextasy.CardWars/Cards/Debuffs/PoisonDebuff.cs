namespace Hextasy.CardWars.Cards.Debuffs
{
    public class PoisonDebuff : Debuff, IActivateDebuffOnStartTurn
    {
        private int Amount { get; set; }
        private int Duration { get; set; }

        public PoisonDebuff(int amount, int duration)
        {
            Amount = amount;
            Duration = duration;
        }

        public override string ImageFilename
        {
            get { return @"Images\Cards\Debuffs\fog-acid-3.png"; }
        }

        public override void Activate(MonsterCard affectedCard)
        {
            affectedCard.TakeDamage(Amount);
            Duration--;
            if (Duration == 0) IsExpired = true;
        }
    }
}
