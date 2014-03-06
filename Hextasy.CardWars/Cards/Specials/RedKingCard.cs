namespace Hextasy.CardWars.Cards.Specials
{
    public class RedKingCard : KingCard
    {
        protected override string ImageFilename
        {
            get { return @"crown-red.png"; }
        }

        protected override Card CreateInstance()
        {
            return new RedKingCard();
        }

        public override Race Race
        {
            get { return Race.Special; }
        }
    }
}
