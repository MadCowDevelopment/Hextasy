using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HorseCard : MonsterCard
    {
        #region Constructors

        public HorseCard()
        {
            Traits.Add(new AdjacentMonsterHaveHasteTrait(this));
            Traits.Add(new AdjacentMonsterLoseHasteTrait(this));
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
            get { return "Friendly monsters played adjacent to this get 'Haste'."; }
        }

        public override string Name
        {
            get { return "Horse"; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Horse01.PNG"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HorseCard();
        }

        #endregion Protected Methods
    }
}