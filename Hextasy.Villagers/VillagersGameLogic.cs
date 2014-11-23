﻿using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.Villagers
{
    [Export(typeof(VillagersGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VillagersGameLogic : GameLogic<VillagersSettings, VillagersTile, VillagersStatistics>
    {
        protected override VillagersTile CreateTile(int column, int row)
        {
            return new VillagersTile();
        }

        public void PlaceItem(VillagersTile tile)
        {
            
        }

        public void PreviewPlaceItem(VillagersTile tile)
        {
            
        }

        public void PreviewRemoveItem(VillagersTile tile)
        {
            
        }
    }
}