using System;
using System.ComponentModel.Composition;
using System.Runtime.InteropServices;
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

        private readonly ExportFactory<TGameViewModel> _gameViewModel;
        private readonly ExportFactory<TSettingsViewModel> _settingsViewModel;

        #endregion Fields

        #region Constructors

        protected Game(ExportFactory<TSettingsViewModel> settingsViewModel, ExportFactory<TGameViewModel> gameViewModel)
        {
            _settingsViewModel = settingsViewModel;
            _gameViewModel = gameViewModel;
        }

        #endregion Constructors

        #region Public Properties

        public abstract string Name
        {
            get;
        }

        public IScreen GameScreen
        {
            get { return GameViewModel; }
        }

        public IScreen SettingsScreen
        {
            get { return SettingsViewModel; }
        }

        #endregion Public Properties

        #region Private Properties

        private GameViewModel<TGameLogic, TSettings, TTile> GameViewModel { get; set; }

        private SettingsViewModel<TSettings> SettingsViewModel { get; set; }

        #endregion Private Properties

        #region Public Methods

        public void Initialize()
        {
            using (var export = _gameViewModel.CreateExport())
                GameViewModel = export.Value;

            using (var export = _settingsViewModel.CreateExport())
                SettingsViewModel = export.Value;
        }

        public void Start()
        {
            GameViewModel.Initialize(SettingsViewModel.Settings);
        }

        #endregion Public Methods
    }
}