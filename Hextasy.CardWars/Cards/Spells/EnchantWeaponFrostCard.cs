using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class EnchantWeaponFrostCard : SpellCard
    {
        public override string Name
        {
            get { return "Enchant Weapon: Frost"; }
        }

        public override string Description
        {
            get { return "Enchants the weapon of the target monster to freeze attackers."; }
        }

        public override int Cost
        {
            get { return 1; }
        }

        protected override string ImageFilename
        {
            get { return "enchant-blue-3.png"; }
        }
    }
}