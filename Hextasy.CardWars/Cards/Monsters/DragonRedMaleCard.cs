using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonRedMaleCard : DragonMaleCard
    {
        public DragonRedMaleCard()
        {
            Traits.Add(new HungryDragonRedTrait());
        }

        public override string Name
        {
            get { return "Thichom"; }
        }

        public override string Description
        {
            get { return "Starving: Deals 2 fire damage to all enemies."; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        protected override string ImageFilename
        {
            get { return "DragonAncientRed.png"; }
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
            get { return DragonFlight.Red; }
        }
    }
}
