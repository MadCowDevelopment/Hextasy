namespace Hextasy.CardWars.Cards
{
    public abstract class DragonMaleCard : DragonCard
    {
        #region Public Properties

        public override sealed Gender Gender
        {
            get { return Gender.Male; }
        }

        #endregion Public Properties
    }
}