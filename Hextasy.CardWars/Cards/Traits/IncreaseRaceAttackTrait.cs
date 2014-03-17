using System.Collections.Generic;
using System.Linq;

using Caliburn.Micro;

using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class IncreaseRaceAttackTrait : Trait, IActivateTraitOnAnyCardPlayed
    {
        #region Fields

        private List<MonsterCard> _buffedCards = new List<MonsterCard>();

        #endregion Fields

        #region Constructors

        public IncreaseRaceAttackTrait(MonsterCard cardThatHasTrait, int amount, Race race)
            : base(cardThatHasTrait)
        {
            Amount = amount;
            Race = race;
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Increase Attack"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/enchant-magenta-3.png"; }
        }

        #endregion Protected Properties

        #region Private Properties

        private int Amount
        {
            get;
            set;
        }

        private Race Race
        {
            get;
            set;
        }

        #endregion Private Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var allCardsOfCurrentPlayerWithRace =
                cardWarsGameLogic.AllCards.Where(
                    p => p.Player.Owner == CardThatHasTrait.Owner && p != CardThatHasTrait && p.Race == Race);
            var beastsToBuff = allCardsOfCurrentPlayerWithRace.Except(_buffedCards).ToList();
            beastsToBuff.Apply(p => p.AttackBonus += Amount);
            _buffedCards.AddRange(beastsToBuff);
        }

        public override void Deactivate(CardWarsGameLogic cardWarsGameLogic)
        {
            _buffedCards.Apply(p => p.AttackBonus -= Amount);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new IncreaseRaceAttackTrait(monsterCard, Amount, Race);
        }

        #endregion Public Methods
    }
}