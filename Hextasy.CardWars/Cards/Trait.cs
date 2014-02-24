
namespace Hextasy.CardWars.Cards
{
    public abstract class Trait : Effect, ITrait
    {
        protected Trait(MonsterCard cardThatHasTrait)
        {
            CardThatHasTrait = cardThatHasTrait;
        }

        public virtual bool IsUnique
        {
            get { return true; }
        }

        protected MonsterCard CardThatHasTrait { get; private set; }

        public abstract void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }

    public interface ITrait : IEffect
    {
        bool IsUnique { get; }
        void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }

    public interface IActivateTraitOnAttack : ITrait { }
    public interface IActivateTraitOnDefense : ITrait { }
    public interface IActivateTraitOnDodge : ITrait { }
    public interface IActivateTraitOnDeath : ITrait { }
    public interface IActivateTraitOnHeal : ITrait { }
    public interface IActivateTraitOnStartTurn : ITrait { }
    public interface IActivateTraitOnEndTurn : ITrait { }
    public interface IActivateTraitOnCardPlayed : ITrait { }
    public interface IActivateTraitOnAnyCardPlayed : ITrait { }
    public interface IActivateTraitOnAnyCardDied : ITrait { }
}