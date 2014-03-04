using System;

namespace Hextasy.CardWars.Cards
{
    public abstract class Debuff : Effect, IDebuff
    {
        public bool IsExpired { get; protected set; }
        public abstract void Activate(MonsterCard affectedCard);
        public IDebuff DeepCopy()
        {
            var instance = (IDebuff)Activator.CreateInstance(GetType());
            OnDeepCopy(instance);
            return instance;
        }

        protected virtual void OnDeepCopy(IDebuff debuff)
        {
        }
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