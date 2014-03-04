using System;
using System.Windows;
using Hextasy.CardWars.Cards.Summoned;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class RecruitMonkTrait : Trait, IActivateTraitOnEndTurn
    {
        public RecruitMonkTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Recrut monk"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/HumanPriest01.PNG"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var adjacentTile = cardWarsGameLogic.GetAdjacentFreeTiles(targetTile).RandomOrDefault();
            if (adjacentTile == null) return;
            HumanMonkCard monk = null;
            Application.Current.Dispatcher.Invoke(new Action(() => monk = new HumanMonkCard()));
            monk.Player = CardThatHasTrait.Player;
            adjacentTile.AssignCard(monk);
        }
    }
}
