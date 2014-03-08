using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonProtectorCard : MonsterCard
    {
        #region Constructors

        public SkeletonProtectorCard()
        {
            Traits.Add(new DefenderTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override string Name
        {
            get { return "Skeleton Protector"; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "SkeletonFighter7.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SkeletonProtectorCard();
        }

        #endregion Protected Methods
    }
}