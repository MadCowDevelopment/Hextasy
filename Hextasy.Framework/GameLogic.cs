using System;
using System.Collections.Generic;
using System.Linq;

using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class GameLogic<TSettings, TTile> : PropertyChangedBase
        where TSettings : Settings
        where TTile : HexagonTile
    {
        #region Events

        public event EventHandler<GameFinishedEventArgs> Finished;

        #endregion Events

        #region Protected Properties

        public HexMap<TTile> HexMap
        {
            get; private set;
        }

        protected TSettings Settings
        {
            get; private set;
        }

        #endregion Protected Properties

        #region Public Methods

        public IEnumerable<TTile> Tiles
        {
            get { return HexMap != null ? HexMap.Tiles : Enumerable.Empty<TTile>(); }
        }

        protected IEnumerable<TTile> NotNullTiles
        {
            get { return Tiles.Where(p => p != null); }
        }

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

        protected void RaiseFinished(GameFinishedEventArgs args)
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