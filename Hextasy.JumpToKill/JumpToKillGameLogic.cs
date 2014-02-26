using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    [Export(typeof(JumpToKillGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class JumpToKillGameLogic : GameLogic<JumpToKillSettings, JumpToKillTile>
    {
        #region Fields

        private bool _player1Active = true;
        private bool _killedOpponent;

        #endregion Fields

        #region Public Methods

        public IEnumerable<JumpToKillTile> GetLegalMoves(JumpToKillTile tile)
        {
            if (!TileCanBeSelectedByCurrentPlayer(tile) && !_killedOpponent) return Enumerable.Empty<JumpToKillTile>();

            var result = new List<JumpToKillTile>();
            var distance = tile.HasBeenMoved ? 1 : 2;
            var neighbours = HexMap.GetNeighbours(tile, distance).ToList();
            result.AddRange(neighbours.Where(p => p.Owner == Owner.None));

            var occupiedNeighbours = HexMap.GetNeighbours(tile).Where(p => p.Owner == Owner.Player1 || p.Owner == Owner.Player2);
            result.AddRange(
                occupiedNeighbours.Select(opponentTile => HexMap.GetNextInLine(tile, opponentTile))
                    .Where(nextInLine => nextInLine != null && nextInLine.Owner == Owner.None));

            return result.Distinct().ToList();
        }

        public void SelectTile(JumpToKillTile tile)
        {
            var previousTile = Tiles.SingleOrDefault(p => p.IsSelected);
            if (TileCanBeSelectedByCurrentPlayer(tile))
            {
                if (previousTile == tile) return;
                if (previousTile != null) previousTile.IsSelected = false;
                tile.IsSelected = true;
                Tiles.Apply(p => p.IsLegalMoveTarget = false);
                GetLegalMoves(tile).Apply(p => p.IsLegalMoveTarget = true);
                return;
            }

            if (previousTile == null) return;
            if (IsLegalMove(previousTile, tile))
            {
                MoveTile(previousTile, tile);
                if (KillOpponent(tile, previousTile))
                {
                    _killedOpponent = true;
                    GetLegalMoves(tile).Apply(p => p.IsLegalMoveTarget = true);
                }
                else
                {
                    _player1Active = !_player1Active;
                    _killedOpponent = false;
                    tile.IsSelected = false;
                }

                CheckWinCondition();
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override JumpToKillTile CreateTile(int column, int row)
        {
            return new JumpToKillTile();
        }

        protected override void OnSettingsInitialized()
        {
            for (var i = 0; i < Settings.Columns * 2; i++)
            {
                HexMap.Tiles[i].Owner = Owner.Player2;
            }

            for (var i = Settings.Columns * (Settings.Rows - 2); i < Settings.Columns * Settings.Rows; i++)
            {
                HexMap.Tiles[i].Owner = Owner.Player1;
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private void CheckWinCondition()
        {
            if (Tiles.All(p => p.Owner != Owner.Player1))
                RaiseFinished(new GameFinishedEventArgs());

            if (Tiles.All(p => p.Owner != Owner.Player2))
                RaiseFinished(new GameFinishedEventArgs());
        }

        private bool IsLegalMove(JumpToKillTile previousTile, JumpToKillTile tile)
        {
            return GetLegalMoves(previousTile).Contains(tile);
        }

        private bool KillOpponent(JumpToKillTile tile, JumpToKillTile previousTile)
        {
            var tilesBetween = HexMap.GetTilesBetween(previousTile, tile).ToList();
            var opponent = _player1Active ? Owner.Player2 : Owner.Player1;
            if (tilesBetween.Any(p => p.Owner == opponent))
            {
                tilesBetween.Apply(p => p.Owner = Owner.None);
                return true;
            }

            return false;
        }

        private void MoveTile(JumpToKillTile previousTile, JumpToKillTile tile)
        {
            tile.Owner = previousTile.Owner;
            previousTile.Owner = Owner.None;
            previousTile.HasBeenMoved = true;
            previousTile.IsSelected = false;
            tile.HasBeenMoved = true;
            tile.IsSelected = true;
            Tiles.Apply(p => p.IsLegalMoveTarget = false);
        }

        private bool TileCanBeSelectedByCurrentPlayer(JumpToKillTile tile)
        {
            return (_player1Active && tile.Owner == Owner.Player1 ||
                    !_player1Active && tile.Owner == Owner.Player2) &&
                   _killedOpponent == false;
        }

        #endregion Private Methods
    }
}