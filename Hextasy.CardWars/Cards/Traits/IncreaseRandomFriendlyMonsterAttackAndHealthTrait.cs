using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class IncreaseRandomFriendlyMonsterAttackAndHealthTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Constructors

        public IncreaseRandomFriendlyMonsterAttackAndHealthTrait(MonsterCard cardThatHasTrait, int attack, int health)
            : base(cardThatHasTrait)
        {
            Attack = attack;
            Health = health;
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Increase attack and health"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/enchant-magenta-3.png"; }
        }

        #endregion Protected Properties

        #region Private Properties

        private int Attack
        {
            get;
            set;
        }

        private int Health
        {
            get;
            set;
        }

        #endregion Private Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var randomFriendlyMonster = cardWarsGameLogic.CurrentPlayerCardsExceptKing.RandomOrDefault();
            if (randomFriendlyMonster == null) return;
            randomFriendlyMonster.AttackBonus += Attack;
            randomFriendlyMonster.HealthBonus += Attack;
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new IncreaseRandomFriendlyMonsterAttackAndHealthTrait(monsterCard, Attack, Health);
        }

        #endregion Public Methods
    }
}