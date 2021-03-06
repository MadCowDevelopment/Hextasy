﻿using System.ComponentModel.Composition;

namespace Hextasy.CardWars.Cards.Monsters
{
    [Export(typeof(Card))]
    public class FallenAngelCard : MonsterCard
    {
        #region Public Properties

        public override int BaseAttack
        {
            get { return 4; }
        }

        public override int BaseHealth
        {
            get { return 5; }
        }

        public override int Cost
        {
            get { return 5; }
        }

        public override string Description
        {
            get { return "The fallen angel will bring you down. And it will bring down your mother."; }
        }

        public override string Name
        {
            get { return "Fallen Angel"; }
        }

        public override Race Race
        {
            get { return Race.Angel; }
        }

        #endregion Public Properties

        #region Protected Properties

        protected override string ImageFilename
        {
            get { return @"AngelGray2.png"; }
        }

        #endregion Protected Properties

        #region Protected Methods

        protected override Card CreateInstance()
        {
            return new FallenAngelCard();
        }

        #endregion Protected Methods
    }
}