using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    public class YinshTile : HexagonTile
    {
        public bool IsSelected { get; set; }

        public bool IsValidTarget { get; set; }
        
        public Disc Disc { get; set; }

        public Ring Ring { get; set; }
    }
}