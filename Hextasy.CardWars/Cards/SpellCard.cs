namespace Hextasy.CardWars.Cards
{
    public abstract class SpellCard : Card
    {
        protected override string ImageFolder
        {
            get { return @"Images\Cards\Spells\"; }
        }

        public override CardType Type
        {
            get { return CardType.Spell; }
        }

        public abstract void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }
}