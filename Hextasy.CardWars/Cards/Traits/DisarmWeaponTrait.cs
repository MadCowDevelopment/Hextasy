namespace Hextasy.CardWars.Cards.Traits
{
    public class DisarmWeaponTrait : Trait, IActivateTraitOnAttack, IActivateTraitOnDefense
    {
        public DisarmWeaponTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Frozen Weapon"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Spells/enchant-orange-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            if(targetTile.Card == null) return;
            targetTile.Card.AttackBonus -= 2;
        }
    }
}