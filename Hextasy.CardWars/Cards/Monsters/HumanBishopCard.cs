using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanBishopCard : MonsterCard
    {
        #region Constructors

        public HumanBishopCard()
        {
            Traits.Add(new DrawCardOnHealTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 7; }
        }

        public override int Cost
        {
            get { return 6; }
        }

        public override string Description
        {
            get { return "Draw a card whenever a monster is healed."; }
        }

        public override string Name
        {
            get { return "Bishop"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"HumanPriest31.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new HumanBishopCard();
        }

        #endregion Protected Methods
    }
}