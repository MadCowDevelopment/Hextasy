using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Hextasy.Trains
{
    [Export(typeof(IMap))]
    public class MapUnitedStates : IMap
    {
        private readonly IEnumerable<string> _stations = new[]
        {
            "Boston", "Bismarck", "Helena", "Carson City", "Denver", "Washington",
            "Indianapolis", "Los Angeles", "Atlanta", "Oklahoma City", "Miami", "Austin"
        };

        public string Name { get { return "United States of America"; } }
        public IEnumerable<string> Stations { get { return _stations; } }

        public TrainsTile CreateTile(int column, int row)
        {
            switch (row)
            {
                case 0:
                    if ((column >= 1 && column <= 3) || column == 5) return TrainsTile.Empty;
                    break;
                case 1:
                    if ((column >= 1 && column <= 10) || (column >= 17 && column <= 18))
                    {
                        if (column == 4) return new StationTile("Helena");
                        if (column == 8) return new StationTile("Bismarck");
                        if (column == 17) return new StationTile("Boston");
                        return TrainsTile.Empty;
                    }
                    break;
                case 2:
                    if ((column >= 0 && column <= 11) || column == 13 || (column >= 15 && column <= 17))
                        return TrainsTile.Empty;
                    break;
                case 3:
                    if ((column >= 0 && column <= 11) || column == 13 || (column >= 15 && column <= 16))
                    {
                        if (column == 1) return new StationTile("Carson City");
                        return TrainsTile.Empty;
                    }
                    break;
                case 4:
                    if (column >= 0 && column <= 16)
                    {
                        if (column == 6) return new StationTile("Denver");
                        if (column == 12) return new StationTile("Indianapolis");
                        if (column == 16) return new StationTile("Washington");
                        return TrainsTile.Empty;
                    }
                    break;
                case 5:
                    if (column >= 0 && column <= 16)
                    {
                        if (column == 1) return new StationTile("Los Angeles");
                        return TrainsTile.Empty;
                    }
                    break;
                case 6:
                    if (column >= 2 && column <= 15)
                    {
                        if (column == 8) return new StationTile("Oklahoma City");
                        if (column == 13) return new StationTile("Atlanta");
                        return TrainsTile.Empty;
                    }
                    break;
                case 7:
                    if (column == 4 ||(column >= 6 && column <= 14)) return TrainsTile.Empty;
                    break;
                case 8:
                    if (column == 6 || (column >= 8 && column <= 10)|| (column >= 14 && column <= 15))
                    {
                        if (column == 8) return new StationTile("Austin");
                        if (column == 15) return new StationTile("Miami");
                        return TrainsTile.Empty;
                    }
                    break;
                case 9:
                    if (column == 8) return TrainsTile.Empty;
                    break;
            }

            return null;
        }

        public int Columns { get { return 19; } }
        public int Rows { get { return 10; } }
    }
}
