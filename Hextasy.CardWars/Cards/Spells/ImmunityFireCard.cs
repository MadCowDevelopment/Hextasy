using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Cards.Traits;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ImmunityFireCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 2; }
        }

        public override string Description
        {
            get { return "Gives the target and adjacent monsters immunity against fire."; }
        }

        public override string Name
        {
            get { return "Immunity: Fire"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "protect-red-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentFriendlyTiles(targetTile).Apply(
                p => p.Card.AddTrait(new ImmunityFireTrait(targetTile.Card)));
            targetTile.Card.AddTrait(new ImmunityFireTrait(targetTile.Card));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new ImmunityFireCard();
        }

        #endregion Protected Methods
    }
}