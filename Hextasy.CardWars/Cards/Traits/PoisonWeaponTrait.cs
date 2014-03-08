using Hextasy.CardWars.Cards.Debuffs;

namespace Hextasy.CardWars.Cards.Traits
{
    public class PoisonWeaponTrait : Trait, IActivateTraitOnAttack, IActivateTraitOnDefense
    {
        #region Constructors

        public PoisonWeaponTrait(MonsterCard cardThatHasTrait, int amount, int duration)
            : base(cardThatHasTrait)
        {
            Amount = amount;
            Duration = duration;
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Poison Weapon"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Spells/enchant-acid-3.png"; }
        }

        #endregion Protected Properties

        #region Private Properties

        private int Amount
        {
            get; set;
        }

        private int Duration
        {
            get; set;
        }

        #endregion Private Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new PoisonDebuff(Amount, Duration));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new PoisonWeaponTrait(monsterCard, Amount, Duration);
        }

        #endregion Public Methods
    }
}