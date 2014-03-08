using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonRedMaleCard : DragonMaleCard
    {
        #region Constructors

        public DragonRedMaleCard()
        {
            Traits.Add(new HungryDragonRedTrait(this));
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
            get { return "Starving: Deals 2 fire damage to all enemies."; }
        }

        public override DragonFlight DragonFlight
        {
            get { return DragonFlight.Red; }
        }

        public override string Name
        {
            get { return "Thichom"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "DragonAncientRed.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new DragonRedMaleCard();
        }

        #endregion Protected Methods
    }
}