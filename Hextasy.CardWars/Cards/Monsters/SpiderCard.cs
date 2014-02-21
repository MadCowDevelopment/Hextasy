using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class SpiderCard : MonsterCard
    {
        public SpiderCard()
        {
            Traits.Add(new PoisonWeaponTrait(2, 3));
        }

        public override string Name
        {
            get { return "Black Widow"; }
        }

        public override string Description
        {
            get { return "Poisons defenders for 2 damage for 3 turns."; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        protected override string ImageFilename
        {
            get { return "SpiderBlack.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 3; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }
    }
}