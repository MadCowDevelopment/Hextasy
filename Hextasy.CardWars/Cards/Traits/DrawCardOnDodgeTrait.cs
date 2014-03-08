﻿namespace Hextasy.CardWars.Cards.Traits
{
    public class DrawCardOnDodgeTrait : Trait, IActivateTraitOnDodge
    {
        #region Constructors

        public DrawCardOnDodgeTrait(MonsterCard cardThatHasTrait)
            : base(cardThatHasTrait)
        {
        }

        #endregion Constructors

        #region Public Properties

        public override string Name
        {
            get { return "Draw card on dodge"; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return "Cards/Traits/drawcard.png"; }
        }

        #endregion Protected Properties

        #region Public Methods

        public override void Activate(CardWarsGameLogic cardWarsGameLogic, CardWarsTile targetTile)
        {
            CardThatHasTrait.Player.DrawCard();
        }

        public override ITrait DeepCopy(MonsterCard monsterCard)
        {
            return new DrawCardOnDodgeTrait(monsterCard);
        }

        #endregion Public Methods
    }
}