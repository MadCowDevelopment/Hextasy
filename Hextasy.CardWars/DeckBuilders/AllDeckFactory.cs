using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Hextasy.CardWars.Cards;

namespace Hextasy.CardWars.DeckBuilders
{
    public class AllDeckFactory : DeckFactory
    {
        private readonly IEnumerable<Card> _cards;

        [ImportingConstructor]
        public AllDeckFactory([ImportMany]IEnumerable<Card> cards)
        {
            _cards = cards;
        }

        protected override string Name
        {
            get { return "All"; }
        }

        protected override List<Card> Cards
        {
            get
            {
                var types = _cards.Select(p => p.GetType());
                return new List<Card>(types.Select(p => Activator.CreateInstance(p) as Card));
            }
        }
    }
}
