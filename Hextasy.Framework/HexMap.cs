using System;
using System.Collections.Generic;
using System.Linq;

using Hextasy.Framework.Utils;

namespace Hextasy.Framework
{
    public class HexMap<T>
        where T : class
    {
        #region Fields

        private readonly int _columns;

        #endregion Fields

        #region Constructors

        public HexMap(IEnumerable<T> tiles, int columns)
        {
            Tiles = new DispatcherObservableCollection<T>(tiles);
            _columns = columns;
        }

        #endregion Constructors

        #region Public Properties

        public DispatcherObservableCollection<T> Tiles
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Private Properties

        private int Rows
        {
            get
            {
                return Tiles.Count / _columns;
            }
        }

        #endregion Private Properties

        #region Public Methods

        public T GetBottomLeftNeighbour(T item)
        {
            var coords = GetCoordinateByItem(item);
            return GetBottomLeftNeighbour(coords.X, coords.Y);
        }

        public T GetBottomNeighbour(T item)
        {
            var coords = GetCoordinateByItem(item);
            return GetBottomNeighbour(coords.X, coords.Y);
        }

        public T GetBottomRightNeighbour(T item)
        {
            var coords = GetCoordinateByItem(item);
            return GetBottomRightNeighbour(coords.X, coords.Y);
        }

        public Coordinate GetCoordinateByItem(T item)
        {
            var indexOfItem = Tiles.IndexOf(item);
            return GetCoordinateByIndex(indexOfItem);
        }

        public IEnumerable<IEnumerable<T>> GetLines(T item)
        {
            var coordinate = GetCoordinateByItem(item);
            return coordinate == null ? Enumerable.Empty<IEnumerable<T>>() : GetLines(coordinate.X, coordinate.Y);
        }

        public IEnumerable<T> GetNeighbours(T item)
        {
            return GetNeighbours(item, 1);
        }

        public IEnumerable<T> GetNeighbours(T item, int distance)
        {
            if (distance < 0) return Enumerable.Empty<T>();
            var coordinate = GetCoordinateByItem(item);
            var result = coordinate == null
                             ? Enumerable.Empty<T>().ToList()
                             : GetNeighbours(coordinate.X, coordinate.Y, distance).ToList();
            result.Remove(item);
            return result;
        }

        public T GetNextInLine(T tile1, T tile2)
        {
            var tile1Coordinate = GetCoordinateByItem(tile1);
            var tile2Coordinate = GetCoordinateByItem(tile2);
            if (tile1Coordinate == null || tile2Coordinate == null ||
                tile1Coordinate.X == tile2Coordinate.X && tile1Coordinate.Y == tile2Coordinate.Y) return null;

            var downwardLine = GetStraightDownLine(tile1Coordinate.X);
            if (downwardLine.Contains(tile2))
            {
                return downwardLine.IndexOf(tile1) < downwardLine.IndexOf(tile2)
                    ? GetBottomNeighbour(tile2Coordinate.X, tile2Coordinate.Y)
                    : GetTopNeighbour(tile2Coordinate.X, tile2Coordinate.Y);
            }

            var diagonalDownwardLine = GetDiagonalDownwardsLine(tile1Coordinate.X, tile1Coordinate.Y);
            if (diagonalDownwardLine.Contains(tile2))
            {
                return diagonalDownwardLine.IndexOf(tile1) < diagonalDownwardLine.IndexOf(tile2)
                    ? GetBottomRightNeighbour(tile2Coordinate.X, tile2Coordinate.Y)
                    : GetTopLeftNeighbour(tile2Coordinate.X, tile2Coordinate.Y);
            }

            var diagonalUpwardLine = GetDiagonalUpwardsLine(tile1Coordinate.X, tile1Coordinate.Y);
            if (diagonalUpwardLine.Contains(tile2))
            {
                return diagonalUpwardLine.IndexOf(tile1) < diagonalUpwardLine.IndexOf(tile2)
                    ? GetTopRightNeighbour(tile2Coordinate.X, tile2Coordinate.Y)
                    : GetBottomLeftNeighbour(tile2Coordinate.X, tile2Coordinate.Y);
            }

            return null;
        }

        public IEnumerable<T> GetTilesBetween(T tile1, T tile2)
        {
            var tile1Coordinate = GetCoordinateByItem(tile1);
            var tile2Coordinate = GetCoordinateByItem(tile2);
            if (tile1Coordinate == null || tile2Coordinate == null ||
                tile1Coordinate.X == tile2Coordinate.X && tile1Coordinate.Y == tile2Coordinate.Y)
                return Enumerable.Empty<T>();

            var lines = GetLines(tile1).Select(p => p.ToList());
            foreach (var line in lines)
            {
                if (!line.Contains(tile2)) continue;
                var min = Math.Min(line.IndexOf(tile1), line.IndexOf(tile2));
                var max = Math.Max(line.IndexOf(tile1), line.IndexOf(tile2));
                return line.GetRange(min + 1, max - min - 1);
            }

            return Enumerable.Empty<T>();
        }
        public bool TilesAreInSameLine(T tile1, T tile2)
        {
            var lines = GetLines(tile1).Select(p => p.ToList());
            return lines.Any(p => p.Contains(tile2));
        }

        public T GetTopLeftNeighbour(T item)
        {
            var coords = GetCoordinateByItem(item);
            return GetTopLeftNeighbour(coords.X, coords.Y);
        }

        public T GetTopNeighbour(T item)
        {
            var coords = GetCoordinateByItem(item);
            return GetTopNeighbour(coords.X, coords.Y);
        }

        public T GetTopRightNeighbour(T item)
        {
            var coords = GetCoordinateByItem(item);
            return GetTopRightNeighbour(coords.X, coords.Y);
        }

        #endregion Public Methods

        #region Private Methods

        private T GetBottomLeftNeighbour(int x, int y)
        {
            var isEvenColumn = x % 2 == 0;
            return isEvenColumn ? GetTileAt(x - 1, y) : GetTileAt(x - 1, y + 1);
        }

        private T GetBottomNeighbour(int x, int y)
        {
            return GetTileAt(x, y + 1);
        }

        private T GetBottomRightNeighbour(int x, int y)
        {
            var isEvenColumn = x % 2 == 0;
            return isEvenColumn ? GetTileAt(x + 1, y) : GetTileAt(x + 1, y + 1);
        }

        private Coordinate GetCoordinateByIndex(int index)
        {
            return index < 0 ? null : new Coordinate(index % _columns, index / _columns);
        }

        private List<T> GetDiagonalDownwardsLine(int x, int y)
        {
            var result = new List<T>();
            var x1 = x;
            var y1 = y;
            while (x1 > 0 && y1 > 0 || (x1 % 2 != 0 && y1 == 0))
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

        private List<T> GetDiagonalUpwardsLine(int x, int y)
        {
            var result = new List<T>();
            var x1 = x;
            var y1 = y;
            while (x1 > 0 && y1 < Rows - 1)
            {
                if (x1 % 2 == 0)
                {
                    x1--;
                }
                else
                {
                    x1--;
                    y1++;
                }
            }

            if (x1 > 0 && y1 == Rows - 1 && x1 % 2 == 0) x1--;

            while (x1 < _columns && y1 >= 0)
            {
                result.AddNotNull(GetTileAt(x1, y1));
                if (x1 % 2 == 0)
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

        private IEnumerable<T> GetNeighbours(int x, int y, int distance)
        {
            if (distance == 0) return Enumerable.Empty<T>();

            var result = new List<T>();
            var directNeighbours = GetNeighbours(x, y).ToList();
            result.AddRange(directNeighbours);
            foreach (var directNeighbour in directNeighbours)
            {
                result.AddRange(GetNeighbours(directNeighbour, distance - 1));
            }

            return result.Distinct().ToList();
        }

        private IEnumerable<T> GetNeighbours(int x, int y)
        {
            var neighbours = new List<T>();
            neighbours.AddNotNull(GetTopLeftNeighbour(x, y));
            neighbours.AddNotNull(GetTopNeighbour(x, y));
            neighbours.AddNotNull(GetTopRightNeighbour(x, y));
            neighbours.AddNotNull(GetBottomLeftNeighbour(x, y));
            neighbours.AddNotNull(GetBottomRightNeighbour(x, y));
            neighbours.AddNotNull(GetBottomNeighbour(x, y));
            return neighbours;
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

        private T GetTileAt(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _columns || y >= Rows) return null;
            var tileIndex = y * _columns + x;
            return tileIndex >= Tiles.Count ? null : Tiles[tileIndex];
        }

        private T GetTopLeftNeighbour(int x, int y)
        {
            var isEvenColumn = x % 2 == 0;
            return isEvenColumn ? GetTileAt(x - 1, y - 1) : GetTileAt(x - 1, y);
        }

        private T GetTopNeighbour(int x, int y)
        {
            return GetTileAt(x, y - 1);
        }

        private T GetTopRightNeighbour(int x, int y)
        {
            var isEvenColumn = x % 2 == 0;
            return isEvenColumn ? GetTileAt(x + 1, y - 1) : GetTileAt(x + 1, y);
        }

        #endregion Private Methods
    }
}