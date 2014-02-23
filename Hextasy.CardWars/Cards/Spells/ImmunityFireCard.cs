using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ImmunityFireCard : SpellCard
    {
        public override string Name
        {
            get { return "Immunity: Fire"; }
        }

        public override string Description
        {
            get { return "Gives the target and adjacent monsters immunity against fire."; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        protected override string ImageFilename
        {
            get { return "protect-red-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentFriendlyTiles(targetTile).Apply(
                p => p.Card.AddTrait(new ImmunityFireTrait(targetTile.Card)));
            targetTile.Card.AddTrait(new ImmunityFireTrait(targetTile.Card));
        }
    }
}