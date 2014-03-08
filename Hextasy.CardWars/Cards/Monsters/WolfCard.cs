using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class WolfCard : MonsterCard
    {
        #region Constructors

        public WolfCard()
        {
            Traits.Add(new DodgeTrait(this));
            Traits.Add(new CounterAttackOnDodgeTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 3; }
        }

        public override int BaseHealth
        {
            get { return 1; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        public override string Description
        {
            get { return "66% chance to dodge. Attacks a random enemy monster when dodging."; }
        }

        public override string Name
        {
            get { return "Wolf"; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Wolf.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new WolfCard();
        }

        #endregion Protected Methods
    }
}