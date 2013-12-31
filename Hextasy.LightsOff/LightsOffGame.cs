using System;
using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(IGame))]
    public class LightsOffGame : Game<ILightsOffSettingsViewModel, ILightsOffGameViewModel, LightsOffSettings>
    {
        [ImportingConstructor]
        public LightsOffGame(
            Lazy<ILightsOffSettingsViewModel> lightsOffSettingsViewModel,
            Lazy<ILightsOffGameViewModel> lightsOffGameViewModel) : base(lightsOffSettingsViewModel, lightsOffGameViewModel)
        {
        }

        public override string Name { get { return "Lights off!"; } }
    }
}
