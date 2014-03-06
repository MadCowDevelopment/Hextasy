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

        public override void Perform(CardWarsGameLogic gameLogic, bool delayAction)
        {
            var attackerTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == AttackerTileId);
            if(delayAction) Wait();
            gameLogic.SelectTile(attackerTile);
        }
    }
}