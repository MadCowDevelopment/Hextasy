using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonAssassinCard : MonsterCard
    {
        public SkeletonAssassinCard()
        {
            Traits.Add(new HasteTrait(this));
            Traits.Add(new DodgeTrait(this));
            Traits.Add(new DrawCardOnDodgeTrait(this));
        }

        public override string Name
        {
            get { return "Skeleton Assassin"; }
        }

        public override string Description
        {
            get { return "66% chance to dodge. Draw card on dodge."; }
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
            get { return 5; }
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