namespace Hextasy.CardWars.Cards.Specials
{
    public abstract class KingCard : MonsterCard
    {
        #region Public Properties

        public override int BaseAttack
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 60; }
        }

        public override int Cost
        {
            get { return 0; }
        }

        public override string Description
        {
            get { return "The king is dead! Long live the king!"; }
        }

        public override string Name
        {
            get { return "King"; }
        }

        public override CardType Type
        {
            get { return CardType.Special; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFolder
        {
            get { return @"pack://application:,,,/Hextasy.CardWars;component/Images/Cards/Specials/"; }
        }

        #endregion Protected Properties
    }
}