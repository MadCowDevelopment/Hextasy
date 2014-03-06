using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class HumanInquisitorMaleCard : MonsterCard
    {
        public HumanInquisitorMaleCard()
        {
            Traits.Add(new FreezeAllEnemiesAndDealDamageToAdjacentEnemiesTrait(this));
        }

        public override string Name
        {
            get { return "Human Inquisitor"; }
        }

        public override string Description
        {
            get { return "Initiative: Freezes all enemy monsters and deals 1 damage to adjacent enemy monsters."; }
        }

        protected override string ImageFilename
        {
            get { return @"HumanPriest35.PNG"; }
        }

        protected override Card CreateInstance()
        {
            return new HumanInquisitorMaleCard();
        }

        public override int BaseAttack
        {
            get { return 2; }
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
            get { return 4; }
        }
    }
}