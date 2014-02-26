using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy.Halma
{
    [Export(typeof(HalmaGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HalmaGameLogic : GameLogic<HalmaSettings, HalmaTile>
    {
        #region Fields

        private bool _jumpedOverPlayerTile;
        private bool _player1Active = true;
        private bool _playerMoved;
        private bool _selectedSameTileAgain;

        #endregion Fields

        #region Public Methods

        public IEnumerable<HalmaTile> GetLegalMoves(HalmaTile tile, HalmaTile previousTile = null)
        {
            if (!TileCanBeSelectedByCurrentPlayer(tile) || (_playerMoved && !_jumpedOverPlayerTile))
                return Enumerable.Empty<HalmaTile>();

            var result = new List<HalmaTile>();

            if (!_jumpedOverPlayerTile)
            {
                var neighbours = HexMap.GetNeighbours(tile).ToList();
                result.AddRange(neighbours.Where(p => p.Owner == Owner.None));
            }

            var occupiedNeighbours = HexMap.GetNeighbours(tile).Where(p => p.Owner == Owner.Player1 || p.Owner == Owner.Player2);
            result.AddRange(
                occupiedNeighbours.Select(opponentTile => HexMap.GetNextInLine(tile, opponentTile))
                    .Where(nextInLine => nextInLine != null && nextInLine.Owner == Owner.None));

            if (previousTile != null) result.Remove(previousTile);
            if (_jumpedOverPlayerTile && result.Count > 0) result.Add(tile);
            return result.Distinct().ToList();
        }

        public void SelectTile(HalmaTile tile)
        {
            var previousTile = NotNullTiles.SingleOrDefault(p => p.IsSelected);
            if (TileCanBeSelectedByCurrentPlayer(tile) && !_jumpedOverPlayerTile)
            {
                SelectTile(tile, previousTile);
            }
            else if (IsLegalMove(previousTile, tile))
            {
                MoveTile(previousTile, tile);
                CheckWinCondition();
                if (ThereAreNoLegalMoves(tile, previousTile) || _selectedSameTileAgain) ChangePlayer(tile);
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override HalmaTile CreateTile(int column, int row)
        {
            if (TileShouldBeCreated(column, row))
            {
                var owner = CalculateTileOwner(column);
                return new HalmaTile { Owner = owner };
            }

            return null;
        }

        #endregion Protected Methods

        #region Private Methods

        private Owner CalculateTileOwner(int column)
        {
            if (column < 5)
            {
                return Owner.Player1;
            }

            if (column > 11)
            {
                return Owner.Player2;
            }

            return Owner.None;
        }

        private void ChangePlayer(HalmaTile tile)
        {
            _player1Active = !_player1Active;
            _jumpedOverPlayerTile = false;
            _playerMoved = false;
            tile.IsSelected = false;
            _selectedSameTileAgain = false;
        }

        private void CheckWinCondition()
        {
            if (NotNullTiles.Where(p => p.Owner == Owner.Player1).All(p => HexMap.GetCoordinateByItem(p).X > 11))
                RaiseFinished(new GameFinishedEventArgs());

            if (NotNullTiles.Where(p => p.Owner == Owner.Player2).All(p => HexMap.GetCoordinateByItem(p).X < 5))
                RaiseFinished(new GameFinishedEventArgs());
        }

        private bool IsLegalMove(HalmaTile previousTile, HalmaTile tile)
        {
            return previousTile != null && GetLegalMoves(previousTile).Contains(tile);
        }

        private void MoveTile(HalmaTile previousTile, HalmaTile tile)
        {
            tile.Owner = previousTile.Owner;
            if (tile != previousTile) previousTile.Owner = Owner.None;
            else _selectedSameTileAgain = true;
            previousTile.IsSelected = false;
            tile.IsSelected = true;
            _playerMoved = true;
            NotNullTiles.Apply(p => p.IsLegalMoveTarget = false);

            if (PlayerTileIsBetween(tile, previousTile))
            {
                _jumpedOverPlayerTile = true;
                GetLegalMoves(tile, previousTile).Apply(p => p.IsLegalMoveTarget = true);
            }
        }

        private bool PlayerTileIsBetween(HalmaTile tile, HalmaTile previousTile)
        {
            var tilesBetween = HexMap.GetTilesBetween(previousTile, tile).ToList();
            return tilesBetween.Any(p => p.Owner == Owner.Player1 || p.Owner == Owner.Player2);
        }

        private void SelectTile(HalmaTile tile, HalmaTile previouslySelectedTile)
        {
            if (previouslySelectedTile == tile) return;
            if (previouslySelectedTile != null) previouslySelectedTile.IsSelected = false;
            tile.IsSelected = true;
            NotNullTiles.Apply(p => p.IsLegalMoveTarget = false);
            GetLegalMoves(tile).Apply(p => p.IsLegalMoveTarget = true);
        }

        private bool ThereAreNoLegalMoves(HalmaTile tile, HalmaTile previousTile)
        {
            return !GetLegalMoves(tile, previousTile).Any();
        }

        private bool TileCanBeSelectedByCurrentPlayer(HalmaTile tile)
        {
            return (_player1Active && tile.Owner == Owner.Player1 ||
                    !_player1Active && tile.Owner == Owner.Player2);
        }

        private bool TileShouldBeCreated(int column, int row)
        {
            if (row < 4)
            {
                var amountOfTiles = (row * 4) + 3;
                var minX = (17 - amountOfTiles) / 2;
                var maxX = 17 - minX - 1;
                if (column >= minX && column <= maxX) return true;
            }
            else if (row == 4)
            {
                return true;
            }
            else
            {
                var amountOfTiles = (Math.Abs(row - 8) * 4) + 1;
                var minX = (17 - amountOfTiles) / 2;
                var maxX = 17 - minX - 1;
                if (column >= minX && column <= maxX) return true;
            }

            return false;
        }

        #endregion Private Methods
    }
}