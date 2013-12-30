using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Hextasy.FourInARow
{
    [Export(typeof(IFourInARowSettingsViewModel))]
    public class FourInARowSettingsViewModel : Screen, IFourInARowSettingsViewModel
    {
        public FourInARowSettingsViewModel()
        {
            Rows = 9;
            Columns = 9;
            Player1 = "Player 1";
            Player2 = "Player 2";
        }

        public FourInARowSettings Settings { get { return new FourInARowSettings(Rows, Columns, Player1, Player2);} }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public string Player1 { get; set; }

        public string Player2 { get; set; }
    }
}
