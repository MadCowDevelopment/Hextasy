using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonCommander : MonsterCard
    {
        public SkeletonCommander()
        {
            Traits.Add(new IncreaseRaceAttackTrait(2, Race.Undead));
            Traits.Add(new IncreaseRaceHealthTrait(2, Race.Undead));
            Traits.Add(new DecreaseRaceAttackTrait(2, Race.Undead));
            Traits.Add(new DecreaseRaceHealthTrait(2, Race.Undead));
        }

        public override string Name
        {
            get { return "Skeleton Commander"; }
        }

        public override string Description
        {
            get { return string.Empty; }
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