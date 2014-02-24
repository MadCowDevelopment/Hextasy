using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanPaladinMaleCard : MonsterCard
    {
        public HumanPaladinMaleCard()
        {
            Traits.Add(new DefenderTrait(this));
        }

        public override string Name
        {
            get { return "Paladin"; }
        }

        public override string Description
        {
            get { return string.Empty; }
        }

        protected override string ImageFilename
        {
            get { return @"HumanFighter8.PNG"; }
        }

        public override int BaseAttack
        {
            get { return 3; }
        }

        public override int BaseHealth
        {
            get { return 6; }
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