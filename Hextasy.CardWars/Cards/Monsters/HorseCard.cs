using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HorseCard : MonsterCard
    {
        public HorseCard()
        {
            Traits.Add(new AdjacentMonsterHaveHasteTrait(this));
            Traits.Add(new AdjacentMonsterLoseHasteTrait());
        }

        public override string Name
        {
            get { return "Horse"; }
        }

        public override string Description
        {
            get { return "Gives all adjacent friendly monsters 'Haste'."; }
        }

        public override int Cost
        {
            get { return 3; }
        }

        protected override string ImageFilename
        {
            get { return "Horse01.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 1; }
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