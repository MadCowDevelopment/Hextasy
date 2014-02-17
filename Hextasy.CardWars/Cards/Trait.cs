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
        string ImageFilename { get; }
        void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }

    public interface IActivateTraitOnAttack : ITrait { }
    public interface IActivateTraitOnDefense : ITrait { }
    public interface IActivateTraitOnStartTurn : ITrait { }
    public interface IActivateTraitOnPlay : ITrait { }
    public interface IActivateTraitOnDeath : ITrait { }
}