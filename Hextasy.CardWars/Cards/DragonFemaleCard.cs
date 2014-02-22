using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards
{
    public abstract class DragonFemaleCard : DragonCard
    {
        protected DragonFemaleCard()
        {
            Traits.Add(new DragonBabyTrait(this));
        }

        public override sealed Gender Gender
        {
            get { return Gender.Female; }
        }
    }
}