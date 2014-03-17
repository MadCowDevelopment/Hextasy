using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class GreaterHealCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 7; }
        }

        public override string Description
        {
            get { return "Restores 5 health to the target monster and 2 health to all adjacent monsters."; }
        }

        public override string Name
        {
            get { return "Greater Heal"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "heal-jade-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.Heal(targetTile.Card, 5);
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => cardWarsGameLogic.Heal(p.Card, 2));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new GreaterHealCard();
        }

        #endregion Protected Methods
    }
}