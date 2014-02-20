using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonAssassin : MonsterCard
    {
        public SkeletonAssassin()
        {
            Traits.Add(new HasteTrait());
            Traits.Add(new DodgeTrait());
            Traits.Add(new DrawCardOnDodgeTrait());
        }

        public override string Name
        {
            get { return "Skeleton Assassin"; }
        }

        public override string Description
        {
            get { return "50% chance to dodge any attack. Draw card on dodge."; }
        }

        public override int Cost
        {
            get { return 6; }
        }

        protected override string ImageFilename
        {
            get { return "SkeletonFighterLord4.png"; }
        }

        public override int BaseAttack
        {
            get { return 6; }
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