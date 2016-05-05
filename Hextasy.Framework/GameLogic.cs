using System;
using System.Collections.Generic;
using System.Linq;

namespace Hextasy.Framework
{
    public abstract class GameLogic<TSettings, TTile, TStatistics> : ObservableObject
        where TSettings : Settings
        where TTile : HexagonTile
        where TStatistics : GameStatistics
    {
        #region Events

        public event EventHandler<GameFinishedEventArgs<TStatistics>> Finished;

        #endregion Events

        #region Public Properties

        public IEnumerable<TTile> Tiles
        {
            get { return HexMap != null ? HexMap.Tiles : Enumerable.Empty<TTile>(); }
        }

        #endregion Public Properties

        #region Protected Properties

        public HexMap<TTile> HexMap
        {
            get;
            protected set;
        }

        protected IEnumerable<TTile> NotNullTiles
        {
            get { return Tiles.Where(p => p != null); }
        }

        protected TSettings Settings
        {
            get;
            set;
        }

        #endregion Protected Properties

        #region Public Methods

        public void Initialize(TSettings settings)
        {
            Settings = settings;
            var items = CreateTiles(settings.Columns, settings.Rows);
            HexMap = new HexMap<TTile>(items, settings.Columns);
            OnSettingsInitialized();
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract TTile CreateTile(int column, int row);

        protected virtual void OnSettingsInitialized()
        {
        }

        protected void RaiseFinished(GameFinishedEventArgs<TStatistics> args)
        {
            var handler = Finished;
            if (handler != null) handler(this, args);
        }

        #endregion Protected Methods

        #region Private Methods

        private IEnumerable<TTile> CreateTiles(int columns, int rows)
        {
            var result = new List<TTile>();
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    result.Add(CreateTile(x, y));
                }
            }

            return result;
        }

        #endregion Private Methods
    }
}