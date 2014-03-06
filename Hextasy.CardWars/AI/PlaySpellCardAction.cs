using System;
using System.Linq;
using Hextasy.CardWars.Cards;

namespace Hextasy.CardWars.AI
{
    internal class PlaySpellCardAction : PlayerAction
    {
        private readonly Guid _targetTileId;
        private readonly Guid _spellCardId;

        public PlaySpellCardAction(Guid targetTileId, Guid spellCardId)
        {
            _targetTileId = targetTileId;
            _spellCardId = spellCardId;
        }

        public override void Perform(CardWarsGameLogic gameLogic, bool delayAction)
        {
            var targetTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _targetTileId);
            var spellCard = gameLogic.CurrentPlayerHand.Single(p => p.Id == _spellCardId) as SpellCard;
            if(delayAction) Wait();
            spellCard.IsSelected = true;
            if (delayAction) Wait();
            gameLogic.PlaySpellCard(targetTile, spellCard);
        }
    }
}