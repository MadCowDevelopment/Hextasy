namespace Hextasy.CardWars.Cards
{
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