using System;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class BurnEnemyMonstersTrait : Trait, IActivateTraitOnStartTurn
    {
        private int Amount { get; set; }

        public BurnEnemyMonstersTrait(MonsterCard cardThatHasTrait, int amount)
            : base(cardThatHasTrait)
        {
            Amount = amount;
        }

        public override string Name
        {
            get { return "Burn enemy monsters."; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Traits/fire-arrows-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.OpponentCards.Apply(p => p.TakeFireDamage(Amount));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return (BurnEnemyMonstersTrait)Activator.CreateInstance(GetType(), CardThatHasTrait, Amount);
        }
    }
}
