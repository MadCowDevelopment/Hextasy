using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonDragonCard : MonsterCard
    {
        public SkeletonDragonCard()
        {
            Traits.Add(new TurnDeadTrait(this));
        }

        public override string Name
        {
            get { return "Bonewing"; }
        }

        public override string Description
        {
            get { return "All dead monsters will rise again as 1/1 skeletons."; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        protected override string ImageFilename
        {
            get { return "DragonGiantBone.png"; }
        }

        public override int BaseAttack
        {
            get { return 7; }
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
