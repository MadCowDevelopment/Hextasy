using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    [Export(typeof(YinshGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class YinshGameLogic : GameLogic<YinshSettings, YinshTile, YinshStatistics>
    {
        protected override YinshTile CreateTile(int column, int row)
        {
            if (row == 0)
            {
                if (column > 2 && column < 8) return new YinshTile();
            }
            else if (row == 1 || row == 2 || row == 7)
            {
                if (column > 0 && column < 10) return new YinshTile();
            }
            else if (row == 8)
            {
                if (column > 1 && column < 9) return new YinshTile();
            }
            else if (row == 9)
            {
                if (column == 4 || column == 6) return new YinshTile();
            }
            else if (row > 2 && row < 7)
            {
                return new YinshTile();
            }

            return null;
        }
    }
}