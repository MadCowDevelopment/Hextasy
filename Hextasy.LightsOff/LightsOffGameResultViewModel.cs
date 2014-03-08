using System.ComponentModel.Composition;

using Hextasy.Framework;

namespace Hextasy.LightsOff
{
    [Export(typeof(LightsOffGameResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LightsOffGameResultViewModel : GameResultViewModel<LightsOffStatistics>
    {
    }
}