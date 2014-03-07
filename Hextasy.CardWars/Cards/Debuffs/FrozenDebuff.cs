namespace Hextasy.CardWars.Cards.Debuffs
{
    public class FrozenDebuff : Debuff, IActivateDebuffOnStartTurn
    {
        public override string Name
        {
            get { return "Frozen"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Debuffs/fog-blue-3.png"; }
        }

        public override void Activate(MonsterCard affectedCard)
        {
            affectedCard.IsExhausted = true;
            IsExpired = true;
        }

        public override IDebuff DeepCopy()
        {
            return new FrozenDebuff();
        }
    }
}
