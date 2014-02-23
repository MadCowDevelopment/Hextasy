namespace Hextasy.CardWars.Cards.Traits
{
    public class ImmunityFireTrait : Trait
    {
        public ImmunityFireTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Immunity: Fire"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Spells/protect-red-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }
    }
}