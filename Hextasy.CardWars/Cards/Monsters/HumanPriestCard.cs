using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanPriestCard : MonsterCard
    {
        public HumanPriestCard()
        {
            Traits.Add(new HealRandomFriendlyMonsterTrait(this));
        }

        public override string Name
        {
            get { return "Priest"; }
        }

        public override string Description
        {
            get { return "Heals 2 damage of a friendly monster at the start of your turn."; }
        }

        protected override string ImageFilename
        {
            get { return @"BarbarianPriest.png"; }
        }

        protected override Card CreateInstance()
        {
            return new HumanPriestCard();
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

        public override int Cost
        {
            get { return 3; }
        }
    }
}
