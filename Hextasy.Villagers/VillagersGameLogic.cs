using System.ComponentModel.Composition;
using System.Security.AccessControl;
using Hextasy.Framework;

namespace Hextasy.Villagers
{
    [Export(typeof(VillagersGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VillagersGameLogic : GameLogic<VillagersSettings, VillagersTile, VillagersStatistics>
    {
        protected override void OnSettingsInitialized()
        {
            base.OnSettingsInitialized();
            InitializeCurrentBuilding();
        }

        private Building CurrentBuilding { get; set; }

        protected override VillagersTile CreateTile(int column, int row)
        {
            return new VillagersTile();
        }

        public void PlaceItem(VillagersTile tile)
        {
            if (tile.IsFixed) return;
            tile.IsFixed = true;
            tile.Building = CurrentBuilding;
            InitializeCurrentBuilding();
        }

        private void InitializeCurrentBuilding()
        {
            CurrentBuilding = Building.Random();
        }

        public void PreviewPlaceItem(VillagersTile tile)
        {
            if (tile.IsFixed) return;
            tile.Building = CurrentBuilding;
        }

        public void PreviewRemoveItem(VillagersTile tile)
        {
            if (tile.IsFixed) return;
            tile.Building = null;
        }
    }
}