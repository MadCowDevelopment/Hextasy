using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanBishopCard : MonsterCard
    {
        public HumanBishopCard()
        {
            Traits.Add(new DrawCardOnHealTrait(this));
        }

        public override string Name
        {
            get { return "Bishop"; }
        }

        public override string Description
        {
            get { return "Draw a card whenever a monster is healed."; }
        }

        protected override string ImageFilename
        {
            get { return @"HumanPriest31.png"; }
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
            get { return 6; }
        }
    }
}