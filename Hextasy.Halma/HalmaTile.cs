using Hextasy.Framework;

namespace Hextasy.Halma
{
    public class HalmaTile : HexagonTile
    {
        public Owner Owner { get; set; }
        public bool IsSelected { get; set; }
        public bool IsLegalMoveTarget { get; set; }
    }
}