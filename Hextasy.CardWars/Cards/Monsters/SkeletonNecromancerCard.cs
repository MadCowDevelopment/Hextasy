using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonNecromancerCard : MonsterCard
    {
        #region Constructors

        public SkeletonNecromancerCard()
        {
            Traits.Add(new SummonUndeadTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 4; }
        }

        public override int Cost
        {
            get { return 4; }
        }

        public override string Description
        {
            get { return "Summons a 1/1 skeleton on an adjacent tile at the start of your turn."; }
        }

        public override string Name
        {
            get { return "Skeleton Necromancer"; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "SkeletonMage3.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SkeletonNecromancerCard();
        }

        #endregion Protected Methods
    }
}