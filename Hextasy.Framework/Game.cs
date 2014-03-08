using System.ComponentModel.Composition;

using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class Game<TSettingsViewModel, TGameViewModel, TGameResultViewModel, TGameLogic, TSettings, TTile, TStatistics> : IGame
        where TSettingsViewModel : SettingsViewModel<TSettings>
        where TGameViewModel : GameViewModel<TGameLogic, TSettings, TTile, TStatistics>
        where TGameResultViewModel : GameResultViewModel<TStatistics>
        where TGameLogic : GameLogic<TSettings, TTile, TStatistics>
        where TSettings : Settings
        where TTile : HexagonTile
        where TStatistics : GameStatistics
    {
        #region Fields

        private readonly ExportFactory<TGameResultViewModel> _gameResultViewModel;
        private readonly ExportFactory<TGameViewModel> _gameViewModel;
        private readonly ExportFactory<TSettingsViewModel> _settingsViewModel;

        #endregion Fields

        #region Constructors

        protected Game(
            ExportFactory<TSettingsViewModel> settingsViewModel,
            ExportFactory<TGameViewModel> gameViewModel,
            ExportFactory<TGameResultViewModel> gameResultViewModel)
        {
            _settingsViewModel = settingsViewModel;
            _gameViewModel = gameViewModel;
            _gameResultViewModel = gameResultViewModel;
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

        public IScreen ResultScreen
        {
            get { return GameResultViewModel; }
        }

        public IScreen SettingsScreen
        {
            get { return SettingsViewModel; }
        }

        #endregion Public Properties

        #region Private Properties

        private GameResultViewModel<TStatistics> GameResultViewModel
        {
            get; set;
        }

        private GameViewModel<TGameLogic, TSettings, TTile, TStatistics> GameViewModel
        {
            get; set;
        }

        private SettingsViewModel<TSettings> SettingsViewModel
        {
            get; set;
        }

        #endregion Private Properties

        #region Public Methods

        public void Initialize()
        {
            using (var export = _gameViewModel.CreateExport())
                GameViewModel = export.Value;

            using (var export = _settingsViewModel.CreateExport())
                SettingsViewModel = export.Value;

            using (var export = _gameResultViewModel.CreateExport())
                GameResultViewModel = export.Value;
        }

        public void Start()
        {
            GameViewModel.Initialize(SettingsViewModel.Settings);
        }

        #endregion Public Methods
    }
}