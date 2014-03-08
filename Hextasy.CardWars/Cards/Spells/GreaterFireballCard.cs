using System.ComponentModel.Composition;

using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class GreaterFireballCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 7; }
        }

        public override string Description
        {
            get { return "Burns the target monster for 5 damage and all adjacent monsters for 3 damage."; }
        }

        public override string Name
        {
            get { return "Greater Fireball"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "fireball-red-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.TakeFireDamage(5);
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.Card.TakeFireDamage(3));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new GreaterFireballCard();
        }

        #endregion Protected Methods
    }
}