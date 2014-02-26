using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.XInARow
{
    [Export(typeof(XInARowSettingsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class XInARowSettingsViewModel : SettingsViewModel<XInARowSettings>
    {
        #region Constructors

        public XInARowSettingsViewModel()
        {
            Rows = 9;
            Columns = 9;
            RequiredForWin = 5;
            Player1 = "Player 1";
            Player2 = "Player 2";
        }

        #endregion Constructors

        #region Public Properties
        
        public string Player1
        {
            get; set;
        }

        public string Player2
        {
            get; set;
        }

        public int RequiredForWin
        {
            get; set;
        }

        public override XInARowSettings Settings
        {
            get { return new XInARowSettings(Rows, Columns, RequiredForWin, Player1, Player2); }
        }

        #endregion Public Properties
    }
}