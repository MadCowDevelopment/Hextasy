namespace Hextasy.Yinsh.AI
{
    internal class PlaceRingAction : PlayerAction
    {
        private readonly YinshTile _tile;

        public PlaceRingAction(YinshGameLogic gameLogic, YinshTile tile) : base(gameLogic)
        {
            _tile = tile;
        }

        public override void Execute()
        {
            GameLogic.ActivateTile(_tile);
        }
    }
}