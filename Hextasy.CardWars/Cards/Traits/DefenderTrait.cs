namespace Hextasy.CardWars.Cards.Traits
{
    public class DefenderTrait : Trait
    {
        public override string Name
        {
            get { return "Defender"; }
        }

        protected override string ImageFilename
        {
            get { return @"Cards/Traits/protect-royal-2.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
        }
    }
}
