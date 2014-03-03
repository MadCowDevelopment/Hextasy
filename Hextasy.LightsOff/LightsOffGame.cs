using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(IGame))]
    public class LightsOffGame : Game<LightsOffSettingsViewModel, LightsOffGameViewModel, LightsOffGameResultViewModel, LightsOffGameLogic, LightsOffSettings, LightsOffTile, LightsOffStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public LightsOffGame(
            ExportFactory<LightsOffSettingsViewModel> lightsOffSettingsViewModel,
            ExportFactory<LightsOffGameViewModel> lightsOffGameViewModel,
            ExportFactory<LightsOffGameResultViewModel> lightsOffGameResultViewModel)
            : base(lightsOffSettingsViewModel, lightsOffGameViewModel, lightsOffGameResultViewModel)
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