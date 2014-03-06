using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Summoned
{
    public class HumanMonkCard : MonsterCard
    {
        public HumanMonkCard()
        {
            Traits.Add(new DefenderTrait(this));
        }

        public override string Name
        {
            get { return "Monk"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        protected override string ImageFilename
        {
            get { return @"HumanPriest01.PNG"; }
        }

        protected override Card CreateInstance()
        {
            return new HumanMonkCard();
        }

        public override int BaseAttack
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 2; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        public override int Cost
        {
            get { return 3; }
        }
    }
}