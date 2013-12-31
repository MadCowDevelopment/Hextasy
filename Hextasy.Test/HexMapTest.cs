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

        private readonly HexMap<Tile> _objectUnderTest;

        #endregion Fields

        #region Constructors

        public HexMapTest()
        {
            var tiles = CreateTiles();
            _objectUnderTest = new HexMap<Tile>(tiles, 6);
        }

        #endregion Constructors

        #region Public Methods

        [Fact]
        public void LinesShouldReturnCorrectLinesFor0x0y()
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
        public void LinesShouldReturnCorrectLinesFor1x0y()
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
        public void LinesShouldReturnCorrectLinesFor2x2y()
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
        public void LinesShouldReturnCorrectLinesFor5x0y()
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
        public void LinesShouldReturnCorrectLinesFor5x3y()
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

        #endregion Public Methods

        #region Private Methods

        private IEnumerable<Tile> CreateTiles()
        {
            var result = new List<Tile>();
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 6; x++)
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