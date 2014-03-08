using System.Threading;
using Hextasy.Framework.Utils;

namespace Hextasy.CardWars.AI
{
    internal abstract class PlayerAction
    {
        public void Perform(CardWarsGameLogic gameLogic, bool simulated)
        {
            if (!simulated) Synchronization.Enabled = true;
            OnPerform(gameLogic, simulated);
            if (simulated) Synchronization.Enabled = false;
        }

        protected abstract void OnPerform(CardWarsGameLogic gameLogic, bool simulated);

        protected void Wait()
        {
            Thread.Sleep(CpuPlayer.DurationBetweenActions);
        }
    }
}