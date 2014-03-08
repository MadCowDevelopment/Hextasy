namespace Hextasy.CardWars.Cards
{
    public interface IActivateTraitOnAnyCardDied : ITrait
    {
    }

    public interface IActivateTraitOnAnyCardPlayed : ITrait
    {
    }

    public interface IActivateTraitOnAttack : ITrait
    {
    }

    public interface IActivateTraitOnCardPlayed : ITrait
    {
    }

    public interface IActivateTraitOnDeath : ITrait
    {
    }

    public interface IActivateTraitOnDefense : ITrait
    {
    }

    public interface IActivateTraitOnDodge : ITrait
    {
    }

    public interface IActivateTraitOnEndTurn : ITrait
    {
    }

    public interface IActivateTraitOnHeal : ITrait
    {
    }

    public interface IActivateTraitOnStartTurn : ITrait
    {
    }

    public interface ITrait : IEffect
    {
        #region Properties

        bool IsUnique
        {
            get;
        }

        #endregion Properties

        #region Methods

        void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);

        ITrait DeepCopy(MonsterCard monsterCard);

        #endregion Methods
    }

    public abstract class Trait : Effect, ITrait
    {
        #region Constructors

        protected Trait(MonsterCard cardThatHasTrait)
        {
            CardThatHasTrait = cardThatHasTrait;
        }

        #endregion Constructors

        #region Public Properties

        public virtual bool IsUnique
        {
            get { return true; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected MonsterCard CardThatHasTrait
        {
            get; private set;
        }

        #endregion Protected Properties

        #region Public Methods

        public abstract void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);

        public abstract ITrait DeepCopy(MonsterCard monsterCard);

        #endregion Public Methods
    }
}