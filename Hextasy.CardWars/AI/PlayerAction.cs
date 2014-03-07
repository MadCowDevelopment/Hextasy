using System;
using System.Threading;

namespace Hextasy.CardWars.AI
{
    internal abstract class PlayerAction
    {
        public abstract void Perform(CardWarsGameLogic gameLogic, bool delayActions);

        protected void Wait()
        {
            Thread.Sleep(CpuPlayer.DurationBetweenActions);
        }
    }
}