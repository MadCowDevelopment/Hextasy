using System.Threading;

namespace Hextasy.CardWars.AI
{
    internal abstract class PlayerAction
    {
        public abstract void Perform(CardWarsGameLogic gameLogic);

        protected void Wait()
        {
            Thread.Sleep(CpuPlayer.DurationBetweenActions);
        }
    }
}