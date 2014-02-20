namespace Hextasy.CardWars.Cards
{
    public abstract class SpellCard : Card
    {
        protected override string ImageFolder
        {
            get { return @"pack://application:,,,/Hextasy.CardWars;component/Images/Cards/Spells/"; }
        }

        public override CardType Type
        {
            get { return CardType.Spell; }
        }

        public abstract void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile);
    }
}