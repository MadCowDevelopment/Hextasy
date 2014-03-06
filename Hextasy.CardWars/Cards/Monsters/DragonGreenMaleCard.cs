using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonGreenMaleCard : DragonMaleCard
    {
        public DragonGreenMaleCard()
        {
            Traits.Add(new HungryDragonGreenTrait(this));
        }

        public override string Name
        {
            get { return "Yokixum"; }
        }

        public override string Description
        {
            get { return "Saturated: Heals 2 damage of all friendly monsters."; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        protected override string ImageFilename
        {
            get { return "DragonAncientGreen.png"; }
        }

        protected override Card CreateInstance()
        {
            return new DragonGreenMaleCard();
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
            get { return DragonFlight.Green; }
        }
    }
}