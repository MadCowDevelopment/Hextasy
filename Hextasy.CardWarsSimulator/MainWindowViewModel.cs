using System.ComponentModel.Composition;

using Caliburn.Micro;

namespace Hextasy.CardWarsSimulator
{
    [Export(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : Screen
    {
        #region Fields

        private readonly SettingsViewModel _settingsViewModel;
        private readonly SimulationViewModel _simulationViewModel;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public MainWindowViewModel(SettingsViewModel settingsViewModel, SimulationViewModel simulationViewModel)
        {
            _settingsViewModel = settingsViewModel;
            _simulationViewModel = simulationViewModel;

            Screen = _settingsViewModel;
        }

        #endregion Constructors

        #region Public Properties

        public Screen Screen
        {
            get; set;
        }

        #endregion Public Properties

        #region Public Methods

        public void Back()
        {
            Screen = _settingsViewModel;
        }

        public void Start()
        {
            Screen = _simulationViewModel;
            _simulationViewModel.Start(_settingsViewModel);
        }

        #endregion Public Methods
    }
}