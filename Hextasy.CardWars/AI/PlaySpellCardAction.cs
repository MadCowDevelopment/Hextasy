using System.Linq;

using Hextasy.CardWars.Cards;

namespace Hextasy.CardWars.AI
{
    internal class PlaySpellCardAction : PlayerAction
    {
        #region Fields

        private readonly SpellCard _spellCard;
        private readonly CardWarsTile _targetTile;

        #endregion Fields

        #region Constructors

        public PlaySpellCardAction(CardWarsTile targetTile, SpellCard spellCard)
        {
            _targetTile = targetTile;
            _spellCard = spellCard;
        }

        #endregion Constructors

        #region Protected Methods

        protected override void OnPerform(CardWarsGameLogic gameLogic, bool simulated)
        {
            var targetTile = gameLogic.Tiles.SingleOrDefault(p => p.Id == _targetTile.Id);
            var spellCard = gameLogic.CurrentPlayerHand.SingleOrDefault(p => p.Id == _spellCard.Id) as SpellCard;
            if (targetTile == null || spellCard == null) return;
            if (!simulated) Wait();
            spellCard.IsSelected = true;
            if (!simulated) Wait();
            gameLogic.PlaySpellCard(targetTile, spellCard);
        }

        #endregion Protected Methods
    }
}