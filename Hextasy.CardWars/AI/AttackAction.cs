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

        protected override void OnPerform(CardWarsGameLogic gameLogic, bool simulated)
        {
            var attackerTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _attackerTile.Id);
            var defenderTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _defenderTile.Id);

            if (!simulated) Wait();
            gameLogic.SelectTile(attackerTile);

            if(!simulated) Wait();
            gameLogic.AttackCard(defenderTile);
        }
    }
}