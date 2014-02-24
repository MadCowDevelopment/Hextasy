using System.Collections.Generic;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Monsters;
using Hextasy.CardWars.Cards.Spells;

namespace Hextasy.CardWars.DeckBuilders
{
    public class HumanDeckFactory : DeckFactory
    {
        protected override string Name
        {
            get { return "Human"; }
        }

        protected override List<Card> Cards
        {
            get
            {
                return new List<Card>
                {
                    new HumanAbbotCard(),
                    new HumanFrostmageCard(),
                    new HumanInquisitorFemaleCard(),
                    new HumanInquisitorMaleCard(),
                    new HumanPaladinFemaleCard(),
                    new HumanPaladinMaleCard(),
                    new HumanPopeCard(),
                    new HumanPriestCard(),
                    new HumanPriestFemaleCard(),
                    new HumanWarriorCard(),
                    new HumanBishopCard(),
                    new HumanAbbotCard(),
                    new HumanFrostmageCard(),
                    new HumanInquisitorFemaleCard(),
                    new HumanInquisitorMaleCard(),
                    new HumanPaladinFemaleCard(),
                    new HumanPaladinMaleCard(),
                    new HumanPopeCard(),
                    new HumanPriestCard(),
                    new HumanPriestFemaleCard(),
                    new HumanWarriorCard(),
                    new HumanBishopCard(),

                    new ChainLightningHealSpell(),
                    new LesserHealCard(),
                    new HealCard(),
                    new GreaterHealCard(),
                    new HorrorFrostCard(),
                    new TwisterFrostCard(),
                };
            }
        }
    }
}