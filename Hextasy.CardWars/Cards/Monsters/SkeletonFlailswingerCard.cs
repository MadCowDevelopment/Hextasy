using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonFlailswingerCard : MonsterCard
    {
        public override string Name
        {
            get { return "Skeleton Flailswinger"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        protected override string ImageFilename
        {
            get { return "SkeletonFighter11.png"; }
        }

        protected override Card CreateInstance()
        {
            return new SkeletonFlailswingerCard();
        }

        public override int BaseAttack
        {
            get { return 3; }
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
