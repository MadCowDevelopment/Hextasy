using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.MiningBot
{
    [Export(typeof(IGame))]
    public class MiningBotGame :
        Game
            <MiningBotSettingsViewModel, MiningBotGameViewModel, MiningBotResultViewModel, MiningBotGameLogic,
                MiningBotSettings, MiningBotTile, MiningBotStatistic>
    {
        [ImportingConstructor]
        public MiningBotGame(ExportFactory<MiningBotSettingsViewModel> settingsViewModel,
            ExportFactory<MiningBotGameViewModel> gameViewModel,
            ExportFactory<MiningBotResultViewModel> gameResultViewModel)
            : base(settingsViewModel, gameViewModel, gameResultViewModel)
        {
        }

        public override string Name
        {
            get { return "Mining Bot"; }
        }
    }
}
