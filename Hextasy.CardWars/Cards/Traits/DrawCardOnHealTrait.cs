
namespace Hextasy.CardWars.Cards.Traits
{
    public class DrawCardOnHealTrait : Trait, IActivateTraitOnHeal
    {
        public DrawCardOnHealTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Draw card on heal"; }
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
