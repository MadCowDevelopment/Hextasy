using System;
using System.Linq;

namespace Hextasy.CardWars.AI
{
    internal class SelectTileAction : PlayerAction
    {
        internal Guid AttackerTileId { get; private set; }

        public SelectTileAction(Guid attackerTileId)
        {
            AttackerTileId = attackerTileId;
        }

        public override void Perform(CardWarsGameLogic gameLogic)
        {
            var attackerTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == AttackerTileId);
            Wait();
            gameLogic.SelectTile(attackerTile);
        }
    }
}