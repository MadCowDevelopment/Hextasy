using System.Collections.Generic;
using Hextasy.Framework;

namespace Hextasy.MapExporter
{
    public class MainWindowViewModel
    {
        private readonly HexMap<HexTile> _hexmap;

        public MainWindowViewModel()
        {
            var tiles = CreateTiles();
            _hexmap = new HexMap<HexTile>(tiles, 20);
        }

        public IEnumerable<HexTile> Tiles { get { return _hexmap.Tiles; } }

        public int Columns { get { return 20; } }

        private IEnumerable<HexTile> CreateTiles()
        {
            var result = new List<HexTile>();
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    result.Add(new HexTile(x, y));
                }
            }

            return result;
        }
    }
}
