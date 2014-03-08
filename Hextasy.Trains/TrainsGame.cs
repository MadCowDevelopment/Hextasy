using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.Trains
{
    [Export(typeof(IGame))]
    public class TrainsGame : Game<TrainsSettingsViewModel, TrainsGameViewModel, TrainsGameResultViewModel, TrainsGameLogic, TrainsSettings, TrainsTile, TrainsStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public TrainsGame(
            ExportFactory<TrainsSettingsViewModel> settingsViewModel,
            ExportFactory<TrainsGameViewModel> gameViewModel,
            ExportFactory<TrainsGameResultViewModel> gameResultViewModel)
            : base(settingsViewModel, gameViewModel, gameResultViewModel)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Trains"; }
        }

        #endregion Public Properties
    }
}