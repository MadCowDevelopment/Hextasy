namespace Hextasy.Yinsh.AI
{
    internal abstract class PlayerAction
    {
        protected YinshGameLogic GameLogic { get; set; }

        protected PlayerAction(YinshGameLogic gameLogic)
        {
            GameLogic = gameLogic;
        }

        public abstract void Execute();
    }
}