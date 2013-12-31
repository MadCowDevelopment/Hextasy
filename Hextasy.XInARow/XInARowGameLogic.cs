using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(XInARowGameLogic))]
    public class XInARowGameLogic : GameLogic<XInARowSettings, HexagonField>
    {
        #region Public Properties

        public bool Player1Active
        {
            get; private set;
        }

        #endregion Public Properties

        #region Public Methods

        public void SelectTile(HexagonField field)
        {
            if (field.Owner != Owner.None) return;

            field.Owner = Player1Active ? Owner.Player1 : Owner.Player2;
            Player1Active = !Player1Active;
            CheckWinCondition(field);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override HexagonField CreateField(int index)
        {
            return new HexagonField();
        }

        #endregion Protected Methods

        #region Private Methods

        private bool CheckLineForFourInARow(IEnumerable<HexagonField> rows)
        {
            var previousOwner = Owner.None;
            var consecutiveFields = 0;
            foreach (var hexField in rows)
            {
                if (hexField.Owner == previousOwner && hexField.Owner != Owner.None)
                {
                    consecutiveFields++;
                    if (consecutiveFields == Settings.RequiredForWin) return true;
                }
                else
                {
                    previousOwner = hexField.Owner;
                    consecutiveFields = 1;
                }
            }

            return false;
        }

        private void CheckWinCondition(HexagonField field)
        {
            if(HexMap.Tiles.All(p=>p.Owner != Owner.None)) RaiseFinished(new GameFinishedEventArgs());

            var lines = HexMap.GetLines(field);
            foreach (var line in lines)
            {
                if(CheckLineForFourInARow(line)) RaiseFinished(new GameFinishedEventArgs());
            }
        }

        #endregion Private Methods
    }
}