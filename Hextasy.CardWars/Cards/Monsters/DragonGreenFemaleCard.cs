using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonGreenFemaleCard : DragonFemaleCard
    {
        #region Public Properties

        public override int BaseAttack
        {
            get { return 3; }
        }

        public override int BaseHealth
        {
            get { return 7; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        public override string Description
        {
            get { return "Gives birth to a baby dragon at the start of your turn if there is a male dragon present."; }
        }

        public override DragonFlight DragonFlight
        {
            get { return DragonFlight.Green; }
        }

        public override string Name
        {
            get { return "Zoxska"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "DragonAdultGreen.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new DragonGoldFemaleCard();
        }

        #endregion Protected Methods
    }
}