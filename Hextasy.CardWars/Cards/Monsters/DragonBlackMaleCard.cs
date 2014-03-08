using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonBlackMaleCard : DragonMaleCard
    {
        #region Constructors

        public DragonBlackMaleCard()
        {
            Traits.Add(new HungryDragonBlackTrait(this));
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
            get { return "Starving: Kills 2 random enemies with 3 or less attack."; }
        }

        public override DragonFlight DragonFlight
        {
            get { return DragonFlight.Black; }
        }

        public override string Name
        {
            get { return "Xyafyiu"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "DragonAncientBlack.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new DragonBlackMaleCard();
        }

        #endregion Protected Methods
    }
}