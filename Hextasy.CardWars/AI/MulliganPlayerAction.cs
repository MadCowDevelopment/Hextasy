using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.AI
{
    internal class MulliganPlayerAction : PlayerAction
    {
        #region Protected Methods

        protected override void OnPerform(CardWarsGameLogic gameLogic, bool simulated)
        {
            if (!simulated) Wait();
            gameLogic.Mulligan();
        }

        #endregion Protected Methods
    }
}