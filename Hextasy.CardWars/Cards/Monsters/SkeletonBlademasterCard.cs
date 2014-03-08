using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonBlademasterCard : MonsterCard
    {
        #region Public Properties

        public override int BaseAttack
        {
            get { return 6; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override string Name
        {
            get { return "Skeleton Blademaster"; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "SkeletonFighter6.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SkeletonBlademasterCard();
        }

        #endregion Protected Methods
    }
}