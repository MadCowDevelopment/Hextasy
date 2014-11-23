using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.AccessControl;
using Caliburn.Micro;
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

            if (tile.Building.Level == tile.Building.MaxLevel) return;

            var connectedBuildings = GetConnectedBuildings(tile);
            while (connectedBuildings.Count >= 2)
            {
                connectedBuildings.ForEach(p =>
                {
                    p.Building = null;
                    p.IsFixed = false;
                });

                tile.Building.LevelUp();
                connectedBuildings = GetConnectedBuildings(tile);
            }

            if (Tiles.Any(p => p.Building == null)) return;
            RaiseFinished(new GameFinishedEventArgs<VillagersStatistics>(new VillagersStatistics()));
        }

        private List<VillagersTile> GetConnectedBuildings(VillagersTile tile)
        {
            if (tile.Building == null) return new List<VillagersTile>();

            var neighbours = GetNeighbourBuildings(tile).ToList();
            var neighboursToCheck = new Queue<VillagersTile>(neighbours);
            while (neighboursToCheck.Count > 0)
            {
                var currentNeighbour = neighboursToCheck.Dequeue();
                var newNeighboursToCheck = GetNeighbourBuildings(currentNeighbour).Where(p => !neighbours.Contains(p) && p != tile).ToList();
                newNeighboursToCheck.Apply(neighboursToCheck.Enqueue);
                neighbours.AddRange(newNeighboursToCheck);
            }

            return neighbours.Distinct().ToList();
        }

        private IEnumerable<VillagersTile> GetNeighbourBuildings(VillagersTile tile)
        {
            return
                HexMap.GetNeighbours(tile)
                    .Where(
                        p =>
                            p.Building != null && p.Building.Type == tile.Building.Type &&
                            p.Building.Level == tile.Building.Level &&
                            p != tile);
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