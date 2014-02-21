using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class FireAntCard : MonsterCard
    {
        public FireAntCard()
        {
            Traits.Add(new DrawCardTrait(1));
        }

        public override string Name
        {
            get { return "Fire Ant"; }
        }

        public override string Description
        {
            get { return "Draw 1 card."; }
        }

        public override int BaseAttack
        {
            get { return 1; }
        }

        public override int BaseHealth
        {
            get { return 1; }
        }

        public override Race Race
        {
            get { return Race.Beast; }
        }

        public override int Cost
        {
            get { return 1; }
        }

        protected override string ImageFilename
        {
            get { return "AntRed2.png"; }
        }
    }
}
