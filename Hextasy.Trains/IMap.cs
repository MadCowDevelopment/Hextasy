using System.Collections.Generic;

namespace Hextasy.Trains
{
    public interface IMap
    {
        #region Properties

        int Columns
        {
            get;
        }

        string Name
        {
            get;
        }

        int Rows
        {
            get;
        }

        IEnumerable<string> Stations
        {
            get;
        }

        #endregion Properties

        #region Methods

        TrainsTile CreateTile(int column, int row);

        #endregion Methods
    }
}