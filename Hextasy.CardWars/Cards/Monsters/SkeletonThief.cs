using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonThief : MonsterCard
    {
        public SkeletonThief()
        {
            Traits.Add(new HasteTrait());
        }

        public override string Name
        {
            get { return "Skeleton Thief"; }
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
            get { return "SkeletonFighter5.png"; }
        }

        public override int BaseAttack
        {
            get { return 5; }
        }

        public override int BaseHealth
        {
            get { return 2; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }
    }
}