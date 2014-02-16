namespace Hextasy.CardWars.Cards
{
    public abstract class Trait : ITrait
    {
        public abstract string ImageFilename { get; }
        public abstract void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }

    public interface ITrait
    {
        string ImageFilename { get; }
        void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }

    public interface IActivateOnAttack : ITrait
    {
    }
}