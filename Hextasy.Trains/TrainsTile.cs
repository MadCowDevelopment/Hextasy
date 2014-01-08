using Hextasy.Framework;

namespace Hextasy.Trains
{
    public class TrainsTile : HexagonTile
    {
        #region Constructors

        public TrainsTile(
            Owner owner,
            bool hasTopExit,
            bool hasTopRightExit,
            bool hasBottomRightExit,
            bool hasBottomExit,
            bool hasBottomLeftExit,
            bool hasTopLeftExit)
        {
            Owner = owner;
            HasTopExit = hasTopExit;
            HasTopRightExit = hasTopRightExit;
            HasBottomRightExit = hasBottomRightExit;
            HasBottomExit = hasBottomExit;
            HasBottomLeftExit = hasBottomLeftExit;
            HasTopLeftExit = hasTopLeftExit;
        }

        #endregion Constructors

        #region Public Properties

        public bool HasBottomExit
        {
            get; private set;
        }

        public bool HasBottomLeftExit
        {
            get; private set;
        }

        public bool HasBottomRightExit
        {
            get; private set;
        }

        public bool HasTopExit
        {
            get; private set;
        }

        public bool HasTopLeftExit
        {
            get; private set;
        }

        public bool HasTopRightExit
        {
            get; private set;
        }

        public Owner Owner
        {
            get; internal set;
        }

        public static TrainsTile Empty
        {
            get
            {
                return new TrainsTile(Owner.None, false, false, false, false, false, false);
            }
        }

        public bool IsFixed { get; set; }

        public bool CanBePlaced { get; set; }

        #endregion Public Properties

        public void CopyExits(TrainsTile newTile)
        {
            HasTopExit = newTile.HasTopExit;
            HasTopRightExit = newTile.HasTopRightExit;
            HasBottomRightExit = newTile.HasBottomRightExit;
            HasBottomExit = newTile.HasBottomExit;
            HasBottomLeftExit = newTile.HasBottomLeftExit;
            HasTopLeftExit = newTile.HasTopLeftExit;
        }
    }
}