using System;
using System.ComponentModel.Composition;
using System.Linq;

using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(LightsOffGameLogic))]
    public class LightsOffGameLogic : GameLogic<LightsOffSettings, HexagonField>
    {
        #region Fields

        private readonly Random _random = new Random((int)DateTime.Now.Ticks);

        #endregion Fields

        #region Public Methods

        public void ToggleNeighbors(HexagonField item)
        {
            HexMap.GetNeighbours(item).ToList().ForEach(p => p.IsChecked = !p.IsChecked);
            if (HexMap.Tiles.All(p => !p.IsChecked))
            {
                RaiseFinished(new GameFinishedEventArgs());
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override HexagonField CreateField(int index)
        {
            return new HexagonField();
        }

        protected override void OnInitialize(LightsOffSettings settings)
        {
            Enumerable.Range(0, settings.Toggles).ToList().ForEach(p =>
            {
                var randomTile = HexMap.Tiles[_random.Next(HexMap.Tiles.Count)];
                randomTile.IsChecked = !randomTile.IsChecked;
                ToggleNeighbors(randomTile);
            });
        }

        #endregion Protected Methods
    }
}