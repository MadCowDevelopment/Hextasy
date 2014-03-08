using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    [Export(typeof(IGame))]
    public class JumpToKillGame : Game<JumpToKillSettingsViewModel, JumpToKillGameViewModel, JumpToKillGameResultViewModel, JumpToKillGameLogic, JumpToKillSettings, JumpToKillTile, JumpToKillStatistics>
    {
        #region Constructors

        [ImportingConstructor]
        public JumpToKillGame(
            ExportFactory<JumpToKillSettingsViewModel> settingsViewModel,
            ExportFactory<JumpToKillGameViewModel> gameViewModel,
            ExportFactory<JumpToKillGameResultViewModel> gameResultViewModel)
            : base(settingsViewModel, gameViewModel, gameResultViewModel)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Jump to kill"; }
        }

        #endregion Public Properties
    }
}