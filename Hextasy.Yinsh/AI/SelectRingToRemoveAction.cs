namespace Hextasy.Yinsh.AI
{
    internal class SelectRingToRemoveAction : PlayerAction
    {
        private readonly YinshTile _tileWithRing;

        public SelectRingToRemoveAction(YinshGameLogic gameLogic, YinshTile tileWithRing) : base(gameLogic)
        {
            _tileWithRing = tileWithRing;
        }

        public override void Execute()
        {
            GameLogic.ActivateTile(_tileWithRing);
        }
    }
}