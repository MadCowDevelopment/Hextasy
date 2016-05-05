using System.Collections.Generic;
using System.Linq;
using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    internal class MoveRingGameState : GameState
    {
        public MoveRingGameState(YinshGameLogic gameLogic) : base(gameLogic)
        {
        }

        public override string Message => $"{GameLogic.CurrentPlayer.Color} must move a ring.";

        public override void Activate(YinshTile tile)
        {
            if (tile.Ring != null && tile.Ring.Color == GameLogic.CurrentPlayer.Color)
            {
                SelectTile(tile);
            }
            else if (GameLogic.SelectedTile != null)
            {
                MoveRing(tile);
            }
        }

        private void MoveRing(YinshTile tile)
        {
            if (MovementIsValid(tile))
            {
                GameLogic.SelectedTile.Disc = new Disc(GameLogic.CurrentPlayer.Color);
                GameLogic.FlipDiscs(GameLogic.SelectedTile, tile);
                tile.Ring = GameLogic.SelectedTile.Ring;
                GameLogic.SelectedTile.Ring = null;
                GameLogic.SelectedTile = null;
                GameLogic.YinshTiles.ForEach(p => p.IsValidTarget = false);

                GameLogic.CheckForFiveInARow(tile);
            }
        }

        private void SelectTile(YinshTile tile)
        {
            GameLogic.SelectedTile = tile;
            tile.IsSelected = true;

            var validTargets = GameLogic.GetValidTargets(tile);
            GameLogic.YinshTiles.ForEach(p => p.IsValidTarget = validTargets.Contains(p));
        }

        private bool MovementIsValid(YinshTile tile)
        {
            var validTargets = GameLogic.GetValidTargets(GameLogic.SelectedTile);
            return validTargets.Contains(tile);
        }
    }
}