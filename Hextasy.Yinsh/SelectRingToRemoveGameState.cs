namespace Hextasy.Yinsh
{
    internal class SelectRingToRemoveGameState : GameState
    {
        private Player Player { get; }

        public SelectRingToRemoveGameState(YinshGameLogic gameLogic, Player player) : base(gameLogic)
        {
            Player = player;
        }

        public override string Message => $"{Player.Color} must select a ring to remove.";
        public override void Activate(YinshTile tile)
        {
            if (tile.Ring?.Color != Player.Color) return;
            GameLogic.RemoveRing(tile);
            GameLogic.CheckForFiveInARow(tile);
        }

        public override GameState DeepCopy(YinshGameLogic gameLogic)
        {
            var copy = new SelectRingToRemoveGameState(gameLogic,
                gameLogic.Player1.Color == Player.Color ? gameLogic.Player1 : gameLogic.Player2);
            return copy;
        }
    }
}