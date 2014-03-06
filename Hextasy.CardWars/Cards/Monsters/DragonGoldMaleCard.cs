using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonGoldMaleCard : DragonMaleCard
    {
        public DragonGoldMaleCard()
        {
            Traits.Add(new HungryDragonGoldTrait(this));
        }

        public override string Name
        {
            get { return "Fudron"; }
        }

        public override string Description
        {
            get { return "Saturated: Gain 1 card for every 2 health of the eaten monster."; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        protected override string ImageFilename
        {
            get { return "DragonAncientGold.png"; }
        }

        protected override Card CreateInstance()
        {
            return new DragonGoldMaleCard();
        }

        public override int BaseAttack
        {
            get { return 3; }
        }

        public override int BaseHealth
        {
            get { return 7; }
        }

        public override DragonFlight DragonFlight
        {
            get { return DragonFlight.Gold; }
        }
    }
}