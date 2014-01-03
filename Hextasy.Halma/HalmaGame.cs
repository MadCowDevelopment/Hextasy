using System;
using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Halma
{
    [Export(typeof(IGame))]
    public class HalmaGame : Game<HalmaSettingsViewModel, HalmaGameViewModel, HalmaGameLogic, HalmaSettings, HalmaTile>
    {
        [ImportingConstructor]
        public HalmaGame(Lazy<HalmaSettingsViewModel> settingsViewModel, Lazy<HalmaGameViewModel> gameViewModel) : base(settingsViewModel, gameViewModel)
        {
        }

        public override string Name
        {
            get { return "Halma"; }
        }
    }
}
