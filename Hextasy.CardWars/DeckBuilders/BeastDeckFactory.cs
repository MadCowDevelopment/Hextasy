using System.Collections.Generic;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Monsters;
using Hextasy.CardWars.Cards.Spells;

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
                    new DiviciacusCard(),
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
                    new DiviciacusCard(),
                    new GryphonCard(),
                    new HorseCard(),
                    new MuleCard(),
                    new SpiderCard(),
                    new TurtleCard(),
                    new WarElephantCard(),
                    new WolfCard(),
                    new WormCard(),
                    new ChainLightningPoisonSpell(),
                    new LesserAcidballCard(),
                    new AcidballCard(),
                    new GreaterAcidballCard(),
                    new HorrorPoisonCard(),
                    new TwisterPoisonCard()
                };
            }
        }
    }
}
