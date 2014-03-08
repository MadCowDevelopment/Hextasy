using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    [Export(typeof(JumpToKillSettingsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class JumpToKillSettingsViewModel : SettingsViewModel<JumpToKillSettings>
    {
        #region Constructors

        public JumpToKillSettingsViewModel()
        {
            Rows = 8;
            Columns = 8;
            Player1 = "Player 1";
            Player2 = "Player 2";
        }

        #endregion Constructors

        #region Public Properties

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

        #endregion Public Properties
    }
}