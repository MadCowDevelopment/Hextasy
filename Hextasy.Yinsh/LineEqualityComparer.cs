using System.Collections.Generic;
using System.Linq;

namespace Hextasy.Yinsh
{
    internal class LineEqualityComparer : IEqualityComparer<IEnumerable<YinshTile>>
    {
        public bool Equals(IEnumerable<YinshTile> x, IEnumerable<YinshTile> y)
        {
            var leftList = x.ToList();
            var rightList = y.ToList();

            if (leftList.Count != rightList.Count) return false;

            for (int i = 0; i < leftList.Count; i++)
            {
                if (!ReferenceEquals(leftList[i], rightList[i])) return false;
            }

            return true;
        }

        public int GetHashCode(IEnumerable<YinshTile> obj)
        {
            return obj.Sum(p => p.GetHashCode());
        }
    }
}