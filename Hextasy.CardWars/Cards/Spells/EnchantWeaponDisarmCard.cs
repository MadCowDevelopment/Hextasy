using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class EnchantWeaponDisarmCard : SpellCard
    {
        public override string Name
        {
            get { return "Enchant Weapon: Disarm"; }
        }

        public override string Description
        {
            get { return "Enchants a weapon to give the opponent -2 attack."; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        protected override string ImageFilename
        {
            get { return "enchant-orange-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.AddTrait(new DisarmWeaponTrait(targetTile.Card));
        }
    }
}