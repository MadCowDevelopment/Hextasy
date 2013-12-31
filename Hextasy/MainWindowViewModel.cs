using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy
{
    [Export(typeof(IMainWindowViewModel))]
    public class MainWindowViewModel : Screen, IMainWindowViewModel, 
        IHandle<GameSelected>,
        IHandle<ShowGameSelectionRequest>,
        IHandle<SettingsConfirmed>
    {
        private readonly IGameSelectionViewModel _gameSelectionViewModel;
        private readonly ISettingsShellViewModel _settingsShellViewModel;

        [ImportingConstructor]
        public MainWindowViewModel(
            IEventAggregator eventAggregator, 
            IGameSelectionViewModel gameSelectionViewModel,
            ISettingsShellViewModel settingsShellViewModel)
        {
            eventAggregator.Subscribe(this);
            _gameSelectionViewModel = gameSelectionViewModel;
            _settingsShellViewModel = settingsShellViewModel;
            MainContent = _gameSelectionViewModel;
        }

        public IScreen MainContent { get; private set; }

        public void Handle(ShowGameSelectionRequest message)
        {
            MainContent = _gameSelectionViewModel;
        }

        public void Handle(GameSelected message)
        {
            MainContent = _settingsShellViewModel;
        }

        public void Handle(SettingsConfirmed message)
        {
            MainContent = message.Game.GameScreen;
        }
    }
}
