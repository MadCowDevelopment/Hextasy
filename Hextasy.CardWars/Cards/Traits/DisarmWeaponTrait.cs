namespace Hextasy.CardWars.Cards.Traits
{
    public class DisarmWeaponTrait : Trait, IActivateTraitOnAttack, IActivateTraitOnDefense
    {
        #region Constructors

        public DisarmWeaponTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Frozen Weapon"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Spells/enchant-orange-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            if (targetTile.Card == null) return;
            targetTile.Card.AttackBonus -= 2;
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new DisarmWeaponTrait(monsterCard);
        }

        #endregion Public Methods
    }
}