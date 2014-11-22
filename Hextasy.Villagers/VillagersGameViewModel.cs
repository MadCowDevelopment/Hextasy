using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.Villagers
{
    [Export(typeof(VillagersGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VillagersGameViewModel : GameViewModel<VillagersGameLogic, VillagersSettings, VillagersTile, VillagersStatistics>
    {
        [ImportingConstructor]
        public VillagersGameViewModel(VillagersGameLogic game, IEventAggregator eventAggregator) : base(game, eventAggregator)
        {
        }
    }
}