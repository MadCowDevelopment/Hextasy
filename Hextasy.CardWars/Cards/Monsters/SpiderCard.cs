using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SpiderCard : MonsterCard
    {
        #region Constructors

        public SpiderCard()
        {
            Traits.Add(new PoisonWeaponTrait(this, 2, 3));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override int Cost
        {
            get { return 4; }
        }

        public override string Description
        {
            get { return "Poisons opponents for 2 damage for 3 turns."; }
        }

        public override string Name
        {
            get { return "Black Widow"; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "SpiderBlack.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SpiderCard();
        }

        #endregion Protected Methods
    }
}