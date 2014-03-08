using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanPriestFemaleCard : MonsterCard
    {
        #region Constructors

        public HumanPriestFemaleCard()
        {
            Traits.Add(new IncreaseRandomFriendlyMonsterAttackAndHealthTrait(this, 1, 1));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 1; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        public override string Description
        {
            get { return "Gives a random friendly monster +1/+1 at the start of your turn."; }
        }

        public override string Name
        {
            get { return "Female Priest"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"FemalePriest01.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanPriestFemaleCard();
        }

        #endregion Protected Methods
    }
}