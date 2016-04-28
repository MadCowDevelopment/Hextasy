using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    public class YinshTile : HexagonTile
    {
        public bool IsChecked { get; set; }
        
        public Disc Disc { get; set; }

        public Ring Ring { get; set; }
    }
}