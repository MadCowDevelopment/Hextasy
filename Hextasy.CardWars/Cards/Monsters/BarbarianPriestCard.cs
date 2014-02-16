using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class BarbarianPriestCard : MonsterCard
    {
        public BarbarianPriestCard()
        {
            Traits.Add(new HealRandomFriendlyMonsterTrait());
        }

        public override string Name
        {
            get { return "Barbarian Priest"; }
        }

        public override string Description
        {
            get { return "Heals 2 damage of a friendly monster at the start of your turn."; }
        }

        protected override string ImageFilename
        {
            get { return @"BarbarianPriest.png"; }
        }

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override int Cost
        {
            get { return 3; }
        }
    }
}
