namespace Hextasy.CardWars.Cards.Debuffs
{
    public class PoisonDebuff : Debuff, IActivateDebuffOnEndTurn
    {
        #region Constructors

        public PoisonDebuff(int amount, int duration)
        {
            Amount = amount;
            Duration = duration;
        }

        #endregion Constructors

        #region Public Properties

        public int Amount
        {
            get; set;
        }

        public int Duration
        {
            get; set;
        }

        public override string Name
        {
            get { return "Poisoned"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Debuffs/fog-acid-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

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

        #endregion Public Methods
    }
}