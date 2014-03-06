namespace Hextasy.CardWars.AI
{
    internal class MulliganPlayerAction : PlayerAction
    {
        public override void Perform(CardWarsGameLogic gameLogic, bool delayAction)
        {
            if(delayAction) Wait();
            gameLogic.Mulligan();
        }
    }
}