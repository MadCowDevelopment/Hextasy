using Hextasy.Framework;

namespace Hextasy.XInARow
{
    public class XInARowSettings : Settings
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int RequiredForWin { get; private set; }
        public string Player1 { get; private set; }
        public string Player2 { get; private set; }

        public XInARowSettings(int rows, int columns, int requiredForWin, string player1, string player2)
        {
            Rows = rows;
            Columns = columns;
            RequiredForWin = requiredForWin;
            Player1 = player1;
            Player2 = player2;
        }
    }
}