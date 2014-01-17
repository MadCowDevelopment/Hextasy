using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Hextasy.Trains
{
    [Export(typeof(IMap))]
    public class MapChina : IMap
    {
        private readonly IEnumerable<string> _stations = new[]
        {
            "Urumqi", "Harbin", "Beijing", "Hotan", "Golmud", "Xian",
            "Shanghai", "Lhasa", "Chengdu", "Guiyang", "Guangzhou"
        };

        public string Name { get { return "China"; } }
        public IEnumerable<string> Stations { get { return _stations; } }

        public TrainsTile CreateTile(int column, int row)
        {
            switch (row)
            {
                case 0:
                    if (column == 12 || column == 13) return TrainsTile.Empty;
                    break;
                case 1:
                    if (column == 3 || (column >= 12 && column <= 15)) return TrainsTile.Empty;
                    break;
                case 2:
                    if ((column >= 3 && column <= 5) || (column >= 11 && column <= 15))
                    {
                        if (column == 3) return new StationTile("Urumqi");
                        if (column == 14) return new StationTile("Harbin");
                        return TrainsTile.Empty;
                    }
                    break;
                case 3:
                    if ((column >= 1 && column <= 5) || (column >= 10 && column <= 14)) return TrainsTile.Empty;
                    break;
                case 4:
                    if ((column >= 0 && column <= 7) || (column >= 9 && column <= 12))
                    {
                        if (column == 1) return new StationTile("Hotan");
                        if (column == 11) return new StationTile("Beijing");
                        return TrainsTile.Empty;
                    }
                    break;
                case 5:
                    if (column >= 0 && column <= 11)
                    {
                        if (column == 5) return new StationTile("Golmud");
                        return TrainsTile.Empty;
                    }
                    break;
                case 6:
                    if (column >= 1 && column <= 12)
                    {
                        if (column == 9) return new StationTile("Xian");
                        return TrainsTile.Empty;
                    }
                    break;
                case 7:
                    if (column >= 1 && column <= 13)
                    {
                        if (column == 13) return new StationTile("Shanghai");
                        return TrainsTile.Empty;
                    }
                    break;
                case 8:
                    if ((column >= 2 && column <= 4) || (column >= 6 && column <= 13))
                    {
                        if (column == 4) return new StationTile("Lhasa");
                        if (column == 8) return new StationTile("Chengdu");
                        return TrainsTile.Empty;
                    }
                    break;
                case 9:
                    if (column >= 6 && column <= 13)
                    {
                        if (column == 9) return new StationTile("Guiyang");
                        return TrainsTile.Empty;
                    }
                    break;
                case 10:
                    if (column >= 6 && column <= 12)
                    {
                        if (column == 11) return new StationTile("Guangzhou");
                        return TrainsTile.Empty;
                    }
                    break;
            }

            return null;
        }

        public int Columns { get { return 16; } }
        public int Rows { get { return 11; } }
    }
}
