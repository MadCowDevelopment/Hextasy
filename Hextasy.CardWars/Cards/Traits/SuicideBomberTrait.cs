using System;
using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class SuicideBomberTrait : Trait, IActivateTraitOnStartTurn
    {
        private int Amount { get; set; }

        public SuicideBomberTrait(MonsterCard cardThatHasTrait, int amount)
            : base(cardThatHasTrait)
        {
            Amount = amount;
        }

        public override string Name
        {
            get { return "Suicide bomber."; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Traits/link-royal-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentMonsterTiles(targetTile).Apply(p => p.Card.TakeFireDamage(Amount));
            CardThatHasTrait.Kill();
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return (SuicideBomberTrait)Activator.CreateInstance(GetType(), CardThatHasTrait, Amount);
        }
    }
}
