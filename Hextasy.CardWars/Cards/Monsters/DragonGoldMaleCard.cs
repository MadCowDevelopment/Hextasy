using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonGoldMaleCard : DragonMaleCard
    {
        #region Constructors

        public DragonGoldMaleCard()
        {
            Traits.Add(new HungryDragonGoldTrait(this));
        }

        #endregion Constructors

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
            get { return "Saturated: Gain 1 card for every 2 health of the eaten monster."; }
        }

        public override DragonFlight DragonFlight
        {
            get { return DragonFlight.Gold; }
        }

        public override string Name
        {
            get { return "Fudron"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "DragonAncientGold.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new DragonGoldMaleCard();
        }

        #endregion Protected Methods
    }
}