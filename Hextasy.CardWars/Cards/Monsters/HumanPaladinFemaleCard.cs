using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanPaladinFemaleCard : MonsterCard
    {
        #region Constructors

        public HumanPaladinFemaleCard()
        {
            Traits.Add(new DefenderTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 2; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override string Name
        {
            get { return "Female Paladin"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"FemalePaladin01.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanPaladinFemaleCard();
        }

        #endregion Protected Methods
    }
}