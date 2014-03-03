using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(XInARowGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class XInARowGameLogic : GameLogic<XInARowSettings, XInARowTile, XInARowStatistics>
    {
        public XInARowGameLogic()
        {
            Player1Active = true;
        }

        #region Public Properties

        public bool Player1Active
        {
            get; private set;
        }

        #endregion Public Properties

        #region Public Methods

        public void SelectTile(XInARowTile tile)
        {
            if (tile.Owner != Owner.None) return;

            tile.Owner = Player1Active ? Owner.Player1 : Owner.Player2;
            Player1Active = !Player1Active;
            CheckWinCondition(tile);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override XInARowTile CreateTile(int column, int row)
        {
            return new XInARowTile();
        }

        #endregion Protected Methods

        #region Private Methods

        private bool CheckLineForFourInARow(IEnumerable<XInARowTile> rows)
        {
            var previousOwner = Owner.None;
            var consecutiveTiles = 0;
            foreach (var hexTile in rows)
            {
                if (hexTile.Owner == previousOwner && hexTile.Owner != Owner.None)
                {
                    consecutiveTiles++;
                    if (consecutiveTiles == Settings.RequiredForWin) return true;
                }
                else
                {
                    previousOwner = hexTile.Owner;
                    consecutiveTiles = 1;
                }
            }

            return false;
        }

        private void CheckWinCondition(XInARowTile tile)
        {
            if (HexMap.Tiles.All(p => p.Owner != Owner.None))
                RaiseFinished(new GameFinishedEventArgs<XInARowStatistics>(new XInARowStatistics()));

            var lines = HexMap.GetLines(tile);
            foreach (var line in lines)
            {
                if (CheckLineForFourInARow(line))
                    RaiseFinished(new GameFinishedEventArgs<XInARowStatistics>(new XInARowStatistics()));
            }
        }

        #endregion Private Methods
    }
}