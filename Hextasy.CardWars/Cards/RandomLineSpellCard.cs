using System;
using System.Collections.Generic;
using System.Linq;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards
{
    public abstract class RandomLineSpellCard : SpellCard
    {
        #region Public Methods

        public override sealed void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var targetOwner = GetTargetOwner(cardWarsGameLogic);
            var lines = cardWarsGameLogic.GetLinesOfTiles(targetTile).ToList();
            Func<CardWarsTile, bool> cardBelongsToOpponent = p => p.Owner == targetOwner;
            var randomLine = (from line in lines
                              where line.Count(cardBelongsToOpponent) == lines.Max(p => p.Count(cardBelongsToOpponent))
                              select line).RandomOrDefault();
            if (randomLine == null) return;
            ApplyEffect(randomLine);
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract void ApplyEffect(IEnumerable<CardWarsTile> randomLine);

        protected abstract Owner GetTargetOwner(CardWarsGameLogic cardWarsGameLogic);

        #endregion Protected Methods
    }
}