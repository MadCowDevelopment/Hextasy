using System.ComponentModel.Composition;
using Caliburn.Micro;
using Hextasy.CardWars.Cards.Traits;

namespace Hextasy.CardWars.Cards.Spells
{
    [Export(typeof(Card))]
    public class ImmunityPoisonCard : SpellCard
    {
        public override string Name
        {
            get { return "Immunity: Poison"; }
        }

        public override string Description
        {
            get { return "Gives the target and adjacent monsters immunity against poison."; }
        }

        public override int Cost
        {
            get { return 2; }
        }

        protected override string ImageFilename
        {
            get { return "protect-acid-3.png"; }
        }

        protected override Card CreateInstance()
        {
            return new ImmunityPoisonCard();
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentFriendlyTiles(targetTile).Apply(
                p => p.Card.AddTrait(new ImmunityPoisonTrait(targetTile.Card)));
            targetTile.Card.AddTrait(new ImmunityPoisonTrait(targetTile.Card));
        }
    }
}