namespace Hextasy.CardWars.Cards
{
    public abstract class MonsterCard : Card
    {
        protected override string ImageFolder
        {
            get { return @"Images\Cards\"; }
        }
    }
}
