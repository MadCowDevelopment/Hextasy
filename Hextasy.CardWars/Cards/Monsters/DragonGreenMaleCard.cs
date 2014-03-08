using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonGreenMaleCard : DragonMaleCard
    {
        #region Constructors

        public DragonGreenMaleCard()
        {
            Traits.Add(new HungryDragonGreenTrait(this));
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
            get { return "Saturated: Heals 2 damage of all friendly monsters."; }
        }

        public override DragonFlight DragonFlight
        {
            get { return DragonFlight.Green; }
        }

        public override string Name
        {
            get { return "Yokixum"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "DragonAncientGreen.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new DragonGreenMaleCard();
        }

        #endregion Protected Methods
    }
}