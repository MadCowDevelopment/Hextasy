using System;
using System.Windows;
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
            SkeletonCard skeletonCard = null;
            Application.Current.Dispatcher.Invoke(new Action(() => skeletonCard = new SkeletonCard()));
            skeletonCard.Player = CardThatHasTrait.Player;
            targetTile.AssignCard(skeletonCard);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new TurnDeadTrait(monsterCard);
        }
    }
}
