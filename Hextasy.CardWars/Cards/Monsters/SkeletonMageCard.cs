using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonMageCard : MonsterCard
    {
        #region Constructors

        public SkeletonMageCard()
        {
            Traits.Add(new BurnEnemyMonstersTrait(this, 2));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 5; }
        }

        public override int Cost
        {
            get { return 7; }
        }

        public override string Description
        {
            get { return "Burns all enemy monsters for 2 fire damage at the start of your turn."; }
        }

        public override string Name
        {
            get { return "Skeleton Mage"; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "SkeletonMageLord1.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SkeletonMageCard();
        }

        #endregion Protected Methods
    }
}