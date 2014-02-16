using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Spells
{
    public class EnchantWeaponPoisonCard : SpellCard
    {
        public override string Name
        {
            get { return "Enchant Weapon: Poison"; }
        }

        public override string Description
        {
            get { return "Enchants a weapon to poison defenders for 1 damage for 3 turns."; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        protected override string ImageFilename
        {
            get { return "enchant-acid-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.AddTrait(new PoisonWeaponTrait(1, 3));
        }
    }
}
