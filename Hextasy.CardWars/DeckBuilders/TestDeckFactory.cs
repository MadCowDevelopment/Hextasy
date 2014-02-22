using System.Collections.Generic;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Monsters;
using Hextasy.CardWars.Cards.Spells;

namespace Hextasy.CardWars.DeckBuilders
{
    public class TestDeckFactory : DeckFactory
    {
        private List<Card> _cards;

        protected override string Name
        {
            get { return "Test"; }
        }

        protected override List<Card> Cards
        {
            get
            {
                return _cards ?? (_cards = new List<Card>
                {
                    new HealCard(),
                    new LesserHealCard(),
                    new GreaterHealCard(),
                    new BarbarianWarlordCard(),
                    new BarbarianWarlordCard(),
                    new BarbarianWarlordCard(),
                    new BarbarianWarlordCard(),
                    new BarbarianWarlordCard()
                });
            }
        }
    }
}
