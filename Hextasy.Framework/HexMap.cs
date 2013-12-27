using System.Collections.Generic;
using System.Linq;

namespace Hextasy.Framework
{
    public class HexMap<T> where T : class
    {
        private readonly int _columns;

        public HexMap(IEnumerable<T> tiles, int columns)
        {
            Tiles = new List<T>(tiles);
            _columns = columns;
        }

        public List<T> Tiles { get; private set; }

        public T GetTileAt(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _columns || y >= Rows) return null;
            var tileIndex = y * _columns + x;
            return tileIndex >= Tiles.Count ? null : Tiles[tileIndex];
        }

        public IEnumerable<T> GetNeighbours(int x, int y)
        {
            var isEvenColumn = x % 2 == 0;
            var neighbours = new List<T>();
            neighbours.AddNotNull(isEvenColumn ? GetTileAt(x - 1, y - 1) : GetTileAt(x - 1, y));
            neighbours.AddNotNull(GetTileAt(x, y - 1));
            neighbours.AddNotNull(isEvenColumn ? GetTileAt(x + 1, y - 1) : GetTileAt(x + 1, y));
            neighbours.AddNotNull(isEvenColumn ? GetTileAt(x - 1, y) : GetTileAt(x - 1, y + 1));
            neighbours.AddNotNull(isEvenColumn ? GetTileAt(x + 1, y) : GetTileAt(x + 1, y + 1));
            neighbours.AddNotNull(GetTileAt(x, y + 1));
            return neighbours;
        }

        public IEnumerable<T> GetNeighbours(T item)
        {
            var indexOfItem = Tiles.IndexOf(item);
            if (indexOfItem < 0) return Enumerable.Empty<T>();
            var x = indexOfItem % _columns;
            var y = indexOfItem / _columns;
            return GetNeighbours(x, y);
        }

        private int Rows
        {
            get
            {
                return Tiles.Count / _columns;
            }
        }
    }

    public static class ListExtensions
    {
        public static void AddNotNull<T>(this IList<T> enumerable, T objToAdd) where T : class
        {
            if (objToAdd != null)
            {
                enumerable.Add(objToAdd);
            }
        }
    }
}
