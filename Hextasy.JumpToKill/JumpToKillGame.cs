using System;
using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    [Export(typeof(IGame))]
    public class JumpToKillGame
        : Game<JumpToKillSettingsViewModel, JumpToKillGameViewModel, JumpToKillGameLogic, JumpToKillSettings, JumpToKillTile>
    {
        [ImportingConstructor]
        public JumpToKillGame(Lazy<JumpToKillSettingsViewModel> settingsViewModel, Lazy<JumpToKillGameViewModel> gameViewModel)
            : base(settingsViewModel, gameViewModel)
        {
        }

        public override string Name
        {
            get { return "Jump to kill"; }
        }
    }
}
