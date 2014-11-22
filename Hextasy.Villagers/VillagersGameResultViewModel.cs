using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Villagers
{
    [Export(typeof(VillagersGameResultViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VillagersGameResultViewModel : GameResultViewModel<VillagersStatistics>
    {
    }
}