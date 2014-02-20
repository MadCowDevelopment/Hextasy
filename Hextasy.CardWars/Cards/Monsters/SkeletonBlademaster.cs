using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonBlademaster : MonsterCard
    {
        public override string Name
        {
            get { return "Skeleton Blademaster"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        protected override string ImageFilename
        {
            get { return "SkeletonFighter6.png"; }
        }

        public override int BaseAttack
        {
            get { return 6; }
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