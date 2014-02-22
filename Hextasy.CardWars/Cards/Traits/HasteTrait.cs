namespace Hextasy.CardWars.Cards.Traits
{
    public class HasteTrait : Trait, IActivateTraitOnCardPlayed
    {
        public HasteTrait(MonsterCard cardThatHasTrait) : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Haste"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/haste.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            CardThatHasTrait.IsExhausted = false;
        }
    }
}
