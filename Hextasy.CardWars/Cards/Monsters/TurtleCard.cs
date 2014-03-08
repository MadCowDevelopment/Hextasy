using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class TurtleCard : MonsterCard
    {
        #region Constructors

        public TurtleCard()
        {
            Traits.Add(new DefenderTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 3; }
        }

        public override int BaseHealth
        {
            get { return 5; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override string Name
        {
            get { return "Turtle"; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "TurtleBrown.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new TurtleCard();
        }

        #endregion Protected Methods
    }
}