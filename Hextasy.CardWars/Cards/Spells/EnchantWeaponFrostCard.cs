using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class EnchantWeaponFrostCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 3; }
        }

        public override string Description
        {
            get { return "Enchants a weapon to freeze defenders for 1 turn."; }
        }

        public override string Name
        {
            get { return "Enchant Weapon: Frost"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "enchant-blue-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.AddTrait(new FrostWeaponTrait(targetTile.Card));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new EnchantWeaponFrostCard();
        }

        #endregion Protected Methods
    }
}