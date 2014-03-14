using System.Linq;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HealRandomFriendlyMonsterTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Constructors

        public HealRandomFriendlyMonsterTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Heal friendly monster"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/heal-royal-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

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

        #endregion Public Methods
    }
}