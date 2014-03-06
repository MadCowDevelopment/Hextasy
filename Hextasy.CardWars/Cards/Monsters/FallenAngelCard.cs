using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class FallenAngelCard : MonsterCard
    {
        protected override string ImageFilename
        {
            get { return @"AngelGray2.png"; }
        }

        protected override Card CreateInstance()
        {
            return new FallenAngelCard();
        }

        public override string Name
        {
            get { return "Fallen Angel"; }
        }

        public override string Description
        {
            get { return "The fallen angel will bring you down. And it will bring down your mother."; }
        }

        public override int BaseAttack
        {
            get { return 4; }
        }

        public override int BaseHealth
        {
            get { return 5; }
        }

        public override Race Race
        {
            get { return Race.Angel; }
        }

        public override int Cost
        {
            get { return 5; }
        }
    }
}