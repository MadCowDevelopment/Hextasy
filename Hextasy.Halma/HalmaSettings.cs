﻿using Hextasy.Framework;

namespace Hextasy.Halma
{
    public class HalmaSettings : Settings
    {
        #region Constructors

        public HalmaSettings(string player1, string player2)
            : base(9, 17)
        {
            Player1 = player1;
            Player2 = player2;
        }

        #endregion Constructors

        #region Public Properties

        public string Player1
        {
            get; private set;
        }

        public string Player2
        {
            get; private set;
        }

        #endregion Public Properties
    }
}