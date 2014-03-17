using System.Threading;
using Hextasy.CardWars.Logic;
using Hextasy.Framework.Utils;

namespace Hextasy.CardWars.AI
{
    internal abstract class CpuPlayerCommand
    {
        #region Public Methods

        public void Perform(CardWarsGameLogic gameLogic, bool simulated)
        {
            if (!simulated) Synchronization.Enabled = true;
            OnPerform(gameLogic, simulated);
            if (simulated) Synchronization.Enabled = false;
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract void OnPerform(CardWarsGameLogic gameLogic, bool simulated);

        protected void Wait()
        {
            Thread.Sleep(CpuPlayer.DurationBetweenActions);
        }

        #endregion Protected Methods
    }
}