using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanInquisitorFemaleCard : MonsterCard
    {
        #region Constructors

        public HumanInquisitorFemaleCard()
        {
            Traits.Add(new InquisitorTrait(this));
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
            get { return "33% chance to subdue a random enemy or kill an undead at the start of your turn."; }
        }

        public override string Name
        {
            get { return "Female Inquisitor"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"FemalePriest02.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanInquisitorFemaleCard();
        }

        #endregion Protected Methods
    }
}