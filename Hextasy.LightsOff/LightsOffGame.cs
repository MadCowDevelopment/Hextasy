using System;
using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(IGame))]
    public class LightsOffGame : Game<LightsOffSettingsViewModel, LightsOffGameViewModel, LightsOffGameLogic, LightsOffSettings, LightsOffTile>
    {
        #region Constructors

        [ImportingConstructor]
        public LightsOffGame(
            Lazy<LightsOffSettingsViewModel> lightsOffSettingsViewModel,
            Lazy<LightsOffGameViewModel> lightsOffGameViewModel)
            : base(lightsOffSettingsViewModel, lightsOffGameViewModel)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Lights off!"; }
        }

        #endregion Public Properties
    }
}