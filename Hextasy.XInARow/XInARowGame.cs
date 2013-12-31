using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(IGame))]
    public class XInARowGame : IGame
    {
        private readonly Lazy<IXInARowSettingsViewModel> _xInARowSettingsViewModel;
        private readonly Lazy<IXInARowGameViewModel> _xInARowGameViewModel;

        [ImportingConstructor]
        public XInARowGame(
            Lazy<IXInARowSettingsViewModel> xInARowSettingsViewModel,
            Lazy<IXInARowGameViewModel> xInARowGameViewModel)
        {
            _xInARowSettingsViewModel = xInARowSettingsViewModel;
            _xInARowGameViewModel = xInARowGameViewModel;
        }

        public void Start()
        {
            _xInARowGameViewModel.Value.Initialize(_xInARowSettingsViewModel.Value.Settings);
        }

        public string Name { get { return "X in a row"; } }

        public IScreen GameScreen { get { return _xInARowGameViewModel.Value; } }

        public IScreen SettingsScreen { get { return _xInARowSettingsViewModel.Value; } }
    }
}
