using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonMageCard : MonsterCard
    {
        public SkeletonMageCard()
        {
            Traits.Add(new BurnEnemyMonstersTrait(this, 2));
        }

        public override string Name
        {
            get { return "Skeleton Mage"; }
        }

        public override string Description
        {
            get { return "Burns all enemy monsters for 2 fire damage at the start of your turn."; }
        }

        public override int Cost
        {
            get { return 7; }
        }

        protected override string ImageFilename
        {
            get { return "SkeletonMageLord1.png"; }
        }

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 5; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }
    }
}