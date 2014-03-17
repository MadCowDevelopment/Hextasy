using System.Linq;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.AI
{
    internal class AttackCommand : CpuPlayerCommand
    {
        #region Fields

        private readonly CardWarsTile _attackerTile;
        private readonly CardWarsTile _defenderTile;

        #endregion Fields

        #region Constructors

        public AttackCommand(CardWarsTile attackerTile, CardWarsTile defenderTile)
        {
            _attackerTile = attackerTile;
            _defenderTile = defenderTile;
        }

        #endregion Constructors

        #region Protected Methods

        protected override void OnPerform(CardWarsGameLogic gameLogic, bool simulated)
        {
            var attackerTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _attackerTile.Id);
            var defenderTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _defenderTile.Id);

            if (!simulated) Wait();
            gameLogic.SelectTile(attackerTile);

            if (!simulated) Wait();
            gameLogic.AttackCard(defenderTile);
        }

        #endregion Protected Methods
    }
}