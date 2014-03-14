using Caliburn.Micro;

using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class HungryDragonBlueTrait : HungryDragonTrait
    {
        #region Constructors

        public HungryDragonBlueTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Methods

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new HungryDragonBlueTrait(monsterCard);
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void ActivateSaturatedEffect(
            CardWarsGameLogic cardWarsGameLogic,
            CardWarsTile targetTile,
            MonsterCard eatenMonster)
        {
        }

        protected override void ActivateStarvingEffect(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var enemyMonsters = cardWarsGameLogic.OpponentCards;
            enemyMonsters.Apply(p => p.AddDebuff(new FrozenDebuff()));
        }

        #endregion Protected Methods
    }
}