namespace Hextasy.CardWars.Cards.Traits
{
    public class ImmunityPoisonTrait : Trait
    {
        public ImmunityPoisonTrait(MonsterCard cardThatHasTrait) : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Immunity: Acid"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Spells/protect-acid-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }
    }
}
