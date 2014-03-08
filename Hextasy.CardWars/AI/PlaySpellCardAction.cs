using System.Linq;
using Hextasy.CardWars.Cards;

namespace Hextasy.CardWars.AI
{
    internal class PlaySpellCardAction : PlayerAction
    {
        private readonly CardWarsTile _targetTile;
        private readonly SpellCard _spellCard;

        public PlaySpellCardAction(CardWarsTile targetTile, SpellCard spellCard)
        {
            _targetTile = targetTile;
            _spellCard = spellCard;
        }

        protected override void OnPerform(CardWarsGameLogic gameLogic, bool simulated)
        {
            var targetTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _targetTile.Id);
            var spellCard = gameLogic.CurrentPlayerHand.Single(p => p.Id == _spellCard.Id) as SpellCard;
            if(!simulated) Wait();
            spellCard.IsSelected = true;
            if (!simulated) Wait();
            gameLogic.PlaySpellCard(targetTile, spellCard);
        }
    }
}