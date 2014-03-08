using System;
using System.Windows;

using Hextasy.CardWars.Cards.Summoned;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class RecruitMonkTrait : Trait, IActivateTraitOnEndTurn
    {
        #region Constructors

        public RecruitMonkTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Recrut monk"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/HumanPriest01.PNG"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var adjacentTile = cardWarsGameLogic.GetAdjacentFreeTiles(targetTile).RandomOrDefault();
            if (adjacentTile == null) return;
            HumanMonkCard monk = null;
            Application.Current.Dispatcher.Invoke(new Action(() => monk = new HumanMonkCard()));
            monk.Player = CardThatHasTrait.Player;
            adjacentTile.AssignCard(monk);
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new RecruitMonkTrait(monsterCard);
        }

        #endregion Public Methods
    }
}