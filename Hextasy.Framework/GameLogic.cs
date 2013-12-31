using System;
using System.Collections.Generic;
using System.Linq;

using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class GameLogic<TSettings, TField> : PropertyChangedBase
        where TSettings : Settings
        where TField : class
    {
        #region Events

        public event EventHandler<GameFinishedEventArgs> Finished;

        #endregion Events

        #region Protected Properties

        protected HexMap<TField> HexMap
        {
            get; private set;
        }

        protected TSettings Settings
        {
            get; private set;
        }

        #endregion Protected Properties

        #region Public Methods

        public IEnumerable<TField> Fields
        {
            get { return HexMap != null ? HexMap.Tiles : Enumerable.Empty<TField>(); }
        }

        public void Initialize(TSettings settings)
        {
            Settings = settings;
            var items = CreateFields(settings.Rows * settings.Columns);
            HexMap = new HexMap<TField>(items, settings.Columns);
            OnInitialize(settings);
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract TField CreateField(int index);

        protected virtual void OnInitialize(TSettings settings)
        {
        }

        protected void RaiseFinished(GameFinishedEventArgs args)
        {
            var handler = Finished;
            if (handler != null) handler(this, args);
        }

        #endregion Protected Methods

        #region Private Methods

        private IEnumerable<TField> CreateFields(int numberOfFields)
        {
            var result = new List<TField>();
            for (var i = 0; i < numberOfFields; i++)
            {
                result.Add(CreateField(i));
            }

            return result;
        }

        #endregion Private Methods
    }
}