using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanAbbotCard : MonsterCard
    {
        public HumanAbbotCard()
        {
            Traits.Add(new RecruitMonkTrait(this));
        }

        public override string Name
        {
            get { return "Abbot"; }
        }

        public override string Description
        {
            get { return "Recruits a 0/2 monk at the end of your turn."; }
        }

        protected override string ImageFilename
        {
            get { return @"HumanPriest04.PNG"; }
        }

        protected override Card CreateInstance()
        {
            return new HumanAbbotCard();
        }

        public override int BaseAttack
        {
            get { return 4; }
        }

        public override int BaseHealth
        {
            get { return 4; }
        }

        public override Race Race
        {
            get { return Race.Human; }
        }

        public override int Cost
        {
            get { return 7; }
        }
    }
}