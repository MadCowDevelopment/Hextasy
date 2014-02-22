﻿using Hextasy.CardWars.Cards.Summoned;
using Hextasy.Framework;

namespace Hextasy.CardWars.Cards.Traits
{
    public class SummonUndeadTrait : Trait, IActivateTraitOnStartTurn
    {
        public SummonUndeadTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        public override string Name
        {
            get { return "Summon Undead"; }
        }

        protected override string ImageFilename
        {
            get { return "Cards/Monsters/Skeleton.png"; }
        }

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            var randomTile = cardWarsGameLogic.GetAdjacentFreeTiles(targetTile).RandomOrDefault();
            if (randomTile == null) return;
            var skeleton = new SkeletonCard();
            skeleton.Player = CardThatHasTrait.Player;
            randomTile.AssignCard(skeleton);
        }
    }
}