using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(IGame))]
    public class LightsOffGame : IGame
    {
        private readonly Lazy<ILightsOffSettingsViewModel> _lightsOffSettingsViewModel;
        private readonly Lazy<ILightsOffViewModel> _lightsOffViewModel;

        public IScreen GameScreen { get { return _lightsOffViewModel.Value; } }

        public IScreen SettingsScreen { get { return _lightsOffSettingsViewModel.Value; } }

        public void Start()
        {
            _lightsOffViewModel.Value.Initialize(_lightsOffSettingsViewModel.Value.Settings);
        }

        [ImportingConstructor]
        public LightsOffGame(
            Lazy<ILightsOffSettingsViewModel> lightsOffSettingsViewModel,
            Lazy<ILightsOffViewModel> lightsOffViewModel)
        {
            _lightsOffSettingsViewModel = lightsOffSettingsViewModel;
            _lightsOffViewModel = lightsOffViewModel;
        }

        public string Name { get { return "Lights off!"; } }
    }
}
