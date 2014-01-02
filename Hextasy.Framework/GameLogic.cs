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

        protected HexMap<TTile> HexMap
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

        public void Initialize(TSettings settings)
        {
            Settings = settings;
            var items = CreateTiles(settings.Rows * settings.Columns);
            HexMap = new HexMap<TTile>(items, settings.Columns);
            OnSettingsInitialized();
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract TTile CreateTile(int index);

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

        private IEnumerable<TTile> CreateTiles(int numberOfTiles)
        {
            var result = new List<TTile>();
            for (var i = 0; i < numberOfTiles; i++)
            {
                result.Add(CreateTile(i));
            }

            return result;
        }

        #endregion Private Methods
    }
}