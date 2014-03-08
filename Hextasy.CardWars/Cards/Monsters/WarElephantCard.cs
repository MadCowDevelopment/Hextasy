using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class WarElephantCard : MonsterCard
    {
        #region Constructors

        public WarElephantCard()
        {
            Traits.Add(new IncreaseRaceAttackTrait(this, 1, Race.Beast));
            Traits.Add(new DecreaseRaceAttackTrait(this, 1, Race.Beast));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 6; }
        }

        public override int BaseHealth
        {
            get { return 8; }
        }

        public override int Cost
        {
            get { return 9; }
        }

        public override string Description
        {
            get { return "Gives all friendly beasts +1 attack."; }
        }

        public override string Name
        {
            get { return "War Elephant"; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "WarElephantGrey.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new WarElephantCard();
        }

        #endregion Protected Methods
    }
}