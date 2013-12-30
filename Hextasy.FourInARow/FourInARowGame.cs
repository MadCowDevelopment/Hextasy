using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.FourInARow
{
    [Export(typeof(IGame))]
    public class FourInARowGame : IGame
    {
        private readonly Lazy<IFourInARowSettingsViewModel> _fiveInARowSettingsViewModel;
        private readonly Lazy<IFourInARowGameViewModel> _fiveInARowGameViewModel;

        [ImportingConstructor]
        public FourInARowGame(
            Lazy<IFourInARowSettingsViewModel> fiveInARowSettingsViewModel,
            Lazy<IFourInARowGameViewModel> fiveInARowGameViewModel)
        {
            _fiveInARowSettingsViewModel = fiveInARowSettingsViewModel;
            _fiveInARowGameViewModel = fiveInARowGameViewModel;
        }

        public void Start()
        {
            _fiveInARowGameViewModel.Value.Initialize(_fiveInARowSettingsViewModel.Value.Settings);
        }

        public string Name { get { return "Four in a row"; } }

        public IScreen GameScreen { get { return _fiveInARowGameViewModel.Value; } }

        public IScreen SettingsScreen { get { return _fiveInARowSettingsViewModel.Value; } }
    }
}
