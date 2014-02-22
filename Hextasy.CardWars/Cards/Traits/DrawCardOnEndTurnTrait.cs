
namespace Hextasy.CardWars.Cards.Traits
{
    public class DrawCardOnEndTurnTrait : Trait, IActivateTraitOnStartTurn
    {
        public DrawCardOnEndTurnTrait(MonsterCard cardThatHasTrait) : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Draw card at the end of your turn."; }
        }

        protected override string ImageFilename
        {
            get { return string.Empty; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            CardThatHasTrait.Player.DrawCard();
        }
    }
}
