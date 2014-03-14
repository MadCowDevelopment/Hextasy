using System.ComponentModel.Composition;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class LesserHealCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 1; }
        }

        public override string Description
        {
            get { return "Restores 2 health to the target monster."; }
        }

        public override string Name
        {
            get { return "Lesser Heal"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "heal-jade-1.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.Heal(targetTile.Card, 2);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new LesserHealCard();
        }

        #endregion Protected Methods
    }
}