using Hextasy.Framework;

namespace Hextasy.JumpToKill
{
    public class JumpToKillTile : HexagonTile
    {
        #region Public Properties

        public bool HasBeenMoved
        {
            get; set;
        }

        public bool IsLegalMoveTarget
        {
            get; set;
        }

        public bool IsSelected
        {
            get; set;
        }

        public Owner Owner
        {
            get; set;
        }

        #endregion Public Properties
    }
}