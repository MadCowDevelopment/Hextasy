using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ImmunityFrostCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 2; }
        }

        public override string Description
        {
            get { return "Gives the target and adjacent monsters immunity against frost."; }
        }

        public override string Name
        {
            get { return "Immunity: Frost"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "protect-blue-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentFriendlyTiles(targetTile).Apply(
                p => p.Card.AddTrait(new ImmunityFrostTrait(targetTile.Card)));
            targetTile.Card.AddTrait(new ImmunityFrostTrait(targetTile.Card));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new ImmunityFrostCard();
        }

        #endregion Protected Methods
    }
}