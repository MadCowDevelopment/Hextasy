using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanPriestCard : MonsterCard
    {
        #region Constructors

        public HumanPriestCard()
        {
            Traits.Add(new HealRandomFriendlyMonsterTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        public override string Description
        {
            get { return "Heals 2 damage of a friendly monster at the start of your turn."; }
        }

        public override string Name
        {
            get { return "Priest"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"BarbarianPriest.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanPriestCard();
        }

        #endregion Protected Methods
    }
}