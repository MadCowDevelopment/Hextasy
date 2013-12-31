using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.Framework;

namespace Hextasy
{
    [Export(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : Screen, IHandle<GameSelected>, IHandle<ShowGameSelectionRequest>, IHandle<SettingsConfirmed>
    {
        #region Fields

        private readonly GameSelectionViewModel _gameSelectionViewModel;
        private readonly SettingsShellViewModel _settingsShellViewModel;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public MainWindowViewModel(
            IEventAggregator eventAggregator,
            GameSelectionViewModel gameSelectionViewModel,
            SettingsShellViewModel settingsShellViewModel)
        {
            eventAggregator.Subscribe(this);
            _gameSelectionViewModel = gameSelectionViewModel;
            _settingsShellViewModel = settingsShellViewModel;
            MainContent = _gameSelectionViewModel;
        }

        #endregion Constructors

        #region Public Properties

        public IScreen MainContent
        {
            get; private set;
        }

        #endregion Public Properties

        #region Public Methods

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

        #endregion Public Methods
    }
}