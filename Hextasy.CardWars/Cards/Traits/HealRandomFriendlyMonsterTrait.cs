using System.Linq;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HealRandomFriendlyMonsterTrait : Trait, IActivateTraitOnStartTurn
    {
        public HealRandomFriendlyMonsterTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Heal friendly monster"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/heal-royal-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var damagedFriendlyMonsters = cardWarsGameLogic.CurrentPlayerCards.Where(p => p.HasDecreasedHealth).ToList();
            if (damagedFriendlyMonsters.Count == 0) return;
            var randomIndex = RNG.Next(0, damagedFriendlyMonsters.Count - 1);
            var pickedMonster = damagedFriendlyMonsters[randomIndex];
            cardWarsGameLogic.Heal(pickedMonster, 2);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new HealRandomFriendlyMonsterTrait(monsterCard);
        }
    }
}