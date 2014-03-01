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

            Content = _settingsViewModel;
        }

        public Screen Content { get; set; }

        public void Start()
        {
            Content = _simulationViewModel;
            _simulationViewModel.Start(_settingsViewModel);
        }

        public void Back()
        {
            Content = _settingsViewModel;
        }
    }
}
