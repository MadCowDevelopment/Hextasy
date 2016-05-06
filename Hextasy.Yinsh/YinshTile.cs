using System;
using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    public class YinshTile : HexagonTile
    {
        public YinshTile()
        {
            Id = Guid.NewGuid();
        }

        public bool IsSelected { get; set; }

        public bool IsValidTarget { get; set; }

        public Disc Disc { get; set; }

        public Ring Ring { get; set; }

        public Guid Id { get; private set; }

        public YinshTile DeepCopy()
        {
            var copy = new YinshTile();
            copy.Id = Id;
            copy.IsSelected = IsSelected;
            copy.IsValidTarget = IsValidTarget;
            copy.Disc = Disc?.DeepCopy();
            copy.Ring = Ring?.DeepCopy();
            return copy;
        }
    }
}