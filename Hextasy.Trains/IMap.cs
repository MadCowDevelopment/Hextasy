using System.Collections.Generic;

namespace Hextasy.Trains
{
    public interface IMap
    {
        string Name { get; }
        IEnumerable<string> Stations { get; }
        TrainsTile CreateTile(int column, int row);
        int Columns { get; }
        int Rows { get; }
    }
}