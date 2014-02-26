using System;
using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Trains
{
    [Export(typeof(IGame))]
    public class TrainsGame : Game<TrainsSettingsViewModel, TrainsGameViewModel, TrainsGameLogic, TrainsSettings, TrainsTile>
    {
        [ImportingConstructor]
        public TrainsGame(ExportFactory<TrainsSettingsViewModel> settingsViewModel, ExportFactory<TrainsGameViewModel> gameViewModel) 
            : base(settingsViewModel, gameViewModel)
        {
        }

        public override string Name
        {
            get { return "Trains"; }
        }
    }
}
