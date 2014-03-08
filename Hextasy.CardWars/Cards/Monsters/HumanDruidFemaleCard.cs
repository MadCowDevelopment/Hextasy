using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanDruidFemaleCard : MonsterCard
    {
        #region Constructors

        public HumanDruidFemaleCard()
        {
            Traits.Add(new ShapeshifterTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 2; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        public override string Description
        {
            get { return "Transform into a random beast at the start of your turn."; }
        }

        public override string Name
        {
            get { return "Shapeshifter"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"FemaleDruid01.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanDruidFemaleCard();
        }

        #endregion Protected Methods
    }
}