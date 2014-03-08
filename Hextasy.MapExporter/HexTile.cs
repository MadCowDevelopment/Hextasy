namespace Hextasy.MapExporter
{
    public class HexTile
    {
        #region Constructors

        public HexTile(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion Constructors

        #region Public Properties

        public string DisplayName
        {
            get
            {
                return string.Format("{0},{1}", X, Y);
            }
        }

        public int X
        {
            get; private set;
        }

        public int Y
        {
            get; private set;
        }

        #endregion Public Properties
    }
}