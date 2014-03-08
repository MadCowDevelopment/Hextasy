using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class BurnEnemyMonstersTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Constructors

        public BurnEnemyMonstersTrait(MonsterCard cardThatHasTrait, int amount)
            : base(cardThatHasTrait)
        {
            Amount = amount;
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Burn enemy monsters."; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Traits/fire-arrows-3.png"; }
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
            cardWarsGameLogic.OpponentCards.Apply(p => p.TakeFireDamage(Amount));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new BurnEnemyMonstersTrait(monsterCard, Amount);
        }

        #endregion Public Methods
    }
}