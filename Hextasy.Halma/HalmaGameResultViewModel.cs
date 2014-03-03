using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Halma
{
    [Export(typeof(HalmaGameResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class HalmaGameResultViewModel : GameResultViewModel<HalmaStatistics>
    {
    }
}