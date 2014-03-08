using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanInquisitorMaleCard : MonsterCard
    {
        #region Constructors

        public HumanInquisitorMaleCard()
        {
            Traits.Add(new FreezeAllEnemiesAndDealDamageToAdjacentEnemiesTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 4; }
        }

        public override int Cost
        {
            get { return 4; }
        }

        public override string Description
        {
            get { return "Initiative: Freezes all enemy monsters and deals 1 damage to adjacent enemy monsters."; }
        }

        public override string Name
        {
            get { return "Human Inquisitor"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"HumanPriest35.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanInquisitorMaleCard();
        }

        #endregion Protected Methods
    }
}