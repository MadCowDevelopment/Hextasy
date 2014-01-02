using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    public class JumpToKillTile : HexagonTile
    {
        public Owner Owner { get; set; }
        public bool IsSelected { get; set; }
        public bool HasBeenMoved { get; set; }
        public bool IsLegalMoveTarget { get; set; }
    }
}