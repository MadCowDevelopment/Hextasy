using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Summoned
{
    public class HumanMonkCard : MonsterCard
    {
        #region Constructors

        public HumanMonkCard()
        {
            Traits.Add(new DefenderTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 2; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override string Name
        {
            get { return "Monk"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"HumanPriest01.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanMonkCard();
        }

        #endregion Protected Methods
    }
}