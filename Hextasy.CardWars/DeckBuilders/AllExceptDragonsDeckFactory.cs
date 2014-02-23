using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Hextasy.CardWars.Cards;

namespace Hextasy.CardWars.DeckBuilders
{
    public class AllExceptDragonsDeckFactory : DeckFactory
    {
        private readonly IEnumerable<Card> _cards;

        [ImportingConstructor]
        public AllExceptDragonsDeckFactory([ImportMany]IEnumerable<Card> cards)
        {
            _cards = cards;
        }

        protected override string Name
        {
            get { return "All except dragons"; }
        }

        protected override List<Card> Cards
        {
            get
            {
                var types = _cards.Where(p=> !(p is DragonCard)).Select(p => p.GetType());
                return new List<Card>(types.Select(p => Activator.CreateInstance(p) as Card));
            }
        }
    }
}