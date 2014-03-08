using System.ComponentModel.Composition;
using System.Threading;

namespace Hextasy.CardWars.AI
{
    [InheritedExport(typeof(CpuPlayer))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public abstract class CpuPlayer : Player
    {
        public static int DurationBetweenActions = 2000;
        
        public bool Simulated { get; set; }

        protected void Wait()
        {
            Thread.Sleep(DurationBetweenActions);
        }

        public abstract string CpuName { get; }

        public void TakeTurn(CardWarsGameLogic cardWarsGameLogic)
        {
            OnTakeTurn(cardWarsGameLogic);
            Wait();
        }

        protected abstract void OnTakeTurn(CardWarsGameLogic cardWarsGameLogic);
    }
}
