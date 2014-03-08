namespace Hextasy.CardWars.Cards
{
    public abstract class DragonCard : MonsterCard
    {
        #region Public Properties

        public abstract DragonFlight DragonFlight
        {
            get;
        }

        public abstract Gender Gender
        {
            get;
        }

        public override sealed Race Race
        {
            get { return Race.Dragon; }
        }

        #endregion Public Properties
    }
}