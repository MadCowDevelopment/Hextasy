using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanFrostmageCard : MonsterCard
    {
        #region Constructors

        public HumanFrostmageCard()
        {
            Traits.Add(new HasteTrait(this));
            Traits.Add(new FreezeAdjacentEnemiesTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 4; }
        }

        public override int BaseHealth
        {
            get { return 2; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        public override string Description
        {
            get { return "Initiative: Freezes all adjacent enemy minions."; }
        }

        public override string Name
        {
            get { return "Frostmage"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"HumanMage15.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanFrostmageCard();
        }

        #endregion Protected Methods
    }
}