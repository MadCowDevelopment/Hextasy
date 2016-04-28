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
            IsRingPlacementPhase = true;
        }

        public bool IsRingPlacementPhase { get; private set; }

        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            private set
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
            if (IsRingPlacementPhase)
            {
                PlaceRing(tile);
            }
            else
            {
                if (tile.Ring != null && tile.Ring.Color == CurrentPlayer.Color)
                {
                    SelectTile(tile);
                }
                else if (SelectedTile != null)
                {
                    MoveRing(tile);
                }
            }
        }

        private void MoveRing(YinshTile tile)
        {
            if (MovementIsValid(tile))
            {
                SelectedTile.Disc = new Disc(CurrentPlayer.Color);
                HexMap.GetTilesBetween(SelectedTile, tile).Where(p => p.Disc != null).ForEach(p => p.Disc.Flip());
                tile.Ring = SelectedTile.Ring;
                SelectedTile.Ring = null;
                SelectedTile = null;

                CheckForFiveInARow();
                

                CurrentPlayer = OpponentPlayer;
            }
        }

        private void CheckForFiveInARow()
        {
            // TODO: Check for any 5 in a row
        }

        private bool MovementIsValid(YinshTile tile)
        {
            var start = SelectedTile;
            var end = tile;

            if (end.Ring != null) return false;
            if (end.Disc != null) return false;
            if (!HexMap.TilesAreInSameLine(start, end)) return false;
            var tiles = HexMap.GetTilesBetween(start, end);

            var foundDisc = false;
            foreach (var yinshTile in tiles)
            {
                if (yinshTile.Disc != null)
                {
                    if (foundDisc) return false;
                    foundDisc = true;
                }
            }

            return true;
        }

        private void SelectTile(YinshTile tile)
        {
            SelectedTile = tile;
            tile.IsSelected = true;
        }

        private void PlaceRing(YinshTile tile)
        {
            if (tile.Ring != null) return;
            tile.Ring = new Ring(CurrentPlayer.Color);
            CurrentPlayer.UnplacedRings--;
            CurrentPlayer = OpponentPlayer;
            if (CurrentPlayer.UnplacedRings == 0) IsRingPlacementPhase = false;
        }
    }
}