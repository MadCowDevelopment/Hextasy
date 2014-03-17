using System.Linq;

using Caliburn.Micro;

using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DodgeTrait : Trait, IActivateTraitOnDefense, IActivateTraitOnAttack
    {
        #region Constructors

        public DodgeTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Dodge"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Traits/wind-grasp-sky-1.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            if (!RNG.Chance(66)) return;

            CardThatHasTrait.Dodge();
            CardThatHasTrait.Traits.OfType<IActivateTraitOnDodge>().Apply(
                p => p.Activate(cardWarsGameLogic, targetTile));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new DodgeTrait(monsterCard);
        }

        #endregion Public Methods
    }
}