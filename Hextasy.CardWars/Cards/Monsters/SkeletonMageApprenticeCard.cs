using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonMageApprenticeCard : MonsterCard
    {
        #region Constructors

        public SkeletonMageApprenticeCard()
        {
            Traits.Add(new SuicideBomberTrait(this, 2));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        public override string Description
        {
            get { return "Blows himself up and deals 2 fire damage to all adjacent monsters."; }
        }

        public override string Name
        {
            get { return "Skeleton Mage Apprentice"; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "SkeletonMage2.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SkeletonMageApprenticeCard();
        }

        #endregion Protected Methods
    }
}