using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Trains
{
    [Export(typeof(IGame))]
    public class TrainsGame : Game<TrainsSettingsViewModel, TrainsGameViewModel, TrainsGameResultViewModel, TrainsGameLogic, TrainsSettings, TrainsTile, TrainsStatistics>
    {
        [ImportingConstructor]
        public TrainsGame(
            ExportFactory<TrainsSettingsViewModel> settingsViewModel,
            ExportFactory<TrainsGameViewModel> gameViewModel,
            ExportFactory<TrainsGameResultViewModel> gameResultViewModel)
            : base(settingsViewModel, gameViewModel, gameResultViewModel)
        {
        }

        public override string Name
        {
            get { return "Trains"; }
        }
    }
}
