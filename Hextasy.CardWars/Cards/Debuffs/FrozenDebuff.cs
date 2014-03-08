namespace Hextasy.CardWars.Cards.Debuffs
{
    public class FrozenDebuff : Debuff, IActivateDebuffOnStartTurn
    {
        #region Public Properties

        public override string Name
        {
            get { return "Frozen"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Debuffs/fog-blue-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(MonsterCard affectedCard)
        {
            affectedCard.IsExhausted = true;
            IsExpired = true;
        }

        public override IDebuff DeepCopy()
        {
            return new FrozenDebuff();
        }

        #endregion Public Methods
    }
}