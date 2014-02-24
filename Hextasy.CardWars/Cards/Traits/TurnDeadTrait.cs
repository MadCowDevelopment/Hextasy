using Hextasy.CardWars.Cards.Summoned;

namespace Hextasy.CardWars.Cards.Traits
{
    public class TurnDeadTrait : Trait, IActivateTraitOnAnyCardDied
    {
        public TurnDeadTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
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
            if (targetTile.Card is SkeletonCard) return;
            var skeleton = new SkeletonCard();
            skeleton.Player = CardThatHasTrait.Player;
            targetTile.AssignCard(skeleton);
        }
    }
}
