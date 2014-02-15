namespace Hextasy.CardWars.Cards
{
    public abstract class SpellCard : Card
    {
        protected override string ImageFolder
        {
            get { return @"Images\Cards\Spells\"; }
        }
    }
}