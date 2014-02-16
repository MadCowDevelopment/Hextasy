using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class TurtleCard : MonsterCard
    {
        public TurtleCard()
        {
            Traits.Add(new DefenderTrait());
        }

        public override string Name
        {
            get { return "Turtle"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 5; }
        }

        public override int Cost
        {
            get { return 4; }
        }

        protected override string ImageFilename
        {
            get { return "TurtleBrown.png"; }
        }
    }
}