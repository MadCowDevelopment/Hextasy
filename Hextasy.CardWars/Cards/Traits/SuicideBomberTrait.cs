using Caliburn.Micro;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class SuicideBomberTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Constructors

        public SuicideBomberTrait(MonsterCard cardThatHasTrait, int amount)
            : base(cardThatHasTrait)
        {
            Amount = amount;
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Suicide bomber."; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Traits/link-royal-3.png"; }
        }

        #endregion Protected Properties

        #region Private Properties

        private int Amount
        {
            get;
            set;
        }

        #endregion Private Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.Card.TakeFireDamage(Amount));
            CardThatHasTrait.Kill();
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new SuicideBomberTrait(monsterCard, Amount);
        }

        #endregion Public Methods
    }
}