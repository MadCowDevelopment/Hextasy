using System.Collections.Generic;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Monsters;

namespace Hextasy.CardWars.DeckBuilders
{
    public class BeastDeckFactory : DeckFactory
    {
        protected override string Name
        {
            get { return "Beast"; }
        }

        protected override List<Card> Cards
        {
            get
            {
                return new List<Card>
                {
                    new BasiliskCard(),
                    new BatCard(),
                    new BrownBearCard(),
                    new FireAntCard(),
                    new GryphonCard(),
                    new HorseCard(),
                    new MuleCard(),
                    new SpiderCard(),
                    new TurtleCard(),
                    new WarElephantCard(),
                    new WolfCard(),
                    new WormCard(),
                    new BasiliskCard(),
                    new BatCard(),
                    new BrownBearCard(),
                    new FireAntCard(),
                    new GryphonCard(),
                    new HorseCard(),
                    new MuleCard(),
                    new SpiderCard(),
                    new TurtleCard(),
                    new WarElephantCard(),
                    new WolfCard(),
                    new WormCard()
                };
            }
        }
    }
}
