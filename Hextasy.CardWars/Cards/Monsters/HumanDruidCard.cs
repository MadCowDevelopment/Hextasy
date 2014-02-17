using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    public class HumanDruidCard : MonsterCard
    {
        public HumanDruidCard()
        {
            Traits.Add(new IncreaseBeastAttackTrait(1));
            Traits.Add(new DecreaseBeastAttackTrait(1));
        }
        public override string Name
        {
            get { return "Human Druid"; }
        }

        public override string Description
        {
            get { return "Give all friendly beasts +1 attack."; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        protected override string ImageFilename
        {
            get { return "HumanDruid04.png"; }
        }

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }
    }
}
