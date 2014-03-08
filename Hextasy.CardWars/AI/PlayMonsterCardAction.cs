using System;
using System.Linq;

using Hextasy.CardWars.Cards;

namespace Hextasy.CardWars.AI
{
    internal class PlayMonsterCardAction : PlayerAction
    {
        #region Fields

        private readonly MonsterCard _monsterCard;
        private readonly CardWarsTile _targetTile;

        #endregion Fields

        #region Constructors

        public PlayMonsterCardAction(CardWarsTile targetTile, MonsterCard monsterCard)
        {
            _targetTile = targetTile;
            _monsterCard = monsterCard;
        }

        #endregion Constructors

        #region Protected Methods

        protected override void OnPerform(CardWarsGameLogic gameLogic, bool simulated)
        {
            var targetTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _targetTile.Id);
            var monsterCard = gameLogic.CurrentPlayerHand.Single(p => p.Id == _monsterCard.Id) as MonsterCard;
            if (!simulated) Wait();
            monsterCard.IsSelected = true;
            if (!simulated) Wait();
            gameLogic.PlayMonsterCard(targetTile, monsterCard);
        }

        #endregion Protected Methods
    }
}