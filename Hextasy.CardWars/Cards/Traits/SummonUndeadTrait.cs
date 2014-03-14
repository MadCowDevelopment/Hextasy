using System;
using System.Windows;

using Hextasy.CardWars.Cards.Summoned;
using Hextasy.CardWars.Logic;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class SummonUndeadTrait : Trait, IActivateTraitOnStartTurn
    {
        #region Constructors

        public SummonUndeadTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Summon Undead"; }
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
            var randomTile = cardWarsGameLogic.GetAdjacentFreeTiles(targetTile).RandomOrDefault();
            if (randomTile == null) return;
            SkeletonCard skeleton = null;
            Application.Current.Dispatcher.Invoke(new Action(() => skeleton = new SkeletonCard()));
            skeleton.Player = CardThatHasTrait.Player;
            randomTile.AssignCard(skeleton);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new SummonUndeadTrait(monsterCard);
        }

        #endregion Public Methods
    }
}