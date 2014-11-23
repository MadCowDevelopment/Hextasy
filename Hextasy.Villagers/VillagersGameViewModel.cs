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

        public void OnTileClick(VillagersTile tile)
        {
            Game.PlaceItem(tile);
        }

        public void OnTileEnter(VillagersTile tile)
        {
            Game.PreviewPlaceItem(tile);
        }

        public void OnTileLeave(VillagersTile tile)
        {
            Game.PreviewRemoveItem(tile);
        }
    }
}