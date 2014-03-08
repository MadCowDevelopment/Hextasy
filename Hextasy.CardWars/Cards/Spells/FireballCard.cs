using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class FireballCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 4; }
        }

        public override string Description
        {
            get { return "Burns the target monster for 5 damage."; }
        }

        public override string Name
        {
            get { return "Fireball"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "fireball-red-2.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.TakeFireDamage(5);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new FireballCard();
        }

        #endregion Protected Methods
    }
}