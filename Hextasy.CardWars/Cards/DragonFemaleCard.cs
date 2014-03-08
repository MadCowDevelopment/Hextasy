using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards
{
    public abstract class DragonFemaleCard : DragonCard
    {
        #region Constructors

        protected DragonFemaleCard()
        {
            Traits.Add(new DragonBabyTrait(this));
        }

        #endregion Constructors

        #region Public Properties

        public override sealed Gender Gender
        {
            get { return Gender.Female; }
        }

        #endregion Public Properties
    }
}