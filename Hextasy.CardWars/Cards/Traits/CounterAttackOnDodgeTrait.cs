using System.Linq;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class CounterAttackOnDodgeTrait : Trait, IActivateTraitOnDodge
    {
        #region Constructors

        public CounterAttackOnDodgeTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Counterattack"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Traits/Axe09.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var randomOpponent =
                cardWarsGameLogic.AllCards.Where(p => p.Player != CardThatHasTrait.Player).RandomOrDefault();
            if (randomOpponent == null) return;
            randomOpponent.TakeDamage(CardThatHasTrait.Attack);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new CounterAttackOnDodgeTrait(monsterCard);
        }

        #endregion Public Methods
    }
}