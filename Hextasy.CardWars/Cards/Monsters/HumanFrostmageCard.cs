using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanFrostmageCard : MonsterCard
    {
        public HumanFrostmageCard()
        {
            Traits.Add(new HasteTrait(this));
            Traits.Add(new FreezeAdjacentEnemiesTrait(this));
        }

        public override string Name
        {
            get { return "Frostmage"; }
        }

        public override string Description
        {
            get { return "Initiative: Freezes all adjacent enemy minions."; }
        }

        protected override string ImageFilename
        {
            get { return @"HumanMage15.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 4; }
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
            get { return 5; }
        }
    }
}