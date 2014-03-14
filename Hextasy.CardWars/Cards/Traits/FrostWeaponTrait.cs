using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class FrostWeaponTrait : Trait, IActivateTraitOnAttack, IActivateTraitOnDefense
    {
        #region Constructors

        public FrostWeaponTrait(MonsterCard cardThatHasTrait)
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
            get { return @"Cards/Spells/enchant-blue-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.AddDebuff(new FrozenDebuff());
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new FrostWeaponTrait(monsterCard);
        }

        #endregion Public Methods
    }
}