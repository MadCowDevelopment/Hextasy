using System.Collections.Generic;
using System.Linq;
using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    internal class SelectDiscsToRemoveGameState : GameState
    {
        public SelectDiscsToRemoveGameState(YinshGameLogic gameLogic, List<List<YinshTile>> allFives) : base(gameLogic)
        {
            if (allFives.Any(p => p[0].Disc.Color == GameLogic.CurrentPlayer.Color))
            {
                ActingPlayer = GameLogic.CurrentPlayer;
            }
            else
            {
                ActingPlayer = GameLogic.OpponentPlayer;
            }
        }

        public Player ActingPlayer { get; }

        public override string Message => $"{ActingPlayer.Color} must select discs to remove.";

        public override void Activate(YinshTile tile)
        {
            if (tile.Disc?.Color != ActingPlayer.Color) return;
            if (tile.Disc.IsSelected)
            {
                tile.Disc.IsSelected = false;
                return;
            }

            if (!DiscCanBeSelected(tile)) return;
            tile.Disc.IsSelected = true;

            if (!FiveConsecutiveDiscsAreSelected(tile)) return;

            GameLogic.YinshTiles.Where(p => p.Disc?.IsSelected == true).ForEach(p => p.Disc = null);
            if (ActingPlayer == GameLogic.OpponentPlayer)
                GameLogic.GameState = new SelectRingToRemoveGameState(GameLogic, ActingPlayer);
            else GameLogic.CheckForFiveInARow(tile);
        }

        private bool FiveConsecutiveDiscsAreSelected(YinshTile tile)
        {
            var selectedTiles = GameLogic.YinshTiles.Where(p => p.Disc?.IsSelected == true);
            if (selectedTiles.Count() != 5) return false;

            var line = GameLogic.HexMap.GetLines(tile)
                .FirstOrDefault(l => l.Count(t => t.Disc?.IsSelected == true) == 5);
            if (line == null) return false;

            int consecutiveDiscs = 0;
            var gapFound = false;
            foreach (var yinshTile in line)
            {
               if (yinshTile.Disc?.IsSelected == true)
                {
                    if (gapFound)
                    {
                        return false;
                    }

                    consecutiveDiscs++;
                }
                else if (consecutiveDiscs != 0)
                {
                    gapFound = true;
                }
            }

            return consecutiveDiscs == 5;
        }

        private bool DiscCanBeSelected(YinshTile tile)
        {
            var selectedTiles = GameLogic.YinshTiles.Where(p => p.Disc?.IsSelected == true);
            return selectedTiles.All(p => GameLogic.HexMap.TilesAreInSameLine(p, tile));
        }
    }
}