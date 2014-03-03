using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    [Export(typeof(IGame))]
    public class JumpToKillGame
        : Game<JumpToKillSettingsViewModel, JumpToKillGameViewModel, JumpToKillGameResultViewModel, JumpToKillGameLogic, JumpToKillSettings, JumpToKillTile, JumpToKillStatistics>
    {
        [ImportingConstructor]
        public JumpToKillGame(
            ExportFactory<JumpToKillSettingsViewModel> settingsViewModel,
            ExportFactory<JumpToKillGameViewModel> gameViewModel,
            ExportFactory<JumpToKillGameResultViewModel> gameResultViewModel)
            : base(settingsViewModel, gameViewModel, gameResultViewModel)
        {
        }

        public override string Name
        {
            get { return "Jump to kill"; }
        }
    }
}
