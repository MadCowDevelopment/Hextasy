using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanPopeCard : MonsterCard
    {
        #region Constructors

        public HumanPopeCard()
        {
            Traits.Add(new PopeTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 4; }
        }

        public override int Cost
        {
            get { return 8; }
        }

        public override string Description
        {
            get { return "Initiative: Gives all friendly humans +1 attack and heals 2 damage."; }
        }

        public override string Name
        {
            get { return "Pope"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"HumanPriest31B.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanPopeCard();
        }

        #endregion Protected Methods
    }
}