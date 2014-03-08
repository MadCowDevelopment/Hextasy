namespace Hextasy.CardWars.Cards
{
    public interface IActivateDebuffOnEndTurn : IDebuff
    {
    }

    public interface IActivateDebuffOnStartTurn : IDebuff
    {
    }

    public interface IDebuff : IEffect
    {
        #region Properties

        bool IsExpired
        {
            get;
        }

        #endregion Properties

        #region Methods

        void Activate(MonsterCard affectedCard);

        IDebuff DeepCopy();

        #endregion Methods
    }

    public abstract class Debuff : Effect, IDebuff
    {
        #region Public Properties

        public bool IsExpired
        {
            get; protected set;
        }

        #endregion Public Properties

        #region Public Methods

        public abstract void Activate(MonsterCard affectedCard);

        public abstract IDebuff DeepCopy();

        #endregion Public Methods
    }
}