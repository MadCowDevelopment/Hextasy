using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class PopeTrait : Trait, IActivateTraitOnCardPlayed
    {
        public PopeTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Increase attack and heal"; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.CurrentPlayerCardsExceptKing.Apply(p => p.AttackBonus += 1);
            cardWarsGameLogic.CurrentPlayerCards.Apply(p => cardWarsGameLogic.Heal(p, 2));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new PopeTrait(monsterCard);
        }
    }
}
