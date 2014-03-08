using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanAbbotCard : MonsterCard
    {
        #region Constructors

        public HumanAbbotCard()
        {
            Traits.Add(new RecruitMonkTrait(this));
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
            get { return 7; }
        }

        public override string Description
        {
            get { return "Recruits a 0/2 monk at the end of your turn."; }
        }

        public override string Name
        {
            get { return "Abbot"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"HumanPriest04.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanAbbotCard();
        }

        #endregion Protected Methods
    }
}