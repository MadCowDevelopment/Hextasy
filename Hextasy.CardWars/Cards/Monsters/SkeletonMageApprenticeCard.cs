using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonMageApprenticeCard : MonsterCard
    {
        public SkeletonMageApprenticeCard()
        {
            Traits.Add(new SuicideBomberTrait(this, 2));
        }

        public override string Name
        {
            get { return "Skeleton Mage Apprentice"; }
        }

        public override string Description
        {
            get { return "Blows himself up and deals 2 fire damage to all adjacent monsters."; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        protected override string ImageFilename
        {
            get { return "SkeletonMage2.png"; }
        }

        public override int BaseAttack
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }
    }
}