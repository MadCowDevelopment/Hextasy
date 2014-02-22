using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Traits
{
    public class FrostWeaponTrait : Trait, IActivateTraitOnAttack
    {
        public FrostWeaponTrait(MonsterCard cardThatHasTrait) : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Frozen Weapon"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Spells/enchant-blue-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new FrozenDebuff());
        }
    }
}