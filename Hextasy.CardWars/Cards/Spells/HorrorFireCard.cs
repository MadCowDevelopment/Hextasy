using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class HorrorFireCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 6; }
        }

        public override string Description
        {
            get { return "Kills the target and burns all adjacent enemies for 2 damage."; }
        }

        public override string Name
        {
            get { return "Horror: Fire"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "horror-red-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.Kill();
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.Card.TakeFireDamage(2));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HorrorFireCard();
        }

        #endregion Protected Methods
    }
}