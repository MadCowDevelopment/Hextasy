using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Yinsh
{
    [Export(typeof(YinshGameResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class YinshGameResultViewModel : GameResultViewModel<YinshStatistics>
    {
    }
}