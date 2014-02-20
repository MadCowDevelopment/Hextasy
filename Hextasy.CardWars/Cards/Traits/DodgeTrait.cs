using System.Linq;
using Caliburn.Micro;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class DodgeTrait : Trait, IActivateTraitOnDefense
    {
        public override string Name
        {
            get { return "Dodge"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Traits/wind-grasp-sky-1.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            if (RNG.Next(0, 1) != 0) return;

            targetTile.Card.Dodge();
            targetTile.Card.Traits.OfType<IActivateTraitOnDodge>().Apply(
                p => p.Activate(cardWarsGameLogic, targetTile));
        }
    }
}
