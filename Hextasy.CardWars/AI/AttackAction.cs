using System;
using System.Linq;

namespace Hextasy.CardWars.AI
{
    internal class AttackAction : PlayerAction
    {
        private readonly CardWarsTile _attackerTile;
        private readonly CardWarsTile _defenderTile;

        public AttackAction(CardWarsTile attackerTile, CardWarsTile defenderTile)
        {
            _attackerTile = attackerTile;
            _defenderTile = defenderTile;
        }

        public Guid AttackerTileId { get { return _attackerTile.Id; } }

        public override void Perform(CardWarsGameLogic gameLogic, bool delayAction)
        {
            var attackerTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _attackerTile.Id);
            var defenderTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _defenderTile.Id);

            if (delayAction) Wait();
            gameLogic.SelectTile(attackerTile);

            if(delayAction) Wait();
            gameLogic.AttackCard(defenderTile);
        }
    }
}