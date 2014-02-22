using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class BasiliskCard : MonsterCard
    {
        public BasiliskCard()
        {
            Traits.Add(new DefenderTrait(this));
        }

        public override string Name
        {
            get { return "Basilisk"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        protected override string ImageFilename
        {
            get { return @"BasiliskBrown.png"; }
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
            get { return Race.Beast; }
        }

        public override int Cost
        {
            get { return 3; }
        }
    }
}
