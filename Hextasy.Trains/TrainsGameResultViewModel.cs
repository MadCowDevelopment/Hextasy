using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Trains
{
    [Export(typeof(TrainsGameResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TrainsGameResultViewModel : GameResultViewModel<TrainsStatistics>
    {
    }
}