using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonCommanderCard : MonsterCard
    {
        public SkeletonCommanderCard()
        {
            Traits.Add(new IncreaseRaceAttackTrait(this, 2, Race.Undead));
            Traits.Add(new IncreaseRaceHealthTrait(this, 2, Race.Undead));
            Traits.Add(new DecreaseRaceAttackTrait(this, 2, Race.Undead));
            Traits.Add(new DecreaseRaceHealthTrait(this, 2, Race.Undead));
        }

        public override string Name
        {
            get { return "Skeleton Commander"; }
        }

        public override string Description
        {
            get { return "Gives all friendly undead +1 attack and +1 health."; }
        }

        public override int Cost
        {
            get { return 8; }
        }

        protected override string ImageFilename
        {
            get { return "SkeletonFighterLord3.png"; }
        }

        public override int BaseAttack
        {
            get { return 4; }
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