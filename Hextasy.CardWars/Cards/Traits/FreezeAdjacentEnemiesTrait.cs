﻿using Caliburn.Micro;

using Hextasy.CardWars.Cards.Debuffs;
using Hextasy.CardWars.Logic;

namespace Hextasy.CardWars.Cards.Traits
{
    public class FreezeAdjacentEnemiesTrait : Trait, IActivateTraitOnCardPlayed
    {
        #region Constructors

        public FreezeAdjacentEnemiesTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Freeze adjacent enemies"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"Cards/Spells/enchant-blue-3.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            cardWarsGameLogic.GetAdjacentOpponentTiles(targetTile).Apply(p => p.AddDebuff(new FrozenDebuff()));
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new FreezeAdjacentEnemiesTrait(monsterCard);
        }

        #endregion Public Methods
    }
}