using System.ComponentModel.Composition;
using Hextasy.Framework;

namespace Hextasy.MiningBot
{
    [Export(typeof (MiningBotGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MiningBotGameLogic : GameLogic<MiningBotSettings, MiningBotTile, MiningBotStatistic>
    {
        protected override MiningBotTile CreateTile(int column, int row)
        {
            var soilType = CalculateSoilType(column, row);
            return new MiningBotTile(column, row, soilType);
        }

        protected override void OnSettingsInitialized()
        {
            base.OnSettingsInitialized();

            foreach (var tile in Tiles)
            {
                UpdateOverlays(tile);
            }
        }

        private void UpdateOverlays(MiningBotTile tile)
        {
            var neigbourInfo = new NeighbourInfo(
                HexMap.GetTopNeighbour(tile),
                HexMap.GetTopRightNeighbour(tile),
                HexMap.GetBottomRightNeighbour(tile),
                HexMap.GetBottomNeighbour(tile),
                HexMap.GetBottomLeftNeighbour(tile),
                HexMap.GetTopLeftNeighbour(tile));
            tile.UpdateOverlay(neigbourInfo);
        }

        private SoilType CalculateSoilType(int column, int row)
        {
            if (column == 0 || column == Settings.Columns - 1 || row == 0 || row == Settings.Rows - 1)
                return SoilType.Dirt;
            return (SoilType) RNG.Next(1, 3);
        }
    }

    public class NeighbourInfo
    {
        public MiningBotTile TopNeighbour { get; set; }
        public MiningBotTile TopRightNeighbour { get; set; }
        public MiningBotTile BottomRightNeighbour { get; set; }
        public MiningBotTile BottomNeighbour { get; set; }
        public MiningBotTile BottomLeftNeighbour { get; set; }
        public MiningBotTile TopLeftNeighbour { get; set; }

        public NeighbourInfo(MiningBotTile topNeighbour, MiningBotTile topRightNeighbour,
            MiningBotTile bottomRightNeighbour, MiningBotTile bottomNeighbour, MiningBotTile bottomLeftNeighbour,
            MiningBotTile topLeftNeighbour)
        {
            TopNeighbour = topNeighbour;
            TopRightNeighbour = topRightNeighbour;
            BottomRightNeighbour = bottomRightNeighbour;
            BottomNeighbour = bottomNeighbour;
            BottomLeftNeighbour = bottomLeftNeighbour;
            TopLeftNeighbour = topLeftNeighbour;
        }
    }
}                              