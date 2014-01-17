namespace Hextasy.MapExporter
{
    public class HexTile
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public HexTile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string DisplayName
        {
            get
            {
                return string.Format("{0},{1}", X, Y);
            }
        }
    }
}
