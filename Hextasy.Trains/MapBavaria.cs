using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Hextasy.Trains
{
    [Export(typeof(IMap))]
    public class MapBavaria : IMap
    {
        private readonly IEnumerable<string> _stations = new []
        {
            "Bad Kissingen", "Kulmbach", "Würzburg", "Nürnberg", "Amberg", "Ingolstadt",
            "Regensburg", "Passau", "Augsburg", "München", "Kempten", "Rosenheim"
        };

        public string Name { get { return "Bavaria"; } }
        public IEnumerable<string> Stations { get { return _stations; } }
        public TrainsTile CreateTile(int column, int row)
        {
            switch (row)
            {
                case 0:
                    if ((column >= 3 && column <= 5 || (column >= 8 && column <= 9))) return TrainsTile.Empty;
                    break;
                case 1:
                    if ((column >= 2 && column <= 5 || (column >= 7 && column <= 11)))
                    {
                        if (column == 4) return new StationTile("Bad Kissingen");
                        if (column == 9) return new StationTile("Kulmbach");
                        return TrainsTile.Empty;
                    }
                    break;
                case 2:
                    if (column >= 0 && column <= 12) return TrainsTile.Empty;
                    break;
                case 3:
                    if (column >= 0  && column <= 12)
                    {
                        if (column == 3) return new StationTile("Würzburg");
                        return TrainsTile.Empty;
                    }
                    break;
                case 4:
                    if (column == 0 || (column >= 3 && column <= 12))
                    {
                        if (column == 7) return new StationTile("Nürnberg");
                        if (column == 11) return new StationTile("Amberg");
                        return TrainsTile.Empty;
                    }
                    break;
                case 5:
                    if (column >= 4 && column <= 13) return TrainsTile.Empty;
                    break;
                case 6:
                    if (column >= 4 && column <= 15)
                    {
                        if (column == 11) return new StationTile("Regensburg");
                        return TrainsTile.Empty;
                    }
                    break;
                case 7:
                    if (column >= 5 && column <= 17) return TrainsTile.Empty;
                    break;
                case 8:
                    if (column >= 5 && column <= 17)
                    {
                        if (column == 8) return new StationTile("Ingolstadt");
                        return TrainsTile.Empty;
                    }
                    break;
                case 9:
                    if (column >= 5 && column <= 16)
                    {
                        if (column == 16) return new StationTile("Passau");
                        return TrainsTile.Empty;
                    }
                    break;
                case 10:
                    if (column >= 4 && column <= 14)
                    {
                        if (column == 7) return new StationTile("Augsburg");
                        return TrainsTile.Empty;
                    }
                    break;
                case 11:
                    if (column >= 4 && column <= 13)
                    {
                        if (column == 10) return new StationTile("München");
                        return TrainsTile.Empty;
                    }
                    break;
                case 12:
                    if (column >= 4 && column <= 14) return TrainsTile.Empty;
                    break;
                case 13:
                    if (column >= 4 && column <= 14)
                    {
                        if (column == 5) return new StationTile("Kempten");
                        if (column == 12) return new StationTile("Rosenheim");
                        return TrainsTile.Empty;
                    }
                    break;
                case 14:
                    if (column >= 3 && column <= 14) return TrainsTile.Empty;
                    break;
                case 15:
                    if (column == 4) return TrainsTile.Empty;
                    break;
            }

            return null;
        }

        public int Columns { get { return 18; } }
        public int Rows { get { return 16; } }
    }
}
