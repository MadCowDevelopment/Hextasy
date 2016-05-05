namespace Hextasy.Yinsh
{
    internal class PlaceRingGameState : GameState
    {
        public PlaceRingGameState(YinshGameLogic gameLogic) : base(gameLogic)
        {
        }

        public override string Message => $"{GameLogic.CurrentPlayer.Color} must place a ring.";
        public override void Activate(YinshTile tile)
        {
            if (tile.Ring != null) return;
            tile.Ring = new Ring(GameLogic.CurrentPlayer.Color);
            GameLogic.CurrentPlayer.UnplacedRings--;
            GameLogic.CurrentPlayer = GameLogic.OpponentPlayer;
            if (GameLogic.CurrentPlayer.UnplacedRings == 0)
            {
                GameLogic.GameState = new MoveRingGameState(GameLogic);
            }
            else
            {
                GameLogic.GameState = new PlaceRingGameState(GameLogic);
            }
        }
    }
}