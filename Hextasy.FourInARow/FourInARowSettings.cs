namespace Hextasy.FourInARow
{
    public class FourInARowSettings
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public string Player1 { get; private set; }
        public string Player2 { get; private set; }

        public FourInARowSettings(int rows, int columns, string player1, string player2)
        {
            Rows = rows;
            Columns = columns;
            Player1 = player1;
            Player2 = player2;
        }
    }
}