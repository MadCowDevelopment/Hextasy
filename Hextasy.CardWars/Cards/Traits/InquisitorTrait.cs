using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class InquisitorTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Constructors

        public InquisitorTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Subdue monsters"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/FemalePriest02.PNG"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var randomMonster = cardWarsGameLogic.OpponentCardsExceptKing.RandomOrDefault();
            if (randomMonster == null) return;
            if (!RNG.Chance(33)) return;
            if (randomMonster.Race == Race.Undead) randomMonster.Kill();
            else randomMonster.Player = CardThatHasTrait.Player;
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new InquisitorTrait(monsterCard);
        }

        #endregion Public Methods
    }
}