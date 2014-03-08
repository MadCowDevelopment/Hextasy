using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class IncreaseRandomMonsterAttackTrait : Trait, IActivateTraitOnEndTurn
    {
        #region Constructors

        public IncreaseRandomMonsterAttackTrait(MonsterCard cardThatHasTrait, int amount)
            : base(cardThatHasTrait)
        {
            Amount = amount;
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Increase Monster Attack"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Traits/Sword20.PNG"; }
        }

        #endregion Protected Properties

        #region Private Properties

        private int Amount
        {
            get; set;
        }

        #endregion Private Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var friendlyMonster = cardWarsGameLogic.CurrentPlayerCardsExceptKing.RandomOrDefault();
            if (friendlyMonster != null) friendlyMonster.AttackBonus += Amount;
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new IncreaseRandomMonsterAttackTrait(monsterCard, Amount);
        }

        #endregion Public Methods
    }
}