using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class StealCardTrait : Trait, IActivateTraitOnStartTurn
    {
        public StealCardTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Steal card"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/CoinsGoldSmall.png"; }
        }

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
    }
}
