using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

using Hextasy.CardWars.Cards;

namespace Hextasy.CardWars.DeckBuilders
{
    public class AllDeckFactory : DeckFactory
    {
        #region Fields

        private readonly IEnumerable<Card> _cards;

        #endregion Fields

        #region Constructors

        [ImportingConstructor]
        public AllDeckFactory([ImportMany]IEnumerable<Card> cards)
        {
            _cards = cards;
        }

        #endregion Constructors

        #region Protected Properties

        protected override List<Card> Cards
        {
            get
            {
                var types = _cards.Select(p => p.GetType());
                return new List<Card>(types.Select(p => Activator.CreateInstance(p) as Card));
            }
        }

        protected override string Name
        {
            get { return "All"; }
        }

        #endregion Protected Properties
    }
}