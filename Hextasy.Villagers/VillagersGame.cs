using Hextasy.Framework;
using System.ComponentModel.Composition;

namespace Hextasy.Villagers
{
    [Export(typeof(IGame))]
    public class VillagersGame :
        Game
            <VillagersSettingsViewModel, VillagersGameViewModel, VillagersGameResultViewModel, VillagersGameLogic,
                VillagersSettings, VillagersTile, VillagersStatistics>
    {
        [ImportingConstructor]
        public VillagersGame(ExportFactory<VillagersSettingsViewModel> settingsViewModel,
            ExportFactory<VillagersGameViewModel> gameViewModel,
            ExportFactory<VillagersGameResultViewModel> gameResultViewModel)
            : base(settingsViewModel, gameViewModel, gameResultViewModel)
        {
        }

        public override string Name
        {
            get { return "Villagers"; }
        }
    }
}
