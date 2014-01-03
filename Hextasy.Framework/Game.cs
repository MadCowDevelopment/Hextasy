﻿using System;

using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class Game<TSettingsViewModel, TGameViewModel, TGameLogic, TSettings, TTile> : IGame
        where TSettingsViewModel : SettingsViewModel<TSettings>
        where TGameViewModel : GameViewModel<TGameLogic, TSettings, TTile>
        where TGameLogic : GameLogic<TSettings, TTile>
        where TSettings : Settings
        where TTile : HexagonTile
    {
        #region Fields

        private readonly Lazy<TGameViewModel> _gameViewModel;
        private readonly Lazy<TSettingsViewModel> _settingsViewModel;

        #endregion Fields

        #region Constructors

        protected Game(Lazy<TSettingsViewModel> settingsViewModel, Lazy<TGameViewModel> gameViewModel)
        {
            _settingsViewModel = settingsViewModel;
            _gameViewModel = gameViewModel;
        }

        #endregion Constructors

        #region Public Properties

        public IScreen GameScreen
        {
            get { return GameViewModel; }
        }

        public abstract string Name
        {
            get;
        }

        public IScreen SettingsScreen
        {
            get { return SettingsViewModel; }
        }

        #endregion Public Properties

        #region Private Properties

        private GameViewModel<TGameLogic, TSettings, TTile> GameViewModel
        {
            get { return _gameViewModel.Value; }
        }

        private SettingsViewModel<TSettings> SettingsViewModel
        {
            get { return _settingsViewModel.Value; }
        }

        #endregion Private Properties

        #region Public Methods

        public void Start()
        {
            GameViewModel.Initialize(SettingsViewModel.Settings);
        }

        #endregion Public Methods
    }
}