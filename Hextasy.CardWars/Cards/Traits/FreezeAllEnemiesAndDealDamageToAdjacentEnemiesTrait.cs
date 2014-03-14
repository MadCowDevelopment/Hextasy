using Caliburn.Micro;

using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class FreezeAllEnemiesAndDealDamageToAdjacentEnemiesTrait : Trait, IActivateTraitOnCardPlayed
    {
        #region Constructors

        public FreezeAllEnemiesAndDealDamageToAdjacentEnemiesTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Freeze and deal damage."; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Spells/enchant-blue-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.OpponentCards.Apply(p => p.AddDebuff(new FrozenDebuff()));
            cardWarsGameLogic.GetAdjacentOpponentTiles(targetTile).Apply(p => p.Card.TakeFrostDamage(1));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new FreezeAllEnemiesAndDealDamageToAdjacentEnemiesTrait(monsterCard);
        }

        #endregion Public Methods
    }
}