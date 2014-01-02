using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    [Export(typeof(JumpToKillSettingsViewModel))]
    public class JumpToKillSettingsViewModel : SettingsViewModel<JumpToKillSettings>
    {
        public JumpToKillSettingsViewModel()
        {
            Rows = 8;
            Columns = 8;
            Player1 = "Player 1";
            Player2 = "Player 2";
        }

        public string Player1
        {
            get;
            set;
        }

        public string Player2
        {
            get;
            set;
        }

        public override JumpToKillSettings Settings
        {
            get { return new JumpToKillSettings(Rows, Columns, Player1, Player2); }
        }
    }
}