using System.ComponentModel.Composition;
using System.Threading;

namespace Hextasy.CardWars.AI
{
    [InheritedExport(typeof(CpuPlayer))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public abstract class CpuPlayer : Player
    {
        private const int DurationBetweenActions = 10;

        protected void Wait()
        {
            Thread.Sleep(DurationBetweenActions);
        }

        public abstract string CpuName { get; }

        public void TakeTurn(CardWarsGameLogic cardWarsGameLogic)
        {
            OnTakeTurn(cardWarsGameLogic);
        }

        protected abstract void OnTakeTurn(CardWarsGameLogic cardWarsGameLogic);
    }
}
