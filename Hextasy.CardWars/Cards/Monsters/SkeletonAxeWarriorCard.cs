using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonAxeWarriorCard : MonsterCard
    {
        public SkeletonAxeWarriorCard()
        {
            Traits.Add(new DefenderTrait());
        }

        public override string Name
        {
            get { return "Skeleton Axe Warrior"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int Cost
        {
            get { return 4; }
        }

        protected override string ImageFilename
        {
            get { return "SkeletonFighter13.png"; }
        }

        public override int BaseAttack
        {
            get { return 2; }
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