
namespace Hextasy.CardWars.Cards.Traits
{
    public class DrawCardTrait : Trait, IActivateTraitOnCardPlayed
    {
        private int Amount { get; set; }

        public DrawCardTrait(int amount)
        {
            Amount = amount;
        }

        public override string Name
        {
            get { return string.Format("Draw {0} card(s)", Amount); }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            for (var i = 0; i < Amount; i++)
            {
                cardWarsGameLogic.CurrentPlayer.DrawCard();
            }
        }
    }
}
