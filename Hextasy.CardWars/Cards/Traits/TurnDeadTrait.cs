using System;
using System.Windows;

using Hextasy.CardWars.Cards.Summoned;

namespace Hextasy.CardWars.Cards.Traits
{
    public class TurnDeadTrait : Trait, IActivateTraitOnAnyCardDied
    {
        #region Constructors

        public TurnDeadTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Turn Dead"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/Skeleton.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

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

        #endregion Public Methods
    }
}