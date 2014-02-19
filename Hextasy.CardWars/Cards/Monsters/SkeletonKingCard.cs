using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonKingCard : MonsterCard
    {
        public SkeletonKingCard()
        {
            Traits.Add(new SkeletonKingInitiativeTrait());
        }

        public override string Name
        {
            get { return "Skeleton King"; }
        }

        public override string Description
        {
            get { return "Initiative: Gives -2 attack to all adjacent humans and +2 attack to all adjacent undead."; }
        }

        public override int Cost
        {
            get { return 8; }
        }

        protected override string ImageFilename
        {
            get { return "WraithKing.png"; }
        }

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 4; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }
    }
}
