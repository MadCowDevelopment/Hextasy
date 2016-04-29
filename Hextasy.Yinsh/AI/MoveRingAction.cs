namespace Hextasy.Yinsh.AI
{
    internal class MoveRingAction : PlayerAction
    {
        private readonly YinshTile _start;
        private readonly YinshTile _end;

        public MoveRingAction(YinshGameLogic gameLogic, YinshTile start, YinshTile end) : base(gameLogic)
        {
            _start = start;
            _end = end;
        }

        public override void Execute()
        {
            GameLogic.ActivateTile(_start);
            GameLogic.ActivateTile(_end);
        }
    }
}