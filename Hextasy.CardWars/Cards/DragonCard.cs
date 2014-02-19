
namespace Hextasy.CardWars.Cards
{
    public abstract class DragonCard : MonsterCard
    {
        public abstract DragonFlight DragonFlight { get; }

        public abstract Gender Gender { get; }

        public override Race Race
        {
            get { return Race.Dragon; }
        }
    }
}
