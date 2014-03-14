using System.ComponentModel.Composition;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class LesserFireballCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 1; }
        }

        public override string Description
        {
            get { return "Burns the target monster for 2 damage."; }
        }

        public override string Name
        {
            get { return "Lesser Fireball"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "fireball-red-1.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.TakeFireDamage(2);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new LesserFireballCard();
        }

        #endregion Protected Methods
    }
}