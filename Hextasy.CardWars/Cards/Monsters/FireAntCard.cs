using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class FireAntCard : MonsterCard
    {
        #region Constructors

        public FireAntCard()
        {
            Traits.Add(new DrawCardTrait(this, 1));
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
            get { return "Draw 1 card."; }
        }

        public override string Name
        {
            get { return "Fire Ant"; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "AntRed2.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new FireAntCard();
        }

        #endregion Protected Methods
    }
}