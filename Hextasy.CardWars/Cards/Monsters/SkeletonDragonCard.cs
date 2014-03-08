using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonDragonCard : MonsterCard
    {
        #region Constructors

        public SkeletonDragonCard()
        {
            Traits.Add(new TurnDeadTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 7; }
        }

        public override int BaseHealth
        {
            get { return 5; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        public override string Description
        {
            get { return "All dead monsters will rise again as 1/1 skeletons."; }
        }

        public override string Name
        {
            get { return "Bonewing"; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "DragonGiantBone.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SkeletonDragonCard();
        }

        #endregion Protected Methods
    }
}