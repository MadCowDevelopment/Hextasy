using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonBlueMaleCard : DragonMaleCard
    {
        #region Constructors

        public DragonBlueMaleCard()
        {
            Traits.Add(new HungryDragonBlueTrait(this));
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
            get { return "Starving: Freezes all enemies."; }
        }

        public override DragonFlight DragonFlight
        {
            get { return DragonFlight.Blue; }
        }

        public override string Name
        {
            get { return "Squlor"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "DragonAncientBlue.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new DragonBlueMaleCard();
        }

        #endregion Protected Methods
    }
}