namespace Hextasy.CardWars.Cards
{
    public abstract class Trait : ITrait
    {
        public abstract string Name { get; }
        public abstract string ImageFilename { get; }
        public abstract void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }

    public interface ITrait
    {
        string Name { get; }
        string ImageFilename { get; }
        void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }

    public interface IActivateTraitOnAttack : ITrait { }
    public interface IActivateTraitOnDefense : ITrait { }
    public interface IActivateTraitOnStartTurn : ITrait { }
    public interface IActivateTraitOnCardPlayed : ITrait { }
    public interface IActivateTraitOnDeath : ITrait { }
    public interface IActivateTraitOnAnyCardPlayed : ITrait { }
}