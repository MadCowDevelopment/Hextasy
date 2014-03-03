using System;
using System.ComponentModel.Composition;
using System.Linq;

using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(LightsOffGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LightsOffGameLogic : GameLogic<LightsOffSettings, LightsOffTile, LightsOffStatistics>
    {
        #region Fields

        private readonly Random _random = new Random((int)DateTime.Now.Ticks);

        private int _toggles;

        #endregion Fields

        #region Public Methods

        public void ToggleNeighbors(LightsOffTile item)
        {
            _toggles++;
            HexMap.GetNeighbours(item).ToList().ForEach(p => p.IsChecked = !p.IsChecked);
            if (HexMap.Tiles.All(p => !p.IsChecked))
            {
                RaiseFinished(new GameFinishedEventArgs<LightsOffStatistics>(new LightsOffStatistics(_toggles)));
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override LightsOffTile CreateTile(int column, int row)
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