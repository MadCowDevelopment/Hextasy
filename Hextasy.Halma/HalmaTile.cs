using Hextasy.Framework;

namespace Hextasy.Halma
{
    public class HalmaTile : HexagonTile
    {
        #region Public Properties

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