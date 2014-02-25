namespace Hextasy.CardWars.AI
{
    public class DeepBlueCpuPlayer : CpuPlayer
    {
        public override string CpuName
        {
            get { return "Deep Blue"; }
        }

        protected override void OnTakeTurn(CardWarsGameLogic cardWarsGameLogic)
        {
            Wait();

            cardWarsGameLogic.EndTurn();
        }
    }
}