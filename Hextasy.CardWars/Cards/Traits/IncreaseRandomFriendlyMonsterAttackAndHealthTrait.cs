using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class IncreaseRandomFriendlyMonsterAttackAndHealthTrait : Trait, IActivateTraitOnStartTurn
    {
        private int Attack { get; set; }
        private int Health { get; set; }

        public IncreaseRandomFriendlyMonsterAttackAndHealthTrait(MonsterCard cardThatHasTrait, int attack, int health)
            : base(cardThatHasTrait)
        {
            Attack = attack;
            Health = health;
        }

        public override string Name
        {
            get { return "Increase attack and health"; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var randomFriendlyMonster = cardWarsGameLogic.CurrentPlayerCardsExceptKing.RandomOrDefault();
            if (randomFriendlyMonster == null) return;
            randomFriendlyMonster.AttackBonus += Attack;
            randomFriendlyMonster.HealthBonus += Attack;
        }
    }
}
