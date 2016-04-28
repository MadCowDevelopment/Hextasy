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
            return new YinshTile();
        }
    }
}