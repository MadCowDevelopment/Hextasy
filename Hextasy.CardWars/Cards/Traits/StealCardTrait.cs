using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class StealCardTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Constructors

        public StealCardTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Steal card"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/CoinsGoldSmall.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var randomEnemyCardFromHand = cardWarsGameLogic.OpponentPlayer.Hand.RandomOrDefault();
            if (randomEnemyCardFromHand == null) return;
            cardWarsGameLogic.OpponentPlayer.Hand.Remove(randomEnemyCardFromHand);
            randomEnemyCardFromHand.Player = CardThatHasTrait.Player;
            CardThatHasTrait.Player.Hand.Add(randomEnemyCardFromHand);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new StealCardTrait(monsterCard);
        }

        #endregion Public Methods
    }
}