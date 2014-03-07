namespace Hextasy.CardWars.Cards.Traits
{
    public class ImmunityFrostTrait : Trait
    {
        public ImmunityFrostTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Immunity: Frost"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Spells/protect-blue-3.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new ImmunityFrostTrait(monsterCard);
        }
    }
}