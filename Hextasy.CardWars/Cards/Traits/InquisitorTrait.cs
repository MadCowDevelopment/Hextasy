using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class InquisitorTrait : Trait, IActivateTraitOnStartTurn
    {
        public InquisitorTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Subdue monsters"; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var randomMonster = cardWarsGameLogic.OpponentCardsExceptKing.RandomOrDefault();
            if (randomMonster == null) return;
            if (!RNG.Chance(33)) return;
            if (randomMonster.Race == Race.Undead) randomMonster.Kill();
            else randomMonster.Player = CardThatHasTrait.Player;
        }
    }
}
