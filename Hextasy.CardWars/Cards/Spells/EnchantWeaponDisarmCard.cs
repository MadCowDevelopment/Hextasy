using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class EnchantWeaponDisarmCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 3; }
        }

        public override string Description
        {
            get { return "Enchants a weapon to give the opponent -2 attack."; }
        }

        public override string Name
        {
            get { return "Enchant Weapon: Disarm"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "enchant-orange-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.AddTrait(new DisarmWeaponTrait(targetTile.Card));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new EnchantWeaponDisarmCard();
        }

        #endregion Protected Methods
    }
}