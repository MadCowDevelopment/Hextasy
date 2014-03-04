using System;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class IncreaseRandomMonsterAttackTrait : Trait, IActivateTraitOnEndTurn
    {
        private int Amount { get; set; }

        public IncreaseRandomMonsterAttackTrait(MonsterCard cardThatHasTrait, int amount)
            : base(cardThatHasTrait)
        {
            Amount = amount;
        }

        public override string Name
        {
            get { return "Increase Monster Attack"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Traits/Sword20.PNG"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var friendlyMonster = cardWarsGameLogic.CurrentPlayerCardsExceptKing.RandomOrDefault();
            if (friendlyMonster != null) friendlyMonster.AttackBonus += Amount;
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return (IncreaseRandomMonsterAttackTrait)Activator.CreateInstance(GetType(), CardThatHasTrait, Amount);
        }
    }
}
