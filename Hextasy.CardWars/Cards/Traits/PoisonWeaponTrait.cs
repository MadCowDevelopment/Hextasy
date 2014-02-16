using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Traits
{
    public class PoisonWeaponTrait : Trait, IActivateTraitOnAttack
    {
        private int Amount { get; set; }
        private int Duration { get; set; }

        public PoisonWeaponTrait(int amount, int duration)
        {
            Amount = amount;
            Duration = duration;
        }

        public override string Name
        {
            get { return "Poison Weapon"; }
        }

        public override string ImageFilename
        {
            get { return @"Images\Cards\Spells\enchant-acid-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.AddDebuff(new PoisonDebuff(Amount, Duration));
        }
    }
}
