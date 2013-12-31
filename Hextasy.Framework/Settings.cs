namespace Hextasy.Framework
{
    public abstract class Settings
    {
        #region Constructors

        protected Settings(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        #endregion Constructors

        #region Public Properties

        public int Columns
        {
            get; private set;
        }

        public int Rows
        {
            get; private set;
        }

        #endregion Public Properties
    }
}