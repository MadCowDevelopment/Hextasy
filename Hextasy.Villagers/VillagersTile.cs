using Hextasy.Framework;

namespace Hextasy.Villagers
{
    public class VillagersTile : HexagonTile
    {
        public bool IsFixed { get; set; }
        public Building Building { get; set; }
    }
}