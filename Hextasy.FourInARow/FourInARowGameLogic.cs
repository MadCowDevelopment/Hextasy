using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Hextasy.Framework;

namespace Hextasy.FourInARow
{
    [Export(typeof(FourInARowGameLogic))]
    public class FourInARowGameLogic : GameLogic
    {
        private bool _player1Active = true;

        public void Initialize(int rows, int columns)
        {
            var items = CreateFields(rows * columns);
            HexMap = new HexMap<HexagonField>(items, columns);
        }

        private HexMap<HexagonField> HexMap { get; set; }
        
        private static IEnumerable<HexagonField> CreateFields(int numberOfFields)
        {
            var result = new List<HexagonField>();
            for (int i = 0; i < numberOfFields; i++)
            {
                result.Add(new HexagonField());
            }

            return result;
        }

        public IEnumerable<HexagonField> GetFields()
        {
            return HexMap.Tiles;
        }

        public bool SelectTile(HexagonField field)
        {
            if (field.Owner != Owner.None) return false;

            field.Owner = _player1Active ? Owner.Player1 : Owner.Player2;
            _player1Active = !_player1Active;
            CheckWinCondition(field);
            return true;
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

        private bool CheckLineForFourInARow(IEnumerable<HexagonField> fields)
        {
            var previousOwner = Owner.None;
            int consecutiveFields = 0;
            foreach (var hexField in fields)
            {
                if (hexField.Owner == previousOwner && hexField.Owner != Owner.None)
                {
                    consecutiveFields++;
                    if (consecutiveFields == 4) return true;
                }
                else
                {
                    previousOwner = hexField.Owner;
                    consecutiveFields = 1;
                }
            }

            return false;
        }
    }
}