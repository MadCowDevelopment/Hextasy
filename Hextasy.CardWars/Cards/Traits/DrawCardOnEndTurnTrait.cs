namespace Hextasy.CardWars.Cards.Traits
{
    public class DrawCardOnEndTurnTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Constructors

        public DrawCardOnEndTurnTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Draw card at the end of your turn."; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Traits/drawcard.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            CardThatHasTrait.Player.DrawCard();
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new DrawCardOnEndTurnTrait(monsterCard);
        }

        #endregion Public Methods
    }
}