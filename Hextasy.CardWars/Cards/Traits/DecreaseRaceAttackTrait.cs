using System.Linq;

using Caliburn.Micro;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DecreaseRaceAttackTrait : Trait, IActivateTraitOnDeath
    {
        #region Constructors

        public DecreaseRaceAttackTrait(MonsterCard cardThatHasTrait, int amount, Race race)
            : base(cardThatHasTrait)
        {
            Amount = amount;
            Race = race;
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return string.Empty; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        #endregion Protected Properties

        #region Private Properties

        private int Amount
        {
            get; set;
        }

        private Race Race
        {
            get; set;
        }

        #endregion Private Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var beastCardsToDebuff =
                cardWarsGameLogic.AllCards.Where(
                    p => p.Player.Owner == CardThatHasTrait.Owner && p != targetTile.Card && p.Race == Race);
            beastCardsToDebuff.Apply(p => p.AttackBonus -= Amount);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new DecreaseRaceAttackTrait(monsterCard, Amount, Race);
        }

        #endregion Public Methods
    }
}