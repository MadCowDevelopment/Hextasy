using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonKingCard : MonsterCard
    {
        public SkeletonKingCard()
        {
            Traits.Add(new SkeletonKingInitiativeTrait(this));
        }

        public override string Name
        {
            get { return "Skeleton King"; }
        }

        public override string Description
        {
            get { return "Initiative: Gives -2 attack to all adjacent enemies and +3 attack to all adjacent undead."; }
        }

        public override int Cost
        {
            get { return 9; }
        }

        protected override string ImageFilename
        {
            get { return "WraithKing.png"; }
        }

        public override int BaseAttack
        {
            get { return 4; }
        }

        public override int BaseHealth
        {
            get { return 6; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }
    }
}
