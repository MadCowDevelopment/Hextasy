using System.Collections.Generic;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Monsters;
using Hextasy.CardWars.Cards.Spells;

namespace Hextasy.CardWars.DeckBuilders
{
    public class UndeadDeckFactory : DeckFactory
    {
        protected override string Name
        {
            get { return "Undead"; }
        }

        protected override List<Card> Cards
        {
            get
            {
                return new List<Card>
                {
                    new SkeletonAssassinCard(),
                    new SkeletonAxeWarriorCard(),
                    new SkeletonBlademasterCard(),
                    new SkeletonCommanderCard(),
                    new SkeletonDragonCard(),
                    new SkeletonFlailswingerCard(),
                    new SkeletonKingCard(),
                    new SkeletonMageCard(),
                    new SkeletonMageApprenticeCard(),
                    new SkeletonNecromancerCard(),
                    new SkeletonProtectorCard(),
                    new SkeletonThiefCard(),
                    new SkeletonAssassinCard(),
                    new SkeletonAxeWarriorCard(),
                    new SkeletonBlademasterCard(),
                    new SkeletonCommanderCard(),
                    new SkeletonDragonCard(),
                    new SkeletonFlailswingerCard(),
                    new SkeletonKingCard(),
                    new SkeletonMageCard(),
                    new SkeletonMageApprenticeCard(),
                    new SkeletonNecromancerCard(),
                    new SkeletonProtectorCard(),
                    new SkeletonThiefCard(),
                    new ChainLightningFireSpell(),
                    new LesserFireballCard(),
                    new FireballCard(),
                    new GreaterFireballCard(),
                    new HorrorFireCard(),
                    new TwisterFireCard()
                };
            }
        }
    }
}
