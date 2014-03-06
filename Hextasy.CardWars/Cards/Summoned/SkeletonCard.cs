using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hextasy.CardWars.Cards.Summoned
{
    public class SkeletonCard : MonsterCard
    {
        public override string Name
        {
            get { return "Skeleton"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int Cost
        {
            get { return 0; }
        }

        protected override string ImageFilename
        {
            get { return "Skeleton.png"; }
        }

        protected override Card CreateInstance()
        {
            return new SkeletonCard();
        }

        public override int BaseAttack
        {
            get { return 1; }
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
