using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class EnchantWeaponPoisonCard : SpellCard
    {
        #region Public Properties

        public override int Cost
        {
            get { return 2; }
        }

        public override string Description
        {
            get { return "Enchants a weapon to poison opponents for 2 damage for 2 turns."; }
        }

        public override string Name
        {
            get { return "Enchant Weapon: Poison"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "enchant-acid-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.AddTrait(new PoisonWeaponTrait(targetTile.Card, 2, 2));
        }

        #endregion Public Methods

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new EnchantWeaponPoisonCard();
        }

        #endregion Protected Methods
    }
}