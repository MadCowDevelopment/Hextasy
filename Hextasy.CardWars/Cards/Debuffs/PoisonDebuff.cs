namespace Hextasy.CardWars.Cards.Debuffs
{
    public class PoisonDebuff : Debuff, IActivateDebuffOnStartTurn
    {
        public override string ImageFilename
        {
            get { return @"Images\Cards\Debuffs\fog-acid-3.png"; }
        }

        public override void Activate(MonsterCard affectedCard)
        {
            affectedCard.TakeDamage(1);
        }
    }
}
