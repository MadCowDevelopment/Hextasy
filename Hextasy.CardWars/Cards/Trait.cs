
namespace Hextasy.CardWars.Cards
{
    public abstract class Trait : Effect, ITrait
    {
        public abstract void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }

    public interface ITrait : IEffect
    {
        void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }

    public interface IActivateTraitOnAttack : ITrait { }
    public interface IActivateTraitOnDefense : ITrait { }
    public interface IActivateTraitOnDeath : ITrait { }
    public interface IActivateTraitOnStartTurn : ITrait { }
    public interface IActivateTraitOnEndTurn : ITrait { }
    public interface IActivateTraitOnCardPlayed : ITrait { }
    public interface IActivateTraitOnAnyCardPlayed : ITrait { }
}