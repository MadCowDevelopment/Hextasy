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

        private T GetTileAt(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _columns || y >= Rows) return null;
            var tileIndex = y * _columns + x;
            return tileIndex >= Tiles.Count ? null : Tiles[tileIndex];
        }

        private IEnumerable<T> GetNeighbours(int x, int y)
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

        public IEnumerable<IEnumerable<T>> GetLines(T item)
        {
            var indexOfItem = Tiles.IndexOf(item);
            if (indexOfItem < 0) return Enumerable.Empty<IEnumerable<T>>();
            var x = indexOfItem % _columns;
            var y = indexOfItem / _columns;
            return GetLines(x, y);
        }

        private IEnumerable<IEnumerable<T>> GetLines(int x, int y)
        {
            var result = new List<List<T>>
            {
                GetDiagonalUpwardsLine(x, y),
                GetDiagonalDownwardsLine(x, y),
                GetStraightDownLine(x)
            };

            return result;
        }

        private List<T> GetDiagonalUpwardsLine(int x, int y)
        {
            var result = new List<T>();
            var x1 = x;
            var y1 = y;
            while (x1 > 0 && y1 < Rows - 1)
            {
                if (x1%2 == 0)
                {
                    x1--;
                }
                else
                {
                    x1--;
                    y1++;
                }
            }

            while (x1 < _columns && y1 >= 0)
            {
                result.AddNotNull(GetTileAt(x1, y1));
                if (x1%2 == 0)
                {
                    x1++;
                    y1--;
                }
                else
                {
                    x1++;
                }
            }

            return result;
        }

        private List<T> GetDiagonalDownwardsLine(int x, int y)
        {
            var result = new List<T>();
            var x1 = x;
            var y1 = y;
            while (x1 > 0 && y1 > 0 || (x1%2 != 0 && y1 == 0))
            {
                if (x1 % 2 == 0)
                {
                    x1--;
                    y1--;
                }
                else
                {
                    x1--;
                }
            }

            while (x1 < _columns && y1 < Rows)
            {
                result.AddNotNull(GetTileAt(x1, y1));
                if (x1 % 2 == 0)
                {
                    x1++;
                }
                else
                {
                    x1++;
                    y1++;
                }
            }

            return result;
        }

        private List<T> GetStraightDownLine(int x)
        {
            var result = new List<T>();
            for (var y1 = 0; y1 < Rows; y1++)
            {
                result.AddNotNull(GetTileAt(x, y1));
            }

            return result;
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
