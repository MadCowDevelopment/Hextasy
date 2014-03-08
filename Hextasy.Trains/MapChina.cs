using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Hextasy.Trains
{
    [Export(typeof(IMap))]
    public class MapChina : IMap
    {
        #region Fields

        private readonly IEnumerable<string> _stations = new[]
        {
            "Urumqi", "Harbin", "Beijing", "Hotan", "Golmud", "Xian",
            "Shanghai", "Lhasa", "Chengdu", "Wuhan", "Kunming", "Guangzhou"
        };

        #endregion Fields

        #region Public Properties

        public int Columns
        {
            get { return 20; }
        }

        public string Name
        {
            get { return "China"; }
        }

        public int Rows
        {
            get { return 13; }
        }

        public IEnumerable<string> Stations
        {
            get { return _stations; }
        }

        #endregion Public Properties

        #region Public Methods

        public TrainsTile CreateTile(int column, int row)
        {
            switch (row)
            {
                case 0:
                    if (column >= 15 && column <= 17) return TrainsTile.Empty;
                    break;
                case 1:
                    if (column == 5 || (column >= 15 && column <= 19)) return TrainsTile.Empty;
                    break;
                case 2:
                    if ((column >= 3 && column <= 5) || (column >= 15 && column <= 18))
                    {
                        if (column == 17) return new StationTile("Harbin");
                        return TrainsTile.Empty;
                    }
                    break;
                case 3:
                    if ((column >= 3 && column <= 7) || (column >= 13 && column <= 18))
                    {
                        if (column == 5) return new StationTile("Urumqi");
                        return TrainsTile.Empty;
                    }
                    break;
                case 4:
                    if ((column >= 0 && column <= 9) || (column >= 11 && column <= 17)) return TrainsTile.Empty;
                    break;
                case 5:
                    if (column >= 0 && column <= 15)
                    {
                        if (column == 2) return new StationTile("Hotan");
                        if (column == 14) return new StationTile("Beijing");
                        return TrainsTile.Empty;
                    }
                    break;
                case 6:
                    if (column >= 1 && column <= 16)
                    {
                        if (column == 7) return new StationTile("Golmud");
                        return TrainsTile.Empty;
                    }
                    break;
                case 7:
                    if (column >= 1 && column <= 15)
                    {
                        if (column == 12) return new StationTile("Xian");
                        return TrainsTile.Empty;
                    }
                    break;
                case 8:
                    if (column >= 2 && column <= 17)
                    {
                        if (column == 17) return new StationTile("Shanghai");
                        return TrainsTile.Empty;
                    }
                    break;
                case 9:
                    if (column >= 4 && column <= 17)
                    {
                        if (column == 5) return new StationTile("Lhasa");
                        if (column == 10) return new StationTile("Chengdu");
                        if (column == 14) return new StationTile("Wuhan");
                        return TrainsTile.Empty;
                    }
                    break;
                case 10:
                    if (column >= 8 && column <= 16) return TrainsTile.Empty;
                    break;
                case 11:
                    if (column >= 8 && column <= 16)
                    {
                        if (column == 10) return new StationTile("Kunming");
                        return TrainsTile.Empty;
                    }
                    break;
                case 12:
                    if ((column >= 8 && column <= 10) || (column >= 12 && column <= 14))
                    {
                        if (column == 14) return new StationTile("Guangzhou");
                        return TrainsTile.Empty;
                    }
                    break;
            }

            return null;
        }

        #endregion Public Methods
    }
}