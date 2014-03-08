using System.ComponentModel.Composition;

using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SmithCard : MonsterCard
    {
        #region Constructors

        public SmithCard()
        {
            Traits.Add(new IncreaseRandomMonsterAttackTrait(this, 2));
        }

        #endregion Constructors

        #region Public Properties

        public override int BaseAttack
        {
            get { return 1; }
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
            get { return "Gives a friendly monster +2 attack at the end of your turn."; }
        }

        public override string Name
        {
            get { return "Smitty the Smith"; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Smithy01.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new SmithCard();
        }

        #endregion Protected Methods
    }
}