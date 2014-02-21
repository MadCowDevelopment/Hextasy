using System.Collections.Generic;
using Hextasy.CardWars.Cards;
using Hextasy.CardWars.Cards.Monsters;

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
                    new SkeletonAssassin(),
                    new SkeletonAxeWarrior(),
                    new SkeletonBlademaster(),
                    new SkeletonCommander(),
                    new SkeletonFlailswinger(),
                    new SkeletonKingCard(),
                    new SkeletonMage(),
                    new SkeletonMageApprentice(),
                    new SkeletonNecromancer(),
                    new SkeletonProtector(),
                    new SkeletonThief(),
                    new SkeletonAssassin(),
                    new SkeletonAxeWarrior(),
                    new SkeletonBlademaster(),
                    new SkeletonCommander(),
                    new SkeletonFlailswinger(),
                    new SkeletonKingCard(),
                    new SkeletonMage(),
                    new SkeletonMageApprentice(),
                    new SkeletonNecromancer(),
                    new SkeletonProtector(),
                    new SkeletonThief()
                };
            }
        }
    }
}
