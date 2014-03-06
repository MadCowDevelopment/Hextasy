using System;
using System.Linq;
using Hextasy.CardWars.Cards;

namespace Hextasy.CardWars.AI
{
    internal class PlayMonsterCardAction : PlayerAction
    {
        private readonly Guid _targetTileId;
        private readonly Guid _monsterCardId;

        public PlayMonsterCardAction(Guid targetTileId, Guid monsterCardId)
        {
            _targetTileId = targetTileId;
            _monsterCardId = monsterCardId;
        }

        public override void Perform(CardWarsGameLogic gameLogic, bool delayAction)
        {
            var targetTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _targetTileId);
            var monsterCard = gameLogic.CurrentPlayerHand.Single(p => p.Id == _monsterCardId) as MonsterCard;
            if (delayAction) Wait();
            monsterCard.IsSelected = true;
            if (delayAction) Wait();
            gameLogic.PlayMonsterCard(targetTile, monsterCard);
        }
    }
}