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

        public override void Perform(CardWarsGameLogic gameLogic)
        {
            var targetTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _targetTileId);
            var spellCard = gameLogic.CurrentPlayerHand.Single(p => p.Id == _spellCardId) as SpellCard;
            Wait();
            spellCard.IsSelected = true;
            Wait();
            gameLogic.PlaySpellCard(targetTile, spellCard);
        }
    }
}