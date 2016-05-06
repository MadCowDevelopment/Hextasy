namespace Hextasy.Yinsh
{
    public abstract class GameState
    {
        protected GameState(YinshGameLogic gameLogic)
        {
            GameLogic = gameLogic;
        }

        protected YinshGameLogic GameLogic { get; }

        public abstract string Message { get; }

        public abstract void Activate(YinshTile tile);

        public abstract GameState DeepCopy(YinshGameLogic gameLogic);
    }
}