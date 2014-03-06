using System;
using System.Linq;

namespace Hextasy.CardWars.AI
{
    internal class AttackAction : PlayerAction
    {
        private readonly Guid _targetTileId;

        public AttackAction(Guid targetTileId)
        {
            _targetTileId = targetTileId;
        }

        public override void Perform(CardWarsGameLogic gameLogic)
        {
            var targetTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _targetTileId);
            Wait();
            gameLogic.AttackCard(targetTile);
        }
    }
}