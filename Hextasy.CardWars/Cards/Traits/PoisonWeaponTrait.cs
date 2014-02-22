using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Traits
{
    public class PoisonWeaponTrait : Trait, IActivateTraitOnAttack, IActivateTraitOnDefense
    {
        private int Amount { get; set; }
        private int Duration { get; set; }

        public PoisonWeaponTrait(MonsterCard cardThatHasTrait, int amount, int duration)
            : base(cardThatHasTrait)
        {
            Amount = amount;
            Duration = duration;
        }

        public override string Name
        {
            get { return "Poison Weapon"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Spells/enchant-acid-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new PoisonDebuff(Amount, Duration));
        }
    }
}
