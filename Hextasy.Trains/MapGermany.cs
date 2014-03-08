using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Hextasy.Trains
{
    [Export(typeof(IMap))]
    public class MapGermany : IMap
    {
        #region Fields

        private readonly IEnumerable<string> _stations = new List<string>
        {
            "Kiel", "Rostock", "Bremen", "Hannover", "Berlin", "Kassel",
            "Dresden", "Frankfurt", "Mannheim", "Nürnberg", "Stuttgart", "München"
        };

        #endregion Fields

        #region Public Properties

        public int Columns
        {
            get { return 12; }
        }

        public string Name
        {
            get
            {
                return "Germany";
            }
        }

        public int Rows
        {
            get { return 14; }
        }

        public IEnumerable<string> Stations
        {
            get
            {
                return _stations;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public TrainsTile CreateTile(int column, int row)
        {
            switch (row)
            {
                case 0:
                    if (column == 4 || column == 5 || column == 9)
                    {
                        return column == 5 ? new StationTile("Kiel") : TrainsTile.Empty;
                    }
                    break;
                case 1:
                    if (column >= 3 && column <= 9)
                    {
                        return column == 9 ? new StationTile("Rostock") : TrainsTile.Empty;
                    }
                    break;
                case 2:
                    if (column >= 1 && column <= 10)
                    {
                        return column == 3 ? new StationTile("Bremen") : TrainsTile.Empty;
                    }
                    break;
                case 3:
                    if (column >= 1 && column <= 10)
                    {
                        return TrainsTile.Empty;
                    }
                    break;
                case 4:
                    if (column >= 1 && column <= 11)
                    {
                        if (column == 3) return new StationTile("Hannover");
                        if (column == 9) return new StationTile("Berlin");
                        return TrainsTile.Empty;
                    }
                    break;
                case 5:
                    if (column >= 1 && column <= 11)
                    {
                        return TrainsTile.Empty;
                    }
                    break;
                case 6:
                    if (column >= 0 && column <= 11)
                    {
                        return column == 4 ? new StationTile("Kassel") : TrainsTile.Empty;
                    }
                    break;
                case 7:
                    if (column >= 0 && column <= 10)
                    {
                        return column == 8 ? new StationTile("Dresden") : TrainsTile.Empty;
                    }
                    break;
                case 8:
                    if (column >= 0 && column <= 8)
                    {
                        return column == 3 ? new StationTile("Frankfurt") : TrainsTile.Empty;
                    }
                    break;
                case 9:
                    if (column >= 0 && column <= 8)
                    {
                        return TrainsTile.Empty;
                    }
                    break;
                case 10:
                    if (column >= 0 && column <= 9)
                    {
                        if (column == 2) return new StationTile("Mannheim");
                        if (column == 6) return new StationTile("Nürnberg");
                        return TrainsTile.Empty;
                    }
                    break;
                case 11:
                    if (column >= 2 && column <= 10)
                    {
                        return column == 3 ? new StationTile("Stuttgart") : TrainsTile.Empty;
                    }
                    break;
                case 12:
                    if (column >= 2 && column <= 9)
                    {
                        return column == 7 ? new StationTile("München") : TrainsTile.Empty;
                    }
                    break;
                case 13:
                    if (column >= 2 && column <= 9)
                    {
                        return TrainsTile.Empty;
                    }
                    break;
            }

            return null;
        }

        #endregion Public Methods
    }
}