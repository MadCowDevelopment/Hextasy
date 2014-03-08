using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonKingCard : MonsterCard
    {
        #region Constructors

        public SkeletonKingCard()
        {
            Traits.Add(new SkeletonKingInitiativeTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 4; }
        }

        public override int BaseHealth
        {
            get { return 6; }
        }

        public override int Cost
        {
            get { return 9; }
        }

        public override string Description
        {
            get { return "Initiative: Gives -2 attack to all adjacent enemies and +3 attack to all adjacent undead."; }
        }

        public override string Name
        {
            get { return "Skeleton King"; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "WraithKing.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SkeletonKingCard();
        }

        #endregion Protected Methods
    }
}