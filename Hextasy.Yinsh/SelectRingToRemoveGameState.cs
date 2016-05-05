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
    }
}