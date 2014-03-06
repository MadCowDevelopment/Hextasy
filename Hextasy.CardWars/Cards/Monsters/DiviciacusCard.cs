using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DiviciacusCard : MonsterCard
    {
        public DiviciacusCard()
        {
            Traits.Add(new IncreaseRaceAttackTrait(this, 2, Race.Beast));
            Traits.Add(new DecreaseRaceAttackTrait(this, 2, Race.Beast));
        }
        public override string Name
        {
            get { return "Diviciacus"; }
        }

        public override string Description
        {
            get { return "Give all friendly beasts +2 attack."; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        protected override string ImageFilename
        {
            get { return "HumanDruid04.png"; }
        }

        protected override Card CreateInstance()
        {
            return new DiviciacusCard();
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
