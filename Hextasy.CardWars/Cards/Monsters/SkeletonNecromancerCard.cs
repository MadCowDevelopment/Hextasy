using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonNecromancerCard : MonsterCard
    {
        public SkeletonNecromancerCard()
        {
            Traits.Add(new SummonUndeadTrait());
        }

        public override string Name
        {
            get { return "Skeleton Necromancer"; }
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
            get { return "SkeletonMage3.png"; }
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