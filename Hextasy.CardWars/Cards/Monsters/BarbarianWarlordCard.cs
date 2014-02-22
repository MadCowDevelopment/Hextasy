using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class BarbarianWarlordCard : MonsterCard
    {
        public BarbarianWarlordCard()
        {
            Traits.Add(new DefenderTrait(this));
        }

        public override string Name
        {
            get { return "Barbarian Warlord"; }
        }

        public override string Description
        {
            get { return "SMASH!"; }
        }

        protected override string ImageFilename
        {
            get { return @"BarbarianFighter2.png"; }
        }

        public override int BaseAttack
        {
            get { return 2; }
        }

        public override int BaseHealth
        {
            get { return 7; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        public override int Cost
        {
            get { return 5; }
        }
    }
}
