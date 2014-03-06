using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonThiefCard : MonsterCard
    {
        public SkeletonThiefCard()
        {
            Traits.Add(new StealCardTrait(this));
        }

        public override string Name
        {
            get { return "Skeleton Thief"; }
        }

        public override string Description
        {
            get { return "Steals a random card from your opponent's hand at the start of your turn."; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        protected override string ImageFilename
        {
            get { return "SkeletonFighter5.png"; }
        }

        protected override Card CreateInstance()
        {
            return new SkeletonThiefCard();
        }

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 1; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }
    }
}