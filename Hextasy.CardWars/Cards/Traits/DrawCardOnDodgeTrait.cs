
namespace Hextasy.CardWars.Cards.Traits
{
    public class DrawCardOnDodgeTrait : Trait, IActivateTraitOnDodge
    {
        public DrawCardOnDodgeTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Draw card on dodge"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Traits/drawcard.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            CardThatHasTrait.Player.DrawCard();
        }
    }
}
