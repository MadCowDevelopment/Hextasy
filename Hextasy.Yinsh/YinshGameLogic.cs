using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    [Export(typeof(YinshGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class YinshGameLogic : GameLogic<YinshSettings, YinshTile, YinshStatistics>
    {
        private Player _currentPlayer;
        private YinshTile _selectedTile;

        public YinshGameLogic()
        {
            GameState = new PlaceRingGameState(this);
        }

        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                if (_currentPlayer == value) return;
                if (_currentPlayer != null)
                {
                    _currentPlayer.IsActive = false;
                }

                _currentPlayer = value;
                _currentPlayer.IsActive = true;
            }
        }

        public Player Player2 { get; private set; }

        public Player Player1 { get; private set; }

        public Player OpponentPlayer => _currentPlayer == Player1 ? Player2 : Player1;

        public YinshTile SelectedTile
        {
            get
            {
                return _selectedTile;
            }
            set
            {
                if (_selectedTile == value) return;
                if (_selectedTile != null) _selectedTile.IsSelected = false;
                _selectedTile = value;
                if (_selectedTile != null) _selectedTile.IsSelected = true;
            }
        }

        public IEnumerable<YinshTile> YinshTiles { get { return Tiles.Where(p => p != null); } }

        protected override YinshTile CreateTile(int column, int row)
        {
            if (row == 0)
            {
                if (column > 2 && column < 8) return new YinshTile();
            }
            else if (row == 1 || row == 2 || row == 7)
            {
                if (column > 0 && column < 10) return new YinshTile();
            }
            else if (row == 8)
            {
                if (column > 1 && column < 9) return new YinshTile();
            }
            else if (row == 9)
            {
                if (column == 4 || column == 6) return new YinshTile();
            }
            else if (row > 2 && row < 7)
            {
                return new YinshTile();
            }

            return null;
        }

        protected override void OnSettingsInitialized()
        {
            base.OnSettingsInitialized();
            Player1 = Settings.Player1;
            Player2 = Settings.Player2;
            CurrentPlayer = Player1;
        }

        public void ActivateTile(YinshTile tile)
        {
            GameState.Activate(tile);
        }

        public GameState GameState { get; set; }

        public List<IEnumerable<YinshTile>> GetAllLines()
        {
            return YinshTiles.SelectMany(p => HexMap.GetLines(p)).Distinct(new LineEqualityComparer()).ToList();
        }

        public IEnumerable<YinshTile> GetValidTargets(YinshTile start)
        {
            var targets = new List<YinshTile>();
            var lines = HexMap.GetLines(start);
            foreach (var line in lines)
            {
                var currentLine = line.ToList();
                var indexOfStart = currentLine.IndexOf(start);
                if (indexOfStart > 0)
                {
                    var foundDisc = false;
                    for (var i = indexOfStart - 1; i >= 0; i--)
                    {
                        var tile = currentLine[i];
                        if (tile.Ring != null)
                        {
                            break;
                        }

                        if (tile.Disc == null)
                        {
                            targets.Add(tile);
                            if (foundDisc)
                            {
                                break;
                            }
                        }
                        else
                        {
                            foundDisc = true;
                        }
                    }
                }

                if (indexOfStart < currentLine.Count)
                {
                    var foundDisc = false;
                    for (var i = indexOfStart + 1; i < currentLine.Count; i++)
                    {
                        var tile = currentLine[i];
                        if (tile.Ring != null)
                        {
                            break;
                        }

                        if (tile.Disc == null)
                        {
                            targets.Add(tile);
                            if (foundDisc)
                            {
                                break;
                            }
                        }
                        else
                        {
                            foundDisc = true;
                        }
                    }
                }
            }

            return targets;
        }

        public bool GameOver()
        {
            var winner = CurrentPlayer.Score == 3 ? CurrentPlayer : (OpponentPlayer.Score == 3 ? OpponentPlayer : null);
            if (winner != null)
                RaiseFinished(new GameFinishedEventArgs<YinshStatistics>(new YinshStatistics(winner)));

            return winner != null;
        }

        public void FlipDiscs(YinshTile selectedTile, YinshTile tile)
        {
            HexMap.GetTilesBetween(selectedTile, tile).Where(p => p.Disc != null).ForEach(p => p.Disc.Flip());
        }

        public void CheckForFiveInARow(YinshTile tile)
        {
            var allFives = GetAllFiveInARow();
            if (!allFives.Any())
            {
                CurrentPlayer = OpponentPlayer;
                GameState = new MoveRingGameState(this);
                return;
            }

            var currentPlayerHasFiveInARow = allFives.Any(p => p[0].Disc.Color == CurrentPlayer.Color);
            if (currentPlayerHasFiveInARow)
            {
                RemoveRing(tile);
                if (GameOver()) return;
            }

            if (allFives.Count == 1 && allFives[0].Count == 5)
            {
                allFives[0].ForEach(p => p.Disc = null);

                if (currentPlayerHasFiveInARow)
                {
                    CheckForFiveInARow(tile);
                }
                else
                {
                    GameState = new SelectRingToRemoveGameState(this, OpponentPlayer);
                }
            }
            else
            {
                GameState = new SelectDiscsToRemoveGameState(this, allFives);
            }
        }

        private List<List<YinshTile>> GetAllFiveInARow()
        {
            var result = new List<List<YinshTile>>();
            var allLines = GetAllLines();

            foreach (var line in allLines)
            {
                var candidates = new List<YinshTile>();
                var currentColor = PlayerColor.Black;
                foreach (var tile in line)
                {
                    if (tile.Disc != null)
                    {
                        if (tile.Disc.Color != currentColor)
                        {
                            if (candidates.Count >= 5)
                            {
                                result.Add(candidates.ToList());
                            }

                            candidates.Clear();
                            currentColor = tile.Disc.Color;
                        }

                        candidates.Add(tile);
                    }
                    else
                    {
                        if (candidates.Count >= 5)
                        {
                            result.Add(candidates.ToList());
                        }

                        candidates.Clear();
                    }
                }

                if (candidates.Count >= 5) result.Add(candidates.ToList());
            }

            return result;
        }

        public void RemoveRing(YinshTile tile)
        {
            if (tile.Ring == null) return;
            var color = tile.Ring.Color;
            tile.Ring = null;
            if (CurrentPlayer.Color == color) CurrentPlayer.Score++;
            else OpponentPlayer.Score++;
        }
    }
}