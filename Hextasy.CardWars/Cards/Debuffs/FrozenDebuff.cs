namespace Hextasy.CardWars.Cards.Debuffs
{
    public class FrozenDebuff : Debuff, IActivateDebuffOnStartTurn
    {
        public override string ImageFilename
        {
            get { return @"Images\Cards\Debuffs\fog-blue-3.png"; }
        }

        public override void Activate(MonsterCard affectedCard)
        {
            affectedCard.IsExhausted = true;
            IsExpired = true;
        }
    }
}
