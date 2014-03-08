namespace Hextasy.CardWars.AI
{
    internal class MulliganPlayerAction : PlayerAction
    {
        protected override void OnPerform(CardWarsGameLogic gameLogic, bool simulated)
        {
            if(!simulated) Wait();
            gameLogic.Mulligan();
        }
    }
}