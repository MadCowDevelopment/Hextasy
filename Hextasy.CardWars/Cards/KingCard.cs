namespace Hextasy.CardWars.Cards
{
    public abstract class KingCard : Card
    {
        public override string Name
        {
            get { return "King"; }
        }

        public override string Description
        {
            get { return "The king is dead! Long live the king!"; }
        }

        public override int BaseAttack
        {
            get { return 0; }
        }

        public override int BaseHealth
        {
            get { return 50; }
        }

        public override int Cost
        {
            get { return 0; }
        }
    }
}
