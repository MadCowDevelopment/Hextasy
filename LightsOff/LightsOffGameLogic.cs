using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(LightsOffGameLogic))]
    public class LightsOffGameLogic : GameLogic
    {
        private readonly Random _random = new Random((int)DateTime.Now.Ticks);


        public void Initialize(int rows, int columns, int toggles)
        {
            var items = CreateFields(rows*columns);
            HexMap = new HexMap<HexagonField>(items, columns);
            Enumerable.Range(0, toggles).ToList().ForEach(p =>
            {
                var randomTile = HexMap.Tiles[_random.Next(HexMap.Tiles.Count)];
                randomTile.IsChecked = !randomTile.IsChecked;
                ToggleNeighbors(randomTile);
            });
        }

        public void ToggleNeighbors(HexagonField item)
        {
            HexMap.GetNeighbours(item).ToList().ForEach(p => p.IsChecked = !p.IsChecked);
            if (HexMap.Tiles.All(p => !p.IsChecked))
            {
                RaiseFinished(new GameFinishedEventArgs());
            }
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
    }
}
