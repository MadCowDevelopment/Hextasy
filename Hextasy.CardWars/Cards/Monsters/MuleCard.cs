using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class MuleCard : MonsterCard
    {
        #region Constructors

        public MuleCard()
        {
            Traits.Add(new DrawCardOnEndTurnTrait(this));
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
            get { return 4; }
        }

        public override string Description
        {
            get { return "Draw 1 card at the end of your turn."; }
        }

        public override string Name
        {
            get { return "Packmule"; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Mule.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new MuleCard();
        }

        #endregion Protected Methods
    }
}