namespace Hextasy.Framework
{
    public class Coordinate
    {
        #region Constructors

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion Constructors

        #region Public Properties

        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        #endregion Public Properties
    }
}