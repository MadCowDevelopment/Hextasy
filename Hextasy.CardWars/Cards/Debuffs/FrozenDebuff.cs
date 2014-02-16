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

    public abstract class Debuff : IDebuff
    {
        public abstract string ImageFilename { get; }
        public bool IsExpired { get; protected set; }
        public abstract void Activate(MonsterCard affectedCard);
    }

    public interface IDebuff
    {
        string ImageFilename { get; }
        bool IsExpired { get; }
        void Activate(MonsterCard affectedCard);
    }
    
    public interface IActivateDebuffOnStartTurn : IDebuff
    {
    }
}
