using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Hextasy.CardWarsSimulator
{
    [Export(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : Screen
    {
        private readonly SettingsViewModel _settingsViewModel;
        private readonly SimulationViewModel _simulationViewModel;

        [ImportingConstructor]
        public MainWindowViewModel(SettingsViewModel settingsViewModel, SimulationViewModel simulationViewModel)
        {
            _settingsViewModel = settingsViewModel;
            _simulationViewModel = simulationViewModel;

            Screen = _settingsViewModel;
        }

        public Screen Screen { get; set; }

        public void Start()
        {
            Screen = _simulationViewModel;
            _simulationViewModel.Start(_settingsViewModel);
        }

        public void Back()
        {
            Screen = _settingsViewModel;
        }
    }
}
