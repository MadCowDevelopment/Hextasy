using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanPriestFemaleCard : MonsterCard
    {
        public HumanPriestFemaleCard()
        {
            Traits.Add(new IncreaseRandomFriendlyMonsterAttackAndHealthTrait(this, 1, 1));
        }

        public override string Name
        {
            get { return "Female Priest"; }
        }

        public override string Description
        {
            get { return "Gives a random friendly monster +1/+1 at the start of your turn."; }
        }

        protected override string ImageFilename
        {
            get { return @"FemalePriest01.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 4; }
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