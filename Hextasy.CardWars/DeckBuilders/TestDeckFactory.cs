using System.Collections.Generic;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Monsters;
using Hextasy.CardWars.Cards.Spells;

namespace Hextasy.CardWars.DeckBuilders
{
    public class TestDeckFactory : DeckFactory
    {
        protected override string Name
        {
            get { return "Test"; }
        }

        protected override List<Card> Cards
        {
            get
            {
                return new List<Card>
                           {
                               new FireAntCard(),
                               new FireAntCard(),
                               new FireAntCard(),
                               new FireAntCard(),
                               new FireAntCard(),
                               new FireAntCard(),
                               new TwisterFrostCard(),
                               new TwisterFrostCard(),
                               new TwisterFrostCard(),
                               new TwisterFrostCard()
                           };
            }
        }
    }
}
