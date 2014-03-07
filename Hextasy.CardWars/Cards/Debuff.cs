
namespace Hextasy.CardWars.Cards
{
    public abstract class Debuff : Effect, IDebuff
    {
        public bool IsExpired { get; protected set; }
        public abstract void Activate(MonsterCard affectedCard);
        public abstract IDebuff DeepCopy();
    }

    public interface IDebuff : IEffect
    {
        bool IsExpired { get; }
        void Activate(MonsterCard affectedCard);
        IDebuff DeepCopy();
    }

    public interface IActivateDebuffOnStartTurn : IDebuff { }
    public interface IActivateDebuffOnEndTurn : IDebuff { }
}