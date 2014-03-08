namespace Hextasy.Trains
{
    public class StationTile : TrainsTile
    {
        #region Constructors

        public StationTile(string name)
            : base(Owner.None, true, true, true, true, true, true)
        {
            Name = name;
            IsFixed = true;
        }

        #endregion Constructors

        #region Public Properties

        public string Name
        {
            get; private set;
        }

        #endregion Public Properties
    }
}