using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ImmunityFrostCard : SpellCard
    {
        public override string Name
        {
            get { return "Immunity: Frost"; }
        }

        public override string Description
        {
            get { return "Gives the target and adjacent monsters immunity against frost."; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        protected override string ImageFilename
        {
            get { return "protect-blue-3.png"; }
        }

        protected override Card CreateInstance()
        {
            return new ImmunityFrostCard();
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentFriendlyTiles(targetTile).Apply(
                p => p.Card.AddTrait(new ImmunityFrostTrait(targetTile.Card)));
            targetTile.Card.AddTrait(new ImmunityFrostTrait(targetTile.Card));
        }
    }
}