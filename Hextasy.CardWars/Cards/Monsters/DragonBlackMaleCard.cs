using System.ComponentModel.Composition;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class DragonBlackMaleCard : DragonMaleCard
    {
        public DragonBlackMaleCard()
        {
            Traits.Add(new HungryDragonBlackTrait(this));
        }

        public override string Name
        {
            get { return "Xyafyiu"; }
        }

        public override string Description
        {
            get { return "Starving: Kills 2 random enemies with 3 or less attack."; }
        }

        public override int Cost
        {
            get { return 10; }
        }

        protected override string ImageFilename
        {
            get { return "DragonAncientBlack.png"; }
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
            get { return DragonFlight.Black; }
        }
    }
}