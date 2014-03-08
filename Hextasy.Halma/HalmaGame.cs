using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.Halma
{
    [Export(typeof(IGame))]
    public class HalmaGame : Game<HalmaSettingsViewModel, HalmaGameViewModel, HalmaGameResultViewModel, HalmaGameLogic, HalmaSettings, HalmaTile, HalmaStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public HalmaGame(
            ExportFactory<HalmaSettingsViewModel> settingsViewModel,
            ExportFactory<HalmaGameViewModel> gameViewModel,
            ExportFactory<HalmaGameResultViewModel> gameResultViewModel)
            : base(settingsViewModel, gameViewModel, gameResultViewModel)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Halma"; }
        }

        #endregion Public Properties
    }
}