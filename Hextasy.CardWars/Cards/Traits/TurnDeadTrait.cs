using Hextasy.CardWars.Cards.Summoned;

namespace Hextasy.CardWars.Cards.Traits
{
    public class TurnDeadTrait : Trait, IActivateTraitOnAnyCardDied
    {
        private Card Card { get; set; }

        public TurnDeadTrait(Card card)
        {
            Card = card;
        }

        public override string Name
        {
            get { return "Turn Dead"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/Skeleton.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var skeleton = new SkeletonCard();
            skeleton.Player = Card.Player;
            targetTile.AssignCard(skeleton);
        }
    }
}
