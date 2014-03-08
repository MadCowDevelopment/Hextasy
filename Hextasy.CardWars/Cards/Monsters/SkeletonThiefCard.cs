using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonThiefCard : MonsterCard
    {
        #region Constructors

        public SkeletonThiefCard()
        {
            Traits.Add(new StealCardTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 1; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        public override string Description
        {
            get { return "Steals a random card from your opponent's hand at the start of your turn."; }
        }

        public override string Name
        {
            get { return "Skeleton Thief"; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "SkeletonFighter5.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SkeletonThiefCard();
        }

        #endregion Protected Methods
    }
}