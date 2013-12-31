using System;
using Caliburn.Micro;

namespace Hextasy.Framework
{
    public abstract class Game<TSettingsViewModel, TGameViewModel, TSettings> : IGame<TSettings>
        where TSettingsViewModel : ISettingsViewModel<TSettings>
        where TGameViewModel : IGameViewModel<TSettings>
        where TSettings : Settings
    {
        private readonly Lazy<TSettingsViewModel> _settingsViewModel;
        private readonly Lazy<TGameViewModel> _gameViewModel;

        protected Game(Lazy<TSettingsViewModel> settingsViewModel, Lazy<TGameViewModel> gameViewModel)
        {
            _settingsViewModel = settingsViewModel;
            _gameViewModel = gameViewModel;
        }

        public abstract string Name { get; }
        public IGameViewModel<TSettings> GameViewModel { get { return _gameViewModel.Value; } }
        public ISettingsViewModel<TSettings> SettingsViewModel { get { return _settingsViewModel.Value; } }

        public void Start()
        {
            GameViewModel.Initialize(SettingsViewModel.Settings);
        }

        public IScreen GameScreen { get { return GameViewModel; } }
        public IScreen SettingsScreen { get { return SettingsViewModel; } }
    }
}
