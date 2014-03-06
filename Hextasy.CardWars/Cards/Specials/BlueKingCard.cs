namespace Hextasy.CardWars.Cards.Specials
{
    public class BlueKingCard : KingCard
    {
        protected override string ImageFilename
        {
            get { return @"crown-blue.png"; }
        }

        protected override Card CreateInstance()
        {
            return new BlueKingCard();
        }

        public override Race Race
        {
            get { return Race.Special; }
        }
    }
}
