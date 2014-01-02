using System;
using System.ComponentModel.Composition;
using System.Linq;

using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(LightsOffGameLogic))]
    public class LightsOffGameLogic : GameLogic<LightsOffSettings, LightsOffTile>
    {
        #region Fields

        private readonly Random _random = new Random((int)DateTime.Now.Ticks);

        #endregion Fields

        #region Public Methods

        public void ToggleNeighbors(LightsOffTile item)
        {
            HexMap.GetNeighbours(item).ToList().ForEach(p => p.IsChecked = !p.IsChecked);
            if (HexMap.Tiles.All(p => !p.IsChecked))
            {
                RaiseFinished(new GameFinishedEventArgs());
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override LightsOffTile CreateTile(int index)
        {
            return new LightsOffTile();
        }

        protected override void OnSettingsInitialized()
        {
            Enumerable.Range(0, Settings.Toggles).ToList().ForEach(p =>
            {
                var randomTile = HexMap.Tiles[_random.Next(HexMap.Tiles.Count)];
                randomTile.IsChecked = !randomTile.IsChecked;
                ToggleNeighbors(randomTile);
            });
        }

        #endregion Protected Methods
    }
}