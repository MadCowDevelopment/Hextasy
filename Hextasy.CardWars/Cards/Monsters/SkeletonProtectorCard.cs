using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonProtectorCard : MonsterCard
    {
        public SkeletonProtectorCard()
        {
            Traits.Add(new DefenderTrait(this));
        }

        public override string Name
        {
            get { return "Skeleton Protector"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        protected override string ImageFilename
        {
            get { return "SkeletonFighter7.png"; }
        }

        public override int BaseAttack
        {
            get { return 1; }
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