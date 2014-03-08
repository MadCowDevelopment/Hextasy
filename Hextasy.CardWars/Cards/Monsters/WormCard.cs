using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class WormCard : MonsterCard
    {
        #region Constructors

        public WormCard()
        {
            Traits.Add(new PoisonWeaponTrait(this, 1, 2));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        public override string Description
        {
            get { return "Poisons opponents for 1 damage for 2 turns."; }
        }

        public override string Name
        {
            get { return "Worm"; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "WormGreen.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new WormCard();
        }

        #endregion Protected Methods
    }
}