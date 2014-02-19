namespace Hextasy.CardWars.Cards.Traits
{
    public class HasteTrait : Trait, IActivateTraitOnCardPlayed
    {
        public override string Name
        {
            get { return "Haste"; }
        }

        public override string ImageFilename
        {
            get { return @"Images\Cards\Traits\haste.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            targetTile.Card.IsExhausted = false;
        }
    }
}
