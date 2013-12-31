using Hextasy.Framework;

namespace Hextasy.XInARow
{
    public class XInARowSettings : Settings
    {
        #region Constructors

        public XInARowSettings(int rows, int columns, int requiredForWin, string player1, string player2)
            : base(rows, columns)
        {
            RequiredForWin = requiredForWin;
            Player1 = player1;
            Player2 = player2;
        }

        #endregion Constructors

        #region Public Properties

        public string Player1
        {
            get; private set;
        }

        public string Player2
        {
            get; private set;
        }

        public int RequiredForWin
        {
            get; private set;
        }

        #endregion Public Properties
    }
}