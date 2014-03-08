using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class GryphonCard : MonsterCard
    {
        #region Constructors

        public GryphonCard()
        {
            Traits.Add(new RemoveDefenderTraitFromEnemiesTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 5; }
        }

        public override int BaseHealth
        {
            get { return 8; }
        }

        public override int Cost
        {
            get { return 8; }
        }

        public override string Description
        {
            get { return "Initiative: Removes defender trait from all enemies."; }
        }

        public override string Name
        {
            get { return "Gryphon"; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Gryphon.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new GryphonCard();
        }

        #endregion Protected Methods
    }
}