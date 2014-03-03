using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy
{
    [Export(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : Screen,
        IHandle<GameSelected>,
        IHandle<ShowGameSelectionRequest>,
        IHandle<ShowGameResultRequest>,
        IHandle<SettingsConfirmed>
    {
        #region Fields

        private readonly GameSelectionViewModel _gameSelectionViewModel;
        private readonly SettingsShellViewModel _settingsShellViewModel;
        private readonly GameResultShellViewModel _gameResultShellViewModel;

        private IGame _currentGame;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public MainWindowViewModel(
            IEventAggregator eventAggregator,
            GameSelectionViewModel gameSelectionViewModel,
            SettingsShellViewModel settingsShellViewModel,
            GameResultShellViewModel gameResultShellViewModel)
        {
            eventAggregator.Subscribe(this);
            _gameSelectionViewModel = gameSelectionViewModel;
            _settingsShellViewModel = settingsShellViewModel;
            _gameResultShellViewModel = gameResultShellViewModel;
            MainContent = _gameSelectionViewModel;
        }

        #endregion Constructors

        #region Public Properties

        public IScreen MainContent
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Public Methods

        public void Handle(ShowGameSelectionRequest message)
        {
            MainContent = _gameSelectionViewModel;
        }

        public void Handle(GameSelected message)
        {
            _currentGame = message.Game;
            MainContent = _settingsShellViewModel;
        }

        public void Handle(SettingsConfirmed message)
        {
            MainContent = _currentGame.GameScreen;
        }

        public void Handle(ShowGameResultRequest message)
        {
            MainContent = _gameResultShellViewModel;
        }

        #endregion Public Methods
    }
}