using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class BrownBearCard : MonsterCard
    {
        public BrownBearCard()
        {
            Traits.Add(new DefenderTrait());
        }

        public override string Name
        {
            get { return "Brown Bear"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        public override int Cost
        {
            get { return 7; }
        }

        protected override string ImageFilename
        {
            get { return "BrownBear.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 6; }
        }

        public override int BaseHealth
        {
            get { return 6; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }
    }
}