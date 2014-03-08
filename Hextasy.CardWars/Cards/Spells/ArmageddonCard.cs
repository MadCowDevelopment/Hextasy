using System.ComponentModel.Composition;

using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ArmageddonCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 10; }
        }

        public override string Description
        {
            get { return "Destroy all monsters."; }
        }

        public override string Name
        {
            get { return "Armageddon"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "explosion-orange-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.AllCardsExceptKing.Apply(p => p.Kill());
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new ArmageddonCard();
        }

        #endregion Protected Methods
    }
}