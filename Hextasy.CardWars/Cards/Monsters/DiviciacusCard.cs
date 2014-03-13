using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DiviciacusCard : MonsterCard
    {
        #region Constructors

        public DiviciacusCard()
        {
            Traits.Add(new IncreaseRaceAttackTrait(this, 2, Race.Beast));
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
            get { return 5; }
        }

        public override string Description
        {
            get { return "Give all friendly beasts +2 attack."; }
        }

        public override string Name
        {
            get { return "Diviciacus"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "HumanDruid04.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new DiviciacusCard();
        }

        #endregion Protected Methods
    }
}