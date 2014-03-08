using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SkeletonAssassinCard : MonsterCard
    {
        #region Constructors

        public SkeletonAssassinCard()
        {
            Traits.Add(new HasteTrait(this));
            Traits.Add(new DodgeTrait(this));
            Traits.Add(new DrawCardOnDodgeTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 5; }
        }

        public override int BaseHealth
        {
            get { return 2; }
        }

        public override int Cost
        {
            get { return 6; }
        }

        public override string Description
        {
            get { return "66% chance to dodge. Draw card on dodge."; }
        }

        public override string Name
        {
            get { return "Skeleton Assassin"; }
        }

        public override Race Race
        {
            get { return Race.Undead; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "SkeletonFighterLord4.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SkeletonAssassinCard();
        }

        #endregion Protected Methods
    }
}