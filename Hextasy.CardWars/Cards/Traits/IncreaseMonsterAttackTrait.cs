using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class IncreaseMonsterAttackTrait : Trait, IActivateTraitOnEndTurn
    {
        private int Amount { get; set; }

        public IncreaseMonsterAttackTrait(int amount)
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
            var friendlyMonster = cardWarsGameLogic.CurrentPlayerCards.RandomOrDefault();
            if (friendlyMonster != null) friendlyMonster.AttackBonus += Amount;
        }
    }
}
