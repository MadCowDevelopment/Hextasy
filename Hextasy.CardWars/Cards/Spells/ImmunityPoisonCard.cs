using System.ComponentModel.Composition;

using Caliburn.Micro;

using Hextasy.CardWars.Cards.Traits;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ImmunityPoisonCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 2; }
        }

        public override string Description
        {
            get { return "Gives the target and adjacent monsters immunity against poison."; }
        }

        public override string Name
        {
            get { return "Immunity: Poison"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "protect-acid-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentFriendlyTiles(targetTile).Apply(
                p => p.Card.AddTrait(new ImmunityPoisonTrait(targetTile.Card)));
            targetTile.Card.AddTrait(new ImmunityPoisonTrait(targetTile.Card));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new ImmunityPoisonCard();
        }

        #endregion Protected Methods
    }
}