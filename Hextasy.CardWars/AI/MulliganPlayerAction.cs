namespace Hextasy.CardWars.AI
{
    internal class MulliganPlayerAction : PlayerAction
    {
        public override void Perform(CardWarsGameLogic gameLogic)
        {
            Wait();
            gameLogic.Mulligan();
        }
    }
}