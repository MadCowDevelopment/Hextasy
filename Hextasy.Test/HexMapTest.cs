using System;
using System.Collections.Generic;
using System.Linq;

using Hextasy.Framework;

using Xunit;

namespace Hextasy.Test
{
    public class HexMapTest
    {
        #region Fields

        private HexMap<Tile> _objectUnderTest;

        #endregion Fields

        #region Constructors

        public HexMapTest()
        {
            CreateObjectUnderTest(6, 4);
        }

        #endregion Constructors

        #region Public Methods

        [Fact]
        public void GetLinesShouldReturnCorrectLinesFor0x0y()
        {
            var lines = _objectUnderTest.GetLines(new Tile(0,0)).ToList();

            Assert.Equal(3, lines.Count());

            Assert.Equal(1, lines[0].Count());
            Assert.Equal(new Tile(0, 0), (lines[0]).ToList()[0]);

            Assert.Equal(6, lines[1].Count());
            Assert.Equal(new Tile(0, 0), (lines[1]).ToList()[0]);
            Assert.Equal(new Tile(1, 0), (lines[1]).ToList()[1]);
            Assert.Equal(new Tile(2, 1), (lines[1]).ToList()[2]);
            Assert.Equal(new Tile(3, 1), (lines[1]).ToList()[3]);
            Assert.Equal(new Tile(4, 2), (lines[1]).ToList()[4]);
            Assert.Equal(new Tile(5, 2), (lines[1]).ToList()[5]);

            Assert.Equal(4, lines[2].Count());
            Assert.Equal(new Tile(0, 0), (lines[2]).ToList()[0]);
            Assert.Equal(new Tile(0, 1), (lines[2]).ToList()[1]);
            Assert.Equal(new Tile(0, 2), (lines[2]).ToList()[2]);
            Assert.Equal(new Tile(0, 3), (lines[2]).ToList()[3]);
        }

        [Fact]
        public void GetLinesShouldReturnCorrectLinesFor1x0y()
        {
            var lines = _objectUnderTest.GetLines(new Tile(1,0)).ToList();

            Assert.Equal(3, lines.Count());

            Assert.Equal(3, lines[0].Count());
            Assert.Equal(new Tile(0, 1), (lines[0]).ToList()[0]);
            Assert.Equal(new Tile(1, 0), (lines[0]).ToList()[1]);
            Assert.Equal(new Tile(2, 0), (lines[0]).ToList()[2]);

            Assert.Equal(6, lines[1].Count());
            Assert.Equal(new Tile(0, 0), (lines[1]).ToList()[0]);
            Assert.Equal(new Tile(1, 0), (lines[1]).ToList()[1]);
            Assert.Equal(new Tile(2, 1), (lines[1]).ToList()[2]);
            Assert.Equal(new Tile(3, 1), (lines[1]).ToList()[3]);
            Assert.Equal(new Tile(4, 2), (lines[1]).ToList()[4]);
            Assert.Equal(new Tile(5, 2), (lines[1]).ToList()[5]);

            Assert.Equal(4, lines[2].Count());
            Assert.Equal(new Tile(1, 0), (lines[2]).ToList()[0]);
            Assert.Equal(new Tile(1, 1), (lines[2]).ToList()[1]);
            Assert.Equal(new Tile(1, 2), (lines[2]).ToList()[2]);
            Assert.Equal(new Tile(1, 3), (lines[2]).ToList()[3]);
        }

        [Fact]
        public void GetLinesShouldReturnCorrectLinesFor2x2y()
        {
            var lines = _objectUnderTest.GetLines(new Tile(2,2)).ToList();

            Assert.Equal(3, lines.Count());

            Assert.Equal(6, lines[0].Count());
            Assert.Equal(new Tile(0, 3), (lines[0]).ToList()[0]);
            Assert.Equal(new Tile(1, 2), (lines[0]).ToList()[1]);
            Assert.Equal(new Tile(2, 2), (lines[0]).ToList()[2]);
            Assert.Equal(new Tile(3, 1), (lines[0]).ToList()[3]);
            Assert.Equal(new Tile(4, 1), (lines[0]).ToList()[4]);
            Assert.Equal(new Tile(5, 0), (lines[0]).ToList()[5]);

            Assert.Equal(6, lines[1].Count());
            Assert.Equal(new Tile(0, 1), (lines[1]).ToList()[0]);
            Assert.Equal(new Tile(1, 1), (lines[1]).ToList()[1]);
            Assert.Equal(new Tile(2, 2), (lines[1]).ToList()[2]);
            Assert.Equal(new Tile(3, 2), (lines[1]).ToList()[3]);
            Assert.Equal(new Tile(4, 3), (lines[1]).ToList()[4]);
            Assert.Equal(new Tile(5, 3), (lines[1]).ToList()[5]);

            Assert.Equal(4, lines[2].Count());
            Assert.Equal(new Tile(2, 0), (lines[2]).ToList()[0]);
            Assert.Equal(new Tile(2, 1), (lines[2]).ToList()[1]);
            Assert.Equal(new Tile(2, 2), (lines[2]).ToList()[2]);
            Assert.Equal(new Tile(2, 3), (lines[2]).ToList()[3]);
        }

        [Fact]
        public void GetLinesShouldReturnCorrectLinesFor3x0yIn5Column3RowsGrid()
        {
            CreateObjectUnderTest(5, 3);

            var lines = _objectUnderTest.GetLines(new Tile(3, 0)).ToList();

            Assert.Equal(3, lines.Count());

            Assert.Equal(5, lines[0].Count());
            Assert.Equal(new Tile(0, 2), (lines[0]).ToList()[0]);
            Assert.Equal(new Tile(1, 1), (lines[0]).ToList()[1]);
            Assert.Equal(new Tile(2, 1), (lines[0]).ToList()[2]);
            Assert.Equal(new Tile(3, 0), (lines[0]).ToList()[3]);
            Assert.Equal(new Tile(4, 0), (lines[0]).ToList()[4]);

            Assert.Equal(3, lines[1].Count());
            Assert.Equal(new Tile(2, 0), (lines[1]).ToList()[0]);
            Assert.Equal(new Tile(3, 0), (lines[1]).ToList()[1]);
            Assert.Equal(new Tile(4, 1), (lines[1]).ToList()[2]);

            Assert.Equal(3, lines[2].Count());
            Assert.Equal(new Tile(3, 0), (lines[2]).ToList()[0]);
            Assert.Equal(new Tile(3, 1), (lines[2]).ToList()[1]);
            Assert.Equal(new Tile(3, 2), (lines[2]).ToList()[2]);
        }

        [Fact]
        public void GetLinesShouldReturnCorrectLinesFor4x3y()
        {
            var lines = _objectUnderTest.GetLines(new Tile(4, 3)).ToList();

            Assert.Equal(3, lines.Count());

            Assert.Equal(3, lines[0].Count());
            Assert.Equal(new Tile(3, 3), (lines[0]).ToList()[0]);
            Assert.Equal(new Tile(4, 3), (lines[0]).ToList()[1]);
            Assert.Equal(new Tile(5, 2), (lines[0]).ToList()[2]);

            Assert.Equal(6, lines[1].Count());
            Assert.Equal(new Tile(0, 1), (lines[1]).ToList()[0]);
            Assert.Equal(new Tile(1, 1), (lines[1]).ToList()[1]);
            Assert.Equal(new Tile(2, 2), (lines[1]).ToList()[2]);
            Assert.Equal(new Tile(3, 2), (lines[1]).ToList()[3]);
            Assert.Equal(new Tile(4, 3), (lines[1]).ToList()[4]);
            Assert.Equal(new Tile(5, 3), (lines[1]).ToList()[5]);

            Assert.Equal(4, lines[2].Count());
            Assert.Equal(new Tile(4, 0), (lines[2]).ToList()[0]);
            Assert.Equal(new Tile(4, 1), (lines[2]).ToList()[1]);
            Assert.Equal(new Tile(4, 2), (lines[2]).ToList()[2]);
            Assert.Equal(new Tile(4, 3), (lines[2]).ToList()[3]);
        }

        [Fact]
        public void GetLinesShouldReturnCorrectLinesFor5x0y()
        {
            var lines = _objectUnderTest.GetLines(new Tile(5,0)).ToList();

            Assert.Equal(3, lines.Count());

            Assert.Equal(6, lines[0].Count());
            Assert.Equal(new Tile(0, 3), (lines[0]).ToList()[0]);
            Assert.Equal(new Tile(1, 2), (lines[0]).ToList()[1]);
            Assert.Equal(new Tile(2, 2), (lines[0]).ToList()[2]);
            Assert.Equal(new Tile(3, 1), (lines[0]).ToList()[3]);
            Assert.Equal(new Tile(4, 1), (lines[0]).ToList()[4]);
            Assert.Equal(new Tile(5, 0), (lines[0]).ToList()[5]);

            Assert.Equal(2, lines[1].Count());
            Assert.Equal(new Tile(4, 0), (lines[1]).ToList()[0]);
            Assert.Equal(new Tile(5, 0), (lines[1]).ToList()[1]);

            Assert.Equal(4, lines[2].Count());
            Assert.Equal(new Tile(5, 0), (lines[2]).ToList()[0]);
            Assert.Equal(new Tile(5, 1), (lines[2]).ToList()[1]);
            Assert.Equal(new Tile(5, 2), (lines[2]).ToList()[2]);
            Assert.Equal(new Tile(5, 3), (lines[2]).ToList()[3]);
        }

        [Fact]
        public void GetLinesShouldReturnCorrectLinesFor5x3y()
        {
            var lines = _objectUnderTest.GetLines(new Tile(5, 3)).ToList();

            Assert.Equal(3, lines.Count());

            Assert.Equal(1, lines[0].Count());
            Assert.Equal(new Tile(5, 3), (lines[0]).ToList()[0]);

            Assert.Equal(6, lines[1].Count());
            Assert.Equal(new Tile(0, 1), (lines[1]).ToList()[0]);
            Assert.Equal(new Tile(1, 1), (lines[1]).ToList()[1]);
            Assert.Equal(new Tile(2, 2), (lines[1]).ToList()[2]);
            Assert.Equal(new Tile(3, 2), (lines[1]).ToList()[3]);
            Assert.Equal(new Tile(4, 3), (lines[1]).ToList()[4]);
            Assert.Equal(new Tile(5, 3), (lines[1]).ToList()[5]);

            Assert.Equal(4, lines[2].Count());
            Assert.Equal(new Tile(5, 0), (lines[2]).ToList()[0]);
            Assert.Equal(new Tile(5, 1), (lines[2]).ToList()[1]);
            Assert.Equal(new Tile(5, 2), (lines[2]).ToList()[2]);
            Assert.Equal(new Tile(5, 3), (lines[2]).ToList()[3]);
        }

        [Fact]
        public void GetTilesBetween5x2yAnd3x3y()
        {
            var tilesBetween = _objectUnderTest.GetTilesBetween(new Tile(5, 2), new Tile(3, 3)).ToList();

            Assert.Equal(1, tilesBetween.Count);
            Assert.Equal(new Tile(4, 3), tilesBetween[0]);
        }

        #endregion Public Methods

        #region Private Methods

        private void CreateObjectUnderTest(int columns, int rows)
        {
            var tiles = CreateTiles(columns, rows);
            _objectUnderTest = new HexMap<Tile>(tiles, columns);
        }

        private IEnumerable<Tile> CreateTiles(int columns, int rows)
        {
            var result = new List<Tile>();
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    result.Add(new Tile(x, y));
                }
            }

            return result;
        }

        #endregion Private Methods
    }

    public class Tile : IEquatable<Tile>
    {
        #region Constructors

        public Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion Constructors

        #region Public Properties

        public int X
        {
            get; private set;
        }

        public int Y
        {
            get; private set;
        }

        #endregion Public Properties

        #region Public Methods

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Tile) obj);
        }

        public bool Equals(Tile other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }

        #endregion Public Methods
    }
}