using System.Collections.Generic;

using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class GameViewModel<TGameLogic, TSettings, TField> : Screen
        where TGameLogic : GameLogic<TSettings, TField>
        where TSettings : Settings
        where TField : class
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;

        #endregion Fields

        #region Constructors

        protected GameViewModel(TGameLogic game, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Game = game;
            Game.Finished += GameFinished;
        }

        #endregion Constructors

        #region Public Properties

        public int Columns
        {
            get { return Settings.Columns; }
        }

        public IEnumerable<TField> Fields
        {
            get { return Game.Fields; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected TGameLogic Game
        {
            get; private set;
        }

        protected TSettings Settings
        {
            get; private set;
        }

        #endregion Protected Properties

        #region Public Methods

        public void Initialize(TSettings settings)
        {
            Settings = settings;
            Game.Initialize(Settings);
            NotifyOfPropertyChange(() => Fields);
            OnSettingsInitialized();
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void OnSettingsInitialized()
        {
        }

        #endregion Protected Methods

        #region Private Methods

        private void GameFinished(object sender, GameFinishedEventArgs e)
        {
            _eventAggregator.Publish(new ShowGameSelectionRequest());
        }

        #endregion Private Methods
    }
}