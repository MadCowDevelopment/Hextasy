using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonCommanderCard : MonsterCard
    {
        #region Constructors

        public SkeletonCommanderCard()
        {
            Traits.Add(new IncreaseRaceAttackTrait(this, 1, Race.Undead));
            Traits.Add(new IncreaseRaceHealthTrait(this, 1, Race.Undead));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 4; }
        }

        public override int BaseHealth
        {
            get { return 4; }
        }

        public override int Cost
        {
            get { return 8; }
        }

        public override string Description
        {
            get { return "Gives all friendly undead +1 attack and +1 health."; }
        }

        public override string Name
        {
            get { return "Skeleton Commander"; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "SkeletonFighterLord3.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SkeletonCommanderCard();
        }

        #endregion Protected Methods
    }
}