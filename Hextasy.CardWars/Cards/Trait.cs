
namespace Hextasy.CardWars.Cards
{
    public abstract class Trait : Effect, ITrait
    {
        public virtual bool IsUnique
        {
            get { return true; }
        }

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
    public interface IActivateTraitOnStartTurn : ITrait { }
    public interface IActivateTraitOnEndTurn : ITrait { }
    public interface IActivateTraitOnCardPlayed : ITrait { }
    public interface IActivateTraitOnAnyCardPlayed : ITrait { }
}